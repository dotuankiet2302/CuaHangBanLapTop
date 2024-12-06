<?php
session_start();
header("Access-Control-Allow-Origin: http://localhost:3001");
header("Access-Control-Allow-Methods: GET, POST, OPTIONS");
header("Access-Control-Allow-Headers: Content-Type");
header("Access-Control-Allow-Credentials: true");
header("Content-Type: application/json; charset=UTF-8");

include '../../config.php';

spl_autoload_register(function ($class_name) {
    include '../../class/' . $class_name . '.php';
});

// Kiểm tra đăng nhập
if (!isset($_SESSION['khachhang'])) {
    echo json_encode([
        'success' => false,
        'message' => 'Vui lòng đăng nhập để thực hiện thanh toán.',
    ]);
    exit;
}

$maKH = $_SESSION['khachhang']['MAKH'];
$input = json_decode(file_get_contents('php://input'), true);
$cartItems = $input['cartItems'] ?? [];
$totalPrice = $input['totalCounter'] ?? 0;

if (empty($cartItems)) {
    echo json_encode([
        'success' => false,
        'message' => 'Giỏ hàng trống. Không thể thanh toán.',
    ]);
    exit;
}

$currentDate = date('Y-m-d');
$pdo = new DB($conn);

try {
    $pdo->getConn()->beginTransaction();

    // Lấy mã đơn hàng lớn nhất hiện tại
    $stmt = $pdo->prepare("SELECT MAX(MADH) AS max_madh FROM donhang");
    $stmt->execute();
    $result = $stmt->fetch(PDO::FETCH_ASSOC);
    $maxMADH = $result['max_madh'];

    // Sinh mã đơn hàng mới
    if ($maxMADH) {
        $number = (int)substr($maxMADH, 2); // Lấy phần số từ mã hiện tại (bỏ 'DH')
        $newNumber = $number + 1; // Tăng giá trị
        $madh = 'DH' . str_pad($newNumber, 3, '0', STR_PAD_LEFT); // Định dạng lại mã
    } else {
        $madh = 'DH001'; // Mã đầu tiên nếu chưa có đơn hàng
    }
    error_log("Generated Order ID: $madh");

    // Thêm đơn hàng vào bảng `donhang`
    $stmt = $pdo->prepare("INSERT INTO donhang (MADH, MAKH, NGAYGIAO, NGAYDAT, DATHANHTOAN, TINHTRANGGIAO, TONGTIEN) 
        VALUES (:MADH, :MAKH, NULL, :NGAYDAT, 'HOÀN TẤT', 'CHƯA GIAO', :TONG_TIEN)");
    $stmt->execute([
        'MADH' => $madh,
        'MAKH' => $maKH,
        'NGAYDAT' => $currentDate,
        'TONG_TIEN' => $totalPrice
    ]);

    // Lưu chi tiết từng sản phẩm vào bảng `chitietdonhang`
    foreach ($cartItems as $item) {
        if ($item['sl'] <= 0) {
            throw new Exception("Số lượng sản phẩm không hợp lệ.");
        }

        $stmt = $pdo->prepare("INSERT INTO chitietdonhang (MADH, MALAP, SOLUONG, DONGIA) 
            VALUES (:MADH, :MALAP, :SOLUONG, :DONGIA)");
        $stmt->execute([
            'MADH' => $madh,
            'MALAP' => $item['maLap'],
            'SOLUONG' => $item['sl'],
            'DONGIA' => $item['giaBan'],
        ]);
    }

    $pdo->getConn()->commit();
    error_log("Order and details saved successfully: $madh");

    // Thực hiện thanh toán qua MoMo
    $orderInfo = "Thanh toán đơn hàng ID: $madh";
    $redirectUrl = "http://localhost:8000/CheckOutIndex.php";
    $ipnUrl = "http://localhost:8000/CheckOutIndex.php";
    $extraData = "";

    $requestId = time() . "";
    $requestType = "payWithATM";
    $rawHash = "accessKey=klm05TvNBzhg7h7j&amount=$totalPrice&extraData=$extraData&ipnUrl=$ipnUrl&orderId=$madh&orderInfo=$orderInfo&partnerCode=MOMOBKUN20180529&redirectUrl=$redirectUrl&requestId=$requestId&requestType=$requestType";
    $signature = hash_hmac("sha256", $rawHash, 'at67qH6mk8w5Y1nAyMoYKMWACiEi2bsa');

    $data = [
        'partnerCode' => 'MOMOBKUN20180529',
        'partnerName' => "Test",
        'storeId' => "MomoTestStore",
        'requestId' => $requestId,
        'amount' => $totalPrice,
        'orderId' => $madh,
        'orderInfo' => $orderInfo,
        'redirectUrl' => $redirectUrl,
        'ipnUrl' => $ipnUrl,
        'lang' => 'vi',
        'extraData' => $extraData,
        'requestType' => $requestType,
        'signature' => $signature
    ];

    error_log("MoMo Request Data: " . json_encode($data));

    $endpoint = "https://test-payment.momo.vn/v2/gateway/api/create";
    $ch = curl_init($endpoint);
    curl_setopt($ch, CURLOPT_CUSTOMREQUEST, "POST");
    curl_setopt($ch, CURLOPT_POSTFIELDS, json_encode($data));
    curl_setopt($ch, CURLOPT_RETURNTRANSFER, true);
    curl_setopt($ch, CURLOPT_HTTPHEADER, [
        'Content-Type: application/json',
        'Content-Length: ' . strlen(json_encode($data))
    ]);
    curl_setopt($ch, CURLOPT_TIMEOUT, 30);
    curl_setopt($ch, CURLOPT_CONNECTTIMEOUT, 30);
    curl_setopt($ch, CURLOPT_FOLLOWLOCATION, true);

    $result = curl_exec($ch);
    if ($result === false) {
        $curlError = curl_error($ch);
        error_log("cURL Error: " . $curlError);
        echo json_encode([
            'success' => false,
            'message' => 'Lỗi cURL: ' . $curlError
        ]);
        curl_close($ch);
        exit;
    }
    curl_close($ch);

    error_log("MoMo API Response: " . $result);

    $jsonResult = json_decode($result, true);

    if (isset($jsonResult['payUrl'])) {
        echo json_encode([
            'success' => true,
            'payUrl' => $jsonResult['payUrl']
        ]);
        exit;
    } else {
        error_log("MoMo API Error Response: " . print_r($jsonResult, true));
        echo json_encode([
            'success' => false,
            'message' => 'Lỗi từ MoMo: ' . print_r($jsonResult, true)
        ]);
        exit;
    }
} catch (Exception $e) {
    $pdo->getConn()->rollBack();
    error_log("Checkout Error: " . $e->getMessage());
    echo json_encode([
        'success' => false,
        'message' => 'Tạo đơn hàng không thành công: ' . $e->getMessage()
    ]);
}

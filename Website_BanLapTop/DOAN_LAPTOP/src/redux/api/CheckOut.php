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

   // Thêm đơn hàng vào bảng `donhang`
   $stmt = $pdo->prepare("INSERT INTO donhang (MADH, MAKH, NGAYGIAO, NGAYDAT, DATHANHTOAN, TINHTRANGGIAO, TONGTIEN) 
       VALUES (:MADH, :MAKH, NULL, :NGAYDAT, 'CHƯA THANH TOÁN', 'CHƯA GIAO', :TONG_TIEN)");
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

   // Commit giao dịch
   $pdo->getConn()->commit();

   echo json_encode([
       'success' => true,
       'message' => 'Đơn hàng đã được tạo thành công.',
       'madh' => $madh
   ]);
} catch (Exception $e) {
   $pdo->getConn()->rollBack();
   error_log("Checkout Error: " . $e->getMessage());
   echo json_encode([
       'success' => false,
       'error' => 'Tạo đơn hàng không thành công: ' . $e->getMessage()
   ]);
}

?>

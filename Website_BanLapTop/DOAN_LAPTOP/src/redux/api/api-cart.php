<?php
session_start();
header("Access-Control-Allow-Origin: http://localhost:3001");
header("Access-Control-Allow-Methods: GET, POST, OPTIONS");
header("Access-Control-Allow-Headers: Content-Type");
header("Access-Control-Allow-Credentials: true");
header("Content-Type: application/json; charset=UTF-8");

include '../../config.php';

if ($_SERVER['REQUEST_METHOD'] === 'OPTIONS') {
    http_response_code(200);
    exit;
}

// Debug session
error_log("Session data: " . print_r($_SESSION, true));

// Kiểm tra session đăng nhập
if (!isset($_SESSION['khachhang'])) {
    echo json_encode([
        'success' => false,
        'message' => 'Vui lòng đăng nhập để sử dụng giỏ hàng',
        'cart' => []
    ]);
    exit;
}

$maKH = $_SESSION['khachhang']['MAKH'];

// Khởi tạo giỏ hàng trong session nếu chưa có
if (!isset($_SESSION['cart'])) {
    $_SESSION['cart'] = [];
}

// Xử lý POST request
if ($_SERVER['REQUEST_METHOD'] === 'POST') {
    $postData = $_POST;
    error_log("Received POST data: " . print_r($postData, true));

    // Thêm vào giỏ hàng
    if (isset($_POST['add_to_cart'])) {
        $maLap = $_POST['maLap'];
        $tenLap = $_POST['tenLap'];
        $anhBia = $_POST['anhBia'];
        $giaBan = $_POST['giaBan'];
        $soLuong = (int)$_POST['sl'];

        // Kiểm tra số lượng tồn kho
        $sql = "SELECT SOLUONGTON FROM laptop WHERE MALAP = :maLap";
        $stmt = $conn->prepare($sql);
        $stmt->execute(['maLap' => $maLap]);
        $result = $stmt->fetch(PDO::FETCH_ASSOC);

        if ($result && $soLuong > $result['SOLUONGTON']) {
            echo json_encode([
                'success' => false,
                'message' => 'Số lượng vượt quá tồn kho! Chỉ còn ' . $result['SOLUONGTON'] . ' sản phẩm'
            ]);
            exit;
        }

        // Kiểm tra sản phẩm đã có trong giỏ hàng chưa
        $found = false;
        foreach ($_SESSION['cart'] as &$item) {
            if ($item['maLap'] === $maLap) {
                $newQuantity = $item['sl'] + $soLuong;
                if ($newQuantity > $result['SOLUONGTON']) {
                    echo json_encode([
                        'success' => false,
                        'message' => 'Tổng số lượng vượt quá tồn kho!'
                    ]);
                    exit;
                }
                $item['sl'] = $newQuantity;
                $found = true;
                break;
            }
        }

        if (!$found) {
            $_SESSION['cart'][] = [
                'maLap' => $maLap,
                'tenLap' => $tenLap,
                'anhBia' => $anhBia,
                'giaBan' => $giaBan,
                'sl' => $soLuong,
                'SOLUONGTON' => $result['SOLUONGTON']
            ];
        }

        error_log("Cart after adding: " . print_r($_SESSION['cart'], true));
        
        echo json_encode([
            'success' => true,
            'message' => 'Thêm vào giỏ hàng thành công',
            'cart' => $_SESSION['cart']
        ]);
        exit;
    }

    // Xóa khỏi giỏ hàng
    if (isset($_POST['remove_from_cart'])) {
        $maLap = $_POST['maLap'];
        
        $_SESSION['cart'] = array_values(array_filter(
            $_SESSION['cart'], 
            function($item) use ($maLap) {
                return $item['maLap'] !== $maLap;
            }
        ));

        echo json_encode([
            'success' => true,
            'message' => 'Đã xóa sản phẩm khỏi giỏ hàng',
            'cart' => $_SESSION['cart']
        ]);
        exit;
    }

    // Cập nhật số lượng
    if (isset($_POST['update_quantity'])) {
        $maLap = $_POST['maLap'];
        $newQuantity = (int)$_POST['quantity'];

        // Kiểm tra số lượng tồn kho
        $sql = "SELECT SOLUONGTON FROM laptop WHERE MALAP = :maLap";
        $stmt = $conn->prepare($sql);
        $stmt->execute(['maLap' => $maLap]);
        $result = $stmt->fetch(PDO::FETCH_ASSOC);

        if ($result && $newQuantity > $result['SOLUONGTON']) {
            echo json_encode([
                'success' => false,
                'message' => 'Số lượng vượt quá tồn kho! Chỉ còn ' . $result['SOLUONGTON'] . ' sản phẩm',
                'availableQuantity' => $result['SOLUONGTON']
            ]);
            exit;
        }

        foreach ($_SESSION['cart'] as &$item) {
            if ($item['maLap'] === $maLap) {
                $item['sl'] = $newQuantity;
                break;
            }
        }

        echo json_encode([
            'success' => true,
            'message' => 'Đã cập nhật số lượng',
            'cart' => $_SESSION['cart']
        ]);
        exit;
    }
}

// Xử lý GET request
if ($_SERVER['REQUEST_METHOD'] === 'GET') {
    // Cập nhật số lượng tồn kho mới nhất
    foreach ($_SESSION['cart'] as &$item) {
        $sql = "SELECT SOLUONGTON FROM laptop WHERE MALAP = :maLap";
        $stmt = $conn->prepare($sql);
        $stmt->execute(['maLap' => $item['maLap']]);
        $result = $stmt->fetch(PDO::FETCH_ASSOC);
        $item['SOLUONGTON'] = $result['SOLUONGTON'];
    }

    echo json_encode([
        'success' => true,
        'cart' => $_SESSION['cart']
    ]);
    exit;
}
?>
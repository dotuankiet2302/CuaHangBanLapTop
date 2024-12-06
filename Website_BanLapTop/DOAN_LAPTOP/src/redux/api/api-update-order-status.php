<?php
header("Access-Control-Allow-Origin: *");
header("Access-Control-Allow-Methods: GET, POST, OPTIONS");
header("Access-Control-Allow-Headers: Content-Type");
header("Content-Type: application/json; charset=UTF-8");

if ($_SERVER['REQUEST_METHOD'] == 'OPTIONS') {
    header("Access-Control-Max-Age: 86400"); 
    http_response_code(200); 
    exit;
}

include '../../config.php'; 
spl_autoload_register(function ($class_name) {
    include '../../class/' . $class_name . '.php';
});

$db = new DB($conn); 

function jsonResponse($success, $message, $data = []) {
    echo json_encode(['success' => $success, 'message' => $message, 'data' => $data]);
    exit;
}

$method = $_SERVER['REQUEST_METHOD'];

if ($method === 'POST') {
    $input = json_decode(file_get_contents('php://input'), true);
    $orderId = $input['id'] ?? '';
    $status = $input['status'] ?? '';

    if (empty($orderId) || empty($status)) {
        jsonResponse(false, 'Dữ liệu không hợp lệ.');
    }

    $allowedStatuses = ['ĐÃ NHẬN', 'ĐANG GIAO', 'CHƯA GIAO'];
    if (!in_array($status, $allowedStatuses)) {
        jsonResponse(false, 'Trạng thái không hợp lệ.');
    }

    // Kiểm tra đơn hàng tồn tại
    $checkQuery = "SELECT DATHANHTOAN FROM donhang WHERE MADH = :orderId";
    $checkStmt = $conn->prepare($checkQuery);
    $checkStmt->bindParam(':orderId', $orderId);
    $checkStmt->execute();

    $order = $checkStmt->fetch(PDO::FETCH_ASSOC);
    if (!$order) {
        jsonResponse(false, 'Đơn hàng không tồn tại.');
    }

    try {
        // Bắt đầu giao dịch
        $conn->beginTransaction();

        // Cập nhật trạng thái giao hàng
        $query = "UPDATE donhang SET TINHTRANGGIAO = :status WHERE MADH = :orderId";
        $stmt = $conn->prepare($query);
        $stmt->bindParam(':status', $status);
        $stmt->bindParam(':orderId', $orderId);
        $stmt->execute();

        // Kiểm tra và cập nhật trạng thái thanh toán nếu cần
        if ($status === 'ĐÃ NHẬN' && $order['DATHANHTOAN'] !== 'HOÀN TẤT') {
            $updatePaymentStatusQuery = "UPDATE donhang SET DATHANHTOAN = 'HOÀN TẤT' WHERE MADH = :orderId";
            $paymentStmt = $conn->prepare($updatePaymentStatusQuery);
            $paymentStmt->bindParam(':orderId', $orderId);
            $paymentStmt->execute();
        }

        // Commit giao dịch
        $conn->commit();
        jsonResponse(true, 'Cập nhật trạng thái thành công.');
    } catch (PDOException $e) {
        // Rollback nếu xảy ra lỗi
        $conn->rollBack();
        error_log($e->getMessage());
        jsonResponse(false, 'Lỗi cơ sở dữ liệu.');
    }
}
?>

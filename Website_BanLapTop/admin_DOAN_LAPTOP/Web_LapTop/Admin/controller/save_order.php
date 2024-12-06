<?php
include_once "../config/dbconnect.php";

// Hàm tạo mã phiếu nhập tự động
function generateOrderCode($conn) {
    $result = $conn->query("SELECT MAX(MAPhieu) AS lastCode FROM phieunhaphang");
    $row = $result->fetch_assoc();
    $lastCode = $row['lastCode'];

    // Tăng số thứ tự từ mã cuối cùng
    $number = intval(substr($lastCode, 2)) + 1; // Lấy số và tăng lên
    return "PH" . str_pad($number, 3, "0", STR_PAD_LEFT); // Tạo mã mới
}

// Nhận dữ liệu JSON từ client
$data = json_decode(file_get_contents("php://input"), true);

// Tách dữ liệu từ yêu cầu
$maphieu = generateOrderCode($conn); // Tạo mã phiếu mới
$manv = $data['manv'];
$mancc = $data['mancc'];
$ngaylap = $data['ngaylap'];
$tinhtrang = $data['tinhtrang'];
$details = $data['details'];
$tongtien = $data['tongtien'];

// Lưu phiếu nhập hàng
$query = "INSERT INTO phieunhaphang (MAPHIEU, MANV, MANCC, NGAYLAP, TONGTIEN, TINHTRANG) 
          VALUES ('$maphieu', '$manv', '$mancc', '$ngaylap', '$tongtien', '$tinhtrang')";
if (!$conn->query($query)) {
    // Nếu có lỗi khi lưu phiếu nhập hàng
    http_response_code(500);
    echo json_encode(['success' => false, 'message' => "Error saving order: " . $conn->error]);
    exit;
}

// Lưu chi tiết đơn hàng
foreach ($details as $detail) {
    $malap = $detail['malap'];  // Đảm bảo trường này trùng với tên trong dữ liệu JSON
    $soluong = $detail['soluong'];
    $dongia = $detail['dongia'];

    $queryDetail = "INSERT INTO chitietdonhang (MADH, MALAP, SOLUONG, DONGIA) 
                    VALUES ('$maphieu', '$malap', $soluong, $dongia)";
    if (!$conn->query($queryDetail)) {
        // Nếu có lỗi khi lưu chi tiết đơn hàng
        http_response_code(500);
        echo json_encode(['success' => false, 'message' => "Error saving order details: " . $conn->error]);
        exit;
    }
}

// Trả kết quả thành công
http_response_code(200);
echo json_encode(['success' => true, 'message' => 'Order saved successfully!']);
?>

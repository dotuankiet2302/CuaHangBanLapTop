<?php
// thongke.php

// Include file kết nối cơ sở dữ liệu
include_once "../config/dbconnect.php";

// Nhận năm từ người dùng (có thể lấy từ GET hoặc POST)
$year = isset($_GET['year']) ? $_GET['year'] : date("Y"); // Mặc định là năm hiện tại

// Lấy dữ liệu chi phí nhập theo tháng
$sqlNhap = "
    SELECT 
        MONTH(NGAYLAP) AS Thang, 
        SUM(TONGTIEN) AS ChiPhiNhap 
    FROM phieunhaphang 
    WHERE YEAR(NGAYLAP) = '$year' 
    GROUP BY MONTH(NGAYLAP)
";
$resultNhap = $conn->query($sqlNhap);

// Lấy dữ liệu chi phí bán theo tháng
$sqlBan = "
    SELECT 
        MONTH(NGAYDAT) AS Thang, 
        SUM(TONGTIEN) AS ChiPhiBan 
    FROM donhang 
    WHERE YEAR(NGAYDAT) = '$year' 
    GROUP BY MONTH(NGAYDAT)
";
$resultBan = $conn->query($sqlBan);

// Chuẩn bị dữ liệu cho JavaScript
$chiPhiNhap = array_fill(0, 12, 0); // Khởi tạo mảng chi phí nhập cho tất cả 12 tháng
$chiPhiBan = array_fill(0, 12, 0); // Khởi tạo mảng chi phí bán cho tất cả 12 tháng

// Điền dữ liệu vào mảng chi phí nhập
while ($row = $resultNhap->fetch_assoc()) {
    $chiPhiNhap[$row['Thang'] - 1] = (float)$row['ChiPhiNhap']; // Lưu vào mảng chi phí nhập
}

// Điền dữ liệu vào mảng chi phí bán
while ($row = $resultBan->fetch_assoc()) {
    $chiPhiBan[$row['Thang'] - 1] = (float)$row['ChiPhiBan']; // Lưu vào mảng chi phí bán
}

// Đóng kết nối
$conn->close();

// Trả về kết quả dưới dạng JSON
echo json_encode([
    'chiPhiNhap' => $chiPhiNhap,
    'chiPhiBan' => $chiPhiBan,
    'year' => $year
]);
?>

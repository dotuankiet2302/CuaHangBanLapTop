<?php
// thongke.php

// Include file kết nối cơ sở dữ liệu
include_once "../config/dbconnect.php";

// Kiểm tra nếu có tháng và năm được gửi từ form
if (isset($_GET['month']) && isset($_GET['year'])) {
    $month = $_GET['month'];
    $year = $_GET['year'];

    // Truy vấn lấy dữ liệu thống kê chi phí nhập hàng với LEFT JOIN
    $sql = "SELECT 
                h.MAHANG AS MaHang,
                h.TENHANG AS HangLaptop,
                COALESCE(SUM(p.TONGTIEN), 0) AS ChiPhiNhap
            FROM hangmay h
            LEFT JOIN laptop l ON h.MAHANG = l.MAHANG
            LEFT JOIN chitietnhaphang ct ON l.MALAP = ct.MALAP
            LEFT JOIN phieunhaphang p ON ct.MAPHIEU = p.MAPHIEU
                AND YEAR(p.NGAYLAP) = $year AND MONTH(p.NGAYLAP) = $month
            GROUP BY h.MAHANG, h.TENHANG
            ORDER BY ChiPhiNhap DESC;
            ";


    // Thực hiện truy vấn
    $result = $conn->query($sql);

    $data = [];
    if ($result->num_rows > 0) {
        while ($row = $result->fetch_assoc()) {
            $data[] = $row;
        }
    }

    // Trả về dữ liệu dưới dạng JSON
    echo json_encode($data);
}

// Đóng kết nối cơ sở dữ liệu
$conn->close();
?>

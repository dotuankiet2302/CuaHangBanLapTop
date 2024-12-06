<?php
// thongke.php

// Include file kết nối cơ sở dữ liệu
include_once "../config/dbconnect.php";

// Kiểm tra nếu có tháng và năm được gửi từ form
if (isset($_GET['month']) && isset($_GET['year'])) {
    $month = $_GET['month'];
    $year = $_GET['year'];

    // Truy vấn lấy dữ liệu thống kê với LEFT JOIN để hiển thị hãng không có đơn
    $sql = "SELECT h.MAHANG AS MaHang,
                   h.TENHANG AS HangLaptop,
                   SUM(COALESCE(ct.SOLUONG * ct.DONGIA, 0) * 0.8) AS ChiPhiMua
            FROM hangmay h
            LEFT JOIN laptop l ON h.MAHANG = l.MAHANG
            LEFT JOIN chitietdonhang ct ON l.MALAP = ct.MALAP
            LEFT JOIN donhang d ON ct.MADH = d.MADH AND YEAR(d.NGAYDAT) = $year AND MONTH(d.NGAYDAT) = $month
            GROUP BY h.MAHANG, h.TENHANG
            ORDER BY ChiPhiMua DESC";

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

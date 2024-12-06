<?php
include '../config/dbconnect.php'; // Kết nối cơ sở dữ liệu
session_start(); // Bắt đầu session

// Kiểm tra xem dữ liệu đã được gửi hay chưa
if ($_SERVER['REQUEST_METHOD'] == 'POST') {
    // Lấy dữ liệu từ form
    $productName = $_POST['product_name']; // Tên sản phẩm
    $price = $_POST['price']; // Giá bán
    $description = $_POST['description']; // Mô tả
    $configuration = $_POST['configuration']; // Cấu hình
    $manufacturer = $_POST['manufacturer']; // Nhà sản xuất
    $brand = $_POST['brand']; // Thương hiệu
    $status = $_POST['status']; // Tình trạng

    // Kiểm tra nếu có ảnh, lưu ảnh vào thư mục
    if (isset($_FILES['image']['name']) && $_FILES['image']['name'] != "") {
        $image = $_FILES['image']['name'];
        $target_dir = "../uploads/";
        $target_file = $target_dir . basename($_FILES["image"]["name"]);
        move_uploaded_file($_FILES["image"]["tmp_name"], $target_file);
    } else {
        $image = NULL; // Nếu không có ảnh, gán giá trị NULL
    }

    // Thực hiện câu lệnh SQL để lưu sản phẩm
    $sql = "INSERT INTO laptop (TENLAP, GIABAN, MOTA, CAUHIHNH, MANSX, MAHANG, MATINHTRANG, ANHBIA) 
            VALUES ('$productName', '$price', '$description', '$configuration', '$manufacturer', '$brand', '$status', '$image')";

    // Kiểm tra kết nối và thực thi câu lệnh
    if ($conn->query($sql) === TRUE) {
        // Nếu lưu thành công, lưu thông báo thành công vào session
        $_SESSION['success_message'] = "Sản phẩm đã được lưu thành công!";
        // Chuyển hướng về trang danh sách sản phẩm
        header("Location: viewAllProducts.php");
        exit();
    } else {
        // Nếu có lỗi, lưu thông báo lỗi vào session
        $_SESSION['error_message'] = "Có lỗi xảy ra khi lưu sản phẩm!";
        // Chuyển hướng lại về form nhập liệu
        header("Location: viewAllProducts.php");
        exit();
    }

    // Đóng kết nối
    $conn->close();
}
?>

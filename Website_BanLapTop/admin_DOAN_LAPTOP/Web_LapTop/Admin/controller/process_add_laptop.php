<?php 
include '../config/dbconnect.php'; // Kết nối cơ sở dữ liệu

if ($_SERVER["REQUEST_METHOD"] == "POST") {
    $p_name = $_POST['p_name'];
    $p_price = $_POST['p_price'];
    $p_desc = $_POST['p_desc'];
    $macauhinh = $_POST['macauhinh'];
    $mansx = $_POST['mansx'];
    $mahang = $_POST['mahang'];
    $matinhtrang = $_POST['matinhtrang'];
    
    // Giả sử bạn đã upload ảnh và lưu tên file trong biến $image
    $image = $_FILES['file']['name']; // Hoặc thêm xử lý upload file để lấy tên file chính xác

    // Để tự động tạo mã sản phẩm LAP001, LAP002,...
    $sql = "SELECT MAX(MALAP) AS last_id FROM laptop";
    $result = $conn->query($sql);
    $row = $result->fetch_assoc();
    $last_id = $row['last_id'];
    $next_id = 'LAP' . str_pad(substr($last_id, 3) + 1, 3, '0', STR_PAD_LEFT);

    // Truy vấn INSERT vào cơ sở dữ liệu
    $insert_sql = "INSERT INTO laptop (MALAP, TENLAP, GIABAN, ANHBIA, SOLUONGTON, NGAYCAPNHAT, MoTa, MACAUHINH, MANSX, MAHANG, MATINHTRANG) 
                   VALUES ('$next_id', '$p_name', '$p_price', '$image', 0, NOW(), '$p_desc', '$macauhinh', '$mansx', '$mahang', '$matinhtrang')";

    if ($conn->query($insert_sql) === TRUE) {
        echo "New laptop item added successfully!";
    } else {
        echo "Error adding laptop item: " . $conn->error;
    }
}
?>
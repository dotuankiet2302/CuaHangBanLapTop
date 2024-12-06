<?php
session_start();
header("Access-Control-Allow-Origin: *");
header("Access-Control-Allow-Methods: GET, POST, OPTIONS");
header("Access-Control-Allow-Headers: Content-Type");
header("Content-Type: application/json; charset=UTF-8");

include '../../config.php'; // Đường dẫn đến file config.php

spl_autoload_register(function ($class_name) {
    include '../../class/' . $class_name . '.php'; // Đường dẫn đến class DB.php
});

try {
    // Khởi tạo đối tượng DB
    $db = new DB($conn); 

    // Lấy từ khóa tìm kiếm từ tham số GET
    $keyword = isset($_GET['ten']) ? trim($_GET['ten']) : ''; 

    // Kiểm tra đầu vào
    if (empty($keyword)) {
        echo json_encode([
            "success" => false,
            "message" => "Từ khóa tìm kiếm không được để trống."
        ]);
        exit;
    }

    // Sửa câu truy vấn SQL để không phân biệt chữ hoa và chữ thường
    $sql = "SELECT DISTINCT * FROM laptop WHERE LOWER(TENLAP) LIKE :keyword";
    $stm = $db->prepare($sql);

    // Gán giá trị cho tham số truy vấn (chuyển từ khóa thành chữ thường)
    $searchTerm = "%" . strtolower($keyword) . "%"; 
    $stm->bindParam(':keyword', $searchTerm, PDO::PARAM_STR);

    // Thực thi truy vấn
    $stm->execute();
    $data = $stm->fetchAll(PDO::FETCH_OBJ);

    // Trả kết quả về dưới dạng JSON
    echo json_encode([
        "success" => true,
        "data" => $data,
        "totalResults" => count($data) // Thêm thông tin tổng số kết quả
    ]);

} catch (Exception $e) {
    // Xử lý khi có lỗi xảy ra
    echo json_encode([
        "success" => false,
        "message" => $e->getMessage()
    ]);
}
?>

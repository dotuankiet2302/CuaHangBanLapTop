<?php
header("Access-Control-Allow-Origin: *");
header("Access-Control-Allow-Methods: GET, POST, OPTIONS");
header("Access-Control-Allow-Headers: Content-Type");
header("Content-Type: application/json; charset=UTF-8");

include '../../config.php'; // Đường dẫn đến file config.php

spl_autoload_register(function ($class_name) {
    include '../../class/' . $class_name . '.php'; // Đường dẫn đến class DB.php
});

$db = new DB($conn); // Khởi tạo đối tượng DB

// Lấy sản phẩm chi tiết nếu có id trong URL
$id = $_GET['id'] ?? '';
if (!empty($id)) {
    $sql = "SELECT * FROM laptop WHERE MALAP = :id";
    $stm = $db->prepare($sql);
   //  $stm->bindParam(':id', $id, PDO::PARAM_INT);
   $stm->bindParam(':id', $id, PDO::PARAM_STR);
    $stm->execute();
    $data = $stm->fetch(PDO::FETCH_OBJ);

    header('Content-Type: application/json');
    echo json_encode($data);
    exit;
}
?>
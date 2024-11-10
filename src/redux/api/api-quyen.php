<?php
session_start();
header("Access-Control-Allow-Origin: *");
header("Access-Control-Allow-Methods: GET, POST, OPTIONS");
header("Access-Control-Allow-Headers: Content-Type");
header("Content-Type: application/json; charset=UTF-8");

// Thiết lập UTF-8 cho kết nối
ini_set('default_charset', 'UTF-8');
mb_internal_encoding('UTF-8');

include '../../config.php'; // Đường dẫn đến file config.php

spl_autoload_register(function ($class_name) {
    include '../../class/' . $class_name . '.php'; // Đường dẫn đến class DB.php
});


try {
    $query = $conn->prepare("SELECT MAQUYEN, TENQUYEN FROM phanquyen ORDER BY TENQUYEN");
    $query->execute();
    $quyenList = $query->fetchAll(PDO::FETCH_ASSOC);
    echo json_encode([
        "success" => true, 
        "quyenList" => $quyenList
    ], JSON_UNESCAPED_UNICODE);
} catch (PDOException $e) {
    echo json_encode([
        "success" => false, 
        "message" => "Lỗi: " . $e->getMessage()
    ], JSON_UNESCAPED_UNICODE);
}
?>
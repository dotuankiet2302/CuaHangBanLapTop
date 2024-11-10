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
    $stm->bindParam(':id', $id, PDO::PARAM_INT);
    $stm->execute();
    $data = $stm->fetch(PDO::FETCH_OBJ);

    header('Content-Type: application/json');
    echo json_encode($data);
    exit;
}

// Lấy từ khóa tìm kiếm
$keyword = $_GET['keyword'] ?? '';
$hangmay = null;

// Xác định loại sản phẩm
if (isset($_GET['menu_tab'])) {
    $menuTab = $_GET['menu_tab'];
    $brands = [
        'HP' => 1, 'ACER' => 2, 'DELL' => 3,
        'ASUS' => 4, 'LENOVO' => 5, 'MACBOOK' => 6,
        'MASSTEL' => 7, 'MSI' => 8, 'SURFACE' => 9,
        'SINGPC' => 10
    ];
    $hangmay = $brands[$menuTab] ?? null;
}

$sql = "SELECT p.MALAP, p.TENLAP, p.GIABAN, p.ANHBIA, t.MAHANG, t.TENHANG
        FROM laptop p
        INNER JOIN hangmay t ON p.MAHANG = t.MAHANG
        WHERE 1=1"; 


if (!empty($keyword)) {
    $sql .= " AND p.TENLAP LIKE :keyword";
}

if ($hangmay !== null) {
    $sql .= " AND p.MAHANG = :hangmay";
}

$stm = $db->prepare($sql);

if (!empty($keyword)) {
    $ten = "%" . $keyword . "%";
    $stm->bindParam(':keyword', $ten, PDO::PARAM_STR);
}

if ($hangmay !== null) {
    $stm->bindParam(':hangmay', $hangmay, PDO::PARAM_INT);
}

$stm->execute();
$data = $stm->fetchAll(PDO::FETCH_OBJ);

// Trả dữ liệu về dạng JSON
header('Content-Type: application/json');
echo json_encode($data);
?>

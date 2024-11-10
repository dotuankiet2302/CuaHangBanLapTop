<?php
header("Access-Control-Allow-Origin: *");
header("Access-Control-Allow-Methods: GET, POST, OPTIONS");
header("Access-Control-Allow-Headers: Content-Type");
header("Content-Type: application/json; charset=UTF-8");

include '../../config.php'; 

spl_autoload_register(function ($class_name) {
    include '../../class/' . $class_name . '.php'; // Đường dẫn đến class DB.php
});

$db = new DB($conn); // Khởi tạo đối tượng DB
$id = $_GET['id'] ?? '';

if (!empty($id)) {
    $sql = "SELECT * FROM laptop WHERE PRODUCTID = :id";
    $stm = $conn->prepare($sql);
    $stm->bindParam(':id', $id, PDO::PARAM_INT);
    $stm->execute();
    $data = $stm->fetch(PDO::FETCH_OBJ);
}
//Giỏ hàng
session_start();
// session_destroy();
//Nếu chưa tồn tại thì khởi tạo giỏ
if (!isset($_SESSION['cart'])) $_SESSION['cart'] = [];

//Xoá all giỏ
if (isset($_GET['emptyCart']) && ($_GET['emptyCart'] == 1)) unset($_SESSION['cart']);

//xoá item trong giỏ
if (isset($_GET['delId']) && ($_GET['delId']) >= 0) {
    array_splice($_SESSION['cart'], $_GET['delId'], 1);
}

//Update item trong giỏ
if (isset($_GET['updateId']) && ($_GET['updateId']) >= 0) {
    $index = ($_GET['updateId']);
    if (isset($_SESSION['cart'][$index])) {
        $new_quantity = $_GET['num_sl'] ?? 1;
        $_SESSION['cart'][$index]['sl'] = $new_quantity;
    }
}

//Lấy dữ liệu từ form xem chi tiết
if (isset($_POST['add_to_cart']) && ($_POST['add_to_cart'])) {
    $masp = $_POST['productID'] ?? '';
    $tensp = $_POST['productName'] ?? '';
    $hinh = $_POST['productImg'] ?? '';
    $donGia = $_POST['productPrice'] ?? 0;
    $sl = $_POST['sl'] ?? 1;

    //kiểm tra sp trong giỏ hàng
    $flag = 0;
    $count = count($_SESSION['cart']);
    for ($i = 0; $i < $count; $i++) {
        $item = $_SESSION['cart'][$i];
        if (isset($item["productID"]) && $item["productID"] == $masp) {
            $flag = 1;
            $sl_new = (int)$sl + (int)$item["sl"];
            $item["sl"] = $sl_new; //cập nhật sl trực tiếp trong mảng $_SESSION['cart']
            $_SESSION['cart'][$i] = $item;
            break;
        }
    }
    //thêm sp vào giỏ nếu ko trùng
    if ($flag == 0) {
        $sp = array(
            'productID' => $masp,
            'productName' => $tensp,
            'productImg' => $hinh,
            'productPrice' => $donGia,
            'sl' => (int)$sl,
        );
        $_SESSION['cart'][] = $sp;
    }
}
?>
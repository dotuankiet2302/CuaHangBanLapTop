<?php
session_start();
header("Access-Control-Allow-Origin: *");
header("Access-Control-Allow-Methods: GET, POST, OPTIONS");
header("Access-Control-Allow-Headers: Content-Type");
header("Content-Type: application/json; charset=UTF-8");

include '../../config.php';

spl_autoload_register(function ($class_name) {
    include '../../class/' . $class_name . '.php';
});

function postIndex($index, $value = "") {
    return isset($_POST[$index]) ? $_POST[$index] : $value;
}

$matkhaucu = postIndex("matkhaucu");
$matkhau = postIndex("matkhau");
$nhaplaimatkhau = postIndex("nhaplaimatkhau");

$errors = array();

if ($_SERVER["REQUEST_METHOD"] == "POST") {
    // Validate các trường input
    if (empty($matkhaucu)) {
        $errors['matkhaucu'] = "Vui lòng nhập mật khẩu cũ";
    }
    if (empty($matkhau)) {
        $errors['matkhau'] = "Vui lòng nhập mật khẩu mới";
    }
    if (empty($nhaplaimatkhau)) {
        $errors['nhaplaimatkhau'] = "Vui lòng nhập lại mật khẩu mới";
    } elseif ($nhaplaimatkhau != $matkhau) {
        $errors['nhaplaimatkhau'] = "Mật khẩu nhập lại không khớp";
    }

    if (empty($errors)) {
        try {
            $conn = new PDO("mysql:host=localhost;dbname=doan_web_laptop", "root", "");
            $conn->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);

            // Kiểm tra mật khẩu cũ có đúng không
            $checkOldPassword = $conn->prepare("SELECT MATKHAU FROM khachhang WHERE MAKH = :maKH");
            $checkOldPassword->bindParam(':maKH', $_SESSION['khachhang']['MAKH']);
            $checkOldPassword->execute();
            $currentPassword = $checkOldPassword->fetchColumn();

            if ($currentPassword === $matkhaucu) {
                // Cập nhật mật khẩu mới
                $updatePassword = $conn->prepare("UPDATE khachhang SET MATKHAU = :matkhaumoi WHERE MAKH = :maKH");
                $updatePassword->bindParam(':matkhaumoi', $nhaplaimatkhau);
                $updatePassword->bindParam(':maKH', $_SESSION['khachhang']['MAKH']);
                $updatePassword->execute();

                // Cập nhật session
                $_SESSION['khachhang']['MATKHAU'] = $nhaplaimatkhau;

                echo json_encode([
                    "success" => true,
                    "message" => "Cập nhật mật khẩu thành công!",
                    "userInfo" => $_SESSION['khachhang']
                ]);
            } else {
                $errors['matkhaucu'] = "Mật khẩu cũ không đúng";
                echo json_encode([
                    "success" => false,
                    "errors" => $errors
                ]);
            }
        } catch (PDOException $e) {
            echo json_encode([
                "success" => false,
                "message" => "Lỗi: " . $e->getMessage()
            ]);
        }
    } else {
        echo json_encode([
            "success" => false,
            "errors" => $errors
        ]);
    }
}
?>
<?php
session_start();
header("Access-Control-Allow-Origin: http://localhost:3001");
header("Access-Control-Allow-Methods: GET, POST, OPTIONS");
header("Access-Control-Allow-Headers: Content-Type");
header("Access-Control-Allow-Credentials: true"); // Thêm dòng này
header("Content-Type: application/json; charset=UTF-8");

include '../../config.php';

spl_autoload_register(function ($class_name) {
    include '../../class/' . $class_name . '.php';
});

$u = isset($_POST['taikhoan']) ? $_POST['taikhoan'] : '';
$p = isset($_POST['matkhau']) ? $_POST['matkhau'] : '';

if ($u == '' || $p == '') {
    echo json_encode([
        "success" => false,
        "message" => "Vui lòng nhập đầy đủ tài khoản và mật khẩu."
    ]);
    exit;
}

$pdo = new DB($conn);
$stmt = $pdo->prepare("SELECT kh.*, pq.TENQUYEN 
                       FROM khachhang kh
                       JOIN phanquyen pq ON kh.MAQUYEN = pq.MAQUYEN
                       WHERE kh.TAIKHOAN = :TAIKHOAN");
$stmt->execute(['TAIKHOAN' => $u]);
$khachhang = $stmt->fetch();

if ($khachhang && $p == $khachhang['MATKHAU']) {
    // Lưu thông tin vào session
    $_SESSION['khachhang'] = [
        'MAKH' => $khachhang['MAKH'],
        'HOTEN' => $khachhang['HOTEN'],
        'TAIKHOAN' => $khachhang['TAIKHOAN'],
        'EMAIL' => $khachhang['EMAIL'],
        'MAQUYEN' => $khachhang['MAQUYEN']
    ];
// Khởi tạo giỏ hàng cho user nếu chưa có
if (!isset($_SESSION['user_carts'])) {
   $_SESSION['user_carts'] = [];
}
if (!isset($_SESSION['user_carts'][$khachhang['MAKH']])) {
   $_SESSION['user_carts'][$khachhang['MAKH']] = [];
}
    echo json_encode([
        "success" => true,
        "message" => "Đăng nhập thành công.",
        "user" => [
            "maKH" => $khachhang['MAKH'],
            "hoTen" => $khachhang['HOTEN'],
            "taikhoan" => $khachhang['TAIKHOAN'],
            "email" => $khachhang['EMAIL'],
            "dienThoai" => $khachhang['DIENTHOAI'],
            "diaChi" => $khachhang['DIACHI'],
            "gioiTinh" => $khachhang['GIOITINH'],
            "ngaySinh" => $khachhang['NGAYSINH'],
            "maQuyen" => $khachhang['MAQUYEN'],
            "tenQuyen" => $khachhang['TENQUYEN'],
            "anh"=>$khachhang['ANH'],
        ]
    ]);
} else {
    echo json_encode([
        "success" => false,
        "message" => "Tên đăng nhập hoặc mật khẩu không chính xác."
    ]);
}
exit;
?>
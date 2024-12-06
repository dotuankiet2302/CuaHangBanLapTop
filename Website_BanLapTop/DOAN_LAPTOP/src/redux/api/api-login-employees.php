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
$stmt = $pdo->prepare("SELECT nv.*, pq.TENQUYEN 
                       FROM nhanvien nv
                       JOIN phanquyen pq ON nv.MAQUYEN = pq.MAQUYEN
                       WHERE nv.TAIKHOAN = :TAIKHOAN");
$stmt->execute(['TAIKHOAN' => $u]);
$nhanvien = $stmt->fetch();

if ($nhanvien && $p == $nhanvien['MATKHAU']) {
    // Lưu thông tin vào session
    $_SESSION['nhanvien'] = [
        'MANV' => $nhanvien['MANV'],
        'HOTEN' => $nhanvien['HOTEN'],
        'TAIKHOAN' => $nhanvien['TAIKHOAN'],
        'EMAIL' => $nhanvien['EMAIL'],
        'MAQUYEN' => $nhanvien['MAQUYEN']
    ];
    echo json_encode([
        "success" => true,
        "message" => "Đăng nhập thành công.",
        "user" => [
            "maNV" => $nhanvien['MANV'],
            "hoTen" => $nhanvien['HOTEN'],
            "taikhoan" => $nhanvien['TAIKHOAN'],
            "email" => $nhanvien['EMAIL'],
            "dienThoai" => $nhanvien['DIENTHOAI'],
            "diaChi" => $nhanvien['DIACHI'],
            "gioiTinh" => $nhanvien['GIOITINH'],
            "ngaySinh" => $nhanvien['NGAYSINH'],
            "maQuyenNV" => $nhanvien['MAQUYEN'], // Sử dụng maQuyenNV cho nhân viên
            "tenQuyen" => $nhanvien['TENQUYEN'],
            "anh" => $nhanvien['ANH'],
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

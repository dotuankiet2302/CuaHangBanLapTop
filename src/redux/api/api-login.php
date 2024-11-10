<?php
session_start();

// Cấu hình CORS và Headers
header("Access-Control-Allow-Origin: *");
header("Access-Control-Allow-Methods: GET, POST, OPTIONS");
header("Access-Control-Allow-Headers: Content-Type");
header("Content-Type: application/json; charset=UTF-8");

// Cấu hình encoding
ini_set('default_charset', 'UTF-8');
mb_internal_encoding('UTF-8');

// Import các file cần thiết
include '../../config.php';
spl_autoload_register(function ($class_name) {
    include '../../class/' . $class_name . '.php';
});

/**
 * Hàm kiểm tra email hợp lệ
 * @param string $email
 * @return bool
 */
function isValidEmail($email) {
    return filter_var($email, FILTER_VALIDATE_EMAIL) && 
           str_ends_with(strtolower($email), '@gmail.com');
}

/**
 * Hàm trả về response JSON
 * @param bool $success
 * @param string $message
 * @param array $data
 */
function sendResponse($success, $message, $data = []) {
    echo json_encode(array_merge(
        [
            "success" => $success,
            "message" => $message
        ],
        $data
    ));
    exit;
}

// Lấy dữ liệu từ request
$taikhoan = isset($_POST['taikhoan']) ? trim($_POST['taikhoan']) : '';
$matkhau = isset($_POST['matkhau']) ? trim($_POST['matkhau']) : '';

// Kiểm tra dữ liệu trống
if (empty($taikhoan) || empty($matkhau)) {
    sendResponse(false, "Vui lòng nhập đầy đủ tài khoản và mật khẩu.");
}

// Kiểm tra định dạng email
if (!isValidEmail($taikhoan)) {
    sendResponse(false, "Email không hợp lệ. Vui lòng sử dụng địa chỉ @gmail.com");
}

try {
    // Kết nối database
    $pdo = new DB($conn);

    // Truy vấn thông tin người dùng
    $stmt = $pdo->prepare("
        SELECT u.*, r.TENQUYEN 
        FROM khachhang u
        JOIN phanquyen r ON u.MAQUYEN = r.MAQUYEN
        WHERE u.TAIKHOAN = :TAIKHOAN
    ");
    
    $stmt->execute(['TAIKHOAN' => $taikhoan]);
    $khachhang = $stmt->fetch();

    // Kiểm tra tài khoản tồn tại
    if (!$khachhang) {
        sendResponse(false, "Tên đăng nhập hoặc mật khẩu không chính xác.");
    }

    // Kiểm tra mật khẩu
    $isValidPassword = 
        password_verify($matkhau, $khachhang['MATKHAU']) || // Kiểm tra bcrypt
        md5($matkhau) === $khachhang['MATKHAU'] ||         // Kiểm tra MD5
        $matkhau === $khachhang['MATKHAU'];               // Kiểm tra plain text

    if (!$isValidPassword) {
        sendResponse(false, "Tên đăng nhập hoặc mật khẩu không chính xác.");
    }

    // Nếu mật khẩu chưa được mã hóa, cập nhật thành bcrypt
    if ($matkhau === $khachhang['MATKHAU']) {
        $hashed_password = password_hash($matkhau, PASSWORD_BCRYPT);
        
        $update_stmt = $pdo->prepare("
            UPDATE khachhang 
            SET MATKHAU = :matkhau 
            WHERE MAKH = :makh
        ");
        
        $update_stmt->execute([
            'matkhau' => $hashed_password,
            'makh' => $khachhang['MAKH']
        ]);
    }

    // Lưu thông tin vào session
    $_SESSION['khachhang'] = $khachhang;

    // Trả về kết quả thành công
    sendResponse(true, "Đăng nhập thành công.", [
        "role" => $khachhang['TENQUYEN']
    ]);

} catch (Exception $e) {
    // Xử lý lỗi
    error_log("Login Error: " . $e->getMessage());
    sendResponse(false, "Đã có lỗi xảy ra, vui lòng thử lại sau.");
}
?>
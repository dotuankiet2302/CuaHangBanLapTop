<?php
session_start();
ini_set('display_errors', 1);
ini_set('display_startup_errors', 1);
error_reporting(E_ALL);

header("Access-Control-Allow-Origin: *");
header("Access-Control-Allow-Methods: GET, POST, OPTIONS");
header("Access-Control-Allow-Headers: Content-Type");
header("Content-Type: application/json; charset=UTF-8");

ini_set('default_charset', 'UTF-8');
mb_internal_encoding('UTF-8');

include '../../config.php';

spl_autoload_register(function ($class_name) {
    include '../../class/' . $class_name . '.php';
});
/**
 * Kiểm tra email có đúng định dạng @gmail.com
 */
function isValidEmail($email) {
    return filter_var($email, FILTER_VALIDATE_EMAIL) && 
           strtolower(substr($email, -10)) === '@gmail.com';
}

/**
 * Kiểm tra mật khẩu đủ mạnh
 */
function isValidPassword($password) {
    $pattern = '/^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$/';
    return preg_match($pattern, $password);
}

/**
 * Kiểm tra email đã tồn tại trong database
 */
function checkEmailExists($conn, $email) {
    $stmt = $conn->prepare("SELECT COUNT(*) FROM khachhang WHERE EMAIL = ?");
    $stmt->execute([$email]);
    return $stmt->fetchColumn() > 0;
}

/**
 * Gửi response JSON về client
 */
function sendResponse($success, $message, $data = []) {
    echo json_encode(array_merge(
        ["success" => $success, "message" => $message],
        $data
    ), JSON_UNESCAPED_UNICODE);
    exit();
}

// ===== PHẦN 3: XỬ LÝ ĐĂNG KÝ =====
if ($_SERVER["REQUEST_METHOD"] == "POST") {
    try {
        // 1. Lấy và làm sạch dữ liệu
        $hoten = isset($_POST["hoten"]) ? trim($_POST["hoten"]) : "";
        $taikhoan = isset($_POST["taikhoan"]) ? trim($_POST["taikhoan"]) : "";
        $email = isset($_POST["email"]) ? trim($_POST["email"]) : "";
        $matkhau = isset($_POST["matkhau"]) ? $_POST["matkhau"] : "";
        $matinh = isset($_POST["matinh"]) ? trim($_POST["matinh"]) : "";
        $maquyen = "2"; // Mặc định là quyền user

        // 2. Validate dữ liệu
        $errors = [];
        
        // Validate họ tên
        if (empty($hoten)) {
            $errors['hoten'] = "Vui lòng nhập họ tên";
        }
        if (empty($taikhoan)) {
         $errors['taikhoan'] = "Vui lòng nhập tên tài khoản";
         }

        // Validate email
        if (empty($email)) {
            $errors['email'] = "Vui lòng nhập email";
        } elseif (!isValidEmail($email)) {
            $errors['email'] = "Email phải có định dạng @gmail.com";
        } elseif (checkEmailExists($conn, $email)) {
            sendResponse(false, "Email đã tồn tại", [
                "errors" => ["email" => "Email này đã được đăng ký"]
            ]);
        }

        // Validate mật khẩu
        if (empty($matkhau)) {
            $errors['matkhau'] = "Vui lòng nhập mật khẩu";
         } elseif (!isValidPassword($matkhau)) {
            $errors['matkhau'] = "Mật khẩu phải có ít nhất 8 ký tự, bao gồm chữ hoa, chữ thường, số và ký tự đặc biệt";
        }

        // Validate tỉnh
        if (empty($matinh)) {
            $errors['matinh'] = "Vui lòng chọn tỉnh/thành phố";
        }

        // Nếu có lỗi thì trả về
        if (!empty($errors)) {
            sendResponse(false, "Dữ liệu không hợp lệ", ["errors" => $errors]);
        }

        // 3. Lấy mã khách hàng mới
        $stmt = $conn->query("SELECT MAX(MAKH) as max_id FROM khachhang");
        $row = $stmt->fetch(PDO::FETCH_ASSOC);
        $next_id = ($row['max_id'] ?? 0) + 1;

        // 4. Mã hóa mật khẩu
       // $hashedPassword = password_hash($matkhau, PASSWORD_BCRYPT);

        // 5. Thêm người dùng mới
        $stmt = $conn->prepare("
            INSERT INTO khachhang (MAKH, HOTEN, TAIKHOAN, EMAIL, MATKHAU, MAQUYEN, MATINH) 
            VALUES (?, ?, ?, ?, ?, ?, ?)
        ");
        
        $result = $stmt->execute([
            $next_id,
            $hoten,
            $taikhoan,
            $email,
           // $hashedPassword,
           $matkhau,
            $maquyen,
            $matinh
        ]);

        // 6. Trả về kết quả
        if ($result) {
            sendResponse(true, "Đăng ký thành công");
        } else {
            sendResponse(false, "Đăng ký không thành công");
        }

    } catch (PDOException $e) {
        error_log("Lỗi đăng ký: " . $e->getMessage());
        sendResponse(false, "Đã có lỗi xảy ra, vui lòng thử lại sau");
    }
} else {
    sendResponse(false, "Phương thức không được hỗ trợ");
}
?>
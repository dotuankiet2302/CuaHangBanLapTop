<?php
error_reporting(E_ERROR | E_PARSE);
session_start();
error_reporting(E_ALL);
ini_set('display_errors', 1);

header("Access-Control-Allow-Origin: *");
header("Access-Control-Allow-Methods: GET, POST, OPTIONS");
header("Access-Control-Allow-Headers: Content-Type, Accept");
header("Content-Type: application/json; charset=utf-8");

try {
    // Đường dẫn đến config và autoload
    $configPath = __DIR__ . '/../../config.php';
    require_once $configPath;
    require_once __DIR__ . '../../google-api/vendor/autoload.php';

    // Khởi tạo Google Client
    $client = new Google_Client();
    $client->setClientId('1058855591853-4ektbhkhc5aar8fa53qiccvvcvkv32jr.apps.googleusercontent.com');
    $client->setClientSecret('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');
    // Sửa lại redirect URI để khớp với cấu hình trong Google Console
    $client->setRedirectUri('http://localhost:8000/google-login.php');
    $client->addScope("email");
    $client->addScope("profile");
   
        if(isset($_GET['code'])) {
            $token = $client->fetchAccessTokenWithAuthCode($_GET['code']);
    
            if(!isset($token["error"])) {
                $client->setAccessToken($token['access_token']);
    
                // Lấy thông tin profile
                $google_oauth = new Google_Service_Oauth2($client);
                $google_account_info = $google_oauth->userinfo->get();
            
                $id = $google_account_info->id;
                $full_name = trim($google_account_info->name);
                $email = $google_account_info->email;
    
                // Kiểm tra email trong database
                $stmt = $conn->prepare("SELECT * FROM khachhang WHERE EMAIL = ?");
                $stmt->execute([$email]);
                $user = $stmt->fetch(PDO::FETCH_ASSOC);
                
                if($user) {
                    // Người dùng đã tồn tại
                    $_SESSION['user_id'] = $user['MAKH'];
                    $_SESSION['user_email'] = $user['EMAIL'];
                    $_SESSION['user_name'] = $user['HOTEN'];
                    
                    echo json_encode([
                        'success' => true,
                        'message' => 'Đăng nhập thành công'
                    ]);
                    header("Location: http://localhost:3000/home");
                    
                    exit();
                } else {
                    // Tạo tài khoản mới
                    $stmt = $conn->prepare("SELECT MAX(MAKH) as max_id FROM khachhang");
                    $stmt->execute();
                    $row = $stmt->fetch(PDO::FETCH_ASSOC);
                    $next_id = ($row['max_id'] ?? 0) + 1;
                    
                    $stmt = $conn->prepare("
                        INSERT INTO khachhang (MAKH, HOTEN, EMAIL, MAQUYEN, MATINH) 
                        VALUES (?, ?, ?, '2', '1')
                    ");
                    if ($stmt->execute([$next_id, $full_name, $email])) {
                     $_SESSION['user_id'] = $next_id;
                     $_SESSION['user_email'] = $email;
                     $_SESSION['user_name'] = $full_name;
                     
                     echo json_encode([
                         'success' => true,
                         'message' => 'Tạo tài khoản thành công'
                     ]);
                     header("Location: http://localhost:3000/home");
                     exit();
                 }
             }
         } else {
             throw new Exception("Lỗi xác thực Google");
         }
     } else {
         // Trả về URL đăng nhập Google
         $authUrl = $client->createAuthUrl();
         echo json_encode([
             'success' => true,
             'auth_url' => $authUrl
         ]);
     }
 
 } catch (Exception $e) {
     error_log("Google Login Error: " . $e->getMessage());
     echo json_encode([
         'success' => false,
         'message' => 'Lỗi: ' . $e->getMessage()
     ]);
 }
 ?>
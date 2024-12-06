<?php
session_start();
header("Access-Control-Allow-Origin: http://localhost:3001");
header("Access-Control-Allow-Methods: GET, POST, OPTIONS");
header("Access-Control-Allow-Headers: Content-Type");
header("Access-Control-Allow-Credentials: true");
header("Content-Type: application/json; charset=UTF-8");

include '../../config.php';

spl_autoload_register(function ($class_name) {
    include '../../class/' . $class_name . '.php';
});

function postIndex($index, $value = "") {
    return isset($_POST[$index]) ? $_POST[$index] : $value;
}

if ($_SERVER["REQUEST_METHOD"] == "POST") {
    try {
        $conn = new PDO("mysql:host=localhost;dbname=doan_web_laptop", "root", "");
        $conn->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);

        if(isset($_POST['action'])){
         // Kiểm tra action reset
            if (isset($_POST['action']) && $_POST['action'] === 'reset_email') {
               $query = $conn->prepare("SELECT EMAIL FROM khachhang WHERE MAKH = :maKH AND TAIKHOAN = :taikhoan");
               $query->bindParam(':maKH', $_SESSION['khachhang']['MAKH']);
               $query->bindParam(':taikhoan', $_SESSION['khachhang']['TAIKHOAN']);
               $query->execute();
               $result = $query->fetch(PDO::FETCH_ASSOC);

               if ($result) {
                  // Cập nhật session
                  $_SESSION['khachhang']['EMAIL'] = $result['EMAIL'];

                  echo json_encode([
                     "success" => true,
                     "message" => "Đã reset email về giá trị ban đầu!",
                     "originalEmail" => $result['EMAIL'],
                     "userInfo" => $_SESSION['khachhang']
                  ]);
               } else {
                  echo json_encode([
                     "success" => false,
                     "message" => "Không tìm thấy thông tin tài khoản"
                  ]);
               }
            }elseif ($_POST['action'] === 'update_info') {
               $errors = array();
               $updateFields = array();
               $params = array();
               $updatedUserInfo = $_SESSION['khachhang']; // Tạo bản sao của session hiện tại
            
               // Xử lý ảnh
               if (isset($_FILES['anh']) && $_FILES['anh']['error'] === UPLOAD_ERR_OK) {
                  $fileName = $_FILES['anh']['name'];
                  move_uploaded_file($_FILES['anh']['tmp_name'], "../../assets/images/user/" . $fileName);
                  $updateFields[] = "ANH = :anh";
                  $params[':anh'] = $fileName;
                  $updatedUserInfo['ANH'] = $fileName; // Cập nhật vào bản sao
               }
            
               // Xử lý các trường thông tin khác
               $fieldMappings = [
                  'hoTen' => 'HOTEN',
                  'ngaySinh' => 'NGAYSINH',
                  'gioiTinh' => 'GIOITINH',
                  'dienThoai' => 'DIENTHOAI',
                  'diaChi' => 'DIACHI',
               ];
            
               foreach ($fieldMappings as $postField => $dbField) {
                  if (isset($_POST[$postField])) {
                     if ($postField === 'ngaySinh' && !empty($_POST[$postField])) {
                        $date = DateTime::createFromFormat('Y-m-d', $_POST[$postField]);
                        if ($date) {
                           $formattedDate = $date->format('Y-m-d');
                           $updateFields[] = "$dbField = :$postField";
                           $params[":$postField"] = $formattedDate;
                           $updatedUserInfo[$dbField] = $formattedDate;
                        }
                     } else {
                        $updateFields[] = "$dbField = :$postField";
                        $params[":$postField"] = $_POST[$postField];
                        $updatedUserInfo[$dbField] = $_POST[$postField];
                     }
                  }
               }
            
               // Thực hiện cập nhật nếu có thay đổi
               if (!empty($updateFields)) {
                  $params[':maKH'] = $_SESSION['khachhang']['MAKH'];
                  $params[':taikhoan'] = $_SESSION['khachhang']['TAIKHOAN'];
            
                  $sql = "UPDATE khachhang SET " . implode(", ", $updateFields) . 
                         " WHERE MAKH = :maKH AND TAIKHOAN = :taikhoan";
            
                  $query = $conn->prepare($sql);
                  
                  if ($query->execute($params)) {
                    // Lấy thông tin mới nhất từ database, thêm ANH vào
                     $getUpdatedInfo = $conn->prepare("SELECT MAKH, TAIKHOAN, HOTEN, NGAYSINH, GIOITINH, DIENTHOAI, DIACHI, EMAIL, ANH FROM khachhang WHERE MAKH = :maKH AND TAIKHOAN = :taikhoan");
                     $getUpdatedInfo->bindParam(':maKH', $_SESSION['khachhang']['MAKH']);
                     $getUpdatedInfo->bindParam(':taikhoan', $_SESSION['khachhang']['TAIKHOAN']);
                     $getUpdatedInfo->execute();
                     $latestInfo = $getUpdatedInfo->fetch(PDO::FETCH_ASSOC);

                     if ($latestInfo) {
                        // Cập nhật session với thông tin mới nhất từ DB
                        $_SESSION['khachhang'] = $latestInfo;

                        // Trả về response với thông tin đã cập nhật
                        echo json_encode([
                           "success" => true,
                           "message" => "Cập nhật thông tin thành công!",
                           "userInfo" => $latestInfo  // Bây giờ sẽ bao gồm cả trường ANH
                        ]);
                     } else {
                        echo json_encode([
                           "success" => false,
                           "message" => "Không thể lấy thông tin mới nhất"
                        ]);
                     }
                  } else {
                     echo json_encode([
                        "success" => false,
                        "message" => "Lỗi khi cập nhật thông tin"
                     ]);
                  }
               } else {
                  echo json_encode([
                     "success" => false,
                     "message" => "Không có thông tin nào được cập nhật"
                  ]);
               }
            }
        } else {
            // Xử lý update email
            $newEmail = postIndex("email");
            $password = postIndex("password");
            $errors = array();

            if (empty($newEmail)) {
                $errors['email'] = "Vui lòng nhập email mới";
            }
            if (empty($password)) {
                $errors['password'] = "Vui lòng nhập mật khẩu";
            }

            if (empty($errors)) {
                // Kiểm tra mật khẩu của user đang đăng nhập
                $checkPassword = $conn->prepare("SELECT COUNT(*) FROM khachhang WHERE MAKH = :maKH AND MATKHAU = :password AND TAIKHOAN = :taikhoan");
                $checkPassword->bindParam(':maKH', $_SESSION['khachhang']['MAKH']);
                $checkPassword->bindParam(':password', $password);
                $checkPassword->bindParam(':taikhoan', $_SESSION['khachhang']['TAIKHOAN']);
                $checkPassword->execute();
                $isValidPassword = $checkPassword->fetchColumn();

                if ($isValidPassword > 0) {
                    // Kiểm tra email mới có trùng với user khác không
                    $checkQuery = $conn->prepare("SELECT COUNT(*) FROM khachhang WHERE EMAIL = :newEmail AND MAKH != :maKH");
                    $checkQuery->bindParam(':newEmail', $newEmail);
                    $checkQuery->bindParam(':maKH', $_SESSION['khachhang']['MAKH']);
                    $checkQuery->execute();
                    $emailExists = $checkQuery->fetchColumn();

                    if ($emailExists > 0) {
                        $errors['email'] = "Email này đã được sử dụng";
                        echo json_encode(["success" => false, "errors" => $errors]);
                    } else {
                        // Cập nhật email mới
                        $query = $conn->prepare("UPDATE khachhang SET EMAIL = :newEmail WHERE MAKH = :maKH AND TAIKHOAN = :taikhoan");
                        $query->bindParam(':newEmail', $newEmail);
                        $query->bindParam(':maKH', $_SESSION['khachhang']['MAKH']);
                        $query->bindParam(':taikhoan', $_SESSION['khachhang']['TAIKHOAN']);
                        $query->execute();

                        // Cập nhật session
                        $_SESSION['khachhang']['EMAIL'] = $newEmail;

                        echo json_encode([
                            "success" => true, 
                            "message" => "Cập nhật email thành công!",
                            "newEmail" => $newEmail,
                            "userInfo" => $_SESSION['khachhang']
                        ]);
                    }
                } else {
                    $errors['password'] = "Mật khẩu không đúng";
                    echo json_encode(["success" => false, "errors" => $errors]);
                }
            } else {
                echo json_encode(["success" => false, "errors" => $errors]);
            }
        }
    } catch (PDOException $e) {
        echo json_encode([
            "success" => false, 
            "message" => "Lỗi: " . $e->getMessage()
        ]);
    }
}
?>
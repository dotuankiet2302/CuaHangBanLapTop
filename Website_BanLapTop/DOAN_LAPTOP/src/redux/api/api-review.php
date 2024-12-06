<?php
header("Access-Control-Allow-Origin: *");
header("Access-Control-Allow-Methods: GET, POST, OPTIONS");
header("Access-Control-Allow-Headers: Content-Type");
header("Content-Type: application/json; charset=UTF-8");

// Kiểm tra phương thức OPTIONS trước khi xử lý
if ($_SERVER['REQUEST_METHOD'] == 'OPTIONS') {
    header("Access-Control-Max-Age: 86400"); 
    http_response_code(200); 
    exit;
}

include '../../config.php'; 
spl_autoload_register(function ($class_name) {
    include '../../class/' . $class_name . '.php';
});

$db = new DB($conn); 

$method = $_SERVER['REQUEST_METHOD'];
$id = $_GET['id'] ?? ''; 

// Đảm bảo ID không rỗng khi sử dụng phương thức POST (thêm đánh giá)
if ($method === 'POST') {
    $input = json_decode(file_get_contents('php://input'), true);
    $id = $input['id'] ?? ''; 
}

// Đảm bảo ID không rỗng
if (empty($id)) {
    http_response_code(400); 
    echo json_encode(['success' => false, 'message' => 'ID sản phẩm không được để trống.']);
    exit;
}

// Hàm trả về phản hồi JSON
function jsonResponse($success, $message, $data = []) {
    echo json_encode(['success' => $success, 'message' => $message, 'data' => $data]);
    exit;
}

// Kiểm tra sự tồn tại của khách hàng trong bảng donhang
function isValidCustomer($db, $userId) {
   // Thực tế MADH phải là mã đơn hàng, và bạn phải lấy MAKH (mã khách hàng) từ bảng `donhang` 
   $query = "SELECT * FROM donhang WHERE MAKH = :MAKH";  // Thay MADH bằng MAKH
   $stmt = $db->prepare($query);
   $stmt->bindParam(':MAKH', $userId);  // Dùng MAKH thay vì MADH
   try {
       $stmt->execute();
   } catch (PDOException $e) {
       jsonResponse(false, 'Lỗi cơ sở dữ liệu: ' . $e->getMessage());
   }
   return $stmt->rowCount() > 0;
}


// Kiểm tra sự tồn tại của sản phẩm trong bảng laptop
function isValidProduct($db, $MALAP) {
    $query = "SELECT * FROM laptop WHERE MALAP = :MALAP";
    $stmt = $db->prepare($query);
    $stmt->bindParam(':MALAP', $MALAP);
    try {
        $stmt->execute();
    } catch (PDOException $e) {
        jsonResponse(false, 'Lỗi cơ sở dữ liệu: ' . $e->getMessage());
    }
    return $stmt->rowCount() > 0; // Nếu có sản phẩm thì trả về true
}

// Kiểm tra xem khách hàng đã mua sản phẩm chưa
function hasPurchasedProduct($db, $userId, $MALAP) {
   $query = "SELECT * FROM donhang i
             INNER JOIN chitietdonhang id ON i.MADH = id.MADH
             WHERE i.MAKH = :MAKH AND id.MALAP = :MALAP AND i.TINHTRANGGIAO = 'ĐÃ NHẬN'";
   $stmt = $db->prepare($query);
   $stmt->bindParam(':MAKH', $userId);
   $stmt->bindParam(':MALAP', $MALAP);
   try {
       $stmt->execute();
   } catch (PDOException $e) {
       jsonResponse(false, 'Lỗi cơ sở dữ liệu: ' . $e->getMessage());
   }
   return $stmt->rowCount() > 0;
}



function hasReviewedProduct($db, $userId, $MALAP) {
   $query = "SELECT * FROM danhgia dg
             INNER JOIN donhang dh ON dg.MADH = dh.MADH
             WHERE dh.MAKH = :MAKH AND dg.MALAP = :MALAP";
   $stmt = $db->prepare($query);
   $stmt->bindParam(':MAKH', $userId);
   $stmt->bindParam(':MALAP', $MALAP);
   try {
       $stmt->execute();
   } catch (PDOException $e) {
       jsonResponse(false, 'Lỗi cơ sở dữ liệu: ' . $e->getMessage());
   }
   return $stmt->rowCount() > 0; // Nếu có đánh giá thì trả về true
}


switch ($method) {
   case 'POST':
      // Thêm đánh giá
      $input = json_decode(file_get_contents('php://input'), true);
  
      // Kiểm tra dữ liệu đánh giá hợp lệ
      if (empty($input['rating']) || empty($input['comment']) || empty($input['userId'])) {
          jsonResponse(false, 'Dữ liệu đánh giá không hợp lệ.');
      }
  
      $rating = $input['rating'];
      $comment = $input['comment'];
      $userId = $input['userId'];
  
      // Kiểm tra sự tồn tại của khách hàng và sản phẩm
      if (!isValidCustomer($db, $userId)) {
          jsonResponse(false, 'Khách hàng không tồn tại.');
      }
      if (!isValidProduct($db, $id)) {
          jsonResponse(false, 'Sản phẩm không tồn tại.');
      }
  
      // Kiểm tra xem khách hàng đã đánh giá sản phẩm chưa
      if (hasReviewedProduct($db, $userId, $id)) {
          jsonResponse(false, 'Bạn đã đánh giá sản phẩm này.');
      }
  
      // Kiểm tra khách hàng đã mua và nhận sản phẩm chưa
      if (!hasPurchasedProduct($db, $userId, $id)) {
          jsonResponse(false, 'Bạn cần mua và nhận sản phẩm trước khi đánh giá.');
      }
  
      // Kiểm tra đánh giá hợp lệ (số sao từ 1 đến 5)
      if ($rating < 1 || $rating > 5) {
          jsonResponse(false, 'Số sao phải từ 1 đến 5.');
      }
  
      // Tạo mã đánh giá mới
      $stmt = $db->prepare("SELECT MAX(MADANHGIA) AS max_madanhgia FROM danhgia");
      $stmt->execute();
      $result = $stmt->fetch(PDO::FETCH_ASSOC);
      $maxMADANHGIA = $result['max_madanhgia'];
  
      $newNumber = ($maxMADANHGIA !== null) ? (int)substr($maxMADANHGIA, 2) + 1 : 1;
      $madanhgia = 'DG' . str_pad($newNumber, 3, '0', STR_PAD_LEFT);
  
      // Lấy MADH từ bảng donhang
      $query = "SELECT MADH FROM donhang WHERE MAKH = :MAKH AND TINHTRANGGIAO = 'ĐÃ NHẬN'";
      $stmt = $db->prepare($query);
      $stmt->bindParam(':MAKH', $userId);
      $stmt->execute();
      $result = $stmt->fetch(PDO::FETCH_ASSOC);
      $madonhang = $result['MADH'];
  
      // Chèn đánh giá vào bảng danhgia
      $stmt = $db->prepare("INSERT INTO danhgia (MADANHGIA, MADH, MALAP, SOSAO, MOTA) 
                            VALUES (:MADANHGIA, :MADH, :MALAP, :SOSAO, :MOTA)");
      $stmt->bindParam(':MADANHGIA', $madanhgia);
      $stmt->bindParam(':MADH', $madonhang);
      $stmt->bindParam(':MALAP', $id);
      $stmt->bindParam(':SOSAO', $rating);
      $stmt->bindParam(':MOTA', $comment);
  
      try {
          $stmt->execute();
      } catch (PDOException $e) {
          jsonResponse(false, 'Lỗi cơ sở dữ liệu: ' . $e->getMessage());
      }
      jsonResponse(true, 'Đánh giá sản phẩm thành công.');
      break;
  

    case 'GET':
        // Lấy danh sách đánh giá
        $query = "SELECT dg.SOSAO, dg.MOTA, kh.HOTEN, kh.ANH
                  FROM danhgia dg
                  INNER JOIN donhang dh ON dg.MADH = dh.MADH
                  INNER JOIN khachhang kh ON dh.MAKH = kh.MAKH
                  WHERE dg.MALAP = :MALAP";
        $stmt = $db->prepare($query);
        $stmt->bindParam(':MALAP', $id);
        try {
            $stmt->execute();
        } catch (PDOException $e) {
            jsonResponse(false, 'Lỗi cơ sở dữ liệu khi truy vấn đánh giá: ' . $e->getMessage());
        }

        $reviews = $stmt->fetchAll(PDO::FETCH_ASSOC);
        jsonResponse(true, 'Danh sách đánh giá', $reviews);
        break;

    default:
        jsonResponse(false, 'Phương thức không được hỗ trợ.');
}
?>

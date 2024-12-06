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
$userId = $_GET['id'] ?? ''; // Lấy mã khách hàng từ URL

// Đảm bảo ID không rỗng khi sử dụng phương thức POST (thêm đánh giá)
if ($method === 'POST') {
    $input = json_decode(file_get_contents('php://input'), true);
    $userId = $input['id'] ?? ''; 
}

// Hàm trả về phản hồi JSON
function jsonResponse($success, $message, $data = []) {
    echo json_encode(['success' => $success, 'message' => $message, 'data' => $data]);
    exit;
}

// Kiểm tra sự tồn tại của khách hàng trong bảng donhang
function isValidCustomer($db, $userId) {
   $query = "SELECT * FROM donhang WHERE MAKH = :MAKH";  
   $stmt = $db->prepare($query);
   $stmt->bindParam(':MAKH', $userId);  
   try {
       $stmt->execute();
   } catch (PDOException $e) {
       jsonResponse(false, 'Lỗi cơ sở dữ liệu: ' . $e->getMessage());
   }
   return $stmt->rowCount() > 0;
}

// Kiểm tra khách hàng có tồn tại
// if (!isValidCustomer($db, $userId)) {
//     jsonResponse(false, 'Khách hàng không tồn tại.');
// }

// Truy vấn lấy thông tin đơn hàng của khách hàng
$query = "
      SELECT 
         donhang.MADH,
          donhang.NGAYGIAO,  
         donhang.NGAYDAT, 
         donhang.DATHANHTOAN, 
         donhang.TINHTRANGGIAO, 
         donhang.TONGTIEN,
         chitietdonhang.SOLUONG, 
         chitietdonhang.DONGIA,
         laptop.ANHBIA,
         laptop.TENLAP, 
         laptop.MALAP 
      FROM donhang
      INNER JOIN chitietdonhang ON donhang.MADH = chitietdonhang.MADH
      INNER JOIN laptop ON chitietdonhang.MALAP = laptop.MALAP
      WHERE donhang.MAKH = :MAKH
      AND donhang.TINHTRANGGIAO != 'ĐÃ NHẬN'
";

$stmt = $db->prepare($query);
$stmt->bindParam(':MAKH', $userId);
$stmt->execute();

$orders = $stmt->fetchAll(PDO::FETCH_ASSOC);

if (count($orders) > 0) {
    jsonResponse(true, 'Lấy thông tin thành công.', $orders);
} else {
    jsonResponse(false, 'Không tìm thấy đơn hàng nào cho khách hàng này.');
}
?>

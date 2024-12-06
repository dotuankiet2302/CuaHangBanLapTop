
<?php
define('BASEPATH', true) OR exit('No direct script access allowed');

$id = $_GET['id'] ?? '';

if (!empty($id)) {
    $sql = "SELECT * FROM laptop WHERE MALAP = :id";
    $stm = $conn->prepare($sql);
    $stm->bindParam(':id', $id, PDO::PARAM_INT);
    $stm->execute(); 
    $data = $stm->fetch(PDO::FETCH_OBJ);
}

?>
<!DOCTYPE html>
<html lang="en">
<body>
<div class="container">
      <h1>Thanh toán thành công</h1>
      <p>Cảm ơn bạn đã thanh toán! Đơn hàng của bạn đã được xác nhận.</p>
</div>

</body>
</html>

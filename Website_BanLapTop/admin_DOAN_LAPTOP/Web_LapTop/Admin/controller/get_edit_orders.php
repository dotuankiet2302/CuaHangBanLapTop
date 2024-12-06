<?php
  session_start(); 
  include_once "../config/dbconnect.php";

  if (isset($_GET['order_id'])) {
    $orderId = $_GET['order_id'];

    // Lấy thông tin đơn hàng
    $sql = "SELECT * FROM donhang WHERE MADH = '$orderId'";
    $result = $conn->query($sql);
    
    if ($result->num_rows > 0) {
      $order = $result->fetch_assoc();
    } else {
      echo "Không tìm thấy đơn hàng!";
      exit();
    }
  } else {
    echo "Mã đơn hàng không hợp lệ!";
    exit();
  }

  // Cập nhật thông tin đơn hàng
  if (isset($_POST['update'])) {
    $newDate = $_POST['NGAYGIAO'];
    $newStatus = $_POST['TINHTRANGGIAO'];
    $paymentStatus = $_POST['DATHANHTOAN'];
    
    // Lấy mã nhân viên từ session
    $maNV = $_SESSION['nhanvien']['maNV'];

    // Cập nhật đơn hàng và thêm thông tin MANV
    $sqlUpdate = "UPDATE donhang 
                  SET NGAYGIAO = '$newDate', 
                      TINHTRANGGIAO = '$newStatus', 
                      DATHANHTOAN = '$paymentStatus', 
                      MANV = '$maNV' 
                  WHERE MADH = '$orderId'";
    if ($conn->query($sqlUpdate) === TRUE) {
      echo "<script>alert('Cập nhật thành công!'); window.location.href = './../index.php#orders';</script>";
    } else {
      echo "Lỗi: " . $conn->error;
    }
  }
?>

<!-- Giao diện sửa đơn hàng -->
<div style="text-align: center; padding: 20px;">
  <h2 style="color: #1a73e8;">Sửa Đơn Hàng: <?= $order['MADH'] ?></h2>
  <form method="POST" style="display: inline-block; text-align: left; padding: 20px; border: 1px solid #ccc; border-radius: 10px; background-color: #f9f9f9;">
    <div style="margin-bottom: 15px;">
      <label for="NGAYGIAO" style="font-weight: bold; color: #333;">Ngày Giao:</label>
      <input type="date" name="NGAYGIAO" value="<?= isset($order['NGAYGIAO']) ? $order['NGAYGIAO'] : '' ?>" required style="padding: 8px; width: 100%; border-radius: 5px;"/>
    </div>
    
    <!-- Tình trạng giao -->
    <div style="margin-bottom: 15px;">
      <label for="TINHTRANGGIAO" style="font-weight: bold; color: #333;">Tình Trạng Giao:</label>
      <select name="TINHTRANGGIAO" required style="padding: 8px; width: 100%; border-radius: 5px;">
        <option value="CHƯA GIAO" <?= ($order['TINHTRANGGIAO'] == 'CHƯA GIAO') ? 'selected' : '' ?>>CHƯA GIAO</option>
        <option value="ĐANG GIAO" <?= ($order['TINHTRANGGIAO'] == 'ĐANG GIAO') ? 'selected' : '' ?>>ĐANG GIAO</option>
        <option value="ĐÃ NHẬN" <?= ($order['TINHTRANGGIAO'] == 'ĐÃ NHẬN') ? 'selected' : '' ?>>ĐÃ NHẬN</option>
      </select>
    </div>
    
    <!-- Trạng thái thanh toán -->
    <div style="margin-bottom: 15px;">
      <label for="DATHANHTOAN" style="font-weight: bold; color: #333;">Trạng Thái Thanh Toán:</label>
      <select name="DATHANHTOAN" required style="padding: 8px; width: 100%; border-radius: 5px;">
        <option value="CHƯA THANH TOÁN" <?= ($order['DATHANHTOAN'] == 'CHƯA THANH TOÁN') ? 'selected' : '' ?>>CHƯA THANH TOÁN</option>
        <option value="HOÀN TẤT" <?= ($order['DATHANHTOAN'] == 'HOÀN TẤT') ? 'selected' : '' ?>>HOÀN TẤT</option>
      </select>
    </div>
    
    <button type="submit" name="update" style="background-color: #4CAF50; color: white; padding: 10px 20px; border: none; border-radius: 5px; cursor: pointer;">
      Cập Nhật
    </button>
  </form>
  <br />
  <a href="./../index.php#orders" class="button" style="text-decoration: none; color: #fff; background-color: #ff5733; padding: 10px 20px; border-radius: 5px;">
    Trở Lại
  </a>
</div>

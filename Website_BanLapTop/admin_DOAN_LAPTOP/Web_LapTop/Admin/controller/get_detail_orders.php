<?php
  include_once "../config/dbconnect.php";

  if (isset($_GET['order_id'])) {
    $orderId = $_GET['order_id'];

    // Lấy thông tin đơn hàng từ bảng donhang
    $sql = "SELECT donhang.MADH, donhang.NGAYGIAO, donhang.TINHTRANGGIAO, donhang.DATHANHTOAN, donhang.TONGTIEN,
                   nhanvien.HOTEN AS employee_name, donhang.MANV
            FROM donhang
            LEFT JOIN nhanvien ON donhang.MANV = nhanvien.MANV
            WHERE donhang.MADH = '$orderId'";
    $result = $conn->query($sql);

    if ($result->num_rows > 0) {
      $order = $result->fetch_assoc();
    } else {
      echo "Không tìm thấy thông tin đơn hàng.";
      exit();
    }

    // Lấy chi tiết đơn hàng từ bảng chitietdonhang
    $sqlDetails = "SELECT chitietdonhang.MALAP, chitietdonhang.SOLUONG, chitietdonhang.DONGIA 
                  FROM chitietdonhang WHERE chitietdonhang.MADH = '$orderId'";
    $resultDetails = $conn->query($sqlDetails);
    $orderDetails = [];
    if ($resultDetails->num_rows > 0) {
      while ($row = $resultDetails->fetch_assoc()) {
        $orderDetails[] = $row;
      }
    } else {
      $orderDetails = "Không có chi tiết cho đơn hàng này.";
    }
  } else {
    echo "Mã đơn hàng không hợp lệ!";
    exit();
  }
?>

<!DOCTYPE html>
<html lang="vi">
<head>
  <meta charset="UTF-8">
  <meta name="viewport" content="width=device-width, initial-scale=1.0">
  <title>Chi Tiết Đơn Hàng</title>
  <link rel="stylesheet" href="../assets/css/style.css">
  <style>
    body {
      font-family: Arial, sans-serif;
      margin: 0;
      padding: 0;
      background-color: #f4f4f4;
    }
    .container {
      width: 80%;
      margin: 0 auto;
      padding: 20px;
      background-color: #fff;
      border-radius: 8px;
      box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
    }
    h2 {
      text-align: center;
      color: #333;
    }
    p {
      font-size: 1.1em;
      color: #555;
    }
    table {
      width: 100%;
      margin-top: 20px;
      border-collapse: collapse;
    }
    th, td {
      padding: 12px;
      text-align: center;
      border: 1px solid #ddd;
    }
    th {
      background-color: #f8c8c1;
    }
    td {
      background-color: #fafafa;
    }
    .total {
      font-weight: bold;
      color: #d9534f;
    }
    .button {
      display: inline-block;
      background-color: #5cb85c;
      color: white;
      padding: 10px 20px;
      border-radius: 5px;
      text-decoration: none;
      margin-top: 20px;
      text-align: center;
    }
    .button:hover {
      background-color: #4cae4c;
    }
  </style>
</head>
<body>

  <div class="container">
    <h2>Chi Tiết Đơn Hàng: <?= $order['MADH'] ?></h2>

    <p><strong>Ngày Giao:</strong> <?= $order['NGAYGIAO'] ?></p>
    <p><strong>Tên Nhân Viên:</strong> <?= $order['employee_name'] ? $order['employee_name'] : 'Chưa có thông tin' ?></p>
    <p><strong>Tình Trạng Giao:</strong> <?= $order['TINHTRANGGIAO'] ?></p>
    <p><strong>Trạng Thái Thanh Toán:</strong> <?= $order['DATHANHTOAN'] ?></p>
    <p><strong>Tổng Tiền:</strong> <span class="total"><?= number_format($order['TONGTIEN'], 2) ?> VND</span></p>

    <h3>Chi Tiết Sản Phẩm</h3>

    <?php if (is_array($orderDetails)) { ?>
      <table>
        <thead>
          <tr>
            <th>Mã Lap</th>
            <th>Số Lượng</th>
            <th>Đơn Giá</th>
            <th>Thành Tiền</th>
          </tr>
        </thead>
        <tbody>
          <?php foreach ($orderDetails as $detail) { ?>
            <tr>
              <td><?= $detail['MALAP'] ?></td>
              <td><?= $detail['SOLUONG'] ?></td>
              <td><?= number_format($detail['DONGIA'], 2) ?> VND</td>
              <td><?= number_format($detail['SOLUONG'] * $detail['DONGIA'], 2) ?> VND</td>
            </tr>
          <?php } ?>
        </tbody>
      </table>
    <?php } else {
      echo "<p>$orderDetails</p>";
    } ?>

    <a href="./../index.php#orders" class="button">Trở Lại</a>
  </div>

</body>
</html>

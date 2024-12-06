<div id="orders" style="text-align: center; padding: 30px;">
  <h2 style="color: #1a73e8;">Quản Lý Đơn Hàng</h2>
  <table class="table" style="max-width: 1600px; margin: auto; border-collapse: collapse; width: 90%; background-color: #f9f9f9;">
    <thead style="background-color: #007BFF; color: white;">
      <tr>
        <th class="text-center" style="padding: 10px;">S.N.</th>
        <th class="text-center" style="padding: 10px;">Mã Đơn Hàng</th>
        <th class="text-center" style="padding: 10px;">Tên Nhân Viên</th>
        <th class="text-center" style="padding: 10px;">Ngày Giao</th>
        <th class="text-center" style="padding: 10px;">Tổng Tiền</th>
        <th class="text-center" style="padding: 10px;">Tình Trạng Giao</th>
        <th class="text-center" style="padding: 10px;">Trạng Thái Thanh Toán</th>
        <th class="text-center" style="padding: 10px;" colspan="2">Hành Động</th>
      </tr>
    </thead>
    <tbody>
      <?php
        include_once "../config/dbconnect.php";
        $sql = "SELECT donhang.MADH, donhang.NGAYGIAO, donhang.TINHTRANGGIAO, donhang.DATHANHTOAN, donhang.TONGTIEN,
                       nhanvien.HOTEN AS employee_name, donhang.MANV
                FROM donhang
                LEFT JOIN nhanvien ON donhang.MANV = nhanvien.MANV";
        $result = $conn->query($sql);
        $count = 1;
        if ($result->num_rows > 0) {
          while ($row = $result->fetch_assoc()) {
      ?>
            <tr style="border: 1px solid #ddd;">
              <td class="text-center" style="padding: 10px;"><?= $count ?></td>
              <td class="text-center" style="padding: 10px;"><?= $row["MADH"] ?></td>
              <td class="text-center" style="padding: 10px;"><?= $row["employee_name"] ? $row["employee_name"] : 'Chưa có thông tin' ?></td>
              <td class="text-center" style="padding: 10px;"><?= $row["NGAYGIAO"] ?></td>
              <td class="text-center" style="padding: 10px;"><?= number_format($row["TONGTIEN"], 2) ?> VND</td>
              
              <!-- Tình trạng giao với màu chữ -->
              <td class="text-center" style="padding: 10px height: 10px;
                <?php 
                  if ($row["TINHTRANGGIAO"] == 'CHƯA GIAO') {
                    echo 'color: red;'; // Màu chữ đỏ
                  } elseif ($row["TINHTRANGGIAO"] == 'ĐANG GIAO') {
                    echo 'color: orange;'; // Màu chữ cam
                  } elseif ($row["TINHTRANGGIAO"] == 'ĐÃ GIAO') {
                    echo 'background-color: red; color: yellow;'; // Màu chữ vàng
                  }
                ?>
              ">
                <?= $row["TINHTRANGGIAO"] ?>
              </td>
              
              <!-- Trạng thái thanh toán với màu chữ -->
              <td class="text-center" style="padding: 10px;
                <?php 
                  if ($row["DATHANHTOAN"] == 'CHƯA THANH TOÁN') {
                    echo 'color: red;'; // Màu chữ đỏ
                  } elseif ($row["DATHANHTOAN"] == 'HOÀN TẤT') {
                    echo 'background-color: pink; color: green;'; // Màu chữ xanh
                  }
                ?>
              ">
                <?= $row["DATHANHTOAN"] ?>
              </td>

              <td style="padding: 10px;">
                <button class="btn btn-primary" onclick="editOrder('<?= $row["MADH"] ?>')" style="background-color: #4CAF50; color: white; border: none; padding: 10px 20px; cursor: pointer;">Sửa</button>
              </td>
              <td style="padding: 10px;">
                <button class="btn" onclick="viewOrderDetails('<?= $row["MADH"] ?>')" style="background-color: #ffcc00; color: white; border: none; padding: 10px 20px; cursor: pointer;">Chi Tiết</button>
              </td>
            </tr>

      <?php
            $count++;
          }
        }
      ?>
    </tbody>
  </table>
</div>


<script>
  function viewOrderDetails(orderId) {
    window.location.href = 'controller/get_detail_orders.php?order_id=' + orderId;
  }

  function editOrder(orderId) {
    window.location.href = 'controller/get_edit_orders.php?order_id=' + orderId;
  }
</script>



</body>

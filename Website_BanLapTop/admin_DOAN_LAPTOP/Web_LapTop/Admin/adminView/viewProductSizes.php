<div>
  <h2>Danh Sách Đơn Nhập</h2>
  <button onclick="AddOder()" type="button" class="btn btn-secondary" style="height:40px" >
    Thêm Đơn Nhập
  </button>
  <div class="container" style="max-width: 1200px; margin: 0 auto;">
    <!-- Tìm kiếm và sắp xếp -->
    <div class="row mb-2">
        <!-- Hộp tìm kiếm -->
        <div class="col-md-6">
            <input type="text" id="searchInput" placeholder="Tìm kiếm phiếu nhập..." class="form-control form-control-lg" style="width: 100%; display: inline-block;">
        </div>
        <div class="col-md-2">
            <button onclick="searchOrder()" class="btn btn-primary btn-lg" style="width: 100%; height: 100%;">Tìm kiếm</button>
        </div>
    </div>
  </div>

  <table class="table" style="max-width: 1600px;">
    <thead>
      <tr>
        <th class="text-center">S.N.</th>
        <th class="text-center">Purchase Order Code</th>
        <th class="text-center">Employee Name</th>
        <th class="text-center">Supplier Name</th>
        <th class="text-center">Order Date</th>
        <th class="text-center">Total Price</th>
        <th class="text-center">Status</th>
        <th class="text-center" colspan="3">Action</th>
      </tr>
    </thead>
    <?php
      include_once "../config/dbconnect.php";
      // Sửa lại câu lệnh SQL để truy vấn bảng phieunhaphang và các thông tin liên quan
      $sql = "SELECT phieunhaphang.MAPHIEU, phieunhaphang.NGAYLAP, phieunhaphang.TONGTIEN, phieunhaphang.TINHTRANG,
                     nhanvien.HOTEN AS employee_name, nhacungcap.TENNCC AS supplier_name 
              FROM phieunhaphang 
              JOIN nhanvien ON phieunhaphang.MANV = nhanvien.MANV 
              JOIN nhacungcap ON phieunhaphang.MANCC = nhacungcap.MANCC";
      $result = $conn->query($sql);
      $count = 1;
      if ($result->num_rows > 0) {
        while ($row = $result->fetch_assoc()) {
    ?>
    <tr>
      <!-- Hiển thị thông tin phiếu nhập -->
      <td class="text-center"><?= $count ?></td>
      <td class="text-center"><?= $row["MAPHIEU"] ?></td>
      <td class="text-center"><?= $row["employee_name"] ?></td>
      <td class="text-center"><?= $row["supplier_name"] ?></td>
      <td class="text-center"><?= $row["NGAYLAP"] ?></td>
      <td class="text-center"><?= number_format($row["TONGTIEN"], 2) ?> VND</td>
      <td class="text-center"><?= $row["TINHTRANG"] ?></td>
      <td><button class="btn btn-primary" style="height:40px" onclick="editOrder('<?= $row["MAPHIEU"] ?>')">Edit</button></td>
      <td><button class="btn btn-danger" style="height:40px" onclick="deleteOrder('<?= $row["MAPHIEU"] ?>')">Delete</button></td>
      <td><button class="btn" style="height:40px; background-color: #ffcc00; color: white; border: none;" onclick="viewOrderDetails('<?= $row["MAPHIEU"] ?>')">Detail</button></td>
    </tr>
    <?php
            $count++;
        }
      }
    ?>
  </table>
   <!-- Trigger the modal with a button -->
   <button type="button" class="btn btn-secondary" style="height:40px" data-toggle="modal" data-target="#myModal">
    Add Suppliers
  </button>
</div>

<script>
  

  function AddOder()
  {
    // Chuyển hướng đến trang chi tiết đơn nhập
    window.location.href = 'controller/add_order.php';
  }

  function viewOrderDetails(orderId) {
    // Chuyển hướng đến trang chi tiết đơn nhập
    window.location.href = 'controller/order_details.php?order_id=' + orderId;
}

</script>

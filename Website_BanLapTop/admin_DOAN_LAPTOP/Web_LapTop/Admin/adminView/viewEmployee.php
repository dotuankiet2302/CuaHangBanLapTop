<div>
  <h2>All Employees</h2>
  <div class="container" style="max-width: 1200px; margin: 0 auto;">
    
    <!-- Tìm kiếm và sắp xếp -->
    <div class="row mb-2">
        <!-- Hộp tìm kiếm -->
        <div class="col-md-6">
            <input type="text" id="searchInput" placeholder="Tìm kiếm nhân viên..." class="form-control form-control-lg" style="width: 100%; display: inline-block;">
        </div>
        <div class="col-md-2">
            <button onclick="searchEmployee()" class="btn btn-primary btn-lg" style="width: 100%; height: 100%;">Tìm kiếm</button>
        </div>
    </div>
  </div>
  <table class="table" style="max-width: 1600px;">
    <thead>
      <tr>
        <th class="text-center">S.N.</th>
        <th class="text-center">Name</th>
        <th class="text-center">Email</th>
        <th class="text-center">Contact Number</th>
        <th class="text-center">Date of Birth</th>
        <th class="text-center">Gender</th>
        <th class="text-center">Address</th>
        <th class="text-center" colspan="3">Action</th>
      </tr>
    </thead>
    <?php
      include_once "../config/dbconnect.php";
      // Truy vấn bảng nhanvien
      $sql = "SELECT * FROM nhanvien";
      $result = $conn->query($sql);
      $count = 1;
      if ($result->num_rows > 0) {
        while ($row = $result->fetch_assoc()) {
    ?>
    <tr>
      <!-- Hiển thị thông tin nhân viên -->
      <td class="text-center"><?= $count ?></td>
      <td class="text-center"><?= $row["HOTEN"] ?></td>
      <td class="text-center"><?= $row["EMAIL"] ?></td>
      <td class="text-center"><?= $row["DIENTHOAI"] ?></td>
      <td class="text-center"><?= $row["NGAYSINH"] ?></td>
      <td class="text-center"><?= $row["GIOITINH"] ?></td>
      <td class="text-center"><?= $row["DIACHI"] ?></td>
      <td><button class="btn btn-primary" style="height:40px" onclick="">Edit</button></td>
      <td><button class="btn btn-danger" style="height:40px" onclick="">Delete</button></td>
      <td><button class="btn" style="height:40px; background-color: #ffcc00; color: white; border: none;" onclick="">Detail</button></td>
    </tr>
    <?php
            $count++;
        }
      }
    ?>
  </table>
</div>

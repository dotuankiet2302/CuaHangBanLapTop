
<?php
include_once "../config/dbconnect.php";
session_start(); // Bắt đầu session

// Hiển thị thông báo nếu có
if (isset($_SESSION['success_message'])) {
    echo '<div class="alert alert-success">' . $_SESSION['success_message'] . '</div>';
    unset($_SESSION['success_message']); // Xóa thông báo sau khi hiển thị
}

if (isset($_SESSION['error_message'])) {
    echo '<div class="alert alert-danger">' . $_SESSION['error_message'] . '</div>';
    unset($_SESSION['error_message']); // Xóa thông báo lỗi
}

?>
<div >
  <h2>Product Items</h2>
 <!-- Container giới hạn chiều rộng 1000px -->
<div class="container" style="max-width: 1000px; margin: 0 auto;">
    

    <!-- Tìm kiếm và sắp xếp -->
    <div class="row mb-2">
        <!-- Hộp tìm kiếm -->
        <div class="col-md-6">
            <input type="text" id="searchInput" placeholder="Tìm kiếm sản phẩm..." class="form-control form-control-lg" style="width: 100%; display: inline-block;">
        </div>
        <div class="col-md-2">
            <button onclick="searchProduct()" class="btn btn-primary btn-lg" style="width: 100%; height: 100%;">Tìm kiếm</button>
        </div>
    </div>

   <!-- Combobox Sắp xếp (xuống hàng và căn phải) -->
   <div class="row mb-4" style="justify-content: flex-end;">
        <div class="col-md-4">
          <select id="sortByStock" class="form-control form-control-lg" onchange="sortByStock()">
              <option value="">Sắp Xếp Tồn Kho</option>
              <option value="ASC">Tăng dần</option>
              <option value="DESC">Giảm dần</option>
          </select>
      </div>

        <div class="col-md-4">
            <select id="sortByPrice" class="form-control form-control-lg" onchange="sortByPrice()">
            <option value="">Sắp Xếp Giá Bán</option>
                <option value="ASC">Tăng dần</option>
                <option value="DESC">Giảm dần</option>
            </select>
        </div>
    </div>
</div>
<div class="row">
  <table class="table" style="width: 1600px;">

    <thead>
    <tr>
        <th class="text-center">S.N.</th>
        <th class="text-center">Ảnh </th>
        <th class="text-center">Tên LapTop</th>
        <th class="text-center">Hãng Máy</th>
        <th class="text-center">Cấu Hình</th>
        <th class="text-center">Nhà Sản Xuất</th>
        <th class="text-center">Giá Bán</th>
        <th class="text-center">Số Lượng Tồn </th>
        <th class="text-center">Tình Trạng Máy </th>
        <th class="text-center" colspan="3">Action</th>
  </tr>
    </thead>
    <tbody id="laptopTable">
        <?php
        // Kết nối cơ sở dữ liệu
       // include_once "../config/dbconnect.php";
    
        // Truy vấn dữ liệu
        $sql = "
                SELECT 
                    laptop.*, 
                    hangmay.TENHANG, 
                    nhasx.TENNSX, 
                    tinhtrangmay.TENTINHTRANG, 
                    cauhinh.CPU, 
                    cauhinh.RAM, 
                    cauhinh.OCUNG, 
                    cauhinh.CARDMH, 
                    cauhinh.TRONGLUONG
                FROM 
                    laptop
                JOIN 
                    hangmay ON laptop.MAHANG = hangmay.MAHANG
                JOIN 
                    nhasx ON laptop.MANSX = nhasx.MANSX
                JOIN 
                    tinhtrangmay ON laptop.MATINHTRANG = tinhtrangmay.MATINHTRANG
                JOIN 
                    cauhinh ON laptop.MACAUHINH = cauhinh.MACAUHINH
                ";


        $result = $conn->query($sql);
        $count = 1;

        // Kiểm tra kết quả truy vấn
        if ($result->num_rows > 0) {
            while ($row = $result->fetch_assoc()) {
                ?>
               <tr id="row-<?=$row['MALAP']?>">
                      <td class="text-center"><?=$count?></td>
                      <td><img height='100px' src='/Web_LapTop/Admin/assets/images/<?=$row["ANHBIA"]?>'></td>


                      <td class="text-center"><?=htmlspecialchars($row["TENLAP"])?></td>
                      <td class="text-center"><?=htmlspecialchars($row["TENHANG"])?></td>
                      <td class="text-center">
                          CPU: <?=htmlspecialchars($row["CPU"])?>, 
                          RAM: <?=htmlspecialchars($row["RAM"])?>GB, 
                          Ổ cứng: <?=htmlspecialchars($row["OCUNG"])?>, 
                          Card MH: <?=htmlspecialchars($row["CARDMH"])?>, 
                          Trọng lượng: <?=htmlspecialchars($row["TRONGLUONG"])?>kg
                      </td>
                      <td class="text-center"><?=htmlspecialchars($row["TENNSX"])?></td>
                      <td class="text-center"><?=htmlspecialchars($row["GIABAN"])?></td>
                      <td class="text-center"><?=htmlspecialchars($row["SOLUONGTON"])?></td>
                      <td class="text-center"><?=htmlspecialchars($row["TENTINHTRANG"])?></td>
                      <td>
                        <a href="controller/process_edit_laptop.php?product_id=<?=$row['MALAP']?>" class="btn btn-primary" style="height:40px">Edit</a>
                      </td>

                      <td><button class="btn btn-danger" style="height:40px" onclick="itemDelete('<?=$row['MALAP']?>')">Delete</button></td>
                      <td><button class="btn" style="height:40px; background-color: #ffcc00; color: white; border: none;" onclick="itemDetail('<?=$row['MALAP']?>')">Detail</button></td>


</tr>

                <?php
                $count++;
            }
        } else {
            echo '<tr><td colspan="10" class="text-center">No laptops found</td></tr>';
        }
        ?>
    </tbody>
</table>
</div>

  <!-- Trigger the modal with a button -->
  <button type="button" class="btn btn-secondary " style="height:40px" data-toggle="modal" data-target="#myModal">
    Add Product
  </button>

 <!-- Modal -->
 <div class="modal fade" id="myModal" role="dialog">
  <div class="modal-dialog">
    <!-- Modal content-->
    <div class="modal-content">
      <div class="modal-header">
        <h4 class="modal-title">New Laptop Item</h4>
        <button type="button" class="close" data-dismiss="modal">&times;</button>
      </div>
      <div class="modal-body">
        <form enctype="multipart/form-data" onsubmit="addLaptopItem(event)" method="POST">
          
          <!-- Row for two fields per line -->
          <div class="row">
            <div class="col-md-6 form-group">
              <label for="name">Product Name:</label>
              <input type="text" class="form-control" id="p_name" required>
            </div>
            <div class="col-md-6 form-group">
              <label for="price">Price:</label>
              <input type="number" class="form-control" id="p_price" required>
            </div>
          </div>

          <div class="row">
            <div class="col-md-6 form-group">
              <label for="qty">Description:</label>
              <input type="text" class="form-control" id="p_desc" required>
            </div>

            <!-- Add ComboBox for selecting cấu hình -->
            <div class="col-md-6 form-group">
              <label>Configuration:</label>
              <select id="macauhinh" onchange="loadConfiguration()" class="form-control">
                <option disabled selected>Select configuration</option>
                <?php
                  // Query to load all cấu hình
                  $sql = "SELECT * FROM cauhinh";
                  $result = $conn->query($sql);
                  if ($result->num_rows > 0) {
                    while ($row = $result->fetch_assoc()) {
                      echo "<option value='" . $row['MACAUHINH'] . "'>" . $row['MACAUHINH'] . "</option>";
                    }
                  }
                ?>
              </select>
            </div>
          </div>

          <!-- Configuration Info (will be filled automatically based on selection) -->
          <div id="config-info">
            <div class="row">
              <div class="col-md-6 form-group">
                <label for="cpu">CPU:</label>
                <input type="text" class="form-control" id="cpu" required readonly>
              </div>
              <div class="col-md-6 form-group">
                <label for="ram">RAM (GB):</label>
                <input type="text" class="form-control" id="ram" required readonly>
              </div>
            </div>

            <div class="row">
              <div class="col-md-6 form-group">
                <label for="ocung">Storage (GB):</label>
                <input type="text" class="form-control" id="ocung" required readonly>
              </div>
              <div class="col-md-6 form-group">
                <label for="cardmh">Graphics Card:</label>
                <input type="text" class="form-control" id="cardmh" required readonly>
              </div>
            </div>

            <div class="row">
              <div class="col-md-6 form-group">
                <label for="trongluong">Weight (kg):</label>
                <input type="number" class="form-control" id="trongluong" step="0.1" required readonly>
              </div>
            </div>
          </div>

          <!-- Manufacturer -->
          <div class="row">
            <div class="col-md-6 form-group">
              <label for="mansx">Manufacturer:</label>
              <select class="form-control" id="mansx" required>
                <option disabled selected>Select Manufacturer</option>
                <?php
                  $sql = "SELECT * FROM nhasx";
                  $result = $conn->query($sql);
                  if ($result->num_rows > 0) {
                    while($row = $result->fetch_assoc()){
                      echo "<option value='".$row['MANSX']."'>".$row['TENNSX']."</option>";
                    }
                  }
                ?>
              </select>
            </div>
            <div class="col-md-6 form-group">
              <label for="mahang">Brand:</label>
              <select class="form-control" id="mahang" required>
                <option disabled selected>Select Brand</option>
                <?php
                  $sql = "SELECT * FROM hangmay";
                  $result = $conn->query($sql);
                  if ($result->num_rows > 0) {
                    while($row = $result->fetch_assoc()){
                      echo "<option value='".$row['MAHANG']."'>".$row['TENHANG']."</option>";
                    }
                  }
                ?>
              </select>
            </div>
          </div>

          <!-- Status -->
          <div class="row">
            <div class="col-md-6 form-group">
              <label for="matinhtrang">Status:</label>
              <select class="form-control" id="matinhtrang" required>
                <option disabled selected>Select Status</option>
                <?php
                  $sql = "SELECT * FROM tinhtrangmay";
                  $result = $conn->query($sql);
                  if ($result->num_rows > 0) {
                    while($row = $result->fetch_assoc()){
                      echo "<option value='".$row['MATINHTRANG']."'>".$row['TENTINHTRANG']."</option>";
                    }
                  }
                ?>
              </select>
            </div>

            <div class="col-md-6 form-group">
              <label for="file">Choose Image:</label>
              <input type="file" class="form-control-file" id="file">
            </div>
          </div>

          <div class="form-group">
            <button type="submit" class="btn btn-secondary" id="upload" style="height:40px">Add Item</button>
          </div>
        </form>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-default" data-dismiss="modal" style="height:40px">Close</button>
      </div>
    </div>
  </div>
</div>


<script>
 function loadConfiguration() {
    var macauhinh = document.getElementById('macauhinh').value;
    if (macauhinh) {
        console.log("Fetching data for MACAUHINH: " + macauhinh);

        fetch('controller/get_configuration.php?macauhinh=' + macauhinh)
            .then(response => {
                if (!response.ok) {
                    throw new Error('Network response was not ok ' + response.statusText);
                }
                return response.json();
            })
            .then(data => {
                console.log(data); // Kiểm tra dữ liệu trả về
                if (data && !data.error) {
                    document.getElementById('cpu').value = data.CPU || '';
                    document.getElementById('ram').value = data.RAM || '';
                    document.getElementById('ocung').value = data.OCUNG || '';
                    document.getElementById('cardmh').value = data.CardMH || '';
                    document.getElementById('trongluong').value = data.TrongLuong || '';
                } else {
                    alert(data.error || 'No data found');
                }
            })
            .catch(error => {
                console.error('Error fetching configuration:', error);
                alert('Error fetching configuration: ' + error.message);
            });
    }
}
function addLaptopItem(event) {
    event.preventDefault();  // Ngừng form gửi lại

    // Lấy giá trị từ các trường input
    var pName = document.getElementById('p_name').value;
    var pPrice = document.getElementById('p_price').value;
    var pDesc = document.getElementById('p_desc').value;

    if (!pName || !pPrice || !pDesc) {
        alert('Please fill in all required fields!');
        return;
    }

    // Tiến hành gửi dữ liệu qua AJAX (hoặc có thể xử lý form gửi trực tiếp)
    var formData = new FormData();
    formData.append('p_name', pName);
    formData.append('p_price', pPrice);
    formData.append('p_desc', pDesc);
    formData.append('macauhinh', document.getElementById('macauhinh').value);
    formData.append('mansx', document.getElementById('mansx').value);
    formData.append('mahang', document.getElementById('mahang').value);
    formData.append('matinhtrang', document.getElementById('matinhtrang').value);
    formData.append('file', document.getElementById('file').files[0]);

    var xhr = new XMLHttpRequest();
    xhr.open('POST', 'controller/process_add_laptop.php', true);
    xhr.onload = function () {
        if (xhr.status === 200) { 
            alert('Item added successfully!');
            showProductItems();
        } else {
            alert('Error adding item');
        }
    };
    xhr.send(formData);
}

function loadProductList() {
    var xhr = new XMLHttpRequest();
    xhr.open('GET', 'controller/load_products.php', true);
    xhr.onload = function () {
        if (xhr.status === 200) {
            document.getElementById('productList').innerHTML = xhr.responseText; // Hiển thị lại danh sách sản phẩm
        } else {
            alert('Error loading products');
        }
    };
    xhr.send();
}
function itemDelete(malap) {
  if (confirm("Are you sure you want to delete this laptop?")) {
    var xhr = new XMLHttpRequest();
    xhr.open("POST", "controller/process_delete_laptop.php", true);
    xhr.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");

    xhr.onload = function () {
      if (xhr.status === 200) {
        console.log(xhr.responseText);
        
        // Tìm dòng với ID tương ứng và xóa khỏi giao diện
        var row = document.getElementById("row-" + malap);
        if (row) {
          row.remove();
          alert("Laptop item deleted successfully!");
        } else {
          alert("Row with ID " + malap + " not found!");
        }
      } else {
        alert("Error deleting laptop item!");
      }
    };

    xhr.send("malap=" + malap);
  }
}


// function itemEditForm(MALAP) {
//     // Tạo URL cho trang chỉnh sửa, thêm mã sản phẩm vào query string
//     var url = 'http://localhost:3000/Web_LapTop/Admin/controller/process_edit_laptop.php?product_id=' + MALAP;
    
//     // Chuyển hướng người dùng đến trang chỉnh sửa
//     window.location.href = url;
   
// }

// function itemDetail(MALAP) {
//         // Chuyển hướng đến trang chi tiết sản phẩm
//         window.location.href = `http://localhost:8000/Web_LapTop/Admin/controller/process_detail_laptop.php?MALAP=` + encodeURIComponent(MALAP);
//     }

//     function searchProduct() {
//     var searchValue = document.getElementById("searchInput").value;

//     // Tạo đối tượng XMLHttpRequest
//     var xhr = new XMLHttpRequest();
    
//     // Cấu hình yêu cầu (GET) và đính kèm tham số tìm kiếm
//     xhr.open("GET", "http://localhost:8000/Web_LapTop/Admin/controller/searchLaptops.php?search=" + searchValue, true);
    
//     // Xử lý khi có phản hồi từ server
//     xhr.onload = function() {
//         if (xhr.status == 200) {
//             // Cập nhật danh sách sản phẩm với kết quả tìm kiếm
//             document.getElementById("laptopTable").innerHTML = xhr.responseText;
//         }
//     };

//     // Gửi yêu cầu
//     xhr.send();
// }
function itemDetail(MALAP) {
  window.location.href = `controller/process_detail_laptop.php?MALAP=` + encodeURIComponent(MALAP); 
}

function searchProduct() {
  var searchValue = document.getElementById("searchInput").value;

  var xhr = new XMLHttpRequest();
  
  xhr.open("GET", "controller/searchLaptops.php?search=" + searchValue, true); 

  xhr.onload = function() {
    if (xhr.status == 200) {
      document.getElementById("laptopTable").innerHTML = xhr.responseText;
    }
  };

  xhr.send();
}


function sortByStock() {
    var sortValue = document.getElementById("sortByStock").value;

    // Tạo đối tượng XMLHttpRequest
    var xhr = new XMLHttpRequest();
    
    // Cấu hình yêu cầu (GET) và đính kèm tham số sắp xếp
    xhr.open("GET", "controller/sortLaptopsByStock.php?sort=" + sortValue, true);
    
    // Xử lý khi có phản hồi từ server
    xhr.onload = function() {
        if (xhr.status == 200) {
            // Cập nhật danh sách sản phẩm với kết quả đã sắp xếp
            document.getElementById("laptopTable").innerHTML = xhr.responseText;
        }
    };

    // Gửi yêu cầu
    xhr.send();
}

function sortByPrice() {
    var sortValue = document.getElementById("sortByPrice").value;

    // Tạo đối tượng XMLHttpRequest
    var xhr = new XMLHttpRequest();
    
    // Cấu hình yêu cầu (GET) và đính kèm tham số sắp xếp theo giá bán
    xhr.open("GET", "controller/sortLaptopsByPrice.php?sort=" + sortValue, true);
    
    // Xử lý khi có phản hồi từ server
    xhr.onload = function() {
        if (xhr.status == 200) {
            // Cập nhật danh sách sản phẩm với kết quả đã sắp xếp
            document.getElementById("laptopTable").innerHTML = xhr.responseText;
        }
    };

    // Gửi yêu cầu
    xhr.send();
}


</script>





  
</div>
   
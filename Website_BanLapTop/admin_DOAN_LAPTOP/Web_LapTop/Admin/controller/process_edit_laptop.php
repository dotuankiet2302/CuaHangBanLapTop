<?php
include '../config/dbconnect.php'; // Kết nối cơ sở dữ liệu
include('Product.php'); // Bao gồm lớp Product

// Khởi tạo đối tượng Product
$product = new Product($conn);

// Khai báo các biến để lưu thông tin sản phẩm
$productName = '';
$price = '';
$description = '';
$configuration = '';
$manufacturer = '';
$brand = '';
$status = '';

// Nếu có yêu cầu sửa thông tin sản phẩm, lấy ID sản phẩm từ URL hoặc phương thức POST
if (isset($_GET['product_id'])) {
    $product->setProductId($_GET['product_id']);
    $product->getProduct(); // Lấy thông tin sản phẩm từ cơ sở dữ liệu

    // Gán các giá trị từ sản phẩm vào các biến để hiển thị trên form
    $productName = $product->getProductName();
    $price = $product->getPrice();
    $description = $product->getDescription();
    $configuration = $product->getConfiguration();
    $manufacturer = $product->getManufacturer();
    $brand = $product->getBrand();
    $status = $product->getStatus();
    $malap = $product->getProductID();
}

// Nếu form được gửi đi, cập nhật thông tin sản phẩm
if ($_SERVER['REQUEST_METHOD'] == 'POST') {
    // Lấy dữ liệu từ form
    $productName = $_POST['p_name'];
    $price = $_POST['p_price'];
    $description = $_POST['p_desc'];
    $configuration = $_POST['macauhinh'];
    $manufacturer = $_POST['mansx'];
    $brand = $_POST['mahang'];
    $status = $_POST['matinhtrang'];
    $productId = $_POST['MALAP']; // Lấy productId từ form
    // Thiết lập thông tin sản phẩm
    
     // Thiết lập thông tin sản phẩm
     $product->setProductInfo($productId, $productName, $price, $description, $configuration, $manufacturer, $brand, $status);
    // Cập nhật sản phẩm
    if ($product->updateProduct()) {
        // Thông báo thành công và chuyển hướng
        echo "<script>
        alert('Cập nhật sản phẩm thành công!');
        showProductItems();  // Gọi hàm showProductItems để cập nhật nội dung trang
    </script>";


    } else {
        // Thông báo thất bại và chuyển hướng
        echo "<script>
                alert('Cập nhật sản phẩm thất bại.');
                showProductItems();
              </script>";
    }
    
}
?>

<!DOCTYPE html>
<html>
<head> 
  <title>Admin</title>
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">
  <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
  <link rel="stylesheet" href="./assets/css/style.css">
</head>

<body>
<div id="main-content" class="container allContent-section py-4">
<h1 class="text-center">Product Updates</h1>
<form enctype="multipart/form-data" method="POST">
   
    <div class="form-row">
        <div class="form-group col-md-6">
            <label for="name">Product ID :</label>
            <input type="text" class="form-control"  name="MALAP" value="<?php echo $malap; ?>" required>
        </div>
        <div class="form-group col-md-6">
            <label for="price">Price:</label>
            <input type="number" class="form-control" id="p_price" name="p_price" value="<?php echo $price; ?>" required>
        </div>
    </div>
    <div class="form-row">
        <div class="form-group col-md-6">
            <label for="name">Product Name:</label>
            <input type="text" class="form-control" id="p_name" name="p_name" value="<?php echo $productName; ?>" required>
        </div>
        <div class="form-group col-md-6">
            <label for="price">Price:</label>
            <input type="number" class="form-control" id="p_price" name="p_price" value="<?php echo $price; ?>" required>
        </div>
    </div>
    <div class="form-row">
        <div class="form-group col-md-6">
            <label for="qty">Description:</label>
            <input type="text" class="form-control" id="p_desc" name="p_desc" value="<?php echo $description; ?>" required>
        </div>
        <div class="form-group col-md-6">
            <label>Configuration:</label>
            <select id="macauhinh" name="macauhinh" class="form-control" onchange="loadConfiguration()">
                <option disabled selected>Select configuration</option>
                <?php
                $sql = "SELECT * FROM cauhinh";
                $result = $conn->query($sql);
                if ($result->num_rows > 0) {
                    while ($row = $result->fetch_assoc()) {
                        $selected = ($row['MACAUHINH'] == $configuration) ? "selected" : "";
                        echo "<option value='" . $row['MACAUHINH'] . "' $selected>" . $row['MACAUHINH'] . "</option>";
                    }
                }
                ?>
            </select>
        </div>
    </div>
    <div id="config-info" class="form-row">
        <div class="form-group col-md-6">
            <label for="cpu">CPU:</label>
            <input type="text" class="form-control" id="cpu" name="cpu" value="" required readonly>
        </div>
        <div class="form-group col-md-6">
            <label for="ram">RAM (GB):</label>
            <input type="text" class="form-control" id="ram" name="ram" value="" required readonly>
        </div>
        <div class="form-group col-md-6">
            <label for="ocung">Storage (GB):</label>
            <input type="text" class="form-control" id="ocung" name="ocung" value="" required readonly>
        </div>
        <div class="form-group col-md-6">
            <label for="cardmh">Graphics Card:</label>
            <input type="text" class="form-control" id="cardmh" name="cardmh" value="" required readonly>
        </div>
        <div class="form-group col-md-6">
            <label for="trongluong">Weight (kg):</label>
            <input type="number" class="form-control" id="trongluong" name="trongluong" step="0.1" value="" required readonly>
        </div>
    </div>
    <div class="form-row">
        <div class="form-group col-md-6">
            <label for="mansx">Manufacturer:</label>
            <select class="form-control" id="mansx" name="mansx" required>
                <option disabled selected>Select Manufacturer</option>
                <?php
                $sql = "SELECT * FROM nhasx";
                $result = $conn->query($sql);
                if ($result->num_rows > 0) {
                    while($row = $result->fetch_assoc()){
                        $selected = ($row['MANSX'] == $manufacturer) ? "selected" : "";
                        echo "<option value='".$row['MANSX']."' $selected>".$row['TENNSX']."</option>";
                    }
                }
                ?>
            </select>
        </div>
        <div class="form-group col-md-6">
            <label for="mahang">Brand:</label>
            <select class="form-control" id="mahang" name="mahang" required>
                <option disabled selected>Select Brand</option>
                <?php
                $sql = "SELECT * FROM hangmay";
                $result = $conn->query($sql);
                if ($result->num_rows > 0) {
                    while($row = $result->fetch_assoc()){
                        $selected = ($row['MAHANG'] == $brand) ? "selected" : "";
                        echo "<option value='".$row['MAHANG']."' $selected>".$row['TENHANG']."</option>";
                    }
                }
                ?>
            </select>
        </div>
    </div>
    <div class="form-row">
        <div class="form-group col-md-6">
            <label for="matinhtrang">Status:</label>
            <select class="form-control" id="matinhtrang" name="matinhtrang" required>
                <option disabled selected>Select Status</option>
                <?php
                $sql = "SELECT * FROM tinhtrangmay";
                $result = $conn->query($sql);
                if ($result->num_rows > 0) {
                    while($row = $result->fetch_assoc()){
                        $selected = ($row['MATINHTRANG'] == $status) ? "selected" : "";
                        echo "<option value='".$row['MATINHTRANG']."' $selected>".$row['TENTINHTRANG']."</option>";
                    }
                }
                ?>
            </select>
        </div>
        <!-- Uncomment this block for the Image upload feature -->
        <!--
        <div class="form-group col-md-6">
            <label for="file">Image:</label>
            <input type="file" class="form-control" id="file" name="file" value="<?php echo $product->getImage(); ?>">
        </div>
        -->
    </div>
    <button type="submit" class="btn btn-primary">Save</button>
</form>

    </div>

</body>

</html>
<script>
 function loadConfiguration() {
    var macauhinh = document.getElementById('macauhinh').value;
    if (macauhinh) {
        console.log("Fetching data for MACAUHINH: " + macauhinh);

        fetch('http://localhost/Web_LapTop/Admin/controller/get_configuration.php?macauhinh=' + macauhinh)
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
</script>

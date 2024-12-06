<?php
// Include file kết nối
include_once "../config/dbconnect.php";

// Lấy danh sách nhà cung cấp
$suppliers = $conn->query("SELECT * FROM nhacungcap");

// Lấy danh sách sản phẩm
$products = $conn->query("SELECT * FROM laptop");

// Xử lý yêu cầu lưu đơn nhập
if ($_SERVER['REQUEST_METHOD'] === 'POST') {
    $maphieu = $_POST['maphieu'];
    $manv = $_POST['manv'];
    $mancc = $_POST['mancc'];
    $ngaylap = $_POST['ngaylap'];
    $tinhtrang = $_POST['tinhtrang'];
    $details = json_decode($_POST['details'], true); // Danh sách chi tiết đơn hàng

    // Lưu vào bảng phieunhaphang
    $sql_order = "INSERT INTO phieunhaphang (MAPHIEU, MANV, MANCC, NGAYLAP, TINHTRANG)
                  VALUES ('$maphieu', '$manv', '$mancc', '$ngaylap', '$tinhtrang')";
    $conn->query($sql_order);

    // Lưu vào bảng chitietnhaphang
    foreach ($details as $detail) {
        $malap = $detail['malap'];
        $soluong = $detail['soluong'];
        $dongia = $detail['dongia'];
        $sql_detail = "INSERT INTO chitietnhaphang (MAPHIEU, MALAP, SOLUONG, DONGIA)
                       VALUES ('$maphieu', '$malap', '$soluong', '$dongia')";
        $conn->query($sql_detail);
    }

    echo "Order added successfully!";
    exit;
}
?>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Add Order</title>
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script>
// Lắng nghe sự kiện submit của form
document.getElementById("orderForm").addEventListener("submit", saveOrder);

// Hàm saveOrder
function saveOrder(event) {
    event.preventDefault(); // Ngăn form gửi dữ liệu ngay lập tức

    const orderDetails = document.getElementById("detailsInput").value;
    const totalPrice = document.getElementById("totalPrice").value;
    const supplierId = document.getElementById("supplierSelect").value;
    const supplierCode = document.getElementById("supplierCode").value;
    const employeeId = document.getElementById("employeeId").value; // Mã nhân viên
    const orderDate = new Date().toISOString().split('T')[0]; // Ngày tạo đơn (yyyy-mm-dd)
    const orderStatus = "Đã hoàn thành"; // Trạng thái đơn hàng

    // Kiểm tra dữ liệu
    if (!orderDetails || orderDetails === "[]") {
        alert("Please add at least one product to the order.");
        return;
    }

    if (parseFloat(totalPrice) <= 0) {
        alert("Total price must be greater than 0.");
        return;
    }

    // Dữ liệu gửi tới server
    const orderData = {
        manv: employeeId,
        mancc: supplierId,
        ngaylap: orderDate,
        tinhtrang: orderStatus,
        details: JSON.parse(orderDetails), // Chuyển đổi JSON
        tongtien: totalPrice
    };

    // Gửi dữ liệu tới PHP thông qua AJAX
    $.ajax({
        url: 'save_order.php', // Đường dẫn đến file PHP
        type: 'POST',
        contentType: 'application/json', // Gửi dưới dạng JSON
        data: JSON.stringify(orderData), // Chuyển đối tượng thành JSON
        success: function(response) {
            alert("Order saved successfully!");
            console.log(response);
        },
        error: function(xhr, status, error) {
            alert("Error saving order: " + xhr.responseText);
            console.error(error);
        }
    });
}
</script>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f4f7fc;
            margin: 0;
            padding: 0;
        }

        h2 {
            text-align: center;
            margin-top: 30px;
            color: #333;
        }

        form {
            width: 80%;
            max-width: 900px;
            margin: 0 auto;
            background-color: #fff;
            padding: 20px;
            border-radius: 8px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
        }

        label {
            font-size: 16px;
            font-weight: bold;
            margin-bottom: 6px;
            display: inline-block;
        }

        input, select {
            width: 100%;
            padding: 10px;
            margin: 8px 0 20px 0;
            border-radius: 5px;
            border: 1px solid #ddd;
            font-size: 14px;
            background-color: #fafafa;
        }

        input[type="date"] {
            width: auto;
            display: inline-block;
        }

        input[readonly] {
            background-color: #f1f1f1;
        }

        button {
            padding: 12px 20px;
            background-color: #4CAF50;
            color: white;
            font-size: 16px;
            border: none;
            border-radius: 5px;
            cursor: pointer;
            transition: background-color 0.3s ease;
        }

        button:hover {
            background-color: #45a049;
        }

        table {
            width: 100%;
            border-collapse: collapse;
            margin-bottom: 20px;
        }

        table, th, td {
            border: 1px solid #ddd;
        }

        th, td {
            padding: 12px;
            text-align: left;
        }

        th {
            background-color: #f4f4f4;
        }

        td {
            background-color: #fff;
        }

        td button {
            padding: 6px 12px;
            background-color: #e74c3c;
            color: white;
            border: none;
            border-radius: 5px;
            cursor: pointer;
        }

        td button:hover {
            background-color: #c0392b;
        }

        #laptopInfo {
            margin-top: 20px;
            background-color: #f9f9f9;
            padding: 20px;
            border-radius: 5px;
            box-shadow: 0 2px 5px rgba(0, 0, 0, 0.1);
        }

        #laptopInfo p {
            margin: 5px 0;
        }

        #laptopInfo img {
            display: block;
            margin-top: 15px;
            max-width: 100%;
            border-radius: 8px;
        }

        .form-group {
            display: flex;
            justify-content: space-between;
            align-items: center;
        }

        .form-group label {
            width: 30%;
        }

        .form-group input, .form-group select {
            width: 65%;
        }

        .form-footer {
            text-align: center;
            margin-top: 30px;
        }
    </style>
</head>
<body>
    <h2>Add New Order</h2>
    <form id="orderForm">
        <!-- Mã phiếu nhập 
        <label>Order Code:</label>
        <input type="text" name="maphieu" required><br>

        Mã nhân viên 
        <label>Employee Code:</label>
        <input type="text" name="manv" required><br> -->

        <!-- Nhà cung cấp -->
        <label>Supplier:</label>
        <select name="mancc" id="supplierSelect" onchange="loadSupplierInfo()">
            <option value="">-- Select Supplier --</option>
            <?php while ($row = $suppliers->fetch_assoc()) { ?>
                <option value="<?= $row['MANCC'] ?>"><?= $row['TENNCC'] ?></option>
            <?php } ?>
        </select><br>

       <!-- Thông tin nhà cung cấp -->
        <label>Supplier Code:</label>
        <input type="text" id="supplierCode" disabled><br>

        <label>Address:</label>
        <input type="text" id="supplierAddress" disabled><br>

        <label>Phone:</label>
        <input type="text" id="supplierPhone" disabled><br>

        <label>Email:</label>
        <input type="text" id="supplierEmail" disabled><br>


        <!-- Tình trạng -->
        <label>Status:</label>
        <input type="text" name="tinhtrang"><br>

        <label>Choose Laptop:</label>
        <select name="malap" id="laptopSelect" onchange="loadLaptopInfo()">
            <option value="">-- Select Laptop --</option>
            <?php
            // Lấy danh sách laptop từ database
            $laptops = $conn->query("SELECT MALAP, TENLAP FROM laptop");
            while ($row = $laptops->fetch_assoc()) { ?>
                <option value="<?= $row['MALAP'] ?>"><?= $row['TENLAP'] ?></option>
            <?php } ?>
        </select>

        <div id="laptopInfo">
            <p><strong>Laptop Code:</strong> <span id="laptopCode"></span></p>
            <p><strong>Name:</strong> <span id="laptopName"></span></p>
            <p><strong>Price:</strong> <span id="laptopPrice"></span></p>
            <p><strong>Stock:</strong> <span id="laptopStock"></span></p>
            <img id="laptopImage" src="" alt="Laptop Image" style="max-width: 200px;">
        </div>



       <!-- Danh sách sản phẩm -->
       <h3>Order Details</h3>
        <table id="detailsTable">
            <thead>
                <tr>
                    <th>Product Code</th>
                    <th>Quantity</th>
                    <th>Unit Price</th>
                    <th>Total</th>
                    <th>Actions</th>
                </tr>
            </thead>
            <tbody></tbody>
        </table>
        <button type="button" onclick="addDetail()">Add Product</button><br>

        <!-- Dữ liệu chi tiết -->
        <input type="hidden" name="details" id="detailsInput">
        <label>Total Price:</label>
        <input type="text" id="totalPrice" readonly><br>
        <button type="submit">Save Order</button>

    </form>

    <script>
        const details = [];


// Hàm thêm sản phẩm
function addDetail() {
    const productCode = document.getElementById("laptopSelect").value;
    const quantity = parseInt(prompt("Enter Quantity:"));
    const unitPrice = parseFloat(document.getElementById("laptopPrice").innerText.replace("$", ""));
    const totalPrice = quantity * unitPrice;

    // Kiểm tra xem mã sản phẩm đã có trong đơn hàng chưa
    const existingProduct = details.find(detail => detail.malap === productCode);

    if (existingProduct) {
        alert("Product already exists in the order!");
    } else {
        details.push({ malap: productCode, soluong: quantity, dongia: unitPrice, total: totalPrice });
        renderDetails();
    }
}


/// Render danh sách chi tiết
function renderDetails() {
    const tbody = document.querySelector("#detailsTable tbody");
    tbody.innerHTML = "";
    let sumTotal = 0;

    details.forEach((detail, index) => {
        tbody.innerHTML += `
            <tr>
                <td>${detail.malap}</td>
                <td>${detail.soluong}</td>
                <td>${detail.dongia.toFixed(2)}</td>
                <td>${detail.total.toFixed(2)}</td>
                <td>
                    <button onclick="removeDetail(${index})">Remove</button>
                    <button onclick="updateQuantity(${index})">Update</button>
                </td>
            </tr>`;
        sumTotal += detail.total;
    });

    document.getElementById("detailsInput").value = JSON.stringify(details);
    document.getElementById("totalPrice").value = sumTotal.toFixed(2);
}

// Hàm cập nhật số lượng
function updateQuantity(index) {
    const newQuantity = prompt("Enter new quantity:");
    
    if (newQuantity && !isNaN(newQuantity) && newQuantity > 0) {
        details[index].soluong = parseInt(newQuantity);
        details[index].total = details[index].soluong * details[index].dongia;
        renderDetails();  // Cập nhật lại bảng sau khi thay đổi số lượng
    } else {
        alert("Please enter a valid quantity.");
    }
}

// Hàm xóa chi tiết đơn hàng
function removeDetail(index) {
    details.splice(index, 1);  // Xóa chi tiết
    renderDetails();  // Cập nhật lại bảng
}

        // Lấy thông tin nhà cung cấp
        function loadSupplierInfo() {
    const supplierId = document.getElementById("supplierSelect").value;
    if (supplierId) {
        $.get(`get_supplier_info.php?mancc=${supplierId}`, function (data) {
            const supplier = JSON.parse(data);
            if (supplier) {
                document.getElementById("supplierCode").value = supplier.MANCC || "";
                document.getElementById("supplierAddress").value = supplier.DIACHI || "";
                document.getElementById("supplierPhone").value = supplier.DIENTHOAI || "";
                document.getElementById("supplierEmail").value = supplier.EMAIL || "";
            }
        }).fail(function () {
            alert("Error loading supplier information.");
        });
    } else {
        document.getElementById("supplierCode").value = "";
        document.getElementById("supplierAddress").value = "";
        document.getElementById("supplierPhone").value = "";
        document.getElementById("supplierEmail").value = "";
    }
}


        function loadLaptopInfo() {
    const laptopId = document.getElementById("laptopSelect").value;

    if (laptopId) {
        $.get(`get_laptop_info.php?malap=${laptopId}`, function(data) {
            const laptop = JSON.parse(data);

            if (laptop) {
                document.getElementById("laptopCode").innerText = laptop.MALAP || "N/A";
                document.getElementById("laptopName").innerText = laptop.TENLAP || "N/A";
                document.getElementById("laptopPrice").innerText = laptop.GIABAN ? `$${laptop.GIABAN}` : "N/A";
                document.getElementById("laptopStock").innerText = laptop.SOLUONGTON || "N/A";
                document.getElementById("laptopImage").src = laptop.ANHBIA || "default-image.jpg";
            }
        }).fail(function() {
            alert("Error loading laptop information.");
        });
    } else {
        // Reset thông tin nếu không chọn laptop
        document.getElementById("laptopCode").innerText = "";
        document.getElementById("laptopName").innerText = "";
        document.getElementById("laptopPrice").innerText = "";
        document.getElementById("laptopStock").innerText = "";
        document.getElementById("laptopImage").src = "";
    }
}
// Lắng nghe sự kiện submit của form
document.getElementById("orderForm").addEventListener("submit", saveOrder);

// Hàm saveOrder
function saveOrder(event) {
    event.preventDefault(); // Ngăn form gửi dữ liệu ngay lập tức

    const orderDetails = document.getElementById("detailsInput").value;
    const totalPrice = document.getElementById("totalPrice").value;
    const supplierId = document.getElementById("supplierSelect").value;
    const supplierCode = document.getElementById("supplierCode").value;
    const employeeId = document.getElementById("employeeId").value; // Mã nhân viên
    const orderDate = new Date().toISOString().split('T')[0]; // Ngày tạo đơn (yyyy-mm-dd)
    const orderStatus = "Đã hoàn thành"; // Trạng thái đơn hàng

    // Kiểm tra dữ liệu
    if (!orderDetails || orderDetails === "[]") {
        alert("Please add at least one product to the order.");
        return;
    }

    if (parseFloat(totalPrice) <= 0) {
        alert("Total price must be greater than 0.");
        return;
    }

    // Dữ liệu gửi tới server
    const orderData = {
        manv: employeeId,
        mancc: supplierId,
        ngaylap: orderDate,
        tinhtrang: orderStatus,
        details: JSON.parse(orderDetails), // Chuyển đổi JSON
        tongtien: totalPrice
    };

    // Gửi dữ liệu tới PHP thông qua AJAX
    $.ajax({
        url: 'save_order.php', // Đường dẫn đến file PHP
        type: 'POST',
        contentType: 'application/json', // Gửi dưới dạng JSON
        data: JSON.stringify(orderData), // Chuyển đối tượng thành JSON
        success: function(response) {
            alert("Order saved successfully!");
            console.log(response);
        },
        error: function(xhr, status, error) {
            alert("Error saving order: " + xhr.responseText);
            console.error(error);
        }
    });
}



    </script>
   
</body>
</html>

<?php
// Kết nối cơ sở dữ liệu
include_once "../config/dbconnect.php";

// Lấy mã phiếu nhập từ URL
$order_id = $_GET['order_id'];

// Truy vấn thông tin đơn nhập
$sql = "SELECT phieunhaphang.MAPHIEU, phieunhaphang.NGAYLAP, phieunhaphang.TONGTIEN, phieunhaphang.TINHTRANG,
               nhanvien.HOTEN AS employee_name, nhacungcap.TENNCC AS supplier_name, nhacungcap.DIACHI AS supplier_address, nhacungcap.DIENTHOAI AS supplier_phone, nhacungcap.EMAIL AS supplier_email
        FROM phieunhaphang
        JOIN nhanvien ON phieunhaphang.MANV = nhanvien.MANV
        JOIN nhacungcap ON phieunhaphang.MANCC = nhacungcap.MANCC
        WHERE phieunhaphang.MAPHIEU = '$order_id'";

$result = $conn->query($sql);
$order = $result->fetch_assoc();

// Truy vấn chi tiết đơn nhập
$sql_details = "SELECT chitietnhaphang.MALAP, chitietnhaphang.SOLUONG, chitietnhaphang.DONGIA, laptop.MALAP AS product_code
                FROM chitietnhaphang
                JOIN laptop ON chitietnhaphang.MALAP = laptop.MALAP
                WHERE chitietnhaphang.MAPHIEU = '$order_id'";
$result_details = $conn->query($sql_details);
?>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Order Details</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-KyZXEJp3QhqLMpG8r+Knujs3+PYrK1m1U5bNxqH1F9gYyX7fpMbFiGFQe3r7h1n4" crossorigin="anonymous">
    <style>
        body {
            background-color: #f8f9fa;
        }
        .container {
            margin-top: 50px;
        }
        .section-title {
            font-size: 1.5rem;
            color: #495057;
            border-bottom: 2px solid #343a40;
            padding-bottom: 10px;
            margin-bottom: 20px;
        }
        .order-info, .employee-info, .supplier-info {
            background-color: #fff;
            border: 1px solid #ddd;
            border-radius: 8px;
            padding: 20px;
            margin-bottom: 20px;
        }
        .table th, .table td {
            vertical-align: middle;
        }
        .total-price {
            font-weight: bold;
        }
        .btn-secondary {
            background-color: #6c757d;
            border-color: #6c757d;
        }
        .btn-secondary:hover {
            background-color: #5a6268;
            border-color: #545b62;
        }
    </style>
</head>
<body>

    <div class="container">
        <h2 class="text-center mb-5">Đơn Nhập</h2>

        <!-- Thông tin đơn nhập -->
        <div class="order-info">
            <h4 class="section-title">Thông Tin Đơn Nhập</h4>
            <p><strong>Order Code:</strong> <?= $order['MAPHIEU'] ?></p>
            <p><strong>Order Date:</strong> <?= $order['NGAYLAP'] ?></p>
            <p><strong>Total Price:</strong> <?= number_format($order['TONGTIEN'], 2) ?> VND</p>
            <p><strong>Status:</strong> <?= $order['TINHTRANG'] ?></p>
        </div>

        <!-- Thông tin nhân viên -->
        <div class="employee-info">
            <h4 class="section-title">Nhân Viên Lập Phiếu</h4>
            <p><strong>Employee Name:</strong> <?= $order['employee_name'] ?></p>
        </div>

        <!-- Thông tin nhà cung cấp -->
        <div class="supplier-info">
            <h4 class="section-title">Thông Tin Nhà Cung Cấp</h4>
            <p><strong>Supplier Name:</strong> <?= $order['supplier_name'] ?></p>
            <p><strong>Address:</strong> <?= $order['supplier_address'] ?></p>
            <p><strong>Phone:</strong> <?= $order['supplier_phone'] ?></p>
            <p><strong>Email:</strong> <?= $order['supplier_email'] ?></p>
        </div>

        <!-- Chi tiết đơn nhập -->
        <h4 class="section-title">Chi Tiết Đơn Nhập</h4>
        <table class="table table-striped table-bordered">
            <thead>
                <tr>
                    <th>Product Code</th>
                    <th>Quantity</th>
                    <th>Unit Price</th>
                    <th>Total Price</th>
                </tr>
            </thead>
            <tbody>
                <?php
                if ($result_details->num_rows > 0) {
                    while ($row = $result_details->fetch_assoc()) {
                        echo "<tr>";
                        echo "<td>" . $row['product_code'] . "</td>";
                        echo "<td>" . $row['SOLUONG'] . "</td>";
                        echo "<td>" . number_format($row['DONGIA'], 2) . " VND</td>";
                        echo "<td class='total-price'>" . number_format($row['SOLUONG'] * $row['DONGIA'], 2) . " VND</td>";
                        echo "</tr>";
                    }
                } else {
                    echo "<tr><td colspan='4' class='text-center'>No order details found.</td></tr>";
                }
                ?>
            </tbody>
        </table>

        <!-- Nút quay lại -->
        <div class="text-center">
            <a href="orders.php" class="btn btn-secondary btn-lg">Back to Orders</a>
        </div>
    </div>

    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/js/bootstrap.bundle.min.js" integrity="sha384-pzjw8f+ua7Kw1TIq0Wjxtpsczq5ea+8vabdoT2bTLw8fyKN8PdzBh6rFmnxtfD5V" crossorigin="anonymous"></script>
</body>
</html>

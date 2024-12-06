<?php
include '../config/dbconnect.php'; // Kết nối cơ sở dữ liệu
include('Product.php'); // Bao gồm lớp Product

// Nhận MALAP từ URL
if (isset($_GET['MALAP'])) {
    $productId = $_GET['MALAP'];

    // Tạo đối tượng Product
    $product = new Product($conn);
    $product->setProductId($productId);
    $product->getProduct2();

    // Hiển thị thông tin sản phẩm
    echo "<div style='text-align: center; margin: 20px;'>"; // Div căn giữa
    echo "<h1>Thông tin sản phẩm</h1>";
    echo "<img src='/Web_LapTop/Admin/assets/images/" . $product->getImage() . "' alt='Ảnh sản phẩm' style='max-width: 200px; max-height: 200px; margin-bottom: 20px;'/>";
    echo "<p><strong>Tên sản phẩm:</strong> " . $product->getProductName() . "</p>";
    echo "<p><strong>Giá bán:</strong> " . number_format($product->getPrice(), 2) . " VND</p>";
    echo "<p><strong>Mô tả:</strong> " . $product->getDescription() . "</p>";
     // Hiển thị số lượng tồn kho
     echo "<p><strong>Số lượng tồn kho:</strong> " . $product->getTotal() . "</p>";

    echo "<h2>Thông tin cấu hình</h2>";
    echo "<p><strong>CPU:</strong> " . $product->getCpu() . "</p>";
    echo "<p><strong>RAM:</strong> " . $product->getRam() . "</p>";
    echo "<p><strong>Ổ cứng:</strong> " . $product->getStorage() . "</p>";
    echo "<p><strong>Card màn hình:</strong> " . $product->getGpu() . "</p>";
    echo "<p><strong>Trọng lượng:</strong> " . $product->getWeight() . " kg</p>";
    echo "</div>";
} else {
    echo "<p style='text-align: center;'>Không có sản phẩm được chọn!</p>";
}
?>

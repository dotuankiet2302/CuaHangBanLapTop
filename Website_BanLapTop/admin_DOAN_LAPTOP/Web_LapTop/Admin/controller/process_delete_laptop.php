<?php
include '../config/dbconnect.php'; // Kết nối cơ sở dữ liệu

// Kiểm tra xem có gửi MALAP không
if (isset($_POST['malap'])) {
    $malap = $_POST['malap'];

    // Câu lệnh xóa item theo MALAP
    $sql = "DELETE FROM laptop WHERE MALAP = '$malap'";

    if ($conn->query($sql) === TRUE) {
        echo "Laptop item deleted successfully!";
    } else {
        echo "Error: " . $sql . "<br>" . $conn->error;
    }
} else {
    echo "No laptop ID provided!";
}
?>

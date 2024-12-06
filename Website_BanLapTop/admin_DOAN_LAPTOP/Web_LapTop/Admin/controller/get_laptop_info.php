<?php
// Include file kết nối
include_once "../config/dbconnect.php";

if (isset($_GET['malap'])) {
    $malap = $_GET['malap'];

    // Truy vấn thông tin laptop
    $sql = "SELECT MALAP, TENLAP, GIABAN, ANHBIA, SOLUONGTON FROM laptop WHERE MALAP = '$malap'";
    $result = $conn->query($sql);

    if ($result->num_rows > 0) {
        $laptop = $result->fetch_assoc();
        echo json_encode($laptop); // Trả về dữ liệu JSON
    } else {
        echo json_encode([]);
    }
} else {
    echo json_encode([]);
}
?>

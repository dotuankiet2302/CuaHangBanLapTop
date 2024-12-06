<?php
include_once "../config/dbconnect.php";

if (isset($_GET['mancc'])) {
    $mancc = $_GET['mancc'];
    $query = $conn->query("SELECT * FROM nhacungcap WHERE MANCC = '$mancc'");
    if ($query->num_rows > 0) {
        $supplier = $query->fetch_assoc();
        echo json_encode($supplier);
    } else {
        echo json_encode([]);
    }
}
?>

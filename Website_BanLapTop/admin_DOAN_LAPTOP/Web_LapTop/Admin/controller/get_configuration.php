<?php
include '../config/dbconnect.php';

if (isset($_GET['macauhinh'])) {
    $macauhinh = $_GET['macauhinh'];

    $sql = "SELECT * FROM cauhinh WHERE MACAUHINH = ?";
    if ($stmt = $conn->prepare($sql)) {
        $stmt->bind_param('s', $macauhinh);
        $stmt->execute();
        $result = $stmt->get_result();

        if ($result->num_rows > 0) {
            $row = $result->fetch_assoc();
            echo json_encode($row);
        } else {
            echo json_encode([]);
        }
        
        $stmt->close();
    } else {
        echo json_encode(['error' => 'SQL prepare failed']);
    }
}
?>

<?php
$servername = "DESKTOP-2K7AEF7\SQLEXPRESS01"; 
$username = "sa"; 
$password = "123456789"; 
$dbname = "doan_laptop"; 
$port = "1433"; 

try {
    $conn = new PDO("sqlsrv:Server=$servername,$port;Database=$dbname", $username, $password);
    $conn->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);

} catch(PDOException $e) {
    echo json_encode(["error" => "Connection failed: " . $e->getMessage()]);
    exit; 
}
// $servername = "localhost";
// $username = "root";
// $password = "";
// $dbname = "doan_laptop";

// try {
//     $conn = new PDO("mysql:host=$servername;dbname=$dbname", $username, $password);
//     $conn->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
// } catch(PDOException $e) {
//     echo "Connection failed: " . $e->getMessage();
// }
?>

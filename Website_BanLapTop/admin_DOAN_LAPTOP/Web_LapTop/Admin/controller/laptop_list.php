<?php 
include_once "../config/dbconnect.php";

// Truy vấn tất cả laptop
$sql = "SELECT laptop.*, hangmay.TENHANG, nhasx.TENNSX, tinhtrangmay.TENTINHTRANG 
        FROM laptop
        JOIN hangmay ON laptop.MAHANG = hangmay.MAHANG
        JOIN nhasx ON laptop.MANSX = nhasx.MANSX
        JOIN tinhtrangmay ON laptop.MATINHTRANG = tinhtrangmay.MATINHTRANG";
$result = $conn->query($sql);

$count = 1;

if ($result->num_rows > 0) {
    while ($row = $result->fetch_assoc()) {
        echo "<tr>";
        echo "<td class='text-center'>" . $count . "</td>";
        echo "<td><img height='100px' src='" . $row["ANHBIA"] . "' alt='Laptop Image'></td>";
        echo "<td class='text-center'>" . htmlspecialchars($row["TENLAP"]) . "</td>";
        echo "<td class='text-center'>" . htmlspecialchars($row["TENHANG"]) . "</td>";
        echo "<td class='text-center'>CPU: " . htmlspecialchars($row["CPU"]) . ", RAM: " . htmlspecialchars($row["RAM"]) . "GB, Ổ cứng: " . htmlspecialchars($row["OCUNG"]) . ", Card MH: " . htmlspecialchars($row["CARDMH"]) . "</td>";
        echo "<td class='text-center'>" . htmlspecialchars($row["TENNSX"]) . "</td>";
        echo "<td class='text-center'>" . htmlspecialchars($row["GIABAN"]) . "</td>";
        echo "<td class='text-center'>" . htmlspecialchars($row["SOLUONGTON"]) . "</td>";
        echo "<td class='text-center'>" . htmlspecialchars($row["TENTINHTRANG"]) . "</td>";
        echo "<td><button class='btn btn-primary' style='height:40px' onclick='itemEditForm(\"" . $row["MALAP"] . "\")'>Edit</button></td>";
        echo "<td><button class='btn btn-danger' style='height:40px' onclick='itemDelete(\"" . $row["MALAP"] . "\")'>Delete</button></td>";
        echo "</tr>";

        $count++;
    }
} else {
    echo '<tr><td colspan="10" class="text-center">No laptops found</td></tr>';
}
?>

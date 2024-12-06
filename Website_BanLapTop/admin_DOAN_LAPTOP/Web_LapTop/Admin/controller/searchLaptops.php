<?php
// Kết nối cơ sở dữ liệu
include_once "../config/dbconnect.php";

// Nhận giá trị tìm kiếm từ request
$search = isset($_GET['search']) ? $_GET['search'] : '';

// Truy vấn tìm kiếm gần đúng tên laptop
$sql = "
    SELECT 
        laptop.*, 
        hangmay.TENHANG, 
        nhasx.TENNSX, 
        tinhtrangmay.TENTINHTRANG, 
        cauhinh.CPU, 
        cauhinh.RAM, 
        cauhinh.OCUNG, 
        cauhinh.CARDMH, 
        cauhinh.TRONGLUONG
    FROM 
        laptop
    JOIN 
        hangmay ON laptop.MAHANG = hangmay.MAHANG
    JOIN 
        nhasx ON laptop.MANSX = nhasx.MANSX
    JOIN 
        tinhtrangmay ON laptop.MATINHTRANG = tinhtrangmay.MATINHTRANG
    JOIN 
        cauhinh ON laptop.MACAUHINH = cauhinh.MACAUHINH
    WHERE 
        laptop.TENLAP LIKE '%" . $conn->real_escape_string($search) . "%'
";

// Thực thi truy vấn
$result = $conn->query($sql);

// Kiểm tra kết quả
$count = 1;
if ($result->num_rows > 0) {
    while ($row = $result->fetch_assoc()) {
        ?>
        <tr id="row-<?=$row['MALAP']?>">
            <td class="text-center"><?=$count?></td>
            <td><img height='100px' src='/Web_LapTop/Admin/assets/images/<?=$row["ANHBIA"]?>'></td>
            <td class="text-center"><?=htmlspecialchars($row["TENLAP"])?></td>
            <td class="text-center"><?=htmlspecialchars($row["TENHANG"])?></td>
            <td class="text-center">
                CPU: <?=htmlspecialchars($row["CPU"])?>, 
                RAM: <?=htmlspecialchars($row["RAM"])?>GB, 
                Ổ cứng: <?=htmlspecialchars($row["OCUNG"])?>, 
                Card MH: <?=htmlspecialchars($row["CARDMH"])?>, 
                Trọng lượng: <?=htmlspecialchars($row["TRONGLUONG"])?>kg
            </td>
            <td class="text-center"><?=htmlspecialchars($row["TENNSX"])?></td>
            <td class="text-center"><?=htmlspecialchars($row["GIABAN"])?></td>
            <td class="text-center"><?=htmlspecialchars($row["SOLUONGTON"])?></td>
            <td class="text-center"><?=htmlspecialchars($row["TENTINHTRANG"])?></td>
            <td><button class="btn btn-primary" style="height:40px" onclick="itemEditForm('<?=$row['MALAP']?>')">Edit</button></td>
            <td><button class="btn btn-danger" style="height:40px" onclick="itemDelete('<?=$row['MALAP']?>')">Delete</button></td>
            <td><button class="btn" style="height:40px; background-color: #ffcc00; color: white; border: none;" onclick="itemDetail('<?=$row['MALAP']?>')">Detail</button></td>
        </tr>
        <?php
        $count++;
    }
} else {
    echo '<tr><td colspan="10" class="text-center">No laptops found</td></tr>';
}
?>

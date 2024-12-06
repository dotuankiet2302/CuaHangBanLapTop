<!DOCTYPE html>
<html lang="vi">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Thống Kê Chi Phí Nhập Hàng</title>
    <script src="https://cdn.jsdelivr.net/npm/chart.js"></script>
    <link rel="stylesheet" href="../css/style.css">
</head>
<body>

<h1>Thống Kê Chi Phí Nhập Hàng</h1>

<!-- Form nhập tháng và năm -->
<form method="get" action="controller/thongkechiphinhap.php">
    <label for="month">Tháng: </label>
    <input type="number" name="month" id="month" min="1" max="12" required>
    <label for="year">Năm: </label>
    <input type="number" name="year" id="year" min="2000" required>
    <button type="submit">Xem Thống Kê</button>
</form>

<!-- Hiển thị bảng thống kê chi phí nhập hàng -->
<?php if (isset($data) && !empty($data)) { ?>
    <h2>Bảng Thống Kê Chi Phí Nhập Hàng</h2>
    <table border="1">
        <tr>
            <th>Năm</th>
            <th>Tháng</th>
            <th>Chi Phí Nhập</th>
        </tr>
        <?php foreach ($data as $row) { ?>
            <tr>
                <td><?php echo $row['Year']; ?></td>
                <td><?php echo $row['Month']; ?></td>
                <td><?php echo number_format($row['ChiPhiNhap'], 0, ',', '.'); ?> VND</td>
            </tr>
        <?php } ?>
    </table>

    <!-- Biểu đồ hiển thị chi phí nhập hàng -->
    <canvas id="lineChart" width="600" height="300"></canvas>

    <script>
    var ctx = document.getElementById('lineChart').getContext('2d');
    var chart = new Chart(ctx, {
        type: 'line',  // Loại biểu đồ là Line Chart
        data: {
            labels: <?php echo json_encode(array_column($data, 'Month')); ?>,  // Các tháng
            datasets: [{
                label: 'Chi Phí Nhập Hàng',
                data: <?php echo json_encode(array_column($data, 'ChiPhiNhap')); ?>,  // Dữ liệu chi phí
                borderColor: 'rgba(75, 192, 192, 1)',
                fill: false,
                tension: 0.1
            }]
        },
        options: {
            responsive: true,
            scales: {
                y: {
                    beginAtZero: true
                }
            }
        }
    });
    </script>
<?php } ?>

</body>
</html>

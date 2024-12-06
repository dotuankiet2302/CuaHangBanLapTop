<!DOCTYPE html>
<html lang="vi">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Thống Kê Chi Phí Laptop</title>
    <script src="https://cdn.jsdelivr.net/npm/chart.js"></script>
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <link rel="stylesheet" href="../css/style.css">
    <style>
   
    </style>
</head>
<body>

<h1>Thống Kê Chi Phí Đơn Mua Laptop</h1>

<!-- Form nhập tháng và năm -->
<form id="formThongKe">
    <label for="month">Tháng: </label>
    <input type="number" name="month" id="month" min="1" max="12" required>
    <label for="year">Năm: </label>
    <input type="number" name="year" id="year" min="2000" required>
    <button type="submit">Xem Thống Kê</button>
</form>

<!-- Hiển thị bảng dữ liệu -->
<div id="dataTable"></div>

<!-- Biểu đồ hiển thị chi phí mua -->
<canvas id="chart" width="400" height="200"></canvas>

<script>
// Khi người dùng submit form
$('#formThongKe').on('submit', function(event) {
    event.preventDefault(); // Ngừng form reload trang

    var month = $('#month').val();
    var year = $('#year').val();

    // Gửi yêu cầu AJAX để lấy dữ liệu thống kê
    $.ajax({
        url: 'controller/thongke.php',
        type: 'GET',
        data: { month: month, year: year },
        success: function(response) {
            var data = JSON.parse(response); // Chuyển đổi JSON trả về

            if (data.length > 0) {
                var tableHtml = '<table border="1"><tr><th>Mã Hãng</th><th>Hãng Laptop</th><th>Chi Phí Mua</th></tr>';
                
                data.forEach(function(item) {
                    tableHtml += '<tr><td>' + item.MaHang + '</td><td>' + item.HangLaptop + '</td><td>' + item.ChiPhiMua + '</td></tr>';
                });

                tableHtml += '</table>';
                $('#dataTable').html(tableHtml); // Hiển thị bảng dữ liệu

                // Cập nhật biểu đồ
                var ctx = document.getElementById('chart').getContext('2d');
                var chart = new Chart(ctx, {
                    type: 'bar',
                    data: {
                        labels: data.map(function(item) { return item.HangLaptop; }),
                        datasets: [{
                            label: 'Chi Phí Mua',
                            data: data.map(function(item) { return item.ChiPhiMua; }),
                            backgroundColor: 'rgba(54, 162, 235, 0.2)',
                            borderColor: 'rgba(54, 162, 235, 1)',
                            borderWidth: 1
                        }]
                    },
                    options: {
                        scales: {
                            y: {
                                beginAtZero: true
                            }
                        }
                    }
                });
            } else {
                $('#dataTable').html('<p>Không có dữ liệu cho tháng và năm này.</p>');
            }
        }
    });
});
</script>

</body>
</html>

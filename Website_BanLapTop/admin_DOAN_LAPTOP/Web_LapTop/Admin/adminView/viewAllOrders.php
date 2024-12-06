<!DOCTYPE html>
<html lang="vi">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Thống Kê Chi Phí Laptop</title>
    <script src="https://cdn.jsdelivr.net/npm/chart.js"></script>
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    
    <link rel="stylesheet" href="../css/style.css">
</head>
<body>

<h1>Thống Kê Chi Phí Nhập Laptop</h1>

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
        url: 'controller/thongkechiphinhap.php',
        type: 'GET',
        data: { month: month, year: year },
        success: function(response) {
            var data = JSON.parse(response); // Chuyển đổi JSON trả về

            if (data.length > 0) {
                var tableHtml = '<table border="1"><tr><th>Mã Hãng</th><th>Hãng Laptop</th><th>Chi Phí Nhập</th></tr>';
                
                data.forEach(function(item) {
                    tableHtml += '<tr><td>' + item.MaHang + '</td><td>' + item.HangLaptop + '</td><td>' + item.ChiPhiNhap + '</td></tr>';
                });

                tableHtml += '</table>';
                $('#dataTable').html(tableHtml); // Hiển thị bảng dữ liệu

                // Cập nhật biểu đồ đường (Line Chart)
                var ctx = document.getElementById('chart').getContext('2d');
                var chart = new Chart(ctx, {
                    type: 'line', // Thay đổi từ 'bar' thành 'line' để vẽ biểu đồ đường
                    data: {
                        labels: data.map(function(item) { return item.HangLaptop; }), // Các nhãn cho trục X
                        datasets: [{
                            label: 'Chi Phí Nhập', // Tên của dataset
                            data: data.map(function(item) { return item.ChiPhiNhap || 0; }), // Dữ liệu cho trục Y
                            backgroundColor: 'rgba(54, 162, 235, 0.2)', // Màu nền
                            borderColor: 'rgba(54, 162, 235, 1)', // Màu đường
                            borderWidth: 2, // Độ rộng đường viền
                            fill: false // Để không có màu nền bên dưới đường
                        }]
                    },
                    options: {
                        scales: {
                            y: {
                                beginAtZero: true // Bắt đầu trục Y từ 0
                            }
                        }
                    }
                });
            } else {
                $('#dataTable').html('<p>Không có dữ liệu cho tháng và năm này.</p>');
                $('#chart').hide(); // Ẩn biểu đồ nếu không có dữ liệu
            }
        },
        error: function() {
            $('#dataTable').html('<p>Không thể kết nối đến máy chủ. Vui lòng thử lại sau.</p>');
            $('#chart').hide(); // Ẩn biểu đồ nếu có lỗi kết nối
        }
    });
});
</script>

</body>
</html>

<!DOCTYPE html>
<html lang="vi">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Thống Kê Chi Phí Nhập và Chi Phí Bán</title>
    <script src="https://cdn.jsdelivr.net/npm/chart.js"></script>
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <style>
        /* Đặt kích thước cho canvas */
        #chart {
            width: 80%;   /* Chiều rộng của biểu đồ, có thể thay đổi */
            height: 300px; /* Chiều cao của biểu đồ, có thể thay đổi */
            margin: 0 auto; /* Canh giữa biểu đồ */
        }

        /* Thêm một số style cho bảng */
        table {
            width: 100%;
            margin-top: 20px;
            border-collapse: collapse;
        }

        table, th, td {
            border: 1px solid black;
        }

        th, td {
            padding: 10px;
            text-align: center;
        }
    </style>
</head>
<body>

<h1>Thống Kê Chi Phí Nhập và Chi Phí Bán</h1>

<!-- Form để nhập năm -->
<form id="yearForm">
    <label for="year">Chọn năm:</label>
    <input type="number" id="year" name="year" value="<?php echo date('Y'); ?>" min="2000" max="2100">
    <button type="submit">Xem thống kê</button>
</form>

<!-- Biểu đồ đường -->
<canvas id="chart" width="400" height="200"></canvas>

<!-- Bảng hiển thị dữ liệu chi phí nhập và chi phí bán -->
<h3>Bảng Chi Phí Nhập và Chi Phí Bán</h3>
<table id="dataTable" border="1" cellpadding="5" cellspacing="0">
    <thead>
        <tr>
            <th>Tháng</th>
            <th>Chi Phí Nhập</th>
            <th>Chi Phí Bán</th>
        </tr>
    </thead>
    <tbody>
        <!-- Dữ liệu sẽ được thêm vào đây -->
    </tbody>
</table>

<script>
// Gửi yêu cầu AJAX khi form được submit
$('#yearForm').submit(function(e) {
    e.preventDefault(); // Ngừng việc submit form mặc định

    var year = $('#year').val(); // Lấy năm từ input

    // Gửi yêu cầu AJAX tới PHP để lấy dữ liệu chi phí nhập và chi phí bán
    $.ajax({
        url: 'controller/thongkethuchi.php',  // Đường dẫn tới file PHP bạn đã tạo
        type: 'GET',
        data: { year: year }, // Truyền tham số năm vào
        success: function(response) {
            var data = JSON.parse(response); // Chuyển đổi JSON trả về

            // Cập nhật biểu đồ
            var ctx = document.getElementById('chart').getContext('2d');
            var chart = new Chart(ctx, {
                type: 'line', // Chọn biểu đồ đường
                data: {
                    labels: ['Tháng 1', 'Tháng 2', 'Tháng 3', 'Tháng 4', 'Tháng 5', 'Tháng 6', 'Tháng 7', 'Tháng 8', 'Tháng 9', 'Tháng 10', 'Tháng 11', 'Tháng 12'], // Tháng
                    datasets: [{
                        label: 'Chi Phí Nhập (' + data.year + ')',
                        data: data.chiPhiNhap, // Dữ liệu chi phí nhập
                        borderColor: 'rgba(54, 162, 235, 1)', // Màu đường cho chi phí nhập
                        borderWidth: 2,
                        fill: false // Không tô màu dưới đường
                    },
                    {
                        label: 'Chi Phí Bán (' + data.year + ')',
                        data: data.chiPhiBan, // Dữ liệu chi phí bán
                        borderColor: 'rgba(255, 99, 132, 1)', // Màu đường cho chi phí bán
                        borderWidth: 2,
                        fill: false // Không tô màu dưới đường
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

            // Cập nhật bảng chi phí nhập và chi phí bán
            var tableBody = $('#dataTable tbody');
            tableBody.empty(); // Xóa dữ liệu bảng cũ trước khi thêm mới

            // Lặp qua từng tháng và thêm dòng vào bảng
            for (var i = 0; i < 12; i++) {
                var row = `<tr>
                            <td>Tháng ${i + 1}</td>
                            <td>${data.chiPhiNhap[i]}</td>
                            <td>${data.chiPhiBan[i]}</td>
                          </tr>`;
                tableBody.append(row);
            }
        },
        error: function() {
            alert('Có lỗi khi lấy dữ liệu');
        }
    });
});
</script>

</body>
</html>

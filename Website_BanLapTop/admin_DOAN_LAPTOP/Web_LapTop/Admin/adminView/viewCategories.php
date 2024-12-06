<?php 
// viewInformation.php
?>

<!DOCTYPE html>
<html lang="vi">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Thông Tin Admin</title>
    <!-- Link Bootstrap CSS -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/css/bootstrap.min.css" rel="stylesheet">
    <style>
        .profile-image {
            width: 150px;
            height: 150px;
            border-radius: 50%;
            background-color: #ccc;
            background-image: url('admin.jpg'); /* Thay đổi thành hình ảnh thực tế */
            background-size: cover;
            background-position: center;
            margin-right: 30px;
        }

        .card-body {
            font-size: 16px;
        }

        .card-title {
            font-size: 24px;
            font-weight: bold;
            color: #2c3e50;
        }

        .card-subtitle {
            color: #7f8c8d;
        }

        .btn-custom {
            background-color: #3498db;
            color: white;
            border-radius: 5px;
        }

        .btn-custom:hover {
            background-color: #2980b9;
        }
       
    .profile-image {
        width: 120px; /* Đặt kích thước vòng tròn */
        height: 120px; /* Đặt kích thước vòng tròn */
        border-radius: 50%; /* Làm cho phần tử thành hình tròn */
        overflow: hidden; /* Ẩn phần ảnh ngoài hình tròn */
        display: flex;
        justify-content: center; /* Canh giữa ảnh theo chiều ngang */
        align-items: center; /* Canh giữa ảnh theo chiều dọc */
    }

    .profile-image img {
        width: 100%; /* Đảm bảo ảnh chiếm toàn bộ vòng tròn */
        height: 100%;
        object-fit: cover; /* Đảm bảo ảnh không bị méo, cắt bớt nếu cần */
    }

    </style>
</head>
<body>

<div class="container mt-5">
    <div class="row justify-content-center" >
        <div class="col-md-8">
            <div class="card shadow-sm">
                <div class="row no-gutters">
                    <!-- Profile Image -->
                    <div class="col-md-4 d-flex justify-content-center align-items-center">
                        <div class="profile-image">
                            <!-- Sử dụng đường dẫn tương đối từ thư mục gốc của dự án -->
                            <img src="./assets/images/logo.png" alt="Profile Image">
                        </div>
                    </div>

                    <!-- Profile Details -->
                    <div class="col-md-8">
                        <div class="card-body">
                            <h5 class="card-title">Nguyễn Văn An</h5>
                            <h6 class="card-subtitle mb-2">Quản trị viên hệ thống</h6>
                            <p><strong>Địa chỉ:</strong> 140 Lê Trọng Tấn,Tân Phú, TP.HCM</p>
                            <p><strong>Email:</strong> admin@domain.com</p>
                            <p><strong>Số điện thoại:</strong> 0901234567</p>
                            <p><strong>Ngày tham gia:</strong> 01/01/2020</p>

                            <!-- Edit Button -->
                            <a href="editProfile.php" class="btn btn-custom">Chỉnh sửa thông tin</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>

<!-- Link Bootstrap JS & Popper.js -->
<script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.11.6/dist/umd/popper.min.js"></script>
<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/js/bootstrap.min.js"></script>
</body>
</html>

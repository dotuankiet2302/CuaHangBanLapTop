<?php
session_start();
?>

<nav class="navbar navbar-expand-lg navbar-light px-5" style="background-color: #3B3131;">
    <a class="navbar-brand ml-5" href="./index.php">
        <img src="./assets/images/logo.png" width="80" height="80" alt="Swiss Collection">
    </a>
    <ul class="navbar-nav mr-auto mt-2 mt-lg-0"></ul>

   
    <div class="user-cart" style="display: flex; align-items: center;">  
        <?php           
            if (isset($_SESSION['nhanvien']) && isset($_SESSION['nhanvien']['hoTen'])) {
                echo "<span style='color:white; font-size: 20px; margin-right: 1500px;'>Chào, " . $_SESSION['nhanvien']['hoTen'] . "</span>";
            } else {
                // Nếu chưa đăng nhập, hiển thị icon đăng nhập
                echo '<a href="" style="text-decoration:none;">
                        <i class="fa fa-sign-in mr-5" style="font-size:30px; color:#fff;" aria-hidden="true"></i>
                    </a>';
            }
            
        ?>
    </div>
</nav>

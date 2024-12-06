<?php
class Product {
    private $conn;
    private $productId;
    private $productName;
    private $price;
    private $description;
    private $configuration;
    private $manufacturer;
    private $brand;
    private $status;
    private $image;
    private $cpu;
    private $ram;
    private $storage;
    private $gpu;
    private $weight;
    private $stock; // Số lượng tồn kho
    private $reviews = []; // Danh sách đánh giá


    // Constructor để kết nối đến cơ sở dữ liệu
    public function __construct($dbConnection) {
        $this->conn = $dbConnection;
    }

    // Phương thức để thiết lập ID sản phẩm
    public function setProductId($id) {
        $this->productId = $id;
    }

    // Phương thức để lấy thông tin sản phẩm từ cơ sở dữ liệu
    public function getProduct() {
        // Kiểm tra nếu ID sản phẩm đã được thiết lập
        if (isset($this->productId)) {
            // Sửa câu truy vấn SQL để phù hợp với bảng 'laptop'
            $query = "SELECT * FROM laptop WHERE MALAP = ?";
            $stmt = $this->conn->prepare($query);
            
            // Kiểu dữ liệu 'i' cho ID kiểu INT
            $stmt->bind_param("s", $this->productId); // 's' cho kiểu VARCHAR nếu 'MALAP' là VARCHAR
            $stmt->execute();
            $result = $stmt->get_result();
            
            if ($result->num_rows > 0) {
                $product = $result->fetch_assoc();
                // Lấy dữ liệu từ cơ sở dữ liệu và gán cho các thuộc tính
                $this->productId = $product['MALAP'];
                $this->productName = $product['TENLAP'];
                $this->price = $product['GIABAN'];
                $this->description = $product['MOTA'];
                $this->configuration = $product['MACAUHINH'];  // Sửa lại trường cho đúng
                $this->manufacturer = $product['MANSX'];  // Sửa lại trường cho đúng
                $this->brand = $product['MAHANG'];  // Sửa lại trường cho đúng
                $this->status = $product['MATINHTRANG'];  // Sửa lại trường cho đúng
            }
        }
    }
    public function getProduct2() {
        if (isset($this->productId)) {
            $query = "
                SELECT l.MALAP, l.TENLAP, l.GIABAN, l.MOTA, l.MACAUHINH, l.MANSX, l.MAHANG, l.MATINHTRANG, 
                       c.CPU, c.RAM, c.OCUNG, c.CARDMH, c.TRONGLUONG, l.ANHBIA, l.SOLUONGTON,
                       d.SOSAO, d.MOTA AS DANHGIAMOTA
                FROM laptop l
                JOIN cauhinh c ON l.MACAUHINH = c.MACAUHINH
                LEFT JOIN danhgia d ON l.MALAP = d.MALAP
                WHERE l.MALAP = ?";
    
            $stmt = $this->conn->prepare($query);
            $stmt->bind_param("s", $this->productId);
            $stmt->execute();
            $result = $stmt->get_result();
    
            if ($result->num_rows > 0) {
                $product = $result->fetch_assoc();
    
                // Gán các giá trị vào thuộc tính
                $this->productId = $product['MALAP'];
                $this->productName = $product['TENLAP'];
                $this->price = $product['GIABAN'];
                $this->description = $product['MOTA'];
                $this->configuration = $product['MACAUHINH'];
                $this->manufacturer = $product['MANSX'];
                $this->brand = $product['MAHANG'];
                $this->status = $product['MATINHTRANG'];
                $this->cpu = $product['CPU'];
                $this->ram = $product['RAM'];
                $this->storage = $product['OCUNG'];
                $this->gpu = $product['CARDMH'];
                $this->weight = $product['TRONGLUONG'];
                $this->image = $product['ANHBIA'];
                $this->stock = $product['SOLUONGTON']; // Thông tin tồn kho
    
                // Lấy thông tin đánh giá
                $this->reviews[] = [
                    'stars' => $product['SOSAO'],
                    'comment' => $product['DANHGIAMOTA']
                ];
            }
        }
    }
    
    
    

    // Phương thức để cập nhật thông tin sản phẩm
   // Phương thức để cập nhật thông tin sản phẩm
public function updateProduct() {
    // Sửa câu truy vấn SQL và kiểu dữ liệu cho phù hợp với bảng 'laptop'
    $query = "UPDATE laptop SET TENLAP = ?, GIABAN = ?, MOTA = ?, MACAUHINH = ?, MANSX = ?, MAHANG = ?, MATINHTRANG = ? WHERE MALAP = ?";
    $stmt = $this->conn->prepare($query);
    
    // Kiểm tra kiểu dữ liệu của các tham số và bind_param
    // 's' cho string, 'd' cho double, 'i' cho integer (ví dụ cho giá trị số)
    $stmt->bind_param("sdssssss", $this->productName, $this->price, $this->description, $this->configuration, $this->manufacturer, $this->brand, $this->status, $this->productId);
    
    // Thực hiện câu truy vấn và trả về kết quả
    return $stmt->execute();
}


    // Phương thức để set các thông tin sản phẩm
    public function setProductInfo($ma,$name, $price, $desc, $config, $manufacturer, $brand, $status) {
        $this->productId = $ma;
        $this->productName = $name;
        $this->price = $price;
        $this->description = $desc;
        $this->configuration = $config;
        $this->manufacturer = $manufacturer;
        $this->brand = $brand;
        $this->status = $status;
    }
     // Phương thức lấy thông tin chi tiết cấu hình
     private function getConfigurationDetails($configurationId) {
        // Truy vấn thông tin cấu hình
        $query = "SELECT * FROM cauhinh WHERE MACAUHINH = ?";
        $stmt = $this->conn->prepare($query);
        $stmt->bind_param("s", $configurationId); // 's' cho kiểu VARCHAR
        $stmt->execute();
        $result = $stmt->get_result();

        if ($result->num_rows > 0) {
            $config = $result->fetch_assoc();
            $this->cpu = $config['CPU'];
            $this->ram = $config['RAM'];
            $this->storage = $config['OCUNG'];
            $this->gpu = $config['CARDMH'];
            $this->weight = $config['TRONGLUONG'];
        }
    }

    // Getters cho các giá trị của sản phẩm
    public function getProductName() {
        return $this->productName;
    }
    public function getProductID() {
        return $this->productId;
    }
    public function getPrice() {
        return $this->price;
    }

    public function getDescription() {
        return $this->description;
    }

    public function getConfiguration() {
        return $this->configuration;
    }

    public function getManufacturer() {
        return $this->manufacturer;
    }

    public function getBrand() {
        return $this->brand;
    }

    public function getStatus() {
        return $this->status;
    }

    public function getImage() {
        return $this->image;
    }

    // Getters cho các thông số cấu hình
    public function getCpu() {
        return $this->cpu;
    }

    public function getRam() {
        return $this->ram;
    }

    public function getStorage() {
        return $this->storage;
    }

    public function getGpu() {
        return $this->gpu;
    }

    public function getWeight() {
        return $this->weight;
    }
    public function getTotal()
    {
        return $this->stock;
    }
    public function getReviews() {
        return $this->reviews;
    }
    
}
?>
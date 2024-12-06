<?php
class DB {
    private $conn;

    public function __construct($conn) {
        $this->conn = $conn;
    }
   // Phương thức để lấy kết nối PDO
   public function getConn() {
      return $this->conn;
   }
    public function selectQuery($sql, $params = []) {
        $stm = $this->conn->prepare($sql);
        $stm->execute($params);
        return $stm->fetchAll(PDO::FETCH_OBJ);
    }

    public function updateQuery($sql, $params = []) {
        $stm = $this->conn->prepare($sql);
        $stm->execute($params);
        return $stm->rowCount();
    }

    public function prepare($sql) {
        return $this->conn->prepare($sql);
    }
}
?>
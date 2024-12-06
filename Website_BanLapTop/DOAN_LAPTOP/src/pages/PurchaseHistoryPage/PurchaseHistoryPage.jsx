import { Empty, Button, message } from "antd"; // Import Empty từ Ant Design
import { useUser } from "../UserContext/UserContext";
import { useEffect, useState } from "react";
import axios from "axios";
import { useNavigate } from "react-router-dom";
import { Wrapper, Title, Table, Row, Cell, TitleRow, TitleCell, ProductImage } from "./style";
import { ROUTERS } from "../../utils/router";  // Đảm bảo rằng ROUTERS đã được import đúng

const PurchaseHistory = () => {
  const { userInfo } = useUser(); // Lấy thông tin người dùng
  const [purchaseHistory, setPurchaseHistory] = useState([]);
  const navigate = useNavigate();

  useEffect(() => {
    if (userInfo) {
      const fetchPurchaseHistory = async () => {
        try {
          const response = await axios.get(
            `http://localhost:8000/api-purchase-history.php?id=${userInfo.maKH}`
          );
          if (response.data.success) {
            const filteredOrders = response.data.data.filter(
              (order) => order.TINHTRANGGIAO === "ĐÃ NHẬN"
            );
            setPurchaseHistory(filteredOrders);
          } else {
            message.error(response.data.message);
          }
        } catch (error) {
          message.error("Lỗi khi lấy thông tin lịch sử mua hàng.");
        }
      };

      fetchPurchaseHistory();
    }
  }, [userInfo]);

  return (
    <Wrapper>
      <Title style={{ color: "#FFA500" }}>Lịch Sử Mua Hàng</Title>
      <Table>
        {purchaseHistory.length > 0 ? (
          <div>
            <TitleRow>
            <TitleCell>Ngày Giao</TitleCell>
              <TitleCell>Ngày Đặt</TitleCell>
              <TitleCell>Tổng Tiền</TitleCell>
              <TitleCell>Sản Phẩm</TitleCell>
              <TitleCell>Ảnh</TitleCell>
              <TitleCell>Đánh Giá</TitleCell>
            </TitleRow>
            {purchaseHistory.map((order) => (
              <Row key={order.MADH}>
               <Cell>{order.NGAYGIAO}</Cell>
                <Cell>{order.NGAYDAT}</Cell>
                <Cell>{order.TONGTIEN} VND</Cell>
                <Cell>{order.TENLAP}</Cell>
                <Cell>
                  <ProductImage
                    src={require(`../../assets/users/images/featured/${order.ANHBIA}`)}
                    alt={order.TENLAP}
                    onClick={() => navigate(`${ROUTERS.USER.DETAIL}/${order.MALAP}`)}
                    style={{ cursor: "pointer", width: "50px", height: "50px" }}
                  />
                </Cell>
                <Cell>
                  <Button onClick={() => navigate(`${ROUTERS.USER.DETAIL}/${order.MALAP}`)}>
                    Đánh Giá
                  </Button>
                </Cell>
              </Row>
            ))}
          </div>
        ) : (
          <div style={{ textAlign: "center", marginTop: "40px" }}>
            <Empty
              description="Mua hàng để tạo nhật ký đơn hàng"
              style={{ marginBottom: "20px" }}
            />
            <div style={{ display: "flex", justifyContent: "center" }}>
              <Button
                size="large"
                onClick={() => navigate(ROUTERS.USER.HOME)}
                type="primary"
              >
                Tiếp tục mua sắm
              </Button>
            </div>
          </div>
        )}
      </Table>
    </Wrapper>
  );
};

export default PurchaseHistory;

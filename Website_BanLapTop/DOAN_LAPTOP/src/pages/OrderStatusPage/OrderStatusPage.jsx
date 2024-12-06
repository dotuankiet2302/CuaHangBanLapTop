import { useUser } from "../UserContext/UserContext";
import { useEffect, useState } from "react";
import axios from "axios";
import { message, Modal, Button, Empty } from "antd";
import { useNavigate } from "react-router-dom";
import { ROUTERS } from "../../utils/router";
import {
  Wrapper,
  Title,
  Table,
  Row,
  Cell,
  ProductImage,
  TitleRow,
  TitleCell,
} from "./style";

const OrderStatusPage = () => {
  const { userInfo } = useUser(); // Lấy thông tin người dùng
  const [purchaseHistory, setPurchaseHistory] = useState([]);
  const [isModalOpen, setIsModalOpen] = useState(false);
  const [selectedOrderId, setSelectedOrderId] = useState(null);
  const navigate = useNavigate();

  useEffect(() => {
    if (!userInfo) {
      message.error("Bạn cần đăng nhập để truy cập lịch sử mua hàng.");
      navigate(ROUTERS.USER.LOGIN);
    } else {
      const fetchPurchaseHistory = async () => {
        try {
          const response = await axios.get(
            `http://localhost:8000/api-order-status.php?id=${userInfo.maKH}`
          );
          if (response.data.success) {
            setPurchaseHistory(response.data.data);
          } else {
            message.error(response.data.message);
          }
        } catch (error) {
          message.error("Lỗi khi lấy thông tin lịch sử mua hàng.");
        }
      };

      fetchPurchaseHistory();
    }
  }, [userInfo, navigate]);

  const handleOk = async () => {
   try {
     // Lấy ngày giao hiện tại (định dạng yyyy-mm-dd)
     const currentDate = new Date().toISOString().split("T")[0];
 
     console.log("Order ID:", selectedOrderId); // In Order ID
     console.log("Ngày giao:", currentDate); // In Ngày giao
 
     // Log dữ liệu gửi đi
     const postData = {
       id: selectedOrderId,
       status: "ĐÃ NHẬN",
       ngaygiao: currentDate, // Update NGAYGIAO to current date
     };
     console.log("Dữ liệu gửi đi:", postData); // In dữ liệu gửi đi để kiểm tra
 
     const response = await axios.post(
       "http://localhost:8000/api-update-order-status.php",
       postData
     );
     
     // Log phản hồi từ API
     console.log("Phản hồi từ API:", response.data);
     
     if (response.data.success) {
       message.success("Cập nhật trạng thái thành công!");
       setPurchaseHistory((prev) =>
         prev.filter((order) => order.MADH !== selectedOrderId) // Xóa đơn hàng khỏi danh sách
       );
     } else {
       message.error(response.data.message);
     }
   } catch (error) {
     console.error("Lỗi khi cập nhật trạng thái đơn hàng:", error); // Log lỗi nếu có
     message.error("Lỗi khi cập nhật trạng thái đơn hàng.");
   } finally {
     setIsModalOpen(false);
   }
 };

  const handleCancel = () => {
    setIsModalOpen(false);
  };

  const openModal = (orderId) => {
    setSelectedOrderId(orderId);
    setIsModalOpen(true);
  };

  return (
    <Wrapper>
      <Title style={{ color: "#FF4C4C" }}>Quản Lý Đơn Hàng</Title>
      <Table>
        {purchaseHistory.length > 0 ? (
          <div>
            <TitleRow>
              <TitleCell>Ngày Giao</TitleCell> {/* New column */}
              <TitleCell>Ngày Đặt</TitleCell>
              <TitleCell>Tình Trạng Thanh Toán</TitleCell>
              <TitleCell>Tình Trạng Giao Hàng</TitleCell>
              <TitleCell>Tổng Tiền</TitleCell>
              <TitleCell>Sản Phẩm</TitleCell>
              <TitleCell>Hình Ảnh</TitleCell>
              <TitleCell>Hành Động</TitleCell>
            </TitleRow>

            {purchaseHistory.map((order) => (
              <Row key={order.MADH}>
               <Cell>{order.NGAYGIAO ? order.NGAYGIAO : "Chưa xác nhận"}</Cell>
                <Cell>{order.NGAYDAT}</Cell>
                <Cell
                  style={{
                    color: order.DATHANHTOAN === "HOÀN TẤT" ? "green" : "red",
                  }}
                >
                  {order.DATHANHTOAN === "HOÀN TẤT"
                    ? "Đã thanh toán"
                    : "Chưa thanh toán"}
                </Cell>
                <Cell
                  style={{
                    color:
                      order.TINHTRANGGIAO === "ĐÃ NHẬN"
                        ? "green"
                        : order.TINHTRANGGIAO === "ĐANG GIAO"
                        ? "orange"
                        : "red",
                  }}
                >
                  {order.TINHTRANGGIAO}
                </Cell>
                <Cell>{order.TONGTIEN} VND</Cell>
                <Cell>{order.TENLAP}</Cell>
                <Cell>
                  <ProductImage
                    src={require(`../../assets/users/images/featured/${order.ANHBIA}`)}
                    alt={order.TENLAP}
                  />
                </Cell>
                <Cell>
                  {order.TINHTRANGGIAO === "ĐANG GIAO" ? (
                    <Button
                      style={{ backgroundColor: "#FF6666", color: "white" }}
                      onClick={() => openModal(order.MADH)}
                    >
                      Xác Nhận Đã Nhận
                    </Button>
                  ) : (
                    <Button
                      onClick={() =>
                        navigate(`${ROUTERS.USER.DETAIL}/${order.MALAP}`)
                      }
                    >
                      Chi Tiết
                    </Button>
                  )}
                </Cell>
              </Row>
            ))}
          </div>
        ) : (
          <div>
            <Empty description="Không có đơn hàng nào chờ xác nhận" style={{ margin: "40px 0" }} />
            <div style={{ display: "flex", justifyContent: "center", marginTop: "20px" }}>
              <Button size="large" onClick={() => navigate(ROUTERS.USER.HOME)} type="primary">
                Tiếp tục mua sắm
              </Button>
            </div>
          </div>
        )}
      </Table>

      <Modal
        style={{ color: "red" }}
        title="Xác Nhận Nhận Hàng"
        open={isModalOpen}
        onOk={handleOk}
        onCancel={handleCancel}
      >
        <p>Bạn có chắc chắn muốn đổi trạng thái đơn hàng này thành "ĐÃ NHẬN"?</p>
      </Modal>
    </Wrapper>
  );
};

export default OrderStatusPage;

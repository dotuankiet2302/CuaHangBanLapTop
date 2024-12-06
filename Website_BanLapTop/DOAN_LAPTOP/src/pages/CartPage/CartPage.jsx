import React, {useEffect, useState} from "react";
import {Button, InputNumber, Empty, Spin, message, Checkbox} from "antd";
import {DeleteOutlined} from "@ant-design/icons";
import {useNavigate} from "react-router-dom";
import {ROUTERS} from "../../utils/router";
import {useUser} from "../UserContext/UserContext";
import {useDispatch, useSelector} from "react-redux";
import {removeFromCart, updateQuantity, purchaseProduct} from "../../redux/slides/cartSlide";

const CartPage = () => {
   const navigate = useNavigate();
   const dispatch = useDispatch();
   const [loading, setLoading] = useState(false);
   const [selectedItems, setSelectedItems] = useState([]); // Trạng thái lưu sản phẩm được chọn (checkbox)
   const {userInfo} = useUser();

   // Lấy giỏ hàng từ Redux store
   const cartItems = useSelector((state) => (userInfo ? state.cart.items[userInfo.maKH] || [] : []));

   useEffect(() => {
      if (!userInfo) {
         message.error("Bạn cần đăng nhập để truy cập giỏ hàng.");
         navigate(ROUTERS.USER.LOGIN);
      }
   }, [userInfo, navigate]);

   // Xử lý xóa sản phẩm
   const handleRemoveItem = async (maLap) => {
      try {
         await dispatch(removeFromCart({userId: userInfo.maKH, maLap}));
         message.success("Đã xóa sản phẩm khỏi giỏ hàng");
      } catch (error) {
         console.error("Error removing item:", error);
         message.error("Không thể xóa sản phẩm");
      }
   };

   // Xử lý cập nhật số lượng
   const handleUpdateQuantity = async (maLap, newQuantity) => {
      const item = cartItems.find((item) => item.maLap === maLap);
      if (item && newQuantity > item.SOLUONGTON) {
         message.warning(`Chỉ còn ${item.SOLUONGTON} sản phẩm trong kho`);
         return;
      }

      try {
         await dispatch(updateQuantity({userId: userInfo.maKH, maLap, quantity: newQuantity}));
      } catch (error) {
         console.error("Error updating quantity:", error);
         message.error("Không thể cập nhật số lượng");
      }
   };

   // Xử lý thanh toán khi giao hàng
   const handleCheckout = async () => {
      if (!userInfo || !userInfo.maKH) {
         message.error("Vui lòng đăng nhập để sử dụng giỏ hàng");
         navigate(ROUTERS.USER.LOGIN);
         return;
      }

      setLoading(true);
      try {
         // Lọc các sản phẩm được chọn
         const selectedCartItems = cartItems.filter((item) => selectedItems.includes(item.maLap));
         const totalCounter = selectedCartItems.reduce(
            (sum, item) => sum + parseFloat(item.giaBan) * parseInt(item.sl),
            0
         );
         const requestBody = {
            userId: userInfo.maKH,
            totalCounter: totalCounter,
            cartItems: selectedCartItems.map((item) => ({
               maLap: item.maLap,
               sl: item.sl,
               giaBan: item.giaBan,
            })),
         };
         // Gửi yêu cầu thanh toán
         const response = await fetch("http://localhost:8000/CheckOut.php", {
            method: "POST",
            headers: {
               "Content-Type": "application/json",
            },
            body: JSON.stringify(requestBody),
            credentials: "include",
         });
         if (!response.ok) {
            const errorText = await response.text();
            throw new Error(`Network response was not ok: ${errorText}`);
         }

         const result = await response.json();
         if (result.success) {
            // Thanh toán thành công, gọi action purchaseProduct để xóa sản phẩm đã mua khỏi giỏ hàng
            dispatch(
               purchaseProduct({
                  userId: userInfo.maKH,
                  purchasedItems: selectedCartItems,
               })
            );
            setSelectedItems([]);

            dispatch(
               removeFromCart({
                  userId: userInfo.maKH,
                  maLapList: selectedCartItems.map((item) => item.maLap),
               })
            );

            message.success("Thanh toán thành công!");
            navigate(ROUTERS.USER.ORDER_SUCCESS);
         } else {
            throw new Error(result.message || "Thanh toán thất bại");
         }
      } catch (error) {
         console.error("Error during checkout:", error);
         message.error("Không thể thực hiện thanh toán. Vui lòng thử lại.");
      } finally {
         setLoading(false);
      }
   };
   const handleOnlineCheckout = async () => {
      // Thanh toán qua MOMO
      if (!userInfo || !userInfo.maKH) {
         message.error("Vui lòng đăng nhập để sử dụng giỏ hàng");
         navigate(ROUTERS.USER.LOGIN);
         return;
      }

      setLoading(true);
      try {
         // Lọc các sản phẩm được chọn
         const selectedCartItems = cartItems.filter((item) => selectedItems.includes(item.maLap));
         const totalCounter = selectedCartItems.reduce(
            (sum, item) => sum + parseFloat(item.giaBan) * parseInt(item.sl),
            0
         );
         const requestBody = {
            userId: userInfo.maKH,
            totalCounter: totalCounter,
            cartItems: selectedCartItems.map((item) => ({
               maLap: item.maLap,
               sl: item.sl,
               giaBan: item.giaBan,
            })),
         };

         console.log("Bắt đầu thanh toán MoMo...");
         console.log("Dữ liệu gửi đi:", requestBody);

         // Gửi yêu cầu thanh toán đến OnlineCheckOut.php
         const response = await fetch("http://localhost:8000/OnlineCheckOut.php", {
            method: "POST",
            headers: {
               "Content-Type": "application/json",
            },
            body: JSON.stringify(requestBody),
            credentials: "include",
         });
         console.log("Phản hồi từ server:", response);

         if (!response.ok) {
            const errorText = await response.text();
            throw new Error(`Network response was not ok: ${errorText}`);
         }

         const result = await response.json();

         if (result.success) {
            // Kiểm tra nếu có URL cổng MOMO để chuyển hướng
            if (result.success && result.redirectUrl) {
               // console.log("Redirecting to:", result.redirectUrl); // Kiểm tra giá trị URL
               // window.open(result.redirectUrl, "_blank"); // Mở URL trong tab mới
               // return; // Dừng logic tiếp theo sau khi chuyển hướng
               window.location.href = result.redirectUrl;  // Chuyển hướng đến URL thanh toán
               return; 
            }

            // Nếu không có URL chuyển hướng, xử lý logic thanh toán thành công như cũ
            dispatch(
               purchaseProduct({
                  userId: userInfo.maKH,
                  purchasedItems: selectedCartItems,
               })
            );
            setSelectedItems([]);

            dispatch(
               removeFromCart({
                  userId: userInfo.maKH,
                  maLapList: selectedCartItems.map((item) => item.maLap),
               })
            );

            message.success("Thanh toán thành công!");
            navigate(ROUTERS.USER.ORDER_SUCCESS);
         } else {
            throw new Error(result.message || "Thanh toán thất bại");
         }
      } catch (error) {
         console.error("Error during checkout:", error);
         message.error("Không thể thực hiện thanh toán. Vui lòng thử lại.");
      } finally {
         setLoading(false);
      }
   };

   // Hàm xử lý khi thay đổi trạng thái checkbox
   const handleCheckboxChange = (maLap) => {
      setSelectedItems((prevSelectedItems) => {
         if (prevSelectedItems.includes(maLap)) {
            return prevSelectedItems.filter((item) => item !== maLap); // Bỏ chọn
         } else {
            return [...prevSelectedItems, maLap]; // Chọn
         }
      });
   };

   const tableStyle = {
      width: "100%",
      borderCollapse: "collapse",
      backgroundColor: "#fff",
      boxShadow: "0 1px 3px rgba(0,0,0,0.1)",
      borderRadius: "8px",
      overflow: "hidden",
   };

   const headerCellStyle = {
      padding: "15px",
      backgroundColor: "#f5f5f5",
      borderBottom: "1px solid #ddd",
      textAlign: "left",
      fontWeight: "bold",
   };

   const cellStyle = {
      padding: "15px",
      borderBottom: "1px solid #ddd",
   };

   return (
      <div style={{padding: "20px", maxWidth: "1200px", margin: "0 auto"}}>
         <h2 style={{marginBottom: "20px", fontSize: "24px"}}>Giỏ Hàng Của Bạn</h2>

         {loading ? (
            <Spin size='large' />
         ) : cartItems.length === 0 ? (
            <div>
               <Empty description='Giỏ hàng của bạn hiện đang trống' style={{margin: "40px 0"}} />
               <div style={{display: "flex", justifyContent: "center", marginTop: "20px"}}>
                  <Button size='large' onClick={() => navigate(ROUTERS.USER.HOME)} type='primary'>
                     Tiếp tục mua sắm
                  </Button>
               </div>
            </div>
         ) : (
            // Giỏ hàng có sản phẩm
            <>
               <table style={tableStyle}>
                  <thead>
                     <tr>
                        <th style={headerCellStyle}>Chọn</th>
                        <th style={headerCellStyle}>Sản phẩm</th>
                        <th style={headerCellStyle}>Giá</th>
                        <th style={headerCellStyle}>Số lượng</th>
                        <th style={headerCellStyle}>Tổng cộng</th>
                        <th style={headerCellStyle}>Thao tác</th>
                     </tr>
                  </thead>
                  <tbody>
                     {cartItems.map((item, index) => {
                        const total = parseFloat(item.giaBan) * parseInt(item.sl);
                        return (
                           <tr key={index}>
                              <td style={cellStyle}>
                                 <Checkbox
                                    checked={selectedItems.includes(item.maLap)}
                                    onChange={() => handleCheckboxChange(item.maLap)}
                                 />
                              </td>
                              <td style={cellStyle}>
                                 <div style={{display: "flex", alignItems: "center", gap: "15px"}}>
                                    <img
                                       src={require(`../../assets/users/images/featured/${item.anhBia}`)}
                                       alt={item.tenLap}
                                       style={{
                                          width: "80px",
                                          height: "80px",
                                          objectFit: "cover",
                                          borderRadius: "4px",
                                       }}
                                    />
                                    <span style={{fontWeight: "500"}}>{item.tenLap}</span>
                                 </div>
                              </td>
                              <td style={cellStyle}>{parseInt(item.giaBan).toLocaleString()} VNĐ</td>
                              <td style={cellStyle}>
                                 <InputNumber
                                    min={1}
                                    max={item.SOLUONGTON}
                                    value={parseInt(item.sl)}
                                    onChange={(value) => handleUpdateQuantity(item.maLap, value)}
                                    style={{width: "70px"}}
                                 />
                              </td>
                              <td style={cellStyle}>{total.toLocaleString()} VNĐ</td>
                              <td style={cellStyle}>
                                 <Button
                                    type='text'
                                    danger
                                    icon={<DeleteOutlined />}
                                    onClick={() => handleRemoveItem(item.maLap)}>
                                    Xóa
                                 </Button>
                              </td>
                           </tr>
                        );
                     })}
                  </tbody>
               </table>

               <div style={{marginTop: "20px", padding: "20px", backgroundColor: "#f5f5f5", borderRadius: "8px"}}>
                  <div style={{display: "flex", justifyContent: "space-between", alignItems: "center"}}>
                     <div>
                        <strong>Tổng số sản phẩm:</strong> {selectedItems.length}{" "}
                     </div>
                     <div style={{color: "#ff0000", fontSize: "20px", marginRight: "120px"}}>
                        <strong>Tổng tiền:</strong>{" "}
                        {cartItems
                           .reduce(
                              (sum, item) =>
                                 sum +
                                 (selectedItems.includes(item.maLap) ? parseFloat(item.giaBan) * parseInt(item.sl) : 0),
                              0
                           )
                           .toLocaleString()}{" "}
                        VNĐ
                     </div>
                  </div>
                  <div
                     style={{
                        textAlign: "center",
                        marginTop: "20px",
                        display: "flex",
                        flexDirection: "column",
                        gap: "10px",
                     }}>
                     <Button
                        type='primary'
                        size='large'
                        onClick={() => navigate(ROUTERS.USER.HOME)}
                        style={{
                           paddingLeft: "20px",
                        }}>
                        Tiếp tục mua hàng
                     </Button>

                     <Button
                        type='primary'
                        size='large'
                        onClick={handleCheckout}
                        style={{}}
                        disabled={selectedItems.length === 0}>
                        Thanh toán khi nhận hàng
                     </Button>

                     <Button
                        type='primary'
                        size='large'
                        onClick={handleOnlineCheckout}
                        style={{}}
                        disabled={selectedItems.length === 0}>
                        Thanh toán MOMO
                     </Button>
                  </div>
               </div>
            </>
         )}
      </div>
   );
};

export default CartPage;

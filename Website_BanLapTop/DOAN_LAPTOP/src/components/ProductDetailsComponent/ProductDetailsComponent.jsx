import { Col, Row, Image, message, Rate } from "antd";
import React, { useEffect, useState } from "react";
import { useParams, useNavigate } from "react-router-dom";
import {
   WrapperStyleColImg,
   WrapperStyleImgSmall,
   WrapperStyleNameProduct,
   WrapperStyleTextSell,
   StylePriceProduct,
   StylePriceTextProduct,
   WrapperAddressProduct,
   WrapperQuatityProduct,
   WrapperbtnQuatityProduct,
   WrapperInputNumber,
   WrapperProduct,
   WrapperReviewSection,
   WrapperReviewItem,
} from "./style";
import { StarFilled, MinusOutlined, PlusOutlined } from "@ant-design/icons";
import ButtonComponent from "../ButtonComponent/ButtonComponent";
import axios from "axios";
import { useUser } from "../../pages/UserContext/UserContext";
import { useDispatch } from "react-redux";
import { addToCart } from "../../redux/slides/cartSlide";
import { ROUTERS } from "../../utils/router";
import DEFAULT_AVATAR from "../../assets/images/user.png";

const ProductDetailsComponent = () => {
   const navigate = useNavigate();
   const dispatch = useDispatch();
   const { id } = useParams();
   const { userInfo } = useUser();
   const [product, setProduct] = useState(null);
   const [loading, setLoading] = useState(true);
   const [quantity, setQuantity] = useState(1);
   const [reviews, setReviews] = useState([]);
   const [newReview, setNewReview] = useState({
      rating: 0,
      comment: "",
   });

   const fetchProductDetail = async () => {
      try {
         const response = await axios.get(`http://localhost:8000/api-productdetail.php?id=${id}`);
         setProduct(response.data);
      } catch (error) {
         console.error("Error fetching product detail:", error);
         message.error("Không thể tải thông tin sản phẩm");
      } finally {
         setLoading(false);
      }
   };

      const fetchReviews = async () => {
         try {
            const response = await axios.get(`http://localhost:8000/api-review.php?id=${id}`);
            if (response.data.success && Array.isArray(response.data.data)) {
               setReviews(response.data.data); // Dữ liệu thực sự nằm trong `response.data.data`
            } else {
               setReviews([]); // Không có đánh giá
            }
         } catch (error) {
            console.error("Error fetching reviews:", error);
            message.error("Không thể tải bình luận");
         }
   };
  

   const handleAddToCart = () => {
      if (!userInfo) {
         message.error("Vui lòng đăng nhập để thêm vào giỏ hàng!");
         navigate(ROUTERS.USER.LOGIN);
         return;
      }

      if (quantity > product.SOLUONGTON) {
         message.warning(`Chỉ còn ${product.SOLUONGTON} sản phẩm trong kho`);
         return;
      }

      try {
         dispatch(
            addToCart({
               userId: userInfo.maKH,
               product: {
                  maLap: product.MALAP,
                  tenLap: product.TENLAP,
                  anhBia: product.ANHBIA,
                  giaBan: product.GIABAN,
                  SOLUONGTON: product.SOLUONGTON,
               },
               quantity,
            })
         );

         window.dispatchEvent(
            new CustomEvent("cartUpdated", { detail: { quantity: quantity } })
         );

         message.success("Đã thêm sản phẩm vào giỏ hàng!");
         setQuantity(1);
      } catch (error) {
         console.error("Error adding to cart:", error);
         message.error("Có lỗi xảy ra khi thêm vào giỏ hàng!");
      }
   };

         const handleSubmitReview = async () => {
            if (!newReview.comment || newReview.rating === 0) {
            message.error("Vui lòng nhập đầy đủ thông tin đánh giá!");
            return;
            }
         
            try {
            const response = await axios.post(`http://localhost:8000/api-review.php`, {
               id: id, // Dùng 'id' của sản phẩm
               userId: userInfo?.maKH, // Kiểm tra lại 'userInfo' có dữ liệu không
               rating: newReview.rating,
               comment: newReview.comment,
            });
            console.log("userInfo.maKH:", userInfo?.maKH);
            if (!userInfo?.maKH) {
              message.error("Không tìm thấy thông tin người dùng!");
              return;
            }
            
            // Log toàn bộ dữ liệu trả về từ API để kiểm tra
            console.log("API Response:", response.data);
         
            if (response.data.success) {
               message.success("Đánh giá của bạn đã được gửi!");
               setNewReview({ rating: 0, comment: "" });
               fetchReviews(); // Tải lại danh sách đánh giá sau khi thêm mới
            } else {
               message.error(response.data.message || "Có lỗi khi gửi đánh giá!");
            }
            } catch (error) {
            console.error("Error submitting review:", error);
         
            // Kiểm tra lỗi trả về từ API và thông báo tương ứng
            if (error.response) {
               // Lỗi từ server, có phản hồi
               console.error("Response error:", error.response.data);
               message.error(error.response.data.message || "Có lỗi khi gửi đánh giá!");
            } else if (error.request) {
               // Không nhận được phản hồi từ server
               console.error("No response from server:", error.request);
               message.error("Không nhận được phản hồi từ máy chủ!");
            } else {
               // Lỗi khác
               console.error("Unexpected error:", error.message);
               message.error("Có lỗi xảy ra trong quá trình gửi đánh giá!");
            }
            }
         };
         
      
      const generateRating = (rating) => {
         return Array.from({ length: 5 }, (_, index) =>
            index < rating ? <StarFilled style={{ color: "yellow" }} key={index} /> : <StarFilled style={{ color: "#ccc" }} key={index} />
         );
   };
  

   useEffect(() => {
      fetchProductDetail();
      fetchReviews();
   }, [id]);
   useEffect(() => {
      console.log("Reviews fetched:", reviews); // Debug dữ liệu review
  }, [reviews]);
  

   if (loading) {
      return <div className="loader">Loading...</div>;
   }

   if (!product) {
      return <div>Error: Product not found!</div>;
   }

   const imagePath = require(`../../assets/users/images/featured/${product.ANHBIA}`);

   return (
      <div>
         <Row style={{ padding: "16px" }}>
            <Col span={8}>
               <Image src={imagePath} alt="image product" preview={true} />

               <Row style={{ padding: "10px" }}>
                  {[product.ANHBIA1, product.ANHBIA2, product.ANHBIA3, product.ANHBIA4, product.ANHBIA5]
                     .filter((image) => image)
                     .map((image, index) => (
                        <WrapperStyleColImg key={index} span={4}>
                           <WrapperStyleImgSmall
                              src={require(`../../assets/users/images/featured/${image}`)}
                              alt={`image small ${index + 1}`}
                              preview={true}
                           />
                        </WrapperStyleColImg>
                     ))}
               </Row>
            </Col>

            <Col span={14}>
               <WrapperStyleNameProduct>{product.TENLAP}</WrapperStyleNameProduct>
               <div>
                  <StarFilled style={{ fontSize: "15px", color: "yellow" }} />
                  <StarFilled style={{ fontSize: "15px", color: "yellow" }} />
                  <StarFilled style={{ fontSize: "15px", color: "yellow" }} />
                  <WrapperStyleTextSell> | Đã bán </WrapperStyleTextSell>
               </div>
               <StylePriceProduct>
                  <StylePriceTextProduct>{parseInt(product.GIABAN).toLocaleString()}đ</StylePriceTextProduct>
               </StylePriceProduct>
               <WrapperAddressProduct>
                  <span>Giao đến: </span>
                  <span className="address">Đông Hưng Thuận, Q12, TP.HCM</span> -
                  <span className="change-address"> Đổi địa chỉ</span>
               </WrapperAddressProduct>

               <WrapperQuatityProduct>
                  <div>Số lượng trong kho: {product.SOLUONGTON}</div>
                  <div>
                     <WrapperbtnQuatityProduct>
                        <ButtonComponent
                           icon={<MinusOutlined />}
                           onClick={() => setQuantity((prev) => Math.max(1, prev - 1))}
                        />
                        <WrapperInputNumber
                           min={1}
                           max={product.SOLUONGTON}
                           value={quantity}
                           onChange={(value) => setQuantity(value)}
                           size="small"
                        />
                        <ButtonComponent
                           icon={<PlusOutlined />}
                           onClick={() => setQuantity((prev) => Math.min(product.SOLUONGTON, prev + 1))}
                        />
                     </WrapperbtnQuatityProduct>
                  </div>

                  <div style={{ display: "flex", gap: "12px", alignItems: "center" }}>
                     <ButtonComponent
                        onClick={handleAddToCart}
                        size="large"
                        style={{
                           background: "rgb(255,57,69)",
                           height: "48px",
                           width: "220px",
                           border: "none",
                           borderRadius: "4px",
                        }}
                        textButton="Chọn mua"
                        styleTextButton={{ color: "#fff", fontSize: "15px", fontWeight: "700" }}
                     />
                     <ButtonComponent
                        size="large"
                        style={{
                           background: "#fff",
                           height: "48px",
                           width: "220px",
                           border: "1px solid #ccc",
                           borderRadius: "4px",
                        }}
                        textButton="Mua trả sau"
                     />
                  </div>

                  <div>
                     <WrapperProduct>
                        <span>Thông tin: </span>
                        <span className="cauhinh">Cấu hình: Vi xử lý Intel Core i5 mạnh mẽ.</span>
                        <span className="kichthuoc">Kích Thước: 15.6 inch</span>
                        <span className="cpu">CPU: Intel Core i5</span>
                        <span className="ram">Ram: 8GB</span>
                        <span className="manhinh">Màn hình: 1920x1080</span>
                        <span className="pin">Pin: 5000mAh</span>
                        <span className="mota">
                           Máy tính xách tay này sở hữu một cấu hình mạnh mẽ với vi xử lý Intel Core i5 mạnh mẽ, hỗ trợ đa nhiệm.
                        </span>
                     </WrapperProduct>
                  </div>
               </WrapperQuatityProduct>
            </Col>
         </Row>

         <WrapperReviewSection>
         <h3>Đánh giá sản phẩm</h3>
            {reviews.map((review, index) => (
               <WrapperReviewItem key={index}>
                  <div style={{ display: "flex", alignItems: "center", gap: "10px" }}>
                     <img
                        src={
                           review.ANH
                              ? require(`../../assets/images/user/${review.ANH}`)
                              : DEFAULT_AVATAR
                        }
                        alt={review.HOTEN}
                        style={{ width: "50px", height: "50px", borderRadius: "50%" }}
                     />
                     <strong>{review.HOTEN}</strong>
                  </div>
                  <div>{generateRating(review.SOSAO)}</div>
                  <div>{review.MOTA}</div>
               </WrapperReviewItem>
            ))}

         {userInfo && (
            <div>
               <Rate
                  value={newReview.rating}
                  onChange={(value) =>
                     setNewReview((prev) => ({ ...prev, rating: value }))
                  }
               />
               <textarea
                  placeholder="Nhập đánh giá của bạn..."
                  value={newReview.comment}
                  onChange={(e) =>
                     setNewReview((prev) => ({ ...prev, comment: e.target.value }))
                  }
               />
               <ButtonComponent textButton="Gửi đánh giá" onClick={handleSubmitReview} />
            </div>
         )}
      </WrapperReviewSection>

      </div>
   );
};

export default ProductDetailsComponent;

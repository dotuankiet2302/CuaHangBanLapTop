import React, {useState} from "react";
import {useSelector} from "react-redux";
import {Row, Col} from "antd"; // Import Row và Col từ antd
import SliderComponent from "../../components/SliderComponent/SliderComponent";
import CardComponent from "../../components/CardComponent/CardComponent";
import slide1 from "../../assets/images/Banner7.jpg";
import slide2 from "../../assets/images/Banner3.jpg";
import slide3 from "../../assets/images/Banner8.jpg";
import slide4 from "../../assets/images/Banner6.png";
import slide5 from "../../assets/images/Banner9.jpg";
import slide6 from "../../assets/images/Banner10.jpg";
import slide7 from "../../assets/images/Banner11.jpg";
import baohanh1 from "../../assets/images/bh1.png";
import baohanh2 from "../../assets/images/bh2.png";
import camket1 from "../../assets/images/ck1.png";
import camket2 from "../../assets/images/ck2.png";
import {FontAwesomeIcon} from "@fortawesome/react-fontawesome";
import {faCaretRight} from "@fortawesome/free-solid-svg-icons";
import styled, {keyframes} from "styled-components";

// Hiệu ứng chớp
const blink = keyframes`
   0% { opacity: 1; }
   50% { opacity: 0.5; }
   100% { opacity: 1; }
`;

// Hiệu ứng nhút nhích
const hoverEffect = keyframes`
   0% { transform: scale(1); }
   50% { transform: scale(1.05); }
   100% { transform: scale(1); }
`;

// Styled Components
const Title = styled.div`
   font-size: 25px; /* Đặt kích thước chữ */
   color: #007bff; /* Đặt màu chữ thành màu xanh */
   font-weight: bold;
   margin-top: 20px;
   text-align: center;
`;

const DropdownToggle = styled.div`
   display: flex;
   align-items: center;
   color: #000000;
   margin-top: 10px;
   cursor: pointer;
   padding: 12px; /* Tăng padding */
   border-radius: 8px;

   &:hover {
      background-color: #f0f0f0; /* Hiệu ứng hover */
   }
`;

const DropdownContent = styled.div`
   margin-top: 10px;
   padding: 20px; /* Tăng padding */
   background-color: #fff;
   border-radius: 8px;
   box-shadow: 0 2px 8px rgba(0, 0, 0, 0.1);
`;

const InfoText = styled.p`
   color: #ef5222;
   font-size: 20px; /* Tăng kích thước chữ */
   font-weight: bold; /* Đậm chữ */
   animation: ${blink} 1s infinite; /* Thêm hiệu ứng chớp */
`;

const InfoItem = styled.li`
   margin-bottom: 12px; /* Tăng khoảng cách giữa các mục */
   font-size: 16px; /* Tăng kích thước chữ */
   color: #999999; /* Màu xám nhẹ */
`;

const Image = styled.img`
   max-width: 100%;
   height: auto;
   margin-bottom: 10px;
   transition: transform 0.3s, filter 0.3s; /* Thêm hiệu ứng chuyển đổi */
   border-radius: 12px; /* Bo góc hình ảnh */
   &:hover {
      animation: ${hoverEffect} 0.5s ease-in-out; /* Hiệu ứng nhút nhích */
      filter: brightness(1.1); /* Tăng độ sáng khi hover */
   }
`;

const Commitment = () => {
   const [isOpen, setIsOpen] = useState(false);

   return (
      <div style={{padding: "0", height: "100%"}}>
         <Title>CAM KẾT</Title>
         <DropdownToggle onMouseEnter={() => setIsOpen(true)} onMouseLeave={() => setIsOpen(false)}>
            <FontAwesomeIcon icon={faCaretRight} style={{color: "#bbbcbf", marginRight: "10px"}} />
            <span style={{color: "#ff007f"}}>CAM KẾT CỦA CỬA HÀNG</span> {/* Màu hồng đỏ */}
         </DropdownToggle>
         {isOpen && (
            <DropdownContent>
               <InfoText>UY TÍN & CHẤT LƯỢNG</InfoText>
               <ul style={{padding: "0", listStyleType: "none"}}>
                  <InfoItem>
                     <strong>Chất lượng sản phẩm:</strong>Cung cấp các sản phẩm laptop chính hãng, đảm bảo chất lượng và
                     hiệu suất
                  </InfoItem>
                  <InfoItem>
                     <strong>Bảo hành:</strong>
                  </InfoItem>
                  <InfoItem>
                     + Cam kết bảo hành sản phẩm trong thời gian quy định (ví dụ: 12 tháng hoặc 24 tháng).
                  </InfoItem>
                  <InfoItem>
                     + Đổi mới hoặc sửa chữa miễn phí trong thời gian bảo hành nếu có lỗi do nhà sản xuất.
                  </InfoItem>
                  <InfoItem>
                     <strong>Hỗ trợ kỹ thuật:</strong>
                  </InfoItem>
                  <InfoItem>
                     + Cung cấp dịch vụ hỗ trợ kỹ thuật miễn phí qua điện thoại hoặc trực tiếp tại cửa hàng.
                  </InfoItem>
                  <InfoItem>+ Hướng dẫn khách hàng sử dụng và bảo trì sản phẩm.</InfoItem>
                  <InfoItem>
                     <strong>Đổi trả hàng:</strong>
                  </InfoItem>
                  <InfoItem>
                     + Chính sách đổi trả linh hoạt trong thời gian quy định (thường từ 7 đến 30 ngày) nếu sản phẩm
                     không đáp ứng yêu cầu hoặc có lỗi.
                  </InfoItem>
                  <InfoItem>
                     <strong>Giá minh bạch:</strong>
                  </InfoItem>
                  <InfoItem>+ Đảm bảo giá cả công khai và minh bạch, không có chi phí ẩn.</InfoItem>
                  <InfoItem>+ Thông báo rõ ràng về các chương trình khuyến mãi và giảm giá.</InfoItem>
                  <InfoItem>
                     <strong>Chất lượng dịch vụ:</strong>
                  </InfoItem>
                  <InfoItem>+ Đảm bảo phục vụ khách hàng tận tình, chu đáo và nhanh chóng.</InfoItem>
                  <InfoItem>+ Đào tạo nhân viên để tư vấn phù hợp với nhu cầu của khách hàng.</InfoItem>
                  <InfoItem>
                     <strong>Bảo mật thông tin:</strong>
                  </InfoItem>
                  <InfoItem>+ Cam kết bảo mật thông tin cá nhân và giao dịch của khách hàng.</InfoItem>
                  <InfoItem>
                     <strong>Cung cấp phụ kiện chính hãng:</strong>
                  </InfoItem>
                  <InfoItem>+ Đảm bảo cung cấp các phụ kiện và linh kiện chính hãng cho laptop.</InfoItem>
               </ul>
            </DropdownContent>
         )}
         {/* Chèn ảnh ở đây, bên ngoài DropdownContent */}
         <div style={{display: "flex", flexDirection: "column", alignItems: "center", marginTop: "30px"}}>
            <Image src={camket1} alt='Cam kết 1' />
            <Image src={camket2} alt='Cam kết 2' />
         </div>
      </div>
   );
};

const Warranty = () => {
   const [isOpen, setIsOpen] = useState(false);

   return (
      <div style={{padding: "0", height: "100%"}}>
         <Title>BẢO HÀNH</Title>

         <DropdownToggle onMouseEnter={() => setIsOpen(true)} onMouseLeave={() => setIsOpen(false)}>
            <FontAwesomeIcon icon={faCaretRight} style={{color: "#bbbcbf", marginRight: "10px"}} />
            <span style={{color: "#ff007f"}}>THÔNG TIN BẢO HÀNH</span> {/* Màu hồng đỏ */}
         </DropdownToggle>

         {isOpen && (
            <DropdownContent>
               <InfoText>BẢO HÀNH 12 THÁNG</InfoText>
               <ul style={{padding: "0", listStyleType: "none"}}>
                  <InfoItem>
                     Mô tả:{" "}
                     <strong>
                        Khách hàng sẽ được cửa hàng đổi máy mới khi có bất kì hư hỏng liên quan đến phần mềm của máy{" "}
                     </strong>
                  </InfoItem>
                  <InfoItem>
                     <strong>Thời gian bảo hành:</strong> 12 tháng kể từ ngày mua
                  </InfoItem>
                  <InfoItem>
                     <strong>Các dịch vụ bao gồm:</strong>
                  </InfoItem>
                  <InfoItem>+ Sửa chữa hoặc thay thế linh kiện bị lỗi do nhà sản xuất.</InfoItem>
                  <InfoItem>+ Hỗ trợ kỹ thuật qua điện thoại hoặc email.</InfoItem>
                  <InfoItem>+ Bảo trì phần mềm cơ bản (cài đặt lại hệ điều hành, cập nhật driver).</InfoItem>
                  <InfoItem>
                     <strong>Điều kiện:</strong>Bảo hành không áp dụng cho các hư hỏng do người sử dụng (rơi, va đập,
                     nước vào).
                  </InfoItem>
               </ul>

               <InfoText>BẢO HÀNH 6 THÁNG</InfoText>
               <ul style={{padding: "0", listStyleType: "none"}}>
                  <InfoItem>
                     Mô tả:{" "}
                     <strong>
                        Khách hàng sẽ được cửa hàng đổi máy mới khi có bất kì hư hỏng liên quan đến phần mềm của máy{" "}
                     </strong>
                  </InfoItem>
                  <InfoItem>
                     <strong>Thời gian bảo hành:</strong> 6 tháng kể từ ngày mua
                  </InfoItem>
                  <InfoItem>
                     <strong>Các dịch vụ bao gồm:</strong>
                  </InfoItem>
                  <InfoItem>+ Sửa chữa hoặc thay thế linh kiện bị lỗi do nhà sản xuất.</InfoItem>
                  <InfoItem>+ Hỗ trợ kỹ thuật qua điện thoại hoặc email.</InfoItem>
                  <InfoItem>
                     <strong>Điều kiện:</strong>Bảo hành không bao gồm các vấn đề do sử dụng sai cách hoặc hư hỏng vật
                     lý.
                  </InfoItem>
               </ul>
            </DropdownContent>
         )}

         {/* Chèn ảnh ở đây, bên ngoài DropdownContent */}
         <div style={{display: "flex", flexDirection: "column", alignItems: "center", marginTop: "50px"}}>
            <Image src={baohanh1} alt='Bảo hành 1' />
            <Image src={baohanh2} alt='Bảo hành 2' />
         </div>
      </div>
   );
};

const HomePage = () => {
   // Lấy kết quả tìm kiếm từ Redux store
   const searchResults = useSelector((state) => state.search.searchResults);

   return (
      <div style={{margin: "0", padding: "0"}}>
         <div id='container' style={{background: "#fff", padding: "0", minHeight: "1550px"}}>
            <Row gutter={0}>
               <Col span={4} style={{display: "flex", flexDirection: "column"}}>
                  <Commitment />
               </Col>
               <Col span={16} style={{display: "flex", flexDirection: "column"}}>
                  <SliderComponent arrImage={[slide1, slide2, slide3, slide4, slide5, slide6, slide7]} />
               </Col>
               <Col span={4} style={{display: "flex", flexDirection: "column"}}>
                  <Warranty />
               </Col>
            </Row>
            <div style={{marginTop: "20px"}}>
               <CardComponent /> {/* CardComponent nằm dưới cả ba cột */}
            </div>
         </div>
      </div>
   );
};

export default HomePage;

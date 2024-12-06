import styled from "styled-components"
import { Card } from "antd"

export const UnderlinedText = styled.span`
   cursor: pointer; /* Thay đổi con trỏ khi hover */
   text-decoration: none; /* Bỏ gạch chân mặc định */
   position: relative;
   color: rgba(255, 66, 78, 0.9); /* Màu đỏ hơi hồng */
   font-weight: bold; /* Đặt chữ in đậm */

   &:hover {
      color: #ff4d4f; /* Màu chữ khi hover */
   }

   &:before {
      content: "";
      position: absolute;
      left: 0;
      right: 0;
      bottom: 0;
      height: 2px; /* Độ dày của gạch chân */
      background: #007bff; /* Màu gạch chân */
      transform: scaleX(0);
      transition: transform 0.3s ease; /* Hiệu ứng chuyển tiếp */
   }

   &:hover:before {
      transform: scaleX(1); /* Gạch chân xuất hiện khi hover */
   }
`;
export const StyledProductTitle = styled.span`
   color: #005b7f; /* Màu xanh đậm */
   font-weight: bold; /* In đậm */
   position: relative; /* Để sử dụng cho hiệu ứng gạch chân */

   /* Gạch chân */
   &:after {
      content: "";
      position: absolute;
      left: 0;
      right: 0;
      bottom: -7px; /* Khoảng cách từ chữ đến gạch chân */
      height: 6px; /* Độ dày của gạch chân */
      background-color: rgba(173, 216, 230, 0.8); /* Màu xanh dương nhạt */
      transform: scaleX(0); /* Bắt đầu từ 0 */
      transition: transform 0.2s ease; /* Hiệu ứng chuyển tiếp */
   }

   /* Hiệu ứng khi hover */
   &:hover:after {
      transform: scaleX(1); /* Gạch chân xuất hiện khi hover */
   }

   cursor: pointer; /* Thay đổi con trỏ khi hover */
   
   &:hover {
      color: #FF5733; /* Màu chữ khi hover */
   }
`;
export const WrapperCardStyle = styled(Card)`
    width: 200;
    & img{
        weight: 200px;
        height: 200px;
    }
    position: relative;
`
export const StyleNameProduct= styled.div`
    font-size: 12px;
    color: rgb(56,56,61);
    font-weight: 400;
    line-height:16px
`
export const StyleReportText=styled.div`
    font-size: 11px;
    color: rgb(128,128,137);
    display: flex;
    align-items: center;
    margin: 6px 0 0;
`
export const StylePriceProduct=styled.div`
    font-size: 16px;
    color: rgb(255,66,78);
    line-height:150%;
    line-weight:600;
    text-align: left;
    margin: 8px 0;
`
export const StyleDiscountProduct=styled.span`
    font-size: 10px;
    color: rgb(255,66,78);
    line-height:150%;
    line-weight:600;
`
export const WrapperStyleTextSell=styled.span`
    font-size: 15px;
    line-height: 24px;
    color: rgb(120,120,120);
`
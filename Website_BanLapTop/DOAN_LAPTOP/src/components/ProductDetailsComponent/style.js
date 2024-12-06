import styled from "styled-components";
import { Image, Col, InputNumber } from "antd";

export const WrapperStyleColImg = styled(Col)`
   display: flex;
   justify-content: center;
   margin: 7px; /* Thêm khoảng cách giữa các ảnh nhỏ */
`;

export const WrapperStyleImgSmall = styled(Image)`
   width: 500px; /* Tăng kích thước ảnh nhỏ */
   height: 50px;
   object-fit: cover;
   cursor: pointer;
   margin-bottom: 10px; /* Thêm khoảng cách giữa ảnh nhỏ */
   &:hover {
      opacity: 0.8;
   }
`;

// Các styled-components khác giữ nguyên
export const WrapperStyleNameProduct = styled.h1`
  color: rgb(36, 36, 36);
  font-size: 24px;
  font-weight: 300px;
  line-height: 34px;
  word-break: break-word;
  padding: 10px;
`;

export const WrapperStyleTextSell = styled.span`
  font-size: 15px;
  line-height: 24px;
  color: rgb(120, 120, 120);
`;

export const StylePriceProduct = styled.div`
  color: rgb(250, 250, 250);
  border-radius: 4px;
`;

export const StylePriceTextProduct = styled.h1`
  font-size: 32px;
  line-height: 150%;
  font-weight: 600;
  text-align: left;
  margin: 8px 0;
  padding: 15px;
  color: black;
`;

export const WrapperAddressProduct = styled.div`
  span.address {
    text-decoration: underline;
    font-size: 16px;
    line-height: 24px;
    font-weight: 500;
    white-space: nowrap;
    overflow: hidden;
    text-overflow: ellipsis;
  }
  span.change-address {
    color: rgb(11, 116, 229);
    font-size: 16px;
    font-weight: 500;
    line-height: 24px;
  }
`;

export const WrapperQuatityProduct = styled.h1`
  font-size: 14px;
  padding: 10px;
  margin: 8px 0;
`;

export const WrapperbtnQuatityProduct = styled.h1`
  font-size: 14px;
  padding: 10px;
  margin: 8px 0;
  border: 1px solid #ccc;
  align-items: center;
  width: 150px;
`;

export const WrapperInputNumber = styled(InputNumber)`
  &.ant-input-number.ant-input-number-sm {
    width: 40px;
  }
`;

export const WrapperProduct = styled.div`
  margin: 50px auto 0;
  span {
    color: #007bff;
    display: block;
    margin-bottom: 15px;
    font-size: 20px;
    font-family: 'Arial', sans-serif;
    transition: transform 0.3s ease, color 0.3s ease;
  }

  span:hover {
    transform: translateX(10px);
    color: #ff6f61;
  }

  span.cauhinh,
  span.kichthuoc,
  span.cpu,
  span.ram,
  span.manhinh,
  span.pin {
    font-weight: 400;
    color: #333;
    font-size: 15px;
  }

  span.mota {
    font-size: 16px;
    color: #555;
    line-height: 1.6;
    font-weight: 400;
    margin-bottom: 20px;
  }
`;
export const WrapperReviewItem = styled.div`
  margin-top: 15px;
  padding: 10px;
  border: 1px solid #f0f0f0;
  border-radius: 5px;
  background-color: #fafafa;
  
  p {
    font-size: 14px;
    color: #333;
    line-height: 1.5;
  }
`;
export const WrapperReviewSection = styled.div`
   padding: 20px;
   margin: 0; // Loại bỏ khoảng margin
   background-color: #f9f9f9;
   border-radius: 8px;
   box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
   height: 100%; // Chiều cao full bên trong

   h2 {
      font-size: 20px;
      font-weight: bold;
      color: #333;
   }

   p {
      font-size: 14px;
      color: #666;
      line-height: 1.5;
   }
`;



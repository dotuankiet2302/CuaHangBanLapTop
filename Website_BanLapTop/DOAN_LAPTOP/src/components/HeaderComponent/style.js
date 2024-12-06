import styled from "styled-components";
import { Row } from "antd";

export const WrapperHeader = styled(Row)`
  padding: 10px 120px;
  background-color: rgb(26, 148, 255);
  margin: 0;
`;
export const LogoWrapper = styled.div`
  display: flex;
  flex-direction: row; /* Đặt logo dưới chữ */
  align-items: center; /* Căn giữa logo */
`;
export const WrapperTextHeader = styled.span`
  font-size: 18px;
  color: #fff;
  font-weight: bold;
  text-align: center;
`;

export const WrapperHeaderAccout = styled.div`
  display: flex;
  align-items: center;
  gap: 10px;
  font-size: 12px;
  color: #fff;
`;

export const WrapperHeaderSmall = styled.span`
  font-size: 18px;
  color: #fff;
`;

export const WrapperHeaderIcon = styled.span`
  font-size: 30px;
  color: #fff;
`;
export const WrapperTypeProduct = styled.div`
  display: flex;
  gap: 24px;
  align-items: center;
  justify-content: flex-start;
  border-bottom: 1px solid red;
  font-size: 18px;
  margin-left: 100px; 
  height: 44px;

  & a {
    font-weight: bold;
    color: gray; 
    text-decoration: none; 

    &:hover, 
    &:focus { 
      color: lightblue; 
      text-decoration: underline; 
    }
  }

  & .active {
    color: black; 
  }
`;

export const WrapperImage = styled.div`
   width: 32px;
   height: 32px;
   padding: 0;
   border: 1px solid #e8e8e8;
   border-radius: 50%;
   background-color: #fff;
   overflow: hidden;
   display: flex;
   align-items: center;
   justify-content: center;

   img {
      width: 100%;
      height: 100%;
      object-fit: cover;
      border-radius: 50%;
   }
`;

export const WrapperDropdown = styled.div`
  position: absolute;
  top: 100%;
  right: 0;
  width: 250px;
  background: white;
  border-radius: 8px;
  box-shadow: 0 2px 8px rgba(0,0,0,0.15);
  z-index: 1000;
  margin-top: 8px;

  &::before {
    content: '';
    position: absolute;
    top: -8px;
    right: 20px;
    border-left: 8px solid transparent;
    border-right: 8px solid transparent;
    border-bottom: 8px solid white;
  }
`;

export const WrapperDropdownContent = styled.div`
  padding: 16px;

  h3 {
    color: #333;
    font-size: 14px;
    margin-bottom: 16px;
    text-align: center;
    font-weight: 500;
  }

  button {
    width: 100%;
    padding: 8px 16px;
    margin-bottom: 8px;
    border: none;
    border-radius: 4px;
    cursor: pointer;
    font-size: 14px;
    transition: all 0.3s;

    &:first-of-type {
      background-color: #1890ff;
      color: white;

      &:hover {
        background-color: #40a9ff;
      }
    }

    &:last-of-type {
      background-color: #f5f5f5;
      color: #333;

      &:hover {
        background-color: #e8e8e8;
      }
    }
  }
`;
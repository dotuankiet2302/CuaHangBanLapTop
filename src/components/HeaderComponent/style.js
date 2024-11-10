import styled from "styled-components";
import { Row } from "antd";

export const WrapperHeader = styled(Row)`
  padding: 10px 120px;
  background-color: rgb(26, 148, 255);
  margin: 0;
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

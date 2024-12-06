import styled from "styled-components";
import {Button, Input} from "antd";

export const WrapperTitle = styled.h1`
   font-size: 38px;
   color: #ff6b00; // màu cam đậm
   text-align: center;
   font-weight: 700;
   margin-bottom: 30px;
   text-transform: uppercase;
   font-family: "Arial", sans-serif;
   align-items: center;
`;
export const WrapperContainer = styled.div`
   padding: 20px;
   max-width: 600px;
   margin: 0 auto;
   margin: 50px auto 0 250px;
`;

export const WrapperFormGroup = styled.div`
   display: flex;
   margin-bottom: 15px;
`;

export const WrapperLabel = styled.label`
   width: 150px;
   text-align: right;
   margin-right: 15px;
   color: #333;
   font-weight: bold;
   font-size: 18px;
`;

export const WrapperInput = styled(Input)`
   flex: 1;
   border-radius: 5px;
   border-color: #d9d9d9;
`;

export const WrapperEditButton = styled(Button)`
   margin-left: 10px;
`;

export const WrapperPopupButton = styled(Button)`
   display: block;
   margin: 20px auto;
   width: 120px;
`;

export const WrapperModalContent = styled.div`
   .ant-form-item {
      margin-bottom: 15px;
   }
`;

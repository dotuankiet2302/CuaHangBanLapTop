import styled from "styled-components";
import { Image, Col, InputNumber } from "antd";

export const WrapperStyleImgSmall= styled(Image)`
     height: 64px;
     width: 64px;
`
export const WrapperStyleColImg=styled(Col)`
    flex-basics: unset;
    display: flex;
`
export const WrapperStyleNameProduct=styled.h1`
    color: rgb(36,36,36);
    font-size: 24px;
    font-weight: 300px;
    line-height: 34px;
    word-break: break-word;
    padding: 10px
`
export const WrapperStyleTextSell=styled.span`
    font-size: 15px;
    line-height: 24px;
    color: rgb(120,120,120);
`
export const StylePriceProduct=styled.div`
    color: rgb(250,250,250);
    border-radius: 4px;
   
`
export const StylePriceTextProduct = styled.h1`
  font-size: 32px;
  line-height: 150%;
  line-weight: 600;
  text-align: left;
  margin: 8px 0;
  padding: 15px;
  color: black;
`
export const WrapperAddressProduct= styled.div`
    span.address{
    text-decoration: underline;
    font-size: 16px;
    line-height: 24px;
    font-weight: 500;
    white-space: nowrap;
    overflow: hidden;
    text-overflow: ellipsis;
    };
    span.change-address{
        color: rgb(11,116,229);
        font-size: 16px;
        font-weight: 500;
        line-height: 24px;
    }
`
export const WrapperQuatityProduct = styled.h1`
    font-size: 14px;
     padding: 10px;
     margin: 8px 0;
`
export const WrapperbtnQuatityProduct = styled.h1`
    font-size: 14px;
     padding: 10px;
     margin: 8px 0;
     border: 1px solid #ccc;
     align-items: center;
     width: 150px;
`
export const WrapperInputNumber= styled(InputNumber)`
    &.ant-input-number.ant-input-number-sm{
        width: 40px;
    }
`

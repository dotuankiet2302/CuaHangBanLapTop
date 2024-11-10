import styled from "styled-components"
import { Card } from "antd"

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
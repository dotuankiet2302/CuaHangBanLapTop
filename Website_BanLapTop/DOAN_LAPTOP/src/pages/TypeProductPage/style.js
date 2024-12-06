import { Col } from "antd";
import styled from "styled-components";

export const WrapperProduct=styled(Col)`
  display: flex;
  gap: 15px;
  margin-top: 20px;
  justify-content: center;
  flex-wrap: wrap;
  
  // Đảm bảo mỗi phần tử con chiếm khoảng 15% chiều rộng, có thể hiển thị 6 phần tử trên một dòng
  > * {
    flex-basis: calc(100% / 6);
    max-width: calc(100% / 6 );
  }
`
export const WrapperNavbarProduct=styled.div`
   background: #fff;
    margin-Right: '10px';
    padding: 10px;
     border-Radius:6px;
`
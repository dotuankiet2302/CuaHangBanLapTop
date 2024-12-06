import styled from "styled-components";
import ButtonComponent from "../../components/ButtonComponent/ButtonComponent";

export const WrapperTypeProduct= styled.div`
    display: flex;
    gap: 24px;
    align-items: center;
    justify-content: flex-start;
    border-bottom: 1px solid red;
    height: 44px;
`
export const WrapperButtonMore=styled(ButtonComponent)`
    &:hover{
        color: #fff;
        background: rgb(13,92,182);
        span{ 
            color: #fff; 
        }
    }
        width: 100%;
        text-align: center;
        
`
export const WrapperProduct=styled.div`
   display: flex;
  gap: 15px;
  margin-top: 20px;
  justify-content: center;
  flex-wrap: wrap;
  
  // Đảm bảo mỗi phần tử con chiếm khoảng 15% chiều rộng, có thể hiển thị 6 phần tử trên một dòng
  > * {
    flex-basis: calc(100% / 6 - 15px);
    max-width: calc(100% / 6 - 15px);
  }
`
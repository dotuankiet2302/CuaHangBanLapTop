import styled from "styled-components";

const Wrapper = styled.div`
   padding: 20px;
   max-width: 2000px;
   margin: 0 auto;
   font-family: Arial, sans-serif;
   background-color: #f7f7f7;
`;

const Title = styled.h1`
   text-align: center;
   color: #F8R8C1;
   margin-bottom: 40px;
   font-size: 40px;
   font-weight: bold;
`;

const Table = styled.div`
   display: flex;
   flex-direction: column;
   gap: -50px; /* Giảm khoảng cách giữa các hàng */
`;

const Row = styled.div`
   display: grid;
   grid-template-columns: 1fr 1.5fr 1.5fr 1fr 1.5fr 1fr; /* Điều chỉnh tỷ lệ các cột */
   gap: -50px; /* Khoảng cách giữa các cột giảm xuống */
   background-color: #ffffff;
   padding: 5px;
   border-radius: 8px;
   box-shadow: 0 2px 8px rgba(0, 0, 0, 0.1);
`;

const TitleRow = styled(Row)`
   font-weight: bold;
   background-color: #f1f1f1;
   color: #333;
   text-align: center;
`;

const TitleCell = styled.div`
   font-weight: bold;
   background-color: #f1f1f1;
   color: #333;
   text-align: center;
`;

const Cell = styled.div`
   display: flex;
   justify-content: center;
   align-items: center;
   font-size: 16px;
   padding: 5px 5px;
   background-color: #ffffff;
   border-radius: 8px;
   color: #555;
   overflow: hidden;
   white-space: nowrap;
   text-overflow: ellipsis;
   font-weight: bold;
   font-size: 20px;
`;

const ProductImage = styled.img`
   width: 60px;
   height: 60px;
   object-fit: cover;
   border-radius: 8px;
`;

const NoOrders = styled.p`
   text-align: center;
   font-size: 14px;
   color: #888;
   font-style: italic;
`;

const Button = styled.button`
   background-color: #ffcc00;
   color: white;
   padding: 8px 16px;
   border: none;
   border-radius: 5px;
   cursor: pointer;
   font-size: 16px;

   &:hover {
      background-color: #ffb300;
   }
`;

export {Wrapper, Title, Table, Row, Cell, ProductImage, NoOrders, Button, TitleRow, TitleCell};

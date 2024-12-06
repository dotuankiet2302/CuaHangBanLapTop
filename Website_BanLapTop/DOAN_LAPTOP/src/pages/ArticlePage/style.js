import styled from "styled-components";

// Wrapper tổng cho bài viết
export const WrapperContent = styled.div`
  padding: 20px;
  max-width: 1200px;
  margin: auto;
  background: linear-gradient(to bottom,  #ffffff, #e3f2fd);
  border-radius: 15px;
  box-shadow: 0 8px 15px rgba(0, 0, 0, 0.2);
  transition: transform 0.3s ease;
  &:hover {
    transform: scale(1.02);
  }
`;

// Tiêu đề
export const Title = styled.h1`
  text-align: center;
  font-size: 2rem;
  color: #FF6F61;
  font-family: "Arial", sans-serif;
  text-transform: uppercase;
`;

// Đoạn văn
export const Paragraph = styled.p`
  font-size: 1rem;
  line-height: 1.6;
  color: #333;
  text-align: justify;
  
  // Cải tiến chữ cái đầu dòng
  &::first-letter {
    font-size: 2rem; /* Tăng kích thước chữ cái đầu dòng */
    font-weight: bold; 
    color: #4682B4; 
    float: left; /* Đặt chữ cái đầu dòng bên trái */
  }
`;

// Hình ảnh bên trái
export const WrapperImageLeft = styled.div`
  margin-right: 25px;
  img {
    width: 220px;
    border-radius: 15px;
    box-shadow: 0 4px 10px rgba(0, 0, 0, 0.2);
    transition: transform 0.3s ease;
    &:hover {
      transform: scale(1.1);
    }
  }
`;

// Hình ảnh bên phải
export const WrapperImageRight = styled.div`
  margin-left: 25px;
  img {
    width: 210px;
    border-radius: 15px;
    box-shadow: 0 4px 10px rgba(0, 0, 0, 0.2);
    transition: transform 0.3s ease;
    &:hover {
      transform: scale(1.1);
    }
  }
`;

// Hình ảnh ở giữa
export const WrapperImageCenter = styled.div`
  margin: 20px auto;
  img {
    width: 300px;
    border-radius: 15px;
     transition: transform 0.3s ease;
    box-shadow: 0 4px 10px rgba(0, 0, 0, 0.3);
    &:hover {
      transform: scale(1.1);
    }
  }
`;

// Danh sách hình ảnh
export const WrapperImageList = styled.div`
  display: flex;
  flex-wrap: wrap;
  gap: 20px;
  justify-content: center;
  img {
    width: 150px;
    height: 150px;
    object-fit: cover;
    border-radius: 10px;
    box-shadow: 0 2px 5px rgba(0, 0, 0, 0.1);
    transition: all 0.2s ease-in-out;
    &:hover {
      transform: scale(1.2);
      box-shadow: 0 4px 10px rgba(0, 0, 0, 0.3);
    }
  }
`;

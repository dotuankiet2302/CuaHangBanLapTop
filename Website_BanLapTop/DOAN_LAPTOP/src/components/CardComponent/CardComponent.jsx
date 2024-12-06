import React, { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import { AiOutlineEye, AiOutlineShoppingCart } from "react-icons/ai";
import { Tabs, TabList, TabPanel, Tab } from "react-tabs";
import { useSelector } from "react-redux";
import { Pagination, Rate } from "antd"; // Thêm import cho Rate
import "./styles.scss";
import { UnderlinedText, StyledProductTitle } from "./style";
import { ROUTERS } from "../../utils/router";

const CardComponent = () => {
   const [featProducts, setFeatProducts] = useState(null);
   const [error, setError] = useState(null);
   const [currentPage, setCurrentPage] = useState(1); // Trang hiện tại cho "Tất cả sản phẩm"
   const [currentCategoryPage, setCurrentCategoryPage] = useState({}); // Trang hiện tại cho từng MAHANG
   const [pageSize] = useState(8); // Số sản phẩm trên mỗi trang
   const navigate = useNavigate();
   const searchResults = useSelector((state) => state.search.searchResults);
   const noResultsFound = useSelector((state) => state.search.noResultsFound);

   useEffect(() => {
      if (searchResults && searchResults.length > 0) {
         setFeatProducts(searchResults);
      } else if (!noResultsFound) {
         const fetchData = async () => {
            try {
               const response = await fetch("http://localhost:8000/api-product.php");
               if (!response.ok) throw new Error("Network response was not ok");
               const data = await response.json();
               setFeatProducts(data);
            } catch (error) {
               console.error("Error fetching data:", error);
               setError(error.message);
            }
         };
         fetchData();
      }
   }, [searchResults, noResultsFound]);

   const groupProductsByMAHANG = (data) => {
      const groupedData = { ALL: { title: "Tất cả sản phẩm", laptop: [] } };
      data.forEach((item) => {
         groupedData.ALL.laptop.push(item);

         if (!groupedData[item.MAHANG]) {
            groupedData[item.MAHANG] = {
               title: <StyledProductTitle>{item.TENHANG}</StyledProductTitle>,
               laptop: [],
            };
         }
         groupedData[item.MAHANG].laptop.push(item);
      });
      return groupedData;
   };

   const renderFeaturedProducts = (data, page, setPage) => {
      const indexOfLastProduct = page * pageSize;
      const indexOfFirstProduct = indexOfLastProduct - pageSize;
      const currentProducts = data.slice(indexOfFirstProduct, indexOfLastProduct);

      return (
         <>
            <div className='row'>
               {currentProducts.map((item) => {
                  let imagePath;
                  try {
                     imagePath = require(`../../assets/users/images/featured/${item.ANHBIA}`);
                  } catch (error) {
                     console.error(`Không tìm thấy hình ảnh: ${item.ANHBIA}`, error);
                     imagePath = "path_to_default_image.jpg"; // Hình ảnh mặc định nếu không tìm thấy
                  }

                  return (
                     <div className='col-lg-3 col-md-4 col-sm-6 col-xs-12' key={item.MALAP}>
                        <div className='feature__item pl-pr-10'>
                           <div className='feature__item__pic' style={{ backgroundImage: `url(${imagePath})` }}>
                              <ul className='feature__item__pic__hover'>
                                 <li onClick={() => navigate(`${ROUTERS.USER.DETAIL}/${item.MALAP}`)}>
                                    <AiOutlineEye />
                                 </li>
                                 <li onClick={() => navigate(ROUTERS.USER.CART)}>
                                    <AiOutlineShoppingCart />
                                 </li>
                              </ul>
                           </div>
                           <div className='feature__item__text'>
                              <UnderlinedText onClick={() => navigate(`${ROUTERS.USER.DETAIL}/${item.MALAP}`)}>
                                 {item.TENLAP}
                              </UnderlinedText>
                              {/* Thêm ngôi sao đánh giá ngay sau TENLAP */}
                              <Rate 
                                 tooltips={['terrible', 'bad', 'normal', 'good', 'wonderful']}
                                 defaultValue={item.RATING || 0} 
                                 onChange={(value) => console.log(value)} // Thay đổi giá trị ngôi sao
                                 style={{ margin: '5px 0', color: 'gold' }} // Thay đổi màu sắc
                              />
                              {item.RATING ? <span>{['terrible', 'bad', 'normal', 'good', 'wonderful'][item.RATING - 1]}</span> : null}
                              {/* <h5>{item.GIABAN} <span>VNĐ</span></h5> */}
                              <h5> {parseInt(item.GIABAN).toLocaleString('vi-VN')}đ</h5>
                           </div>
                        </div>
                     </div>
                  );
               })}
            </div>
            <Pagination
               current={page}
               pageSize={pageSize}
               total={data.length}
               onChange={setPage} // Cập nhật trang khi người dùng thay đổi
               showSizeChanger={false} // Tùy chọn để hiển thị kích thước trang
               showTotal={(total) => `Total ${total} items`} // Hiển thị tổng số sản phẩm
            />
         </>
      );
   };

   const groupedData = featProducts ? groupProductsByMAHANG(featProducts) : {};

   if (error) {
      return <div className='error'>Error: {error}</div>;
   }

   if (!featProducts) {
      return <div className='loader'>Loading...</div>;
   }

   if (noResultsFound) {
      return <div style={{ textAlign: "center", color: "red" }}>Không tìm thấy sản phẩm</div>;
   }

   return (
      <div className='container'>
         <div className='featured'>
            <div className='selection-title'>
               <h2>Danh mục sản phẩm</h2>
            </div>
            <Tabs>
               <TabList>
                  <Tab>ALL</Tab>
                  {Object.keys(groupedData)
                     .filter((key) => key !== "ALL")
                     .map((key) => (
                        <Tab key={key}>{groupedData[key].title}</Tab>
                     ))}
               </TabList>
               <TabPanel>{renderFeaturedProducts(groupedData.ALL.laptop, currentPage, setCurrentPage)}</TabPanel>
               {Object.keys(groupedData)
                  .filter((key) => key !== "ALL")
                  .map((key) => (
                     <TabPanel key={key}>
                        {renderFeaturedProducts(groupedData[key].laptop, currentCategoryPage[key] || 1, (page) =>
                           setCurrentCategoryPage((prev) => ({ ...prev, [key]: page }))
                        )}
                     </TabPanel>
                  ))}
            </Tabs>
         </div>
      </div>
   );
};

export default CardComponent;
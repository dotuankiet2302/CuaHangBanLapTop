import React, { useEffect, useState } from 'react';
import { Link, useNavigate } from 'react-router-dom';
import { AiOutlineEye, AiOutlineShoppingCart } from 'react-icons/ai';
import { Tabs, TabList, TabPanel, Tab } from 'react-tabs';
import { useSelector } from 'react-redux';
import './styles.scss';
import { ROUTERS } from '../../utils/router';

const CardComponent = () => {
  const [featProducts, setFeatProducts] = useState(null);
  const [error, setError] = useState(null);
  const navigate = useNavigate();
  const searchResults = useSelector((state) => state.search.searchResults);
  const noResultsFound = useSelector((state) => state.search.noResultsFound); // Lấy noResultsFound từ Redux

  // useEffect(() => {
  //   if (searchResults && searchResults.length > 0) {
  //     setFeatProducts(searchResults); // Cập nhật sản phẩm nổi bật bằng kết quả tìm kiếm
  //   } else {
  //     const fetchData = async () => {
  //       try {
  //         const response = await fetch('http://localhost:8000/api-product.php');
  //         if (!response.ok) throw new Error('Network response was not ok');
  //         const data = await response.json();
  //         setFeatProducts(data);
  //       } catch (error) {
  //         console.error('Error fetching data:', error);
  //         setError(error.message);
  //       }
  //     };
  //     fetchData();
  //   }
  // }, [searchResults]); // Chạy lại khi searchResults thay đổi

  useEffect(() => {
    if (searchResults && searchResults.length > 0) {
      setFeatProducts(searchResults); // Cập nhật sản phẩm nổi bật bằng kết quả tìm kiếm
    } else if (!noResultsFound) {
      // Nếu không tìm thấy kết quả, không fetch dữ liệu sản phẩm
      const fetchData = async () => {
        try {
          const response = await fetch('http://localhost:8000/api-product.php');
          if (!response.ok) throw new Error('Network response was not ok');
          const data = await response.json();
          setFeatProducts(data);
        } catch (error) {
          console.error('Error fetching data:', error);
          setError(error.message);
        }
      };
      fetchData();
    }
  }, [searchResults, noResultsFound]);

  const groupProductsByMAHANG = (data) => {
    const groupedData = {};
    data.forEach((item) => {
      if (!groupedData[item.MAHANG]) {
        groupedData[item.MAHANG] = {
          title: item.TENHANG,
          laptop: [],
        };
      }
      groupedData[item.MAHANG].laptop.push(item);
    });
    return groupedData;
  };

  const renderFeaturedProducts = (data) => {
    const groupedData = groupProductsByMAHANG(data);
    const tabList = [];
    const tabPanels = [];

    Object.keys(groupedData).forEach((key) => {
      if (groupedData[key].laptop && groupedData[key].laptop.length > 0) {
        tabList.push(<Tab key={key}>{groupedData[key].title}</Tab>);
        
        const tabPanel = groupedData[key].laptop.map((item) => {
          let imagePath;
          try {
            imagePath = require(`../../assets/users/images/featured/${item.ANHBIA}`);
          } catch (error) {
            console.error(`Không tìm thấy hình ảnh: ${item.ANHBIA}`, error);
            imagePath = 'path_to_default_image.jpg'; // Hình ảnh mặc định nếu không tìm thấy
          }

          return (
            <div className="col-lg-3 col-md-4 col-sm-6 col-xs-12" key={item.MALAP}>
              <div className="feature__item pl-pr-10">
                <div className="feature__item__pic" style={{ backgroundImage: `url(${imagePath})` }}>
                  <ul className="feature__item__pic__hover">
                    <li onClick={() => navigate(`${ROUTERS.USER.DETAIL}/${item.MALAP}`)}>
                      <AiOutlineEye />
                    </li>
                    <li>
                      <AiOutlineShoppingCart />
                    </li>
                  </ul>
                </div>
                <div className="feature__item__text">
                  <h6>
                    <Link to={`/${item.MALAP}`}>{item.TENLAP}</Link>
                  </h6>
                  <h5>{item.GIABAN}</h5>
                </div>
              </div>
            </div>
          );
        });

        tabPanels.push(<TabPanel key={key}><div className="row">{tabPanel}</div></TabPanel>);
      }
    });

    return (
      <Tabs>
        <TabList>{tabList}</TabList>
        {tabPanels}
      </Tabs>
    );
  };

  if (error) {
    return <div className="error">Error: {error}</div>;
  }

  if (!featProducts) {
    return <div className="loader">Loading...</div>;
  }

  // Không hiển thị danh sách nếu không tìm thấy kết quả
  if (noResultsFound) {
    return <div style={{ textAlign: 'center', color: 'red' }}>Không tìm thấy sản phẩm</div>;
  }


  return (
    <div className="container">
      <div className="featured">
        <div className="selection-title">
          <h2>Sản phẩm nổi bật</h2>
        </div>
        {renderFeaturedProducts(featProducts)}
      </div>
    </div>
  );
};

export default CardComponent;

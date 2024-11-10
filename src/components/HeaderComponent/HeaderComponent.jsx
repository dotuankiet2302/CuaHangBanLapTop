import React, { useState } from 'react';
import { Badge, Col } from 'antd';
import { WrapperHeader, WrapperHeaderAccout, WrapperHeaderIcon, WrapperTextHeader, WrapperTypeProduct } from './style';
import { UserOutlined, CaretDownOutlined, ShoppingCartOutlined } from '@ant-design/icons';
import ButtonInputSearch from '../ButtonInputSearch/ButtonInputSearch';
import { ROUTERS } from '../../utils/router';
import { Link, useNavigate } from "react-router-dom";
import { useDispatch } from 'react-redux';
import { setSearchResults } from '../../redux/searchSlice';

const HeaderComponent = () => {
  const [menus] = useState([
    { name: "Trang chủ", path: ROUTERS.USER.HOME },
    { name: "Cửa hàng", path: ROUTERS.USER.PRODUCTS },
    { name: "Bài viết", path: ROUTERS.USER.HOME },
    { name: "Liên hệ", path: ROUTERS.USER.PRODUCTS },
  ]);

  const dispatch = useDispatch();
  const navigate = useNavigate();
  const [noResultsFound, setNoResultsFound] = useState(false);

  const handleSearch = async (searchTerm) => {
    try {
        const response = await fetch(`http://localhost:8000/api-search.php?ten=${searchTerm}`);
        if (!response.ok) throw new Error('Network response was not ok');
        
        const data = await response.json();

        if (data.success && data.data.length === 0) {
            setNoResultsFound(true); 
            dispatch(setSearchResults([]));
        } else {
            setNoResultsFound(false); // Tìm thấy kết quả
            dispatch(setSearchResults(data.data)); // Cập nhật dữ liệu tìm kiếm
        }
    } catch (error) {
        console.error('Error fetching data:', error);
    }
};


  return (
    <div>
      <WrapperHeader gutter={50}>
        <Col span={5}><WrapperTextHeader>Laptop</WrapperTextHeader></Col>
        <Col span={13} style={{ display: 'flex', justifyContent: 'center' }}>
          <ButtonInputSearch
            size="large"
            textButton="Tìm Kiếm"
            placeholder="Input search text"
            onSearch={handleSearch}
          />
        </Col>
        <Col span={6}>
          <WrapperHeaderAccout>
            <WrapperHeaderIcon onClick={() => navigate(ROUTERS.USER.LOGIN)}><UserOutlined /></WrapperHeaderIcon>
            <div>
              <div>Login/ Logout</div>
              <div>Tài khoản <CaretDownOutlined /></div>
            </div>
            <div>
              <Badge count={4} size="small">
                <WrapperHeaderIcon onClick={()=> navigate(ROUTERS.USER.CART)}><ShoppingCartOutlined /></WrapperHeaderIcon>
              </Badge>
              <div>Giỏ hàng</div>
            </div>
          </WrapperHeaderAccout>
        </Col>
      </WrapperHeader>

      <WrapperTypeProduct>
        <ul style={{ display: 'flex', gap: '24px', listStyleType: 'none', padding: 0 }}>
          {menus.map((menu, menuKey) => (
            <li key={menuKey}>
              <Link to={menu.path}>{menu.name}</Link>
            </li>
          ))}
        </ul>
      </WrapperTypeProduct>

      {/* {noResultsFound && <div style={{ textAlign: 'center', marginTop: '20px', color: 'red' }}>Không tồn tại</div>} */}
    </div>
  );
};

export default HeaderComponent;

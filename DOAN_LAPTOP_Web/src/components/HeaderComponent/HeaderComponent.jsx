import React, { useState } from 'react';
import { Badge, Col, Row } from 'antd';
import { WrapperHeader, WrapperHeaderAccout, WrapperHeaderIcon, WrapperHeaderSmall, WrapperTextHeader, WrapperTypeProduct } from './style';
import { UserOutlined, CaretDownOutlined, ShoppingCartOutlined } from '@ant-design/icons';
import ButtonInputSearch from '../ButtonInputSearch/ButtonInputSearch';
import { ROUTERS } from '../../utils/router';
import { AiOutlineDownCircle } from "react-icons/ai";
import { Link, useNavigate } from "react-router-dom";

const HeaderComponent = () => {
  const navigate=useNavigate();
    const [menus, setMenus] = useState([
        { name: "Trang chủ", path: ROUTERS.USER.HOME },
        { name: "Cửa hàng", path: ROUTERS.USER.PRODUCTS },
       
        { name: "Bài viết", path: ROUTERS.USER.HOME},
        { name: "Liên hệ", path: ROUTERS.USER.PRODUCTS },
    ]);

    return (
        <div>
            <WrapperHeader gutter={50}>
                <Col span={5}><WrapperTextHeader>Laptop</WrapperTextHeader></Col>
                <Col span={13} style={{ display: 'flex', justifyContent: 'center' }}>
                    <ButtonInputSearch size="large" textButton="Tìm Kiếm" placeholder="Input search text" />
                </Col>
                <Col span={6}>
                    <WrapperHeaderAccout>
                        <WrapperHeaderIcon onClick={()=> navigate(ROUTERS.USER.LOGIN)}><UserOutlined /></WrapperHeaderIcon>
                        <div>
                            <WrapperHeaderSmall>Login/ Logout</WrapperHeaderSmall>
                            <div>
                                <WrapperHeaderSmall>Tài khoản</WrapperHeaderSmall> <CaretDownOutlined />
                            </div>
                        </div>
                        <div>
                            <Badge count={4} size="small">
                                <WrapperHeaderIcon><ShoppingCartOutlined /></WrapperHeaderIcon>
                            </Badge>
                            <WrapperHeaderSmall>Giỏ hàng</WrapperHeaderSmall>
                        </div>
                    </WrapperHeaderAccout>
                </Col>
            </WrapperHeader>
            <WrapperTypeProduct>
            <ul style={{ display: 'flex', gap: '24px', listStyleType: 'none', padding: 0 }}>
              {menus.map((menu, menuKey) => (
                <li key={menuKey}>
                  <Link 
                    to={menu.path}
                    className={menu.name === "Trang chủ" ? "active" : ""}
                    onClick={() => {
                      const newMenus = [...menus];
                      setMenus(newMenus);
                    }}
                  >
                    {menu.name}
                  </Link>
                </li>
              ))}
            </ul>
          </WrapperTypeProduct>

        </div>
    );
}

export default HeaderComponent;

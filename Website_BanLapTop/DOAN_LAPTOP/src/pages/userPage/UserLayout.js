import React from "react";
import {UserOutlined} from "@ant-design/icons";
import {Breadcrumb, Menu, theme} from "antd";
import Layout from "antd/es/layout";  // Import Layout riêng
import {useNavigate, useLocation} from "react-router-dom";
import {ROUTERS} from "../../utils/router";
import UserPage from "./userPage";
import PassWordPage from "./PassWordPage";

// Destructure Layout components riêng
const Header = Layout.Header;
const Content = Layout.Content;
const Footer = Layout.Footer;
const Sider = Layout.Sider;

const UserLayout = () => {
 const navigate = useNavigate();
   const location = useLocation();
   const [currentComponent, setCurrentComponent] = React.useState(<UserPage />);

   const {
      token: {colorBgContainer, borderRadiusLG},
   } = theme.useToken();
   const items2 = [
      {
         key: 'sub1',
         icon: <UserOutlined />,  // Thay vì dùng React.createElement
         label: 'Quản lý',
         children: [
            {
               key: '1',
               label: 'Thông tin cá nhân',
               onClick: () => setCurrentComponent(<UserPage />)
            },
            {
               key: '2',
               label: 'Đổi mật khẩu',
               onClick: () => setCurrentComponent(<PassWordPage />)
            }
         ]
      }
   ];
   
   // Đơn giản hóa items1
   const items1 = [
      {
         key: '1',
         label: 'HOME',
         onClick: () => navigate(ROUTERS.USER.HOME)
      }
   ];
   

   const getPageName = (pathname) => {
      switch (pathname) {
         case ROUTERS.USER.HOME:
            return "Trang chủ";
         case ROUTERS.USER.PASSINFO:
            return "Sản phẩm";
         case ROUTERS.USER.USERINFO:
            return "Thông tin cá nhân";
         default:
            return "App";
      }
   };
// Tạo mảng items cho Breadcrumb
      const breadcrumbItems = [
         {
            title: <span onClick={() => navigate(ROUTERS.USER.HOME)} style={{cursor: "pointer"}}>
               Trang chủ
            </span>
         },
         {
            title: <span onClick={() => navigate(ROUTERS.USER.USERINFO)} style={{cursor: "pointer"}}>
               Người dùng
            </span>
         },
         {
            title: getPageName(location.pathname)
         }
      ];
 return (
         <Layout>
            <Header style={{display: "flex", alignItems: "center"}}>
               <div className='demo-logo' />
               <Menu
                  theme='dark'
                  mode='horizontal'
                  defaultSelectedKeys={["1"]}
                  items={items1}
                  style={{flex: 1, minWidth: 0}}
               />
            </Header>
            <Content style={{padding: "0 48px"}}>
               {/* Thay thế Breadcrumb cũ bằng cách mới */}
               <Breadcrumb 
                  style={{margin: "16px 0"}}
                  items={breadcrumbItems}
               />
               
               <Layout style={{padding: "24px 0", background: colorBgContainer, borderRadius: borderRadiusLG}}>
                  <Sider style={{background: colorBgContainer}} width={200}>
                     <Menu
                        mode='inline'
                        defaultSelectedKeys={["1"]}
                        defaultOpenKeys={["sub1"]}
                        style={{height: "100%"}}
                        items={items2}
                     />
                  </Sider>
                  <Content style={{padding: "0 24px", minHeight: 280}}>
                     {currentComponent}
                  </Content>
               </Layout>
            </Content>
            <Footer style={{textAlign: "center"}}>
               Ant Design ©{new Date().getFullYear()} Created by Ant THUY
            </Footer>
         </Layout>
      );
 };

export default UserLayout;

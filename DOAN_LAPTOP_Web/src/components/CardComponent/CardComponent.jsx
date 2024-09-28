import { Card, Image } from 'antd'
import Meta from 'antd/es/card/Meta'
import React, {memo} from 'react'
import { StyleDiscountProduct, StyleNameProduct, StylePriceProduct, StyleReportText, WrapperCardStyle, WrapperStyleTextSell } from './style'
import  { StarOutlined } from '@ant-design/icons';
import logo from '../../assets/images/logo1.png';
import { ROUTERS } from '../../utils/router';
import feature1Img from "../../assets/users/images/featured/ANH1.png";
import feature2Img from "../../assets/users/images/featured/ANH2.png";
import feature3Img from "../../assets/users/images/featured/ANH3.png";
import feature4Img from "../../assets/users/images/featured/ANH4.png";
import feature5Img from "../../assets/users/images/featured/ANH5.png";
import feature6Img from "../../assets/users/images/featured/ANH6.png";
import feature7Img from "../../assets/users/images/featured/ANH1.png";
import feature8Img from "../../assets/users/images/featured/ANH2.png";
import feature9Img from "../../assets/users/images/featured/ANH9.jpg";
import feature10Img from "../../assets/users/images/featured/ANH10.png";
import feature11Img from "../../assets/users/images/featured/ANH11.jpg";
import { Tab, TabList, TabPanel, Tabs } from "react-tabs";
import { AiOutlineEye, AiOutlineShoppingCart } from "react-icons/ai";
import { Link, useNavigate } from "react-router-dom";
import './styles.scss';

const CardComponent = () => {
  const navigate = useNavigate();
  const featProducts= {
    all: {
      title:"ALL",
      products: [
        {
          img: feature1Img,
          name:"Hoa Sứ Hồng",
          price:500000,
        },
        {
          img: feature2Img,
          name:"Cây Hoa Giấy",
          price:450000,
        },
        {
          img: feature3Img,
          name:"Cây Xanh",
          price:390000,
        },
        {
          img: feature4Img,
          name:"Cây Tùng",
          price:450000,
        },
        {
          img: feature5Img,
          name:"Cây Hoa Nhai",
          price:180000,
        },
        {
          img: feature6Img,
          name:"Cây Sung",
          price:450000,
        },
        {
          img: feature7Img,
          name:"Cây Trang Vàng",
          price:300000,
        },
        {
          img: feature8Img,
          name:"Cây Phong lá đỏ",
          price:350000,
        },
      ],
    },
    hoasu: {
      title:"MACBOOK",
      products: [
        {
          img: feature1Img,
          name:"Hoa Sứ Hồng",
          price:500000,
        },
        {
          img: feature11Img,
          name:"Hoa Sứ Trắng",
          price:450000,
        },
      ],
    },
    hoatrang: {
      title:"ACER",
      products: [
        {
          img: feature7Img,
          name:"Hoa Trang Vàng",
          price:300000,
        },
        {
          img: feature9Img,
          name:"Hoa Trang Hồng",
          price:420000,
        },
        {
          img: feature10Img,
          name:"Hoa Trang Đỏ",
          price:450000,
        },
      ],
    },
    hoaxanh: {
      title:"DELL",
      products: [
        {
          img: feature3Img,
          name:"Hoa Xanh Bonsai",
          price:600000,
        },
        {
          img: feature6Img,
          name:"Hoa Sung",
          price:550000,
        },
      ],
    },
  };

  const renderFeaturedProducts =(data)=> {
    const tabList=[];
    const tabPanels=[];
   

    Object.keys(data).forEach((key,index)=> {
      tabList.push(<Tab key={index}>{data[key].title}</Tab>);
      const tabPanel=[];
      data[key].products.forEach((item,j)=>{
        tabPanel.push(<div className="col-lg-3 col-md-4 col-sm-6 col-xs-12" key={j}>
          <div className="feature__item pl-pr-10">
            <div className="feature__item__pic"
            style={{
              backgroundImage:`url(${item.img})`
            }}
            >
              <ul className="feature__item__pic__hover">
              <li onClick={() => navigate(ROUTERS.USER.DETAIL)}>
                    <AiOutlineEye />
                  </li>
                <li>
                  <AiOutlineShoppingCart/>
                </li>
              </ul>
            </div>
            <div className="feature__item__text">
              <h6>
                <Link to="">{item.name}</Link>
              </h6>
              <h5>{(item.price)}</h5>
            </div>
          </div>
        </div>
        );
      });
      tabPanels.push(tabPanel);
    });
    

    return (
      <Tabs>
          <TabList>{tabList}</TabList>
          {
            tabPanels.map((item,key)=>(
              <TabPanel key={key}>
                <div className="row">{item}</div>
              </TabPanel>
            ))}
      </Tabs>
    );
  };

  return (
        <>
        
      <div className="container">
        <div className="featured">
            <div className="selection-title">
              <h2>Sản phẩm nổi bật</h2>
            </div>
            {renderFeaturedProducts(featProducts)}
        </div>
      </div>
       
      </>
      );
    };

export default CardComponent
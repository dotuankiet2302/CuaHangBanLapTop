import { Col, Row, Image } from 'antd'
import React from 'react'
import feature1Img from "../../assets/users/images/featured/ANH1.png";
import ImgPro from '../../assets/images/logo2.png'
import ImgProSmall from '../../assets/images/logo3.png'
import {StylePriceProduct, StylePriceTextProduct, WrapperAddressProduct, WrapperbtnQuatityProduct, WrapperInputNumber, WrapperQuatityProduct, WrapperStyleColImg, WrapperStyleImgSmall, WrapperStyleNameProduct, WrapperStyleTextSell } from './style'
import  { StarFilled, MinusOutlined, PlusOutlined } from '@ant-design/icons';
import ButtonComponent from '../ButtonComponent/ButtonComponent'

const ProductDetailsComponent = () => {
     const onChange=()=>{}
  return (
    <div>
    <Row style={{ padding: '16px'}}>
      <Col span={8}>
            <Image src={feature1Img} alt="image product" preview="false"/>
            <Row style={{padding: '10px'}}>
                <WrapperStyleColImg span={4}>
                     <WrapperStyleImgSmall src={ImgProSmall} alt=" image small" preview="false"/>
                </WrapperStyleColImg>
                <WrapperStyleColImg span={4}>
                     <WrapperStyleImgSmall src={ImgProSmall} alt=" image small" preview="false"/>
                </WrapperStyleColImg>
                <WrapperStyleColImg span={4}>
                     <WrapperStyleImgSmall src={ImgProSmall} alt=" image small" preview="false"/>
                </WrapperStyleColImg>
                <WrapperStyleColImg span={4}>
                     <WrapperStyleImgSmall src={ImgProSmall} alt=" image small" preview="false"/>
                </WrapperStyleColImg>
                <WrapperStyleColImg span={4}>
                     <WrapperStyleImgSmall src={ImgProSmall} alt=" image small" preview="false"/>
                </WrapperStyleColImg>
                <WrapperStyleColImg span={4}>
                     <WrapperStyleImgSmall src={ImgProSmall} alt=" image small" preview="false"/>
                </WrapperStyleColImg>
            </Row>
      </Col>
      <Col span={14}>
          <WrapperStyleNameProduct>Áo thun giành cho bé gái mới nhất năm 2024</WrapperStyleNameProduct>
          <div>
          <StarFilled  style={{fontsize: '15px',color: "yellow"}}/>
          <StarFilled  style={{fontsize: '15px',color: "yellow"}}/>
          <StarFilled  style={{fontsize: '15px',color: "yellow"}}/>
          <WrapperStyleTextSell> | Đã bán 10+</WrapperStyleTextSell>
          </div>
          <StylePriceProduct>
              <StylePriceTextProduct> 200.000đ</StylePriceTextProduct>
          </StylePriceProduct>
          <WrapperAddressProduct>
               <span>Giao đến: </span>
               <span className='address'> Đông Hưng Thuận, Q12, TP.HCM</span> -
               <span className='change-address'> Đổi địa chỉ</span>
          </WrapperAddressProduct>
          <WrapperQuatityProduct>
              <div>Số lượng</div> 
             <div>
               <WrapperbtnQuatityProduct>
               <ButtonComponent  icon={<MinusOutlined />}></ButtonComponent>
               <WrapperInputNumber min={1} max={10} defaultValue={3} onChange={onChange} size="small"/>
               <ButtonComponent  icon={<PlusOutlined />}></ButtonComponent>
               </WrapperbtnQuatityProduct>
             </div> 
             <div style={{ display: 'flex', gap: '12px', alignItems: 'center'}}>
               <ButtonComponent
               size="large"
               border={false}
               style={{
                    background:'rgb(255,57,69)',
                    height: '48px',
                    width: '220px',
                    border: 'none',
                    borderRadius: '4px'
               }}
               textButton="Chọn mua"
               styleTextButton={{ color: '#fff', fontsize:'15px', fontweight: '700' }}
               />
               <ButtonComponent
               size="large"
               border={false}
               style={{
                    background: '#fff',
                    height: '48px',
                    width: '220px',
                    border: 'none',
                    borderRadius: '4px'
               }}
               textButton="Mua trả sau"
              
               />
          </div>
          </WrapperQuatityProduct>
      </Col>
      
    </Row>
    </div>
  )
}

export default ProductDetailsComponent
import React from 'react'
import TypeProduct from '../../components/TypeProduct/TypeProduct'
import { WrapperButtonMore, WrapperProduct, WrapperTypeProduct } from './style'
import SliderComponent from '../../components/SliderComponent/SliderComponent'
import slide1 from '../../assets/images/slide1.webp'
import slide2 from '../../assets/images/slide2.webp'
import slide4 from '../../assets/images/slide4.webp'
import CardComponent from '../../components/CardComponent/CardComponent'
import { StyleNameProduct } from '../../components/CardComponent/style'
import NavBarComponent from '../../components/NavBarComponent/NavBarComponent'
import ButtonComponent from '../../components/ButtonComponent/ButtonComponent'
import FooterComponent from '../../components/FooterComponent/FooterComponent'
import { Footer } from 'antd/es/layout/layout'
const HomePage = () => {
  //const arr = ['Shirt', 'Trousers', 'Dress']
  return (
    <div style={{ padding: '0 120px' }}>
      {/* <WrapperTypeProduct>
        {arr.map((item) => (
          <TypeProduct name={item} key={item} />
        ))}
      </WrapperTypeProduct> */}
      <div id="container" style={{background: '#e0ffff', padding: '0 120px', height:'1500px'}}>
      <SliderComponent arrImage={[slide1, slide2, slide4]} />
        
          {/* <WrapperProduct>
            <CardComponent/>
            <CardComponent/>
            <CardComponent/>
            <CardComponent/>
            <CardComponent/>
            <CardComponent/>
            <CardComponent/>
            <CardComponent/>
            <CardComponent/>
          </WrapperProduct> */}
      <CardComponent/>
      
      </div>
     <div style={{ width:'100%', display: 'flex', marginTop: '80px', justifyContent: 'center'}}>
        <WrapperButtonMore textButton="Xem thêm" type="outline" style={{border: '1px solid rgb(11,116,229)', color: 'rgb(11,116,229)', width: '240px', height: '38px', bordeRadius: '4px'}}  styleTextButton={{fontWeight: 500}}></WrapperButtonMore>
        
     </div>
     {/* <FooterComponent/> */}
    </div>
    
  )
  
}

export default HomePage

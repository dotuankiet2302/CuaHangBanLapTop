import React, { Fragment } from 'react'
import {Row, Col, Pagination} from 'antd'
import CardComponent from '../../components/CardComponent/CardComponent'
import NavBarComponent from '../../components/NavBarComponent/NavBarComponent'
import { WrapperNavbarProduct, WrapperProduct } from './style'

const TypeProductPage = () => {
   const onchange=()=>{}
  return (
   <>
   <div>
   <Row style={{padding: '0 120px', background: '#efefef', flexWrap: 'nowrap'}}>
        <WrapperNavbarProduct span={4} >
           <NavBarComponent/>
        </WrapperNavbarProduct>
        <Col span={20}>
        {/* <WrapperProduct >
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
       
       <Pagination style={{justifyContent: 'center', marginTop: '10px'}}defaultCurrent={2} total={50} onChange={onchange}/>
        </Col>
       
   </Row>
   
</div>
  </>
  )
}

export default TypeProductPage
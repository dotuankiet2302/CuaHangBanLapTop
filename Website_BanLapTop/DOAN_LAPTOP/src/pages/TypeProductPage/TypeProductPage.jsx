import React  from 'react'
import {Row, Col} from 'antd'
import CardComponent from '../../components/CardComponent/CardComponent'
import NavBarComponent from '../../components/NavBarComponent/NavBarComponent'
import { WrapperNavbarProduct } from './style'

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
        
       </WrapperProduct> */}
       <CardComponent/>
       {/* <Pagination style={{justifyContent: 'center', marginTop: '10px'}}defaultCurrent={2} total={50} onChange={onchange}/> */}
        </Col>
       
   </Row>
   
</div>
  </>
  )
}

export default TypeProductPage
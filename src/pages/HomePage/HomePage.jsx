import React from 'react';
import { useSelector } from 'react-redux';
import SliderComponent from '../../components/SliderComponent/SliderComponent';
import CardComponent from '../../components/CardComponent/CardComponent';
import { WrapperButtonMore } from './style';
import slide3 from '../../assets/images/Banner8.jpg';
import slide1 from '../../assets/images/Banner7.jpg';
import slide2 from '../../assets/images/Banner3.jpg';
import slide4 from '../../assets/images/Banner6.png';
import slide5 from '../../assets/images/Banner9.jpg';
import slide6 from '../../assets/images/Banner10.jpg';
import slide7 from '../../assets/images/Banner11.jpg';
import slide8 from '../../assets/images/Banner4.jpg';
import slide9 from '../../assets/images/Banner5.jpg';
const HomePage = () => {
  // Lấy kết quả tìm kiếm từ Redux store
  const searchResults = useSelector((state) => state.search.searchResults);

  return (
    <div style={{ padding: '0 120px' }}>
      <div id="container" style={{ background: '#ffff', padding: '0 120px', height: '1500px' }}>
        <SliderComponent arrImage={[slide1, slide2, slide3, slide4, slide5, slide6, slide7]} />
        
      
                  <CardComponent />
             

      </div>
      <div style={{ width: '100%', display: 'flex', marginTop: '200px', justifyContent: 'center' }}>
        <WrapperButtonMore textButton="Xem thêm" type="outline" style={{ border: '1px solid rgb(11,116,229)', color: 'rgb(11,116,229)', width: '240px', height: '38px', borderRadius: '4px' }} styleTextButton={{ fontWeight: 500 }} />
      </div>
    </div>
  );
}

export default HomePage;

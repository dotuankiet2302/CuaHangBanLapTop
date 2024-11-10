import { Col, Row, Image } from 'antd';
import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import { StylePriceProduct, StylePriceTextProduct, WrapperAddressProduct, WrapperbtnQuatityProduct, WrapperInputNumber, WrapperQuatityProduct, WrapperStyleColImg, WrapperStyleImgSmall, WrapperStyleNameProduct, WrapperStyleTextSell } from './style';
import { StarFilled, MinusOutlined, PlusOutlined } from '@ant-design/icons';
import ButtonComponent from '../ButtonComponent/ButtonComponent';
import axios from 'axios';

const ProductDetailsComponent = () => {
  const { id } = useParams(); // Lấy MALAP từ URL
  const [product, setProduct] = useState(null); // Khởi tạo state cho sản phẩm
  const [loading, setLoading] = useState(true); // State để quản lý trạng thái loading

  useEffect(() => {
    const fetchProductDetail = async () => {
      try {
        const response = await axios.get(`http://localhost:8000/api-productdetail.php?id=${id}`);
        setProduct(response.data); // Cập nhật sản phẩm với dữ liệu từ API
      } catch (error) {
        console.error('Error fetching product detail:', error);
      } finally {
        setLoading(false); // Đặt trạng thái loading thành false
      }
    };

    fetchProductDetail();
  }, [id]);

  if (loading) {
    return <div className="loader">Loading...</div>; // Hiển thị "Loading..." trong khi đang tải dữ liệu
  }

  if (!product) {
    return <div>Error: Product not found!</div>; // Hiển thị thông báo nếu không tìm thấy sản phẩm
  }

  // Đường dẫn hình ảnh sản phẩm
  const imagePath = require(`../../assets/users/images/featured/${product.ANHBIA}`);

  return (
    <div>
      <Row style={{ padding: '16px' }}>
        <Col span={8}>
          <Image src={imagePath} alt="image product" preview="false" />
          <Row style={{ padding: '10px' }}>
            {Array(6).fill().map((_, index) => (
              <WrapperStyleColImg key={index} span={4}>
                <WrapperStyleImgSmall src={imagePath} alt="image small" preview="false" />
              </WrapperStyleColImg>
            ))}
          </Row>
        </Col>
        <Col span={14}>
          <WrapperStyleNameProduct>{product.TENLAP}</WrapperStyleNameProduct>
          <div>
            <StarFilled style={{ fontSize: '15px', color: "yellow" }} />
            <StarFilled style={{ fontSize: '15px', color: "yellow" }} />
            <StarFilled style={{ fontSize: '15px', color: "yellow" }} />
            <WrapperStyleTextSell> | Đã bán </WrapperStyleTextSell>
          </div>
          <StylePriceProduct>
            <StylePriceTextProduct>{product.GIABAN}đ</StylePriceTextProduct>
          </StylePriceProduct>
          <WrapperAddressProduct>
            <span>Giao đến: </span>
            <span className='address'>Đông Hưng Thuận, Q12, TP.HCM</span> -
            <span className='change-address'> Đổi địa chỉ</span>
          </WrapperAddressProduct>
          <WrapperQuatityProduct>
            <div>Số lượng: {product.SOLUONGTON}</div>
            <div>
              <WrapperbtnQuatityProduct>
                <ButtonComponent icon={<MinusOutlined />}></ButtonComponent>
                <WrapperInputNumber min={1} max={10} defaultValue={3} size="small" />
                <ButtonComponent icon={<PlusOutlined />}></ButtonComponent>
              </WrapperbtnQuatityProduct>
            </div>
            <div style={{ display: 'flex', gap: '12px', alignItems: 'center' }}>
              <ButtonComponent
                size="large"
                border={false}
                style={{
                  background: 'rgb(255,57,69)',
                  height: '48px',
                  width: '220px',
                  border: 'none',
                  borderRadius: '4px'
                }}
                textButton="Chọn mua"
                styleTextButton={{ color: '#fff', fontSize: '15px', fontWeight: '700' }}
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
  );
};

export default ProductDetailsComponent;

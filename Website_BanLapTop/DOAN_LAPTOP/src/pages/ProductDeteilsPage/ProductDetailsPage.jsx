import React from 'react';
import ProductDetailsComponent from '../../components/ProductDetailsComponent/ProductDetailsComponent';

const ProductDetailsPage = () => {
  return (
    <div
      style={{
        padding: '0 120px',
        background: '#efefef',
        height: 'calc(100vh - 20px)', 
        overflowY: 'auto', // Thanh trượt nếu nội dung quá dài
        borderRadius: '8px',
        boxShadow: '0 2px 4px rgba(0, 0, 0, 0.1)',
        margin: 0, // Loại bỏ margin thừa
      }}
    >
      <ProductDetailsComponent />
    </div>
  );
};

export default ProductDetailsPage;

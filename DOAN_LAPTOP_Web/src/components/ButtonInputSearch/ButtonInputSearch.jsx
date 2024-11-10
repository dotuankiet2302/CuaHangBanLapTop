import React from 'react';
import { Button, Input } from 'antd';
import { SearchOutlined } from '@ant-design/icons';
import InputComponent from '../InputComponent/InputComponent';
import ButtonComponent from '../ButtonComponent/ButtonComponent';

const ButtonInputSearch = (props) => {
    const { size, textButton, placeholder } = props;

    return (
        <div style={{
            display: 'flex',
            alignItems: 'center',
            width: '500px', // Điều chỉnh chiều rộng của toàn bộ phần tìm kiếm
        }}>
        
             <InputComponent
                size={size}
                placeholder={placeholder}
                bordered={false}
                style={{
                    borderRadius: '4px 0 0 4px', // Bo góc trái
                    flex: 1, // Đảm bảo Input chiếm hết không gian còn lại
                    backgroundColor: '#fff',
                    boxShadow: '0 2px 4px rgba(0,0,0,0.1)', // Thêm bóng nhẹ cho Input
                    marginRight: '-1px', // Loại bỏ khoảng cách giữa Input và Button
                }}
            />
            <ButtonComponent
                size={size}
               // type="primary"
                icon={<SearchOutlined />}
                style={{
                    borderRadius: '0 4px 4px 0', // Bo góc phải
                    border: 'none',
                    backgroundColor: '#003366', // Màu nền của Button
                    color: '#fff', // Màu chữ của Button
                    boxShadow: '0 2px 4px rgba(0,0,0,0.1)', // Thêm bóng nhẹ cho Button
                }}
                textButton={textButton}
            />
        </div>
    );
}

export default ButtonInputSearch;

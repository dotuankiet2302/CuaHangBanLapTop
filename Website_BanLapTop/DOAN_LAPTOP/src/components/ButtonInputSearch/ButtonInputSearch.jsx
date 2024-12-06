import React, { useState } from 'react';
//import { Button, Input } from 'antd';
import { SearchOutlined } from '@ant-design/icons';
import InputComponent from '../InputComponent/InputComponent';
import ButtonComponent from '../ButtonComponent/ButtonComponent';

const ButtonInputSearch = (props) => {
    const { size, textButton, placeholder, onSearch } = props; 
    const [searchTerm, setSearchTerm] = useState(''); 

    const handleSearch = () => {
        if (onSearch) {
            console.log("Search term:", searchTerm); 
            onSearch(searchTerm);
        }
    };
    

    return (
        <div style={{
            display: 'flex',
            alignItems: 'center',
            width: '500px', 
        }}>
            <InputComponent
                size={size}
                placeholder={placeholder}
                bordered={false}
                value={searchTerm} 
                onChange={(e) => setSearchTerm(e.target.value)} 
                style={{
                    borderRadius: '4px 0 0 4px',
                    flex: 1, 
                    backgroundColor: '#fff',
                    boxShadow: '0 2px 4px rgba(0,0,0,0.1)', 
                    marginRight: '-1px', 
                }}
            />
            <ButtonComponent
                size={size}
                icon={<SearchOutlined />}
                onClick={handleSearch} 
                style={{
                    borderRadius: '0 4px 4px 0', 
                    border: 'none',
                    backgroundColor: '#003366', 
                    color: '#fff', 
                    boxShadow: '0 2px 4px rgba(0,0,0,0.1)', 
                }}
                textButton={textButton}
            />
        </div>
    );
}

export default ButtonInputSearch;

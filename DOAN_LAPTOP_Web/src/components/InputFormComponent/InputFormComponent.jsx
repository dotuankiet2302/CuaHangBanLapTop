import React, { useState } from 'react'
import { Input, Tooltip, Form } from 'antd'
import { WrapperInputStyle } from './style'
import { CloseCircleOutlined } from '@ant-design/icons';


const InputFormComponent = ({placeholder='Nhập Text',...rest }) => {
    const [valueInput, setvalueInput]=useState('')
    const [isTouched, setIsTouched] = useState(false);

  const handleChange = (e) => {
    setvalueInput(e.target.value);
  };

  const handleClear = () => {
    setvalueInput('');
    setIsTouched(true);
  };

  const isError = isTouched && !valueInput;
  return (
    //<WrapperInputStyle placeholder={placeholder} valueInput={valueInput} {...rest} />
    <Form.Item
    validateStatus={isError ? 'error' : ''}
    help={isError ? `Vui lòng nhập lại ${placeholder.toLowerCase()}` : ''}
    style={{ position: 'relative', width: '100%' }}
  >
    <Input
    value={valueInput}
    onChange={handleChange}
    onBlur={() => setIsTouched(true)}
    placeholder={placeholder}
    style={{ padding: '8px'}} 
    {...rest}
/>

    {valueInput && (
      <Tooltip title="Xóa dữ liệu">
        <CloseCircleOutlined
          onClick={handleClear}
          style={{
            position: 'absolute',
            left: 'auto',
            top: '50%', 
            transform: 'translateY(-50%)',
            cursor: 'pointer',
            color: '#ff4d4f',
            zIndex: 1,
          }}
        />
      </Tooltip>
    )}
  </Form.Item>
  
  )
}

export default InputFormComponent
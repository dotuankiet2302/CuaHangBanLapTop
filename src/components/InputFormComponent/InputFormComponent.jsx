import React from 'react';
import { Input, Form } from 'antd';

const InputFormComponent = ({ 
  placeholder = 'Nhập Text',
  value,
  onChange,
  onBlur,
  validateStatus,
  help,
  type = 'text',
  ...rest 
}) => {
  return (
    <Form.Item
      validateStatus={validateStatus}
      help={help}
      style={{ position: 'relative', width: '100%', marginBottom: '16px' }}
    >
      <Input
        placeholder={placeholder}
        value={value}
        onChange={onChange}
        onBlur={onBlur}
        type={type}
        status={validateStatus === 'error' ? 'error' : ''}
        allowClear
        style={{ padding: '8px' }}
        {...rest}
      />
    </Form.Item>
  );
};

export default InputFormComponent;
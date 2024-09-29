import React, {useState} from 'react'
import { Image, Form} from 'antd'
import {WapperLable, WrapperContainerLeft, WrapperContainerRight, WrapperTextLight } from './style'
import InputFormComponent from '../../components/InputFormComponent/InputFormComponent'
import ButtonComponent from '../../components/ButtonComponent/ButtonComponent'
import loginimg from '../../assets/images/login.png'
import { EyeFilled, EyeInvisibleFilled } from '@ant-design/icons'
import {Link, useNavigate } from 'react-router-dom'
import { ROUTERS } from '../../utils/router'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faLeftLong } from '@fortawesome/free-solid-svg-icons';

// hiển thị password
const SignInPage = () => {
  const navigate=useNavigate();// gọi trang đăng ký

  const [isShowPassword, setIsShowPassword] = useState(false);

  const togglePasswordVisibility = () => {
    setIsShowPassword(!isShowPassword);
  };

  // Thông báo hiển thị khi chưa nhập dữ liệu vào 2 field
  const [Email, setEmail]= useState('');
  const [isEmailTouched, setIsEmailTouched]= useState(false);

  const [Password, setPassword]= useState('');
  const [isPasswordTouched, setIsPassswordTouched]= useState('');

  const isEmailError= isEmailTouched && !Email;
  const isPasswordError= isPasswordTouched && !Password;

  const handleSubmit=()=>{
    setIsEmailTouched(true);
    setIsPassswordTouched(true);
    if(Email && Password){
      console.log("Form is valid");
    }
  };
  return (
    <div style={{ display: 'flex', gap: '5px', alignItems: 'center', justifyContent: 'center', background: 'rgba(0,0,0,0.53)', height:'1000px'}}>
      <div style={{ width: '800px', height: '500px', borderRadius: '6px', background: '#fff', display: 'flex'}}>
      <WrapperContainerLeft>
        <WapperLable>Đăng Nhập</WapperLable>
        <p style={{margin: '20px', color: '#ccc'}}>Đăng nhập và tạo tài khoản</p>
        <Form.Item validateStatus={isEmailError ? 'error': ''}
        help={isEmailError ? 'Vui lòng nhập Email': ''}
        onChange={(e)=> setEmail(e.target.value)}>
        <InputFormComponent placeholder="abc@gmail"/>
        </Form.Item>
        
        <div style={{ position:'relative'}}>
          <span
           onClick={togglePasswordVisibility} 
          style={{
            zIndex:10,
            position: 'absolute',
            top: '10px',
            right: '8px',
            cursor: 'pointer'
          }}>{
            isShowPassword ?(<EyeFilled/>):(<EyeInvisibleFilled/>)
          }
          </span>
          <Form.Item
          validateStatus={isPasswordError ? 'error': ''}
          help={isPasswordError ? 'Vui lòng nhập password': ''}
          onChange={(e)=> setPassword(e.target.value)}>
           <InputFormComponent placeholder="password" type={isShowPassword? "text": "password"}/>
          </Form.Item>
        </div>
        
       <ButtonComponent
               size="large"
               border={false}
               style={{
                    background:'rgb(255,57,69)',
                    height: '48px',
                    width: '100%',
                    border: 'none',
                    borderRadius: '4px',
                    margin: '5px 0px'
               }}
               textButton="Đăng nhập"
               styleTextButton={{ color: '#fff', fontsize:'15px', fontweight: '700' }}
               onClick={handleSubmit}
               />
               <WrapperTextLight>Chưa có tài khoản</WrapperTextLight>
               <p>Quên mật khẩu ?<WrapperTextLight onClick={()=> navigate(ROUTERS.USER.REGISTER)}>Tạo tài khoản</WrapperTextLight></p>
               <FontAwesomeIcon icon={faLeftLong} size="2x" style={{ color: "#B197FC", marginRight: '390px', marginTop: '30px'}} onClick={()=> navigate(ROUTERS.USER.HOME)}/>

      </WrapperContainerLeft>
      <WrapperContainerRight>
        <Image src={loginimg} preview={false} alt="image-logo" height="203px" width="203px"/>
        <h4>Laptop Store</h4>
      </WrapperContainerRight>
    </div>
    </div>
  )
}

export default SignInPage
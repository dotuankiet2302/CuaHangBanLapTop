import React, {useState} from 'react'
import { Form, Image } from 'antd'
import {WapperLable, WrapperContainerLeft, WrapperContainerRight, WrapperTextLight } from './style'
import InputFormComponent from '../../components/InputFormComponent/InputFormComponent'
import ButtonComponent from '../../components/ButtonComponent/ButtonComponent'
import register from '../../assets/images/register.png'
import { EyeFilled, EyeInvisibleFilled } from '@ant-design/icons'
import { useNavigate } from 'react-router-dom'
import { ROUTERS } from '../../utils/router'

const SignUpPage = () => {
  const navigate=useNavigate(); //chuyển sang trang đăng nhập

  const [isShowPassword1, setIsShowPassword1] = useState(false);
  const [isShowPassword2, setIsShowPassword2] = useState(false);
// thông báo chưa nhập
    const [Email, setEmail]= useState('');
    const [isEmailTouched, setIsEmailTouched]= useState(false);

    const [Password, setPassword]= useState('');
    const [isPasswordTouched, setIsPassswordTouched]= useState('');

    const [ConfirmPassword, setConfirmPassword]= useState('');
    const [isConfirmPasswordTouched, setIsConfirmPassswordTouched]= useState('');

    const isEmailError= isEmailTouched && !Email;
    const isPasswordError= isPasswordTouched && !Password;
    const isConfirmPasswordError= isConfirmPasswordTouched && !ConfirmPassword;

    const handleSubmit=()=>{
      setIsEmailTouched(true);
      setIsPassswordTouched(true);
      setIsConfirmPassswordTouched(true);
      if(Email && Password && ConfirmPassword){
        console.log("Form is valid");
      }
    };
  return (
    <div style={{ display: 'flex', gap: '10px', alignItems: 'center', justifyContent: 'center', background: 'rgba(0,0,0,0.53)', height:'1000px'}}>
    <div style={{ width: '800px', height: '550px', borderRadius: '6px', background: '#fff', display: 'flex'}}>
    <WrapperContainerLeft>
      <WapperLable>Đăng ký</WapperLable>
      <p style={{margin: '20px', color: '#ccc'}}>Đăng Ký để mua sản phẩm</p>
      <Form.Item validateStatus={isEmailError ? 'error': ''}
      help= {isEmailError ? 'Vui lòng nhập Email': ''}
      onChange={(e)=> setEmail(e.target.value)}>
        <InputFormComponent  placeholder="abc@gmail"/>
      </Form.Item>

      <div style={{ position:'relative'}}>
          <span
           onClick={()=>setIsShowPassword1(!isShowPassword1)} 
          style={{
            zIndex:10,
            position: 'absolute',
            top: '10px',
            right: '8px',
            cursor: 'pointer'
          }}>{
            isShowPassword1 ?(<EyeFilled/>):(<EyeInvisibleFilled/>)
          }
          </span>
          <Form.Item validateStatus={isPasswordError ? 'error': ''}
          help= {isPasswordError ? 'Vui lòng nhập Password': ''}
          onChange={(e)=> setPassword(e.target.value)}>
           <InputFormComponent placeholder="Password" type={isShowPassword1? "text": "password"}/>
          </Form.Item>
        </div>
  
        <div style={{ position:'relative'}}>
          <span
           onClick={()=>setIsShowPassword2(!isShowPassword2)} 
          style={{
            zIndex:10,
            position: 'absolute',
            top: '10px',
            right: '8px',
            cursor: 'pointer'
          }}>{
            isShowPassword2 ?(<EyeFilled/>):(<EyeInvisibleFilled/>)
          }
          </span>
          <Form.Item validateStatus={isConfirmPasswordError ? 'error': ''}
          help= {isConfirmPasswordError ? 'Vui lòng nhập Confirm Password': ''}
          onChange={(e)=> setConfirmPassword(e.target.value)}>
            <InputFormComponent placeholder="Confirm password" type={isShowPassword2? "text": "password"}/>
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
                  margin: '26px 0 10px'
             }}
             textButton="Đăng Ký"
             styleTextButton={{ color: '#fff', fontsize:'15px', fontweight: '700' }}
             onClick={handleSubmit}
             />
             <WrapperTextLight onClick={()=> navigate(ROUTERS.USER.LOGIN)}>Quay lại trang Đăng nhập ?</WrapperTextLight>
             
    </WrapperContainerLeft>
    <WrapperContainerRight>
      <Image src={register} preview={false} alt="image-logo" height="203px" width="203px"/>
      <h4>Laptop Store</h4>
    </WrapperContainerRight>
  </div>
  </div>
  )
}

export default SignUpPage
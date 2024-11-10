import React, {useState, useEffect} from "react";
import {Form, Image, message, Select} from "antd";
import {
   WapperLable, 
   WrapperContainerLeft, 
   WrapperContainerRight, 
   WrapperTextLight
} from "./style";
import InputFormComponent from "../../components/InputFormComponent/InputFormComponent";
import ButtonComponent from "../../components/ButtonComponent/ButtonComponent";
import register from "../../assets/images/register.png";
import {useNavigate} from "react-router-dom";
import {ROUTERS} from "../../utils/router";
import {EyeFilled, EyeInvisibleFilled} from "@ant-design/icons";

const {Option} = Select;

const SignUpPage = () => {
   const navigate = useNavigate();

   // States for form data
   const [formData, setFormData] = useState({
      fullName: "",
      email: "",
      password: "",
      confirmPassword: "",
      selectedTinh: ""
   });

   // States for UI
   const [isShowPassword1, setIsShowPassword1] = useState(false);
   const [isShowPassword2, setIsShowPassword2] = useState(false);
   const [loading, setLoading] = useState(false);
   const [tinhList, setTinhList] = useState([]);
   const [errors, setErrors] = useState({});

   // State for input touch tracking
   const [touched, setTouched] = useState({
      fullName: false,
      email: false,
      password: false,
      confirmPassword: false,
      selectedTinh: false
   });

   // Validation functions
   const isValidEmail = (email) => {
      return email.toLowerCase().endsWith('@gmail.com');
   };

   const isValidPassword = (password) => {
      const passwordRegex = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$/;
      return passwordRegex.test(password);
   };

   const getFieldError = (field) => {
      if (!touched[field]) return '';
      
      const value = formData[field];
      
      switch(field) {
         case 'fullName':
            return !value ? 'Vui lòng nhập họ tên' : '';
            
         case 'email':
            if (!value) return 'Vui lòng nhập email';
            if (!isValidEmail(value)) return 'Email phải có định dạng @gmail.com';
            return '';
            
         case 'password':
            if (!value) return 'Vui lòng nhập mật khẩu';
            if (!isValidPassword(value)) 
               return 'Mật khẩu phải có ít nhất 8 ký tự, bao gồm chữ hoa, chữ thường, số và ký tự đặc biệt';
            return '';
            
         case 'confirmPassword':
            if (!value) return 'Vui lòng nhập lại mật khẩu';
            if (formData.password !== value) return 'Mật khẩu nhập lại không khớp';
            return '';
            
         case 'selectedTinh':
            return !value ? 'Vui lòng chọn tỉnh/thành phố' : '';
            
         default:
            return '';
      }
   };

   // Handle input changes
   const handleChange = (field) => (e) => {
      const value = e?.target?.value ?? e;
      setFormData(prev => ({
         ...prev,
         [field]: value
      }));
      if (value) {
         setTouched(prev => ({...prev, [field]: false}));
      }
   };

   // Handle input blur
   const handleBlur = (field) => () => {
      setTouched(prev => ({...prev, [field]: true}));
   };

   // Fetch initial data
   useEffect(() => {
      const fetchData = async () => {
         try {
            setLoading(true);
            const response = await fetch("http://localhost:8000/api-tinh.php");
            const data = await response.json();
            if (data.success) setTinhList(data.tinhList);
         } catch (error) {
            console.error("Error:", error);
            message.error("Lỗi kết nối server");
         } finally {
            setLoading(false);
         }
      };

      fetchData();
   }, []);

   // Handle form submission
   const handleSubmit = async () => {
      // Mark all fields as touched
      setTouched({
         fullName: true,
         email: true,
         password: true,
         confirmPassword: true,
         selectedTinh: true
      });

      // Validate all fields
      const allErrors = {};
      Object.keys(formData).forEach(field => {
         const error = getFieldError(field);
         if (error) allErrors[field] = error;
      });

      if (Object.keys(allErrors).length > 0) {
         setErrors(allErrors);
         message.error("Vui lòng kiểm tra lại thông tin");
         return;
      }

      try {
         setLoading(true);
         const response = await fetch("http://localhost:8000/api-register.php", {
            method: "POST",
            headers: {"Content-Type": "application/x-www-form-urlencoded"},
            body: new URLSearchParams({
               hoten: formData.fullName,
               email: formData.email,
               matkhau: formData.password,
               matinh: formData.selectedTinh
            })
         });

         const data = await response.json();
         if (data.success) {
            message.success("Đăng ký thành công");
            navigate(ROUTERS.USER.LOGIN);
         } else {
            setErrors(data.errors || {});
            message.error(data.message || "Đăng ký không thành công");
         }
      } catch (error) {
         console.error("Error:", error);
         message.error("Lỗi kết nối server");
      } finally {
         setLoading(false);
      }
   };

   return (
      <div style={{
         display: "flex",
         alignItems: "center",
         justifyContent: "center",
         background: "rgba(0,0,0,0.53)",
         height: "100vh"
      }}>
         <div style={{
            width: "800px",
            height: "700px",
            borderRadius: "6px",
            background: "#fff",
            display: "flex"
         }}>
            <WrapperContainerLeft>
               <WapperLable>Đăng ký</WapperLable>
               <p style={{margin: "25px", color: "#ccc", marginTop: "5px"}}>
                  Đăng ký để mua sản phẩm
               </p>

               <Form layout='vertical'>
                  {/* Full Name Input */}
                  <Form.Item
                     validateStatus={getFieldError('fullName') ? "error" : ""}
                     help={getFieldError('fullName')}
                     style={{marginBottom: "2px"}}>
                     <InputFormComponent
                        placeholder='Nhập họ và tên'
                        value={formData.fullName}
                        onChange={handleChange('fullName')}
                        onBlur={handleBlur('fullName')}
                        allowClear
                     />
                  </Form.Item>

                  {/* Email Input */}
                  <Form.Item
                     validateStatus={getFieldError('email') ? "error" : ""}
                     help={getFieldError('email')}
                     style={{marginBottom: "2px"}}>
                     <InputFormComponent
                        placeholder='Nhập email'
                        value={formData.email}
                        onChange={handleChange('email')}
                        onBlur={handleBlur('email')}
                        allowClear
                     />
                  </Form.Item>

                  {/* Password Input */}
                  <Form.Item
                     validateStatus={getFieldError('password') ? "error" : ""}
                     help={getFieldError('password')}
                     style={{marginBottom: "2px"}}>
                     <div style={{position: "relative"}}>
                        <InputFormComponent
                           placeholder='Nhập mật khẩu'
                           type={isShowPassword1 ? "text" : "password"}
                           value={formData.password}
                           onChange={handleChange('password')}
                           onBlur={handleBlur('password')}
                           allowClear={false}
                        />
                        <span
                           onClick={() => setIsShowPassword1(!isShowPassword1)}
                           style={{
                              position: "absolute",
                              top: "50%",
                              right: "10px",
                              transform: "translateY(-50%)",
                              cursor: "pointer"
                           }}>
                           {isShowPassword1 ? <EyeFilled /> : <EyeInvisibleFilled />}
                        </span>
                     </div>
                  </Form.Item>

                  {/* Confirm Password Input */}
                  <Form.Item
                     validateStatus={getFieldError('confirmPassword') ? "error" : ""}
                     help={getFieldError('confirmPassword')}
                     style={{marginBottom: "2px"}}>
                     <div style={{position: "relative"}}>
                        <InputFormComponent
                           placeholder='Nhập lại mật khẩu'
                           type={isShowPassword2 ? "text" : "password"}
                           value={formData.confirmPassword}
                           onChange={handleChange('confirmPassword')}
                           onBlur={handleBlur('confirmPassword')}
                           allowClear={false}
                        />
                        <span
                           onClick={() => setIsShowPassword2(!isShowPassword2)}
                           style={{
                              position: "absolute",
                              top: "50%",
                              right: "10px",
                              transform: "translateY(-50%)",
                              cursor: "pointer"
                           }}>
                           {isShowPassword2 ? <EyeFilled /> : <EyeInvisibleFilled />}
                        </span>
                     </div>
                  </Form.Item>

                  {/* Province Select */}
                  <Form.Item
                     label='Tỉnh/Thành phố'
                     validateStatus={getFieldError('selectedTinh') ? "error" : ""}
                     help={getFieldError('selectedTinh')}
                     style={{marginBottom: "2px"}}>
                     <Select
                        placeholder='Chọn tỉnh/thành phố'
                        value={formData.selectedTinh}
                        onChange={handleChange('selectedTinh')}
                        onBlur={handleBlur('selectedTinh')}>
                        {Array.isArray(tinhList) && tinhList.map(tinh => (
                           <Option key={tinh.MATINH} value={tinh.MATINH}>
                              {tinh.TENTINH}
                           </Option>
                        ))}
                     </Select>
                  </Form.Item>

                  {/* Submit Button */}
                  <ButtonComponent
                     onClick={handleSubmit}
                     size='large'
                     style={{
                        background: "rgb(255,57,69)",
                        width: "100%",
                        height: "30px",
                        border: "none",
                        borderRadius: "4px",
                        margin: "26px 0 10px"
                     }}
                     textButton='Đăng Ký'
                     styleTextButton={{
                        color: "#fff",
                        fontSize: "15px",
                        fontWeight: "700"
                     }}
                     disabled={loading}
                  />
               </Form>

               <WrapperTextLight onClick={() => navigate(ROUTERS.USER.LOGIN)}>
                  Đã có tài khoản? Đăng nhập
               </WrapperTextLight>
            </WrapperContainerLeft>

            <WrapperContainerRight>
               <Image 
                  src={register} 
                  preview={false} 
                  alt='register' 
                  height='203px' 
                  width='203px' 
               />
               <h4>Laptop Store</h4>
            </WrapperContainerRight>
         </div>
      </div>
   );
};

export default SignUpPage;


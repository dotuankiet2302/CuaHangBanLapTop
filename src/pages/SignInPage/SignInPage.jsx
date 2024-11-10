import React, {useState} from "react";
import {Image, Form, message} from "antd";
import {WapperLable, WrapperContainerLeft, WrapperContainerRight, WrapperTextLight, WrapperSocialMedia} from "./style";
import InputFormComponent from "../../components/InputFormComponent/InputFormComponent";
import ButtonComponent from "../../components/ButtonComponent/ButtonComponent";
import loginimg from "../../assets/images/login.png";
import {useNavigate} from "react-router-dom";
import {ROUTERS} from "../../utils/router";
import {FontAwesomeIcon} from "@fortawesome/react-fontawesome";
import {faLeftLong} from "@fortawesome/free-solid-svg-icons";
import {EyeFilled, EyeInvisibleFilled} from "@ant-design/icons";
import {AiOutlineFacebook, AiOutlineGoogle, AiOutlineInstagram, AiOutlineLinkedin} from "react-icons/ai";

const SignInPage = () => {
   const navigate = useNavigate();

   // States
   const [isShowPassword, setIsShowPassword] = useState(false);
   const [formData, setFormData] = useState({
      taikhoan: "",
      matkhau: "",
   });
   const [touched, setTouched] = useState({
      taikhoan: false,
      matkhau: false,
   });

   // Validation helpers
   const isValidEmail = (email) => {
      return email.toLowerCase().endsWith("@gmail.com");
   };

   const getError = (field) => {
      const isTouched = touched[field];
      const value = formData[field];

      if (!isTouched) return false;
      if (!value) return "empty";

      if (field === "taikhoan" && !isValidEmail(value)) {
         return "invalid";
      }

      return false;
   };

   // Event handlers
   const handleChange = (field) => (e) => {
      setFormData((prev) => ({
         ...prev,
         [field]: e.target.value,
      }));
   };

   const handleBlur = (field) => () => {
      setTouched((prev) => ({
         ...prev,
         [field]: true,
      }));
   };

   const handleSubmit = async () => {
      // Đánh dấu tất cả các trường đã được chạm vào
      setTouched({
         taikhoan: true,
         matkhau: true,
      });

      // Validation
      if (!formData.taikhoan || !formData.matkhau) {
         message.error("Vui lòng nhập đầy đủ thông tin");
         return;
      }

      if (!isValidEmail(formData.taikhoan)) {
         message.error("Email phải có định dạng @gmail.com");
         return;
      }

      // API call
      try {
         const response = await fetch("http://localhost:8000/api-login.php", {
            method: "POST",
            headers: {
               "Content-Type": "application/x-www-form-urlencoded",
            },
            body: new URLSearchParams(formData),
         });

         const data = await response.json();

         if (data.success) {
            message.success("Đăng nhập thành công!");
            navigate(ROUTERS.USER.HOME);
         } else {
            message.error(data.message);
         }
      } catch (error) {
         console.error("Error:", error);
         message.error("Không thể kết nối đến server.");
      }
   };

   // Render helpers
   const getEmailErrorMessage = () => {
      const error = getError("taikhoan");
      if (error === "empty") return "Vui lòng nhập email";
      if (error === "invalid") return "Email phải có định dạng @gmail.com";
      return "";
   };

   return (
      <div
         style={{
            display: "flex",
            alignItems: "center",
            justifyContent: "center",
            background: "rgba(0,0,0,0.53)",
            height: "100vh",
         }}>
         <div
            style={{
               width: "800px",
               height: "500px",
               borderRadius: "6px",
               background: "#fff",
               display: "flex",
            }}>
            <WrapperContainerLeft>
               <WapperLable>Đăng Nhập</WapperLable>
               <p style={{margin: "20px", color: "#ccc"}}>Đăng nhập và tạo tài khoản</p>

               {/* Email Input */}
               <InputFormComponent
                  placeholder='Email'
                  value={formData.taikhoan}
                  onChange={handleChange("taikhoan")}
                  onBlur={handleBlur("taikhoan")}
                  validateStatus={getError("taikhoan") ? "error" : ""}
                  help={getEmailErrorMessage()}
               />

               {/* Password Input */}
               <div style={{position: "relative"}}>
                  <span
                     onClick={() => setIsShowPassword(!isShowPassword)}
                     style={{
                        zIndex: 10,
                        position: "absolute",
                        top: "10px",
                        right: "8px",
                        cursor: "pointer",
                     }}>
                     {isShowPassword ? <EyeFilled /> : <EyeInvisibleFilled />}
                  </span>

                  <InputFormComponent
                     placeholder='Mật khẩu'
                     type={isShowPassword ? "text" : "password"}
                     value={formData.matkhau}
                     onChange={handleChange("matkhau")}
                     onBlur={handleBlur("matkhau")}
                     validateStatus={getError("matkhau") ? "error" : ""}
                     help={getError("matkhau") === "empty" ? "Vui lòng nhập mật khẩu" : ""}
                  />
               </div>

               {/* Login Button */}
               <ButtonComponent
                  size='large'
                  style={{
                     background: "rgb(255,57,69)",
                     height: "48px",
                     width: "100%",
                     border: "none",
                     borderRadius: "4px",
                     margin: "5px 0px",
                  }}
                  textButton='Đăng nhập'
                  styleTextButton={{
                     color: "#fff",
                     fontSize: "15px",
                     fontWeight: "700",
                  }}
                  onClick={handleSubmit}
               />

               {/* Additional Links */}
               <WrapperTextLight>Chưa có tài khoản</WrapperTextLight>
               <p>
                  Quên mật khẩu?{" "}
                  <WrapperTextLight onClick={() => navigate(ROUTERS.USER.REGISTER)}>Tạo tài khoản</WrapperTextLight>
               </p>

               {/* Social Media Icons */}
               <WrapperSocialMedia>
                  <div>
                     <AiOutlineFacebook />
                  </div>
                  <div>
                     <AiOutlineInstagram />
                  </div>
                  <div>
                     <AiOutlineLinkedin />
                  </div>
                  <div>
                     <AiOutlineGoogle />
                  </div>
               </WrapperSocialMedia>

               {/* Back Button */}
               <FontAwesomeIcon
                  icon={faLeftLong}
                  size='2x'
                  style={{
                     color: "#B197FC",
                     marginRight: "390px",
                     marginTop: "30px",
                  }}
                  onClick={() => navigate(ROUTERS.USER.HOME)}
               />
            </WrapperContainerLeft>

            {/* Right Side */}
            <WrapperContainerRight>
               <Image src={loginimg} preview={false} alt='image-logo' height='203px' width='203px' />
               <h4>Laptop Store</h4>
            </WrapperContainerRight>
         </div>
      </div>
   );
};

export default SignInPage;

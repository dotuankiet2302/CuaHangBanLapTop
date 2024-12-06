import React, {useState} from "react";
import {Image, Form, message} from "antd";
import {WapperLable, WrapperContainerLeft, WrapperContainerRight, WrapperTextLight, WrapperSocialMedia} from "./style";
import InputFormComponent from "../../components/InputFormComponent/InputFormComponent";
import ButtonComponent from "../../components/ButtonComponent/ButtonComponent";
import loginimg from "../../assets/images/login.png";
import {EyeFilled, EyeInvisibleFilled} from "@ant-design/icons";
import {useNavigate} from "react-router-dom";
import {ROUTERS} from "../../utils/router";
import {FontAwesomeIcon} from "@fortawesome/react-fontawesome";
import {faLeftLong} from "@fortawesome/free-solid-svg-icons";
import {AiOutlineFacebook, AiOutlineGoogle, AiOutlineInstagram, AiOutlineLinkedin} from "react-icons/ai";
import {useUser} from "../UserContext/UserContext"; // lưu thông tin user
const SignInPage = () => {
   const navigate = useNavigate();

   const [isShowPassword, setIsShowPassword] = useState(false);
   const togglePasswordVisibility = () => setIsShowPassword(!isShowPassword);

   // State for form fields
   const [taikhoan, setTaiKhoan] = useState(""); // Đổi tên biến cho rõ ràng
   const [matkhau, setMatKhau] = useState(""); // Đổi tên biến cho rõ ràng
   const [isTaiKhoanTouched, setIsTaiKhoanTouched] = useState(false);
   const [isMatKhauTouched, setIsMatKhauTouched] = useState(false);
   // lưu user
   const {login} = useUser();
   // Validation flags
   const isTaiKhoanError = isTaiKhoanTouched && !taikhoan;
   const isMatKhauError = isMatKhauTouched && !matkhau;

   // Handle form submit
   const handleSubmit = async () => {
      setIsTaiKhoanTouched(true);
      setIsMatKhauTouched(true);
      if (taikhoan && matkhau) {
         try {
            const response = await fetch("http://localhost:8000/api-login.php", {
               method: "POST",
               headers: {
                  "Content-Type": "application/x-www-form-urlencoded", // Thay đổi tiêu đề
               },
               credentials: "include", // Thêm dòng này
               body: new URLSearchParams({
                  taikhoan: taikhoan, // Sử dụng biến taikhoan
                  matkhau: matkhau, // Sử dụng biến matkhau
               }),
            });
            const data = await response.json();

            if (data.success) {
               login(data.user); // Lưu user vào context
               message.success("Đăng nhập thành công!");
               navigate(ROUTERS.USER.HOME);
            } else {
               message.error(data.message);
            }
         } catch (error) {
            console.error("Error:", error);
            message.error("Không thể kết nối đến server.");
         }
      }
   };
   const handleGoogleLogin = async () => {
      try {
         const response = await fetch("http://localhost:8000/google-login.php");
         const data = await response.json();

         if (data.success && data.auth_url) {
            // Chuyển hướng đến trang đăng nhập Google
            window.location.href = data.auth_url;
         } else if (data.success) {
            // Xử lý giống như handleSubmit
            message.success(data.message);
            navigate(ROUTERS.USER.HOME); // Chuyển về trang home
            message.success("Đăng nhập thành công!");
         } else {
            console.error("Google login error:", data);
            message.error(data.message || "Không thể kết nối với Google");
         }
      } catch (error) {
         console.error("Error:", error);
         message.error("Đã có lỗi xảy ra");
      }
   };

   return (
      <div
         style={{
            display: "flex",
            gap: "5px",
            alignItems: "center",
            justifyContent: "center",
            background: "rgba(0,0,0,0.53)",
            height: "1000px",
         }}>
         <div style={{width: "800px", height: "550px", borderRadius: "6px", background: "#fff", display: "flex"}}>
            <WrapperContainerLeft>
               <WapperLable>Đăng Nhập với tài khoản KHÁCH HÀNG</WapperLable>
               <p style={{margin: "20px", color: "#ccc"}}>Đăng nhập và tạo tài khoản</p>
               <Form.Item
                  validateStatus={isTaiKhoanError ? "error" : ""}
                  help={isTaiKhoanError ? "Vui lòng nhập tài khoản" : ""}
                  onChange={(e) => setTaiKhoan(e.target.value)} // Cập nhật tài khoản
               >
                  <InputFormComponent placeholder='Tài khoản' />
               </Form.Item>

               <div style={{position: "relative"}}>
                  <span
                     onClick={togglePasswordVisibility}
                     style={{
                        zIndex: 10,
                        position: "absolute",
                        top: "10px",
                        right: "8px",
                        cursor: "pointer",
                     }}>
                     {isShowPassword ? <EyeFilled /> : <EyeInvisibleFilled />}
                  </span>
                  <Form.Item
                     validateStatus={isMatKhauError ? "error" : ""}
                     help={isMatKhauError ? "Vui lòng nhập mật khẩu" : ""}
                     onChange={(e) => setMatKhau(e.target.value)} // Cập nhật mật khẩu
                  >
                     <InputFormComponent placeholder='Mật khẩu' type={isShowPassword ? "text" : "password"} />
                  </Form.Item>
               </div>

               <ButtonComponent
                  size='large'
                  border={false}
                  style={{
                     background: "rgb(255,57,69)",
                     height: "48px",
                     width: "100%",
                     border: "none",
                     borderRadius: "4px",
                     margin: "5px 0px",
                  }}
                  textButton='Đăng nhập'
                  styleTextButton={{color: "#fff", fontsize: "15px", fontweight: "700"}}
                  onClick={handleSubmit}
               />
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
                  <div onClick={handleGoogleLogin} style={{cursor: "pointer"}}>
                     <AiOutlineGoogle />
                  </div>
               </WrapperSocialMedia>

               {/* Back Button */}
               <FontAwesomeIcon
                  icon={faLeftLong}
                  size='2x'
                  style={{color: "#B197FC", marginRight: "390px", marginTop: "-10px"}}
                  onClick={() => navigate(ROUTERS.USER.HOME)}
               />
            </WrapperContainerLeft>
            <WrapperContainerRight>
               <Image src={loginimg} preview={false} alt='image-logo' height='203px' width='203px' />
               <h4>Laptop Store</h4>
            </WrapperContainerRight>
         </div>
      </div>
   );
};

export default SignInPage;

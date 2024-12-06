import React from "react";
import { Button, message } from "antd";
import { useNavigate } from "react-router-dom";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faLeftLong } from "@fortawesome/free-solid-svg-icons";
import { AiOutlineFacebook, AiOutlineGoogle, AiOutlineInstagram, AiOutlineLinkedin } from "react-icons/ai";
import loginimg from "../../assets/images/login.png";
import { WrapperContainerLeft, WrapperContainerRight, WrapperTextLight, WrapperSocialMedia, WapperLable } from "./style";
import { ROUTERS } from "../../utils/router";

const SignInPage = () => {
  const navigate = useNavigate();

  // Navigate to login or employee login page
  const handleLogin = (route) => {
    navigate(route);
  };

  return (
    <div
      style={{
        display: "flex",
        gap: "5px",
        alignItems: "center",
        justifyContent: "center",
        background: "rgba(0,0,0,0.53)",
        height: "100vh",
      }}
    >
      <div style={{ width: "800px", height: "500px", borderRadius: "6px", background: "#fff", display: "flex" }}>
        <WrapperContainerLeft>
          <WapperLable>Đăng Nhập với quyền</WapperLable>
          <p style={{ margin: "20px", color: "#ccc" }}>Chọn quyền để tiếp tục</p>

          <Button
            size="large"
            style={{
              background: "rgb(255,57,69)",
              height: "48px",
              width: "100%",
              border: "none",
              borderRadius: "4px",
              margin: "10px 0px",
            }}
            onClick={() => handleLogin(ROUTERS.USER.LOGIN)} // Chuyển đến trang đăng nhập người dùng
          >
             Người Dùng
          </Button>

          <Button
            size="large"
            style={{
              background: "rgb(66,133,244)", // Màu khác cho nhân viên
              height: "48px",
              width: "100%",
              border: "none",
              borderRadius: "4px",
              margin: "10px 0px",
            }}
            onClick={() => handleLogin(ROUTERS.USER.LOGINEMPLOY)} // Chuyển đến trang đăng nhập nhân viên
          >
             Nhân Viên
          </Button>

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
            size="2x"
            style={{ color: "#B197FC", marginRight: "390px", marginTop: "-10px" }}
            onClick={() => navigate("/home")} // Quay lại trang chủ
          />
        </WrapperContainerLeft>

        <WrapperContainerRight>
          <img src={loginimg} alt="logo" height="203px" width="203px" />
          <h4>Laptop Store</h4>
        </WrapperContainerRight>
      </div>
    </div>
  );
};

export default SignInPage;

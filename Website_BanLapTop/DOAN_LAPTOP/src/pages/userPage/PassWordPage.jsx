import React from "react";
import { Form, message } from "antd";
import {
   WrapperTitle, WrapperContainer, WrapperInput, WrapperPopupButton,
} from "./style";

const PassWordPage = () => {
   const [form] = Form.useForm();

   const handleUpdatePassword = async () => {
      try {
         const values = await form.validateFields();
         
         const formData = new FormData();
         formData.append("matkhaucu", values.oldPassword);
         formData.append("matkhau", values.newPassword);
         formData.append("nhaplaimatkhau", values.confirmPassword);

         const response = await fetch("http://localhost:8000/api-passwordinfo.php", {
            method: "POST",
            credentials: "include",
            body: formData,
         });

         const data = await response.json();

         if (data.success) {
            message.success(data.message);
            form.resetFields();
         } else {
            if (data.errors) {
               Object.values(data.errors).forEach((error) => message.error(error));
            } else {
               message.error(data.message);
            }
         }
      } catch (error) {
         if (error.errorFields) return;
         console.error("Error:", error);
         message.error("Không thể kết nối đến server.");
      }
   };

   return (
      <WrapperContainer>
         <WrapperTitle>Thay đổi mật khẩu</WrapperTitle>
         <Form form={form} layout="vertical">
            <Form.Item
               name="oldPassword"
               label="Nhập mật khẩu cũ"
               rules={[
                  {
                     required: true,
                     message: "Vui lòng nhập mật khẩu cũ!",
                  }
               ]}
            >
               <WrapperInput.Password placeholder='Nhập mật khẩu cũ' />
            </Form.Item>

            <Form.Item
               name="newPassword"
               label="Nhập mật khẩu mới"
               rules={[
                  {
                     required: true,
                     message: "Vui lòng nhập mật khẩu mới!",
                  },
                  {
                     min: 8,
                     message: "Nhập ít nhất 8 ký tự!",
                  },
                  {
                     pattern: /[A-Z]/,
                     message: "Nhập ít nhất 1 chữ hoa!",
                  },
                  {
                     pattern: /[a-z]/,
                     message: "Nhập ít nhất một chữ thường!",
                  },
                  {
                     pattern: /[0-9]/,
                     message: "Phải có ít nhất 1 ký tự số!",
                  },
                  {
                     pattern: /[!@#$%^&*(),.?":{}|<>]/,
                     message: "Phải có ít nhất 1 ký tự đặc biệt!",
                  },
               ]}
            >
               <WrapperInput.Password placeholder='Nhập mật khẩu mới' />
            </Form.Item>

            <Form.Item
               name="confirmPassword"
               label="Nhập lại mật khẩu mới"
               dependencies={['newPassword']}
               rules={[
                  {
                     required: true,
                     message: "Vui lòng xác nhận mật khẩu mới!",
                  },
                  ({ getFieldValue }) => ({
                     validator(_, value) {
                        if (!value || getFieldValue('newPassword') === value) {
                           return Promise.resolve();
                        }
                        return Promise.reject(new Error('Mật khẩu xác nhận không khớp!'));
                     },
                  }),
               ]}
            >
               <WrapperInput.Password placeholder='Xác nhận mật khẩu' />
            </Form.Item>

            <WrapperPopupButton type='primary' onClick={handleUpdatePassword}>
               Xác nhận
            </WrapperPopupButton>
         </Form>
      </WrapperContainer>
   );
};

export default PassWordPage;
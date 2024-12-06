import React, {useState, useEffect} from "react";
import {UserOutlined, PhoneOutlined, HomeOutlined, MailOutlined, UserAddOutlined} from "@ant-design/icons";
import {Form, Input, Modal, DatePicker, Radio, Space, message} from "antd";
import dayjs from "dayjs";

import {
   WrapperTitle,
   WrapperContainer,
   WrapperFormGroup,
   WrapperLabel,
   WrapperInput,
   WrapperEditButton,
   WrapperPopupButton,
   WrapperModalContent,
} from "./style";
import {useUser} from "../UserContext/UserContext";
import DEFAULT_AVATAR from "../../assets/images/user.png";

const importAll = (r) => {
   let images = {};
   r.keys().forEach((item) => {
      images[item.replace("./", "")] = r(item);
   });
   return images;
};

try {
   // Import tất cả ảnh từ thư mục assets/images/user
   const images = importAll(require.context("../../assets/images/user", false, /\.(png|jpe?g|svg)$/));
   console.log("Loaded images:", images);
} catch (error) {
   console.error("Error loading images:", error);
}

const UserPage = () => {
   const DOMAIN = "http://localhost:8000";
   //const DEFAULT_AVATAR = `${DOMAIN}/assets/images/user.png`;
   const [isModalOpen, setIsModalOpen] = useState(false);
   const [form] = Form.useForm();
   const {userInfo, login} = useUser();
   const [selectedFileName, setSelectedFileName] = useState("");
   const [formData, setFormData] = useState({
      hoTen: userInfo.hoTen,
      ngaySinh: userInfo.ngaySinh,
      gioiTinh: userInfo.gioiTinh?.toLowerCase() || "nam",
      dienThoai: userInfo.dienThoai,
      diaChi: userInfo.diaChi,
      anh: userInfo.anh || null,
      anhHienThi: userInfo.anh ? `${DOMAIN}/assets/images/user/${userInfo.anh}` : null,
   });
   // Khởi tạo form với giá trị mặc định
   const [mainForm] = Form.useForm();
   useEffect(() => {
      mainForm.setFieldsValue({
         hoTen: userInfo.HOTEN,
         ngaySinh: userInfo.NGAYSINH ? dayjs(userInfo.NGAYSINH) : null,
         gioiTinh: userInfo.GIOITINH?.toLowerCase() || "nam",
         dienThoai: userInfo.DIENTHOAI,
         diaChi: userInfo.DIACHI,
      });
   }, [userInfo]);
   const handleInputChange = (e) => {
      // const {name, value} = e.target;
      // setFormData((prev) => ({
      //    ...prev,
      //    [name]: value,
      // }));
      const { name, value } = e.target;

      // Validate phone number to ensure it is numeric and up to 10 digits
      if (name === 'dienThoai') {
         const regex = /^[0-9]*$/; // Allow only digits
         // Only update if the value is numeric and has at most 10 digits
         if (regex.test(value) && value.length <= 10) {
            setFormData((prev) => ({
               ...prev,
               [name]: value,
            }));
         }
      } else {
         setFormData((prev) => ({
            ...prev,
            [name]: value,
         }));
      }
   };

   const handleDateChange = (date, dateString) => {
      setFormData((prev) => ({
         ...prev,
         ngaySinh: dateString,
      }));
   };

   const handleGenderChange = (e) => {
      setFormData((prev) => ({
         ...prev,
         gioiTinh: e.target.value,
      }));
   };

   const showModal = () => {
      setIsModalOpen(true);
   };

   // Xử lý cập nhật email
   const handleEmailUpdate = async () => {
      try {
         const values = await form.validateFields();
         const formData = new FormData();
         formData.append("email", values.email);
         formData.append("password", values.password);

         const response = await fetch("http://localhost:8000/api-userinfo.php", {
            method: "POST",
            credentials: "include",
            body: formData,
         });

         const data = await response.json();

         if (data.success) {
            message.success(data.message);
            const updatedUserInfo = {
               ...userInfo,
               email: data.newEmail,
            };
            localStorage.setItem("userInfo", JSON.stringify(updatedUserInfo));
            login(updatedUserInfo);
            setIsModalOpen(false);
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

   // Xử lý cập nhật thông tin cá nhân
   const handleUpdateInfo = async () => {
       // Kiểm tra độ dài số điện thoại
   if (formData.dienThoai.length !== 10) {
      message.error("Số điện thoại phải có đúng 10 số!");
      return; 
   }
      try {
         const formDataToSend = new FormData();
         formDataToSend.append("action", "update_info");

         // So sánh và chỉ gửi những trường đã thay đổi
         const changedFields = {};
         Object.keys(formData).forEach((key) => {
            // Xử lý ngày sinh riêng
            if (key === "ngaySinh") {
               if (formData[key] && formData[key] !== userInfo[key.toLowerCase()]) {
                  changedFields[key] = formData[key];
               }
            }
            // Xử lý giới tính riêng
            else if (key === "gioiTinh") {
               if (formData[key] !== userInfo[key.toLowerCase()]) {
                  changedFields[key] = formData[key];
               }
            }
            // Xử lý các trường còn lại
            else if (formData[key] !== userInfo[key.toLowerCase()]) {
               changedFields[key] = formData[key];
            }
         });

         // Nếu không có trường nào thay đổi, không gửi request
         if (Object.keys(changedFields).length === 0) {
            message.info("Không có thông tin nào được thay đổi");
            return;
         }

         // Gửi những trường đã thay đổi
         Object.keys(changedFields).forEach((key) => {
            formDataToSend.append(key, changedFields[key]);
         });

         // Gửi các trường không thay đổi từ userInfo (trừ ngày sinh và giới tính)
         Object.keys(formData).forEach((key) => {
            if (!changedFields[key] && key !== "ngaySinh" && key !== "gioiTinh") {
               formDataToSend.append(key, userInfo[key.toLowerCase()]);
            }
         });

         Object.keys(formData).forEach((key) => {
            if (key === "anh" && formData[key] instanceof File) {
               formDataToSend.append("anh", formData[key]);
            } else {
               formDataToSend.append(key, formData[key] || "");
            }
         });
         const response = await fetch("http://localhost:8000/api-userinfo.php", {
            method: "POST",
            credentials: "include",
            body: formDataToSend,
         });

         const data = await response.json();

         if (data.success) {
            message.success(data.message);
            // Cập nhật localStorage và state với dữ liệu mới
            const updatedUserInfo = {
               ...userInfo,
               // ...data.userInfo,
               hoTen: data.userInfo.HOTEN,
               ngaySinh: data.userInfo.NGAYSINH,
               gioiTinh: data.userInfo.GIOITINH,
               dienThoai: data.userInfo.DIENTHOAI,
               diaChi: data.userInfo.DIACHI,
               anh: data.userInfo.ANH,
               email: data.userInfo.EMAIL,
               taikhoan: data.userInfo.TAIKHOAN,
            };
            localStorage.setItem("userInfo", JSON.stringify(updatedUserInfo));
            login(updatedUserInfo);
            // Reset file input
            setSelectedFileName("");
            // Cập nhật formData với ảnh mới
            setFormData((prev) => ({
               /*...prev,*/
               anh: data.userInfo.anh || prev.anh, // Giữ ảnh cũ nếu không có ảnh mới
               anhHienThi: data.userInfo.anh ? `${DOMAIN}/assets/images/user/${data.userInfo.anh}` : prev.anhHienThi, // Giữ URL hiển thị cũ nếu không có ảnh mới
               hoTen: data.userInfo.HOTEN,
               ngaySinh: data.userInfo.NGAYSINH,
               gioiTinh: data.userInfo.GIOITINH?.toLowerCase() || "nam",
               dienThoai: data.userInfo.DIENTHOAI,
               diaChi: data.userInfo.DIACHI,
            }));

            // Xóa URL tạm thời nếu có
            if (formData.anh instanceof File) {
               URL.revokeObjectURL(formData.anhHienThi);
            }
         } else {
            if (data.errors) {
               Object.values(data.errors).forEach((error) => message.error(error));
            } else {
               message.error(data.message);
            }
         }
      } catch (error) {
         console.error("Error:", error);
         message.error("Không thể kết nối đến server.");
      }
   };

   const handleCancel = () => {
      setIsModalOpen(false);
      form.resetFields();
   };

   return (
      <WrapperContainer>
         <WrapperTitle>Thông tin người dùng</WrapperTitle>
         {/* Cột trái chứa form thông tin */}
         <div style={{display: "flex", gap: "40px", alignItems: "flex-start"}}>
            <Form form={mainForm} layout='vertical' style={{flex: 1}}>
               <WrapperFormGroup>
                  <WrapperLabel>Họ và tên:</WrapperLabel>
                  <WrapperInput
                     name='hoTen'
                     value={formData.hoTen}
                     onChange={handleInputChange}
                     placeholder='Nhập họ và tên'
                     prefix={<UserOutlined />}
                  />
               </WrapperFormGroup>

               <WrapperFormGroup>
                  <WrapperLabel>Ngày sinh:</WrapperLabel>
                  <Space direction='vertical' style={{flex: 1}}>
                     <DatePicker
                        value={formData.ngaySinh ? dayjs(formData.ngaySinh) : null}
                        onChange={handleDateChange}
                        style={{width: "100%"}}
                        placeholder='Chọn ngày sinh'
                        //  format='DD/MM/YYYY'
                     />
                  </Space>
               </WrapperFormGroup>

               <WrapperFormGroup>
                  <WrapperLabel>Giới tính:</WrapperLabel>
                  <Radio.Group value={formData.gioiTinh} onChange={handleGenderChange} style={{flex: 1}}>
                     <Radio value='nam'>NAM</Radio>
                     <Radio value='nữ'>NỮ</Radio>
                  </Radio.Group>
               </WrapperFormGroup>

               <WrapperFormGroup>
                  <WrapperLabel>Email:</WrapperLabel>
                  <WrapperInput value={userInfo.email} placeholder='Nhập email' prefix={<MailOutlined />} disabled />
                  <WrapperEditButton type='primary' onClick={showModal}>
                     Edit
                  </WrapperEditButton>
               </WrapperFormGroup>

               <WrapperFormGroup>
   <WrapperLabel>Số điện thoại:</WrapperLabel>
   <WrapperInput
      name='dienThoai'
      value={formData.dienThoai}
      onChange={handleInputChange}
      placeholder='Nhập số điện thoại'
      prefix={<PhoneOutlined />}
   />
   {formData.dienThoai.length > 0 && formData.dienThoai.length !== 10 && (
      <div style={{ color: 'red', marginTop: '5px' }}>
         Nhập đúng 10 số!
      </div>
   )}
</WrapperFormGroup>
               <WrapperFormGroup>
                  <WrapperLabel>Địa chỉ:</WrapperLabel>
                  <WrapperInput
                     name='diaChi'
                     value={formData.diaChi}
                     onChange={handleInputChange}
                     placeholder='Nhập địa chỉ'
                     prefix={<HomeOutlined />}
                  />
               </WrapperFormGroup>

               <WrapperFormGroup>
                  <WrapperLabel>Tài khoản:</WrapperLabel>
                  <WrapperInput
                     value={userInfo.taikhoan}
                     placeholder='Nhập tài khoản'
                     prefix={<UserAddOutlined />}
                     disabled
                  />
               </WrapperFormGroup>
               <WrapperFormGroup>
                  <WrapperLabel>Ảnh đại diện:</WrapperLabel>
                  <div style={{display: "flex", flexDirection: "column", gap: "10px"}}>
                     {/* Hiển thị tên file hiện tại */}
                     {userInfo.anh && <div style={{color: "#666"}}>Ảnh hiện tại: {userInfo.anh}</div>}

                     <Form.Item name='anh'>
                        <input
                           type='file'
                           name='anh'
                           accept='.jpg,.jpeg,.png'
                           onChange={(e) => {
                              const file = e.target.files[0];
                              if (file) {
                                 setSelectedFileName(e.target.value);
                                 setFormData((prev) => ({
                                    ...prev,
                                    anh: file,
                                    anhHienThi: URL.createObjectURL(file),
                                 }));
                              }
                           }}
                        />
                     </Form.Item>

                     {/* Hiển thị tên file mới đã chọn */}
                     {selectedFileName && (
                        <div style={{color: "#666"}}>File mới: {selectedFileName.split("\\").pop()}</div>
                     )}
                  </div>

                  <div style={{marginTop: "10px"}}>
                     <img
                        src={
                           formData.anh instanceof File
                              ? formData.anhHienThi
                              : userInfo.anh
                              ? require(`../../assets/images/user/${userInfo.anh}`)
                              : DEFAULT_AVATAR
                        }
                        alt='Avatar'
                        style={{
                           width: 100,
                           height: 100,
                           objectFit: "cover",
                           borderRadius: "50%",
                           border: "2px solid #ccc",
                        }}
                        onError={(e) => {
                           e.target.onerror = null;
                           e.target.src = DEFAULT_AVATAR;
                        }}
                     />
                  </div>
               </WrapperFormGroup>
            </Form>
            {/* Ảnh đại diện bên phải */}
            <div
               style={{
                  width: "300px",
                  padding: "20px",
                  border: "1px solid #e8e8e8",
                  borderRadius: "8px",
                  backgroundColor: "#fff",
                  textAlign: "center",
               }}>
               {/* 
           {process.env.NODE_ENV === 'development' && (
            <div style={{marginBottom: '10px', fontSize: '12px', color: '#666'}}>
               <div>User Info: {JSON.stringify(userInfo)}</div>
               <div>Image Path: {`${DOMAIN}/assets/images/user/${userInfo?.anh}`}</div>
            </div>
         )} */}
               <img
                  src={userInfo?.anh ? require(`../../assets/images/user/${userInfo.anh}`) : DEFAULT_AVATAR}
                  alt='Avatar'
                  style={{
                     width: "200px",
                     height: "200px",
                     objectFit: "cover",
                     borderRadius: "50%",
                     border: "3px solid #1890ff",
                     marginBottom: "15px",
                  }}
                  onError={(e) => {
                     console.log("Image Error:", {
                        userInfo: userInfo,
                        anh: userInfo?.anh,
                     });
                     e.target.onerror = null;
                     e.target.src = DEFAULT_AVATAR;
                  }}
               />
            </div>
         </div>

         <Modal title='Cập nhật Email' open={isModalOpen} onCancel={handleCancel} footer={null}>
            <WrapperModalContent>
               <Form form={form} layout='vertical'>
                  <Form.Item
                     name='email'
                     label='Email'
                     rules={[
                        {
                           required: true,
                           message: "Vui lòng nhập email!",
                        },
                        {
                           type: "email",
                           message: "Email không hợp lệ, phải nhập đúng định dạng!",
                        },
                     ]}>
                     <Input placeholder='Nhập email' prefix={<MailOutlined />} />
                  </Form.Item>

                  <Form.Item
                     name='password'
                     label='Mật khẩu'
                     rules={[
                        {
                           required: true,
                           message: "Vui lòng nhập mật khẩu!",
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
                     ]}>
                     <Input.Password placeholder='Nhập mật khẩu' />
                  </Form.Item>

                  <WrapperPopupButton type='primary' onClick={handleEmailUpdate}>
                     Xác nhận
                  </WrapperPopupButton>
               </Form>
            </WrapperModalContent>
         </Modal>

         <WrapperPopupButton type='primary' onClick={handleUpdateInfo}>
            Cập nhật
         </WrapperPopupButton>
      </WrapperContainer>
   );
};

export default UserPage;

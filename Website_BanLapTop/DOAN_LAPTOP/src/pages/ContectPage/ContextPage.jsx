import React, {useState} from "react";
import {Button, Row, Col, Form} from "antd";
import InputFormComponent from "../../components/InputFormComponent/InputFormComponent";
import {FontAwesomeIcon} from "@fortawesome/react-fontawesome";
import {faMagnifyingGlass, faCaretRight} from "@fortawesome/free-solid-svg-icons";
import Select from "react-select";

const ContextPage = () => {
   const [isOpen, setIsOpen] = useState(false);

   const toggleDropdown = () => {
      setIsOpen(!isOpen);
   };

   const options1 = [
      {
         value: "TECH VERSE",
         label: (
            <div
               style={{
                  display: "flex",
                  alignItems: "center",
                  width: "200px",
                  margin: "10px 40px 0 20px",
                  borderRadius: "8px",
               }}>
               TECH VERSE
            </div>
         ),
      },
   ];

   const defaultOption1 = options1[0];
   const [value1, setValue1] = useState(defaultOption1);

   const [name, setName] = useState("");
   const [isNameTouched, setIsNameTouched] = useState(false);

   const [email, setEmail] = useState("");
   const [isEmailTouched, setIsEmailTouched] = useState(false);

   const [phone, setPhone] = useState("");
   const [isPhoneTouched, setIsPhoneTouched] = useState(false);

   const [title, setTitle] = useState("");
   const [isTitleTouched, setIsTitleTouched] = useState(false);

   const [note, setNote] = useState("");
   const [isNoteTouched, setIsNoteTouched] = useState(false);

   const isNameError = isNameTouched && !name;
   const isEmailError = isEmailTouched && !email;
   const isPhoneError = isPhoneTouched && !phone;
   const isTitleError = isTitleTouched && !title;
   const isNoteError = isNoteTouched && !note;

   const handleSubmit = () => {
      setIsNameTouched(true);
      setIsEmailTouched(true);
      setIsPhoneTouched(true);
      setIsTitleTouched(true);
      setIsNoteTouched(true);

      if (name && email && phone) {
         console.log("Form is valid");
         // Thực hiện hành động gửi form ở đây
      }
   };

   return (
      <Row gutter={16}>
         <Col span={9}>
            <div style={{fontSize: "18px", color: "#000", fontWeight: "bold", margin: "20px 0 10px 320px"}}>
               Liên hệ với chúng tôi
            </div>

            <div
               style={{
                  display: "flex",
                  alignItems: "center",
                  color: "#000",
                  margin: "10px 0 0 320px",
                  cursor: "pointer",
               }}
               onClick={toggleDropdown}>
               <FontAwesomeIcon icon={faCaretRight} style={{color: "#bbbcbf", marginRight: "10px"}} />
               <span>TECH VERSE</span>
            </div>

            {isOpen && (
               <div style={{marginLeft: "330px", marginTop: "10px", padding: "10px", backgroundColor: "#fff"}}>
                  <p style={{color: "#EF5222", fontSize: "18px"}}>CỬA HÀNG BÁN LAPTOP</p>
                  <ul style={{padding: "0", listStyleType: "none"}}>
                     <li style={{marginBottom: "10px"}}>
                        Địa chỉ:{" "}
                        <span style={{fontWeight: "bold"}}>
                           140 Lê Trọng Tấn, Phường Tây Thạnh, Quận Tân Phú, Việt Nam
                        </span>
                     </li>
                     <li style={{marginBottom: "10px"}}>
                        Website:{" "}
                        <a
                           href='https://techverse.vn/'
                           style={{color: "#000"}}
                           target='_blank'
                           rel='noopener noreferrer'>
                           techverse.vn
                        </a>
                     </li>
                     <li style={{marginBottom: "10px"}}>Điện thoại: 0886704540</li>
                     <li style={{marginBottom: "10px"}}>Fax: 02838386852</li>
                     <li style={{marginBottom: "10px"}}>Email: hotro@techverse.vn</li>
                     <li style={{marginBottom: "10px"}}>Hotline: 1900 ????</li>
                  </ul>
               </div>
            )}
         </Col>

         <Col span={15} style={{borderRadius: "20px"}}>
            <div
               style={{
                  display: "flex",
                  flexDirection: "column",
                  alignItems: "center",
                  gap: "10px",
                  marginTop: "20px",
                  background: "#fff",
                  height: "550px",
                  marginRight: "290px",
               }}>
               <div
                  style={{
                     display: "flex",
                     alignItems: "center",
                     color: "#EF5222",
                     fontWeight: "bold",
                     marginBottom: "10px",
                     marginRight: "350px",
                  }}>
                  <img
                     src='https://futabus.vn/images/icons/mail_send.svg'
                     alt='Gửi thông tin'
                     style={{width: "26px", marginRight: "8px"}}
                  />
                  Gửi thông tin liên hệ đến chúng tôi
               </div>
               <div
                  style={{
                     width: "691px",
                     height: "auto",
                     borderRadius: "6px",
                     background: "#f9f9f9",
                     display: "flex",
                     flexDirection: "column",
                     marginTop: "2px",
                  }}>
                  <div style={{display: "flex", alignItems: "center"}}>
                     <Select
                        options={options1}
                        defaultValue={defaultOption1}
                        value={value1}
                        onChange={(selectedOption) => setValue1(selectedOption)}
                        isDisabled={true}
                        styles={{container: (provided) => ({...provided, marginLeft: "2px"})}}
                     />
                     <Form.Item
                        validateStatus={isNameError ? "error" : ""}
                        help={isNameError ? "Vui lòng nhập họ và tên" : ""}
                        style={{marginLeft: "20px", width: "300px", marginTop: "25px"}}>
                        <InputFormComponent
                           style={{height: "40px", width: "310px"}}
                           placeholder='Họ và tên'
                           onChange={(e) => setName(e.target.value)}
                           onBlur={() => setIsNameTouched(true)}
                        />
                     </Form.Item>
                  </div>

                  <div style={{display: "flex", alignItems: "center", marginTop: "2px"}}>
                     <Form.Item
                        validateStatus={isEmailError ? "error" : ""}
                        help={isEmailError ? "Vui lòng nhập Email" : ""}
                        style={{marginLeft: "10px", width: "320px"}}>
                        <InputFormComponent
                           style={{height: "40px", width: "320px"}}
                           placeholder='Email'
                           onChange={(e) => setEmail(e.target.value)}
                           onBlur={() => setIsEmailTouched(true)}
                        />
                     </Form.Item>
                     <Form.Item
                        validateStatus={isPhoneError ? "error" : ""}
                        help={isPhoneError ? "Vui lòng nhập Điện thoại" : ""}
                        style={{marginLeft: "10px", width: "320px"}}>
                        <InputFormComponent
                           style={{height: "40px", width: "315px"}}
                           placeholder='Điện thoại'
                           onChange={(e) => setPhone(e.target.value)}
                           onBlur={() => setIsPhoneTouched(true)}
                        />
                     </Form.Item>
                  </div>

                  <Form.Item
                     validateStatus={isTitleError ? "error" : ""}
                     help={isTitleError ? "Vui lòng nhập tiêu đề" : ""}
                     style={{marginLeft: "10px", width: "320px", marginTop: "0.5px"}}>
                     <InputFormComponent
                        style={{height: "40px", width: "650px"}}
                        placeholder='Nhập tiêu đề'
                        onChange={(e) => setTitle(e.target.value)}
                        onBlur={() => setIsTitleTouched(true)}
                     />
                  </Form.Item>

                  <Form.Item
                     validateStatus={isNoteError ? "error" : ""}
                     help={isNoteError ? "Vui lòng nhập ghi chú" : ""}
                     style={{marginLeft: "10px", width: "320px", marginTop: "0.5px"}}>
                     <InputFormComponent
                        style={{
                           width: "650px",
                           height: "100px",
                           border: "1px solid #ccc",
                           borderRadius: "8px",
                           padding: "10px",
                           boxSizing: "border-box",
                           marginTop: "0.5px",
                           backgroundColor: "#fff",
                           transition: "border-color 0.3s",
                        }}
                        placeholder='Nhập ghi chú'
                        onChange={(e) => setNote(e.target.value)}
                        onBlur={() => setIsNoteTouched(true)}
                     />
                  </Form.Item>

                  <div style={{textAlign: "center", marginTop: "10px"}}>
                     <Button
                        onClick={handleSubmit}
                        style={{width: "125px", height: "38px", backgroundColor: "#ff4500", color: "#fff"}}>
                        Gửi
                     </Button>
                  </div>
               </div>
            </div>
         </Col>
      </Row>
   );
};

export default ContextPage;

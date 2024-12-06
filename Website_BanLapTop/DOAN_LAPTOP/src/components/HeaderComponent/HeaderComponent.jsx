import React, {useEffect, useState, useRef} from "react";
import {Badge, Col} from "antd";
import {
   WrapperHeader,
   WrapperHeaderAccout,
   WrapperHeaderIcon,
   WrapperTextHeader,
   WrapperTypeProduct,
   WrapperDropdownContent,
   WrapperDropdown,
   WrapperImage,
   LogoWrapper,
} from "./style";
import {UserOutlined, CaretDownOutlined, ShoppingCartOutlined} from "@ant-design/icons";
import ButtonInputSearch from "../ButtonInputSearch/ButtonInputSearch";
import {ROUTERS} from "../../utils/router";
import {Link, useNavigate} from "react-router-dom";
import {useDispatch} from "react-redux";
import {setSearchResults} from "../../redux/searchSlice";
import {useUser} from "../../pages/UserContext/UserContext";
import {message, Image} from "antd";
import DEFAULT_AVATAR from "../../assets/images/user.png";
import logo from "../../assets/images/techverse.jpg";
const HeaderComponent = () => {
   const [menus] = useState([
      {name: "Trang chủ", path: ROUTERS.USER.HOME},
      {name: "Cửa hàng", path: ROUTERS.USER.PRODUCTS},
      {name: "Bài viết", path: ROUTERS.USER.ARTICLE},
      {name: "Liên hệ", path: ROUTERS.USER.CONTECT},
   ]);

   const dispatch = useDispatch();
   const navigate = useNavigate();
   const [cartItems, setCartItems] = useState([]);
   const [noResultsFound, setNoResultsFound] = useState(false);
   const [cartCount, setCartCount] = useState(0);
   // login/logout
   const {userInfo, logout} = useUser();
   const [isDropdownOpen, setIsDropdownOpen] = useState(false);
   const dropdownRef = useRef(null);

   const fetchCartItems = async () => {
      try {
         const response = await fetch("http://localhost:8000/api-cart.php");
         if (!response.ok) throw new Error("Network response was not ok");

         const data = await response.json();
         setCartItems(data.cart || []);

         // Tính tổng số lượng từ giỏ hàng
         const totalItems = (data.cart || []).reduce((acc, item) => acc + parseInt(item.sl), 0);
         setCartCount(totalItems);
      } catch (error) {
         console.error("Error fetching cart items:", error);
      }
   };

   const handleSearch = async (searchTerm) => {
      try {
         const response = await fetch(`http://localhost:8000/api-search.php?ten=${searchTerm}`);
         if (!response.ok) throw new Error("Network response was not ok");

         const data = await response.json();
         if (data.success && data.data.length === 0) {
            setNoResultsFound(true);
            dispatch(setSearchResults([]));
         } else {
            setNoResultsFound(false);
            dispatch(setSearchResults(data.data));
         }
      } catch (error) {
         console.error("Error fetching data:", error);
      }
   };

   // Xử lý cập nhật giỏ hàng
   const handleCartUpdate = (event) => {
      if (event.detail && event.detail.quantity) {
         // Nếu có số lượng cụ thể từ event, cập nhật trực tiếp
         setCartCount((prevCount) => prevCount + parseInt(event.detail.quantity));
      } else {
         // Nếu không có số lượng cụ thể, fetch lại toàn bộ giỏ hàng
         fetchCartItems();
      }
   };
   //logout
   const handleLogout = async () => {
      try {
         const response = await fetch("http://localhost:8000/api-logout.php", {
            method: "POST",
            credentials: "include",
         });

         if (response.ok) {
            logout();
            message.success("Đăng xuất thành công");
            navigate(ROUTERS.USER.HOME);
         }
      } catch (error) {
         console.error("Logout error:", error);
      }
      setIsDropdownOpen(false);
   };
   // Navigate to Admin page
   const navigateToAdmin = () => {
      const userInfo = JSON.parse(localStorage.getItem('userInfo'));
      if (userInfo) {
      const { maQuyenNV, hoTen, email, maNV } = userInfo;
      window.location.href = `http://localhost:3000/Admin/index.php?maQuyenNV=${maQuyenNV}&hoTen=${hoTen}&email=${email}&maNV=${maNV}`;
      } else {
      alert('Chưa đăng nhập!');
      }
   };
   useEffect(() => {
      // Fetch giỏ hàng lần đầu khi component mount
      fetchCartItems();
      window.addEventListener("cartUpdated", handleCartUpdate); // Đăng ký lắng nghe sự kiện cập nhật giỏ hàng

      // Xử lý click outside dropdown
      const handleClickOutside = (event) => {
         if (dropdownRef.current && !dropdownRef.current.contains(event.target)) {
            setIsDropdownOpen(false);
         }
      };
      document.addEventListener("mousedown", handleClickOutside);
      return () => {
         window.removeEventListener("cartUpdated", handleCartUpdate); // Cleanup function
         document.removeEventListener("mousedown", handleClickOutside);
      };
   }, []);

   return (
      <div>
         <WrapperHeader gutter={50}>
            {/* Logo */}
            <Col span={5}>
               <LogoWrapper>
                  <WrapperTextHeader>TechVerse</WrapperTextHeader>
                  <Image width={30} src={logo} alt='Logo' />
               </LogoWrapper>
            </Col>

            {/* Search Bar */}
            <Col span={13} style={{display: "flex", justifyContent: "center"}}>
               <ButtonInputSearch
                  size='large'
                  textButton='Tìm Kiếm'
                  placeholder='Input search text'
                  onSearch={handleSearch}
               />
            </Col>

            {/* User Account & Cart */}
            <Col span={6}>
               <WrapperHeaderAccout>
                  {/* User Account */}
                  <div ref={dropdownRef} style={{display: "flex", alignItems: "center", position: "relative"}}>
                     <WrapperHeaderIcon onClick={() => setIsDropdownOpen(!isDropdownOpen)}>
                        <WrapperImage>
                           <img
                              src={userInfo?.anh ? require(`../../assets/images/user/${userInfo.anh}`) : DEFAULT_AVATAR}
                              alt='Avatar'
                              onError={(e) => {
                                 console.log("Image Error:", {
                                    userInfo: userInfo,
                                    anh: userInfo?.anh,
                                 });
                                 e.target.onerror = null;
                                 e.target.src = DEFAULT_AVATAR;
                              }}
                           />
                        </WrapperImage>
                     </WrapperHeaderIcon>
                     <div>
                        <div>{userInfo ? `Xin chào, ${userInfo.hoTen}!` : "Tài khoản"}</div>
                        <div>
                           {userInfo ? userInfo.taikhoan : "Đăng nhập/Đăng ký"}
                           <CaretDownOutlined onClick={() => setIsDropdownOpen(!isDropdownOpen)} />
                        </div>
                     </div>
                     {isDropdownOpen && (
                        <WrapperDropdown>
                          <WrapperDropdownContent>
                              {!userInfo ? (
                                 <>
                                    <h3>Hãy đăng ký hoặc đăng nhập để mua hàng!</h3>
                                    <button
                                       onClick={() => {
                                          navigate(ROUTERS.USER.LAYOUTLOGIN);
                                          setIsDropdownOpen(false);
                                       }}>
                                       Đăng nhập
                                    </button>
                                    <button
                                       onClick={() => {
                                          navigate(ROUTERS.USER.REGISTER);
                                          setIsDropdownOpen(false);
                                       }}>
                                       Đăng ký
                                    </button>
                                 </>
                              ) : userInfo.maQuyenNV ? (
                                 <> 
                                    <h3>Xin chào, {userInfo.hoTen}!</h3>
                                    <div style={{ padding: "8px 0", color: "#748ffc" }}>
                                       <p>
                                          <strong>Email:</strong> {userInfo.email}
                                       </p>
                                       <p>
                                          <strong>SĐT:</strong> {userInfo.dienThoai}
                                       </p>
                                       <p>
                                          <strong>Quyền:</strong> {userInfo.tenQuyen}
                                       </p>
                                    </div>
                                    <button onClick={navigateToAdmin}>
                                       Quản lý hệ thống
                                    </button>
                                    <button onClick={handleLogout} style={{ color: "red" }}>
                                       Đăng xuất
                                    </button>
                                 </>
                              ) : (
                                 <>
                                    <h3>Xin chào, {userInfo.hoTen}!</h3>
                                    <div style={{ padding: "8px 0", color: "#748ffc" }}>
                                       <p>
                                          <strong>Email:</strong> {userInfo.email}
                                       </p>
                                       <p>
                                          <strong>SĐT:</strong> {userInfo.dienThoai}
                                       </p>
                                       <p>
                                          <strong>Quyền:</strong> {userInfo.tenQuyen}
                                       </p>
                                    </div>
                                    <button
                                       onClick={() => {
                                          navigate(ROUTERS.USER.USERLAYOUT);
                                          setIsDropdownOpen(false);
                                       }}>
                                       Thông tin cá nhân
                                    </button>
                                    <button
                                       onClick={() => {
                                          navigate(ROUTERS.USER.ORDERSTATUS);
                                          setIsDropdownOpen(false);
                                       }}>
                                     Theo dõi đơn hàng
                                    </button>
                                    <button
                                       onClick={() => {
                                          navigate(ROUTERS.USER.PURCHASEHISTORY);
                                          setIsDropdownOpen(false);
                                       }}>
                                       Lịch sử mua hàng
                                    </button>
                                    <button onClick={handleLogout} style={{ color: "red" }}>
                                       Đăng xuất
                                    </button>
                                 </>
                              )}
                           </WrapperDropdownContent>

                        </WrapperDropdown>
                     )}
                  </div>
                  {/* Shopping Cart */}
                  <div style={{display: "flex", flexDirection: "column", alignItems: "center"}}>
                     <Badge count={cartCount} size='small'>
                        <WrapperHeaderIcon onClick={() => navigate(ROUTERS.USER.CART)}>
                           <ShoppingCartOutlined />
                        </WrapperHeaderIcon>
                     </Badge>
                     <div>Giỏ hàng</div>
                  </div>
               </WrapperHeaderAccout>
            </Col>
         </WrapperHeader>

         {/* Navigation Menu */}
         <WrapperTypeProduct>
            <ul style={{display: "flex", gap: "24px", listStyleType: "none", padding: 0}}>
               {menus.map((menu, menuKey) => (
                  <li key={menuKey}>
                     <Link to={menu.path}>{menu.name}</Link>
                  </li>
               ))}
            </ul>
         </WrapperTypeProduct>

         {/* Search Results Message */}
         {noResultsFound && (
            <div style={{textAlign: "center", marginTop: "20px", color: "red"}}>Không tìm thấy sản phẩm</div>
         )}
      </div>
   );
};

export default HeaderComponent;

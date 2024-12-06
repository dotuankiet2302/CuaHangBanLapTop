import { createSlice } from "@reduxjs/toolkit";

// Hàm tải giỏ hàng từ localStorage
const loadCartFromStorage = (userId) => {
  try {
    const savedCart = localStorage.getItem(`cart_${userId}`);
    return savedCart ? JSON.parse(savedCart) : []; 
  } catch (error) {
    console.error("Error loading cart from storage:", error); 
    return []; 
  }
};

// Hàm lưu giỏ hàng vào localStorage
const saveCartToStorage = (userId, cart) => {
  try {
    localStorage.setItem(`cart_${userId}`, JSON.stringify(cart)); 
  } catch (error) {
    console.error("Error saving cart to storage:", error); 
  }
};

// Tạo Redux slice để quản lý trạng thái giỏ hàng
const cartSlice = createSlice({
  name: "cart",
  initialState: {
    items: {}, // Giỏ hàng sẽ được lưu theo userId
    loading: false, 
    error: null, 
  },
  reducers: {
    // Khởi tạo giỏ hàng khi người dùng đăng nhập
    initializeCart: (state, action) => {
      const { userId } = action.payload; 
      if (!state.items[userId]) {
        state.items[userId] = loadCartFromStorage(userId); // Tải giỏ hàng từ localStorage nếu chưa có
      }
    },
    // Thêm sản phẩm vào giỏ hàng
    addToCart: (state, action) => {
      const { userId, product, quantity } = action.payload; 
      if (!state.items[userId]) {
        state.items[userId] = []; // Nếu chưa có giỏ hàng cho userId thì khởi tạo mảng giỏ hàng
      }

      // Kiểm tra sản phẩm đã có trong giỏ hàng chưa
      const existingItem = state.items[userId].find((item) => item.maLap === product.maLap);
      if (existingItem) {
        existingItem.sl += quantity; // Nếu sản phẩm đã có thì cập nhật số lượng
      } else {
        // Nếu sản phẩm chưa có, thêm mới vào giỏ hàng
        state.items[userId].push({
          maLap: product.maLap,
          tenLap: product.tenLap,
          anhBia: product.anhBia,
          giaBan: product.giaBan,
          sl: quantity, 
          SOLUONGTON: product.SOLUONGTON, 
        });
      }

      // Lưu giỏ hàng vào localStorage
      saveCartToStorage(userId, state.items[userId]);
    },
    // Xóa sản phẩm khỏi giỏ hàng
    removeFromCart: (state, action) => {
      const { userId, maLap } = action.payload;
      if (state.items[userId]) {
        // Tìm và lọc bỏ sản phẩm có maLap tương ứng
        state.items[userId] = state.items[userId].filter((item) => item.maLap !== maLap);
        // Lưu giỏ hàng mới vào localStorage
        saveCartToStorage(userId, state.items[userId]);
      }
    },
    // Cập nhật số lượng sản phẩm trong giỏ hàng
    updateQuantity: (state, action) => {
      const { userId, maLap, quantity } = action.payload;
      if (state.items[userId]) {
        const item = state.items[userId].find((item) => item.maLap === maLap);
        if (item) {
          item.sl = quantity; 
          // Lưu lại vào localStorage sau khi cập nhật số lượng
          saveCartToStorage(userId, state.items[userId]);
        }
      }
    },
    // Mua sản phẩm: Xóa các sản phẩm đã được mua khỏi giỏ hàng
    purchaseProduct: (state, action) => {
      const { userId, purchasedItems } = action.payload; 
      
      if (state.items[userId]) {
        state.items[userId] = state.items[userId].filter((item) => 
          !purchasedItems.some(purchasedItem => purchasedItem.maLap === item.maLap) 
        );
        saveCartToStorage(userId, state.items[userId]);
      }
    },
    
    // Xóa toàn bộ giỏ hàng
    clearCart: (state, action) => {
      const { userId } = action.payload;
      state.items[userId] = []; // Xóa toàn bộ giỏ hàng
      saveCartToStorage(userId, []); // Lưu lại giỏ hàng trống vào localStorage
    },
  },
});

// Export các action để sử dụng trong các component
export const { initializeCart, addToCart, removeFromCart, updateQuantity, purchaseProduct, clearCart } = cartSlice.actions;

// Selector để lấy giỏ hàng của người dùng
export const selectCartItems = (state, userId) => state.cart.items[userId] || [];
// Selector để tính tổng giá trị giỏ hàng của người dùng
export const selectTotalCounter = (state, userId) => {
  const items = state.cart.items[userId] || [];
  return items.reduce((total, item) => total + item.giaBan * item.sl, 0);
};

// Export reducer để sử dụng trong store
export default cartSlice.reducer;

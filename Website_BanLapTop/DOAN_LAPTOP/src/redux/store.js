// import { configureStore } from '@reduxjs/toolkit';
// import counterReducer from './slides/counterSlide';

// export const store = configureStore({
//   reducer: {
//     counter: counterReducer,
//   },
// });

// export default store;

import { configureStore } from '@reduxjs/toolkit';
import searchReducer from './searchSlice';
import cartReducer from './slides/cartSlide';

const store = configureStore({
    reducer: {
        search: searchReducer,
        cart: cartReducer
    }
});
    
export default store;

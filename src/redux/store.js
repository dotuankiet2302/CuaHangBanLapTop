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

const store = configureStore({
    reducer: {
        search: searchReducer
    }
});
    
export default store;

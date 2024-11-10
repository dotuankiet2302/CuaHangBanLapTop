import React from 'react';
import ReactDOM from 'react-dom';
import { Provider } from 'react-redux';
import { store } from './redux/store';
import App from './App';
//import 'antd/dist/antd.css'; // Đảm bảo rằng bạn sử dụng antd.css
//import 'slick-carousel/slick/slick.css';
//import 'slick-carousel/slick/slick-theme.css';

ReactDOM.render(
  <Provider store={store}>
    <App />
  </Provider>,
  document.getElementById('root')
);

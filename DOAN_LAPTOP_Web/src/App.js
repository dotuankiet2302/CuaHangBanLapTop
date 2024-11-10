import React, { Fragment } from 'react';
import {BrowserRouter as Router, Routes, Route} from 'react-router-dom'
import HomePage from './pages/HomePage/HomePage';
import OrderPage from './pages/OrderPage/OrderPage';
import {routes} from './routes';
import HeaderComponent from './components/HeaderComponent/HeaderComponent';
import DefaultComponent from './components/DefaultComponent/DefaultComponent';
/*import { useSelector, useDispatch } from 'react-redux';
import { decrement, increment } from './redux/slides/counterSlide';*/
import FooterComponent from './components/FooterComponent/FooterComponent';

function App() {
 /* const count = useSelector((state) => state.counter.value);
  const dispatch = useDispatch();*/

  return (
    <div>
      <Router>
        <Routes>
          {routes.map((route)=>{
            const Page=route.page
            const Layout=route.isShowHeader ? DefaultComponent : Fragment
            const Layouts=route.isShowFooter ? FooterComponent : Fragment
            return(
              <Route key={route.path} path={route.path} element={
                <Layout>
                  
                   <Page/> 
                   <Layouts/>
                </Layout>
                
             
            } />
            )
          })}
        
        </Routes>
      </Router>
      {/* <div>
        <button
          aria-label="Increment value"
          onClick={() => dispatch(increment())}
        >
          Increment
        </button>
        <span>{count}</span>
        <button
          aria-label="Decrement value"
          onClick={() => dispatch(decrement())}
        >
          Decrement
        </button>
      </div> */}
    </div>
  );
}

export default App;

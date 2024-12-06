import HomePage from "../pages/HomePage/HomePage";
import NotFoundPage from "../pages/NotFoundPage/NotFoundPage";
import OrderPage from "../pages/OrderPage/OrderPage";
import ProductDetailsPage from "../pages/ProductDeteilsPage/ProductDetailsPage";
import ProductsPage from "../pages/ProductsPage/ProductsPage";
import LayoutSignInPage from "../pages/SignInPage/LayoutSignInPage";
import SignInPage from "../pages/SignInPage/SignInPage";
import SignInEmployPape from "../pages/SignInPage/SignInEmployPage";
import SignUpPage from "../pages/SignUpPage/SignUpPage";
import TypeProductPage from "../pages/TypeProductPage/TypeProductPage";
//import FooterComponent from "../components/FooterComponent/FooterComponent";
import CartPage from "../pages/CartPage/CartPage";
import userPageInfo from "../pages/userPage/userPage";

import { ROUTERS } from "../utils/router";
import UserLayout from "../pages/userPage/UserLayout";
import PassWordPage from "../pages/userPage/PassWordPage";
import ArticlePage from "../pages/ArticlePage/ArticlePage";
import GoogleCallback from '../pages/SignInPage/GoogleCallback';
import ContextPage from "../pages/ContectPage/ContextPage";
import PurchaseHistory from './../pages/PurchaseHistoryPage/PurchaseHistoryPage';
import OrderStatusPage from "../pages/OrderStatusPage/OrderStatusPage";
export const routes=[
    {
        //path: '/',
        path: ROUTERS.USER.HOME,
        page: HomePage,
        isShowHeader: true,
        isShowFooter: true,
        
    },
    {
        path: '/order',
        page: OrderPage,
        isShowHeader: true,
    },
    {
        path: '/products',
        page: ProductsPage,
        isShowHeader: true,
    },
    {
        path: ROUTERS.USER.PRODUCTS,
        //path: '/type',
        page: TypeProductPage,
        isShowHeader: true,
    },
    {
        path: ROUTERS.USER.REGISTER,
        page: SignUpPage,
        isShowHeader: false,
    },
    {
      path: ROUTERS.USER.LAYOUTLOGIN,
      page: LayoutSignInPage,
      isShowHeader: false,
  },
    {
        path: ROUTERS.USER.LOGIN,
        page: SignInPage,
        isShowHeader: false,
    },
    {
      path: ROUTERS.USER.LOGINEMPLOY,
      page: SignInEmployPape,
      isShowHeader: false,
    },
    {
        path: ROUTERS.USER.CART,
        page: CartPage,
        isShowHeader: false,
        isShowFooter: true,
    },
    {
        //path: '/product-details',
        path: ROUTERS.USER.DETAIL + "/:id",
        page: ProductDetailsPage,
        isShowHeader: true,
        isShowFooter: true,
        
    },
    {
      //path: '/product-details',
      path: ROUTERS.USER.USERINFO,
      page: userPageInfo,
     // isShowHeader: true,
      isShowFooter: true,
      
  },
  {
   path: ROUTERS.USER.USERLAYOUT,
   page: UserLayout,
   children: [  // Thêm children routes
      {
        path: ROUTERS.USER.USERINFO,
        page: userPageInfo
      },
      {
        path: ROUTERS.USER.PASSINFO,
        page: PassWordPage
      }
   ],
   isShowFooter: true,
   
},{
   path: ROUTERS.USER.PURCHASEHISTORY,
   page: PurchaseHistory,
   isShowFooter: true,
   
}, {
   path: ROUTERS.USER.ORDERSTATUS,
   page: OrderStatusPage,
   isShowFooter: true,
   
},{
   path: ROUTERS.USER.ARTICLE,
   page: ArticlePage,
   isShowHeader: true,
   isShowFooter: true,
},
{
   path: ROUTERS.USER.CONTECT,
   page: ContextPage,
   isShowHeader: true,
   isShowFooter: true,
},
{
   path:"/auth/google/callback",
   element: GoogleCallback,
},
{
   path: ROUTERS.USER.GOOGLE_API,
   page: SignInPage,
   isShowHeader: false,
},
{
   path: ROUTERS.USER.GOOGLE_CALLBACK,
   page: SignInPage,
   isShowHeader: false,
},
    {
        path: '*',
        page: NotFoundPage
    }
]
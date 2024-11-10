import HomePage from "../pages/HomePage/HomePage";
import NotFoundPage from "../pages/NotFoundPage/NotFoundPage";
import OrderPage from "../pages/OrderPage/OrderPage";
import ProductDetailsPage from "../pages/ProductDeteilsPage/ProductDetailsPage";
import ProductsPage from "../pages/ProductsPage/ProductsPage";
import SignInPage from "../pages/SignInPage/SignInPage";
import SignUpPage from "../pages/SignUpPage/SignUpPage";
import TypeProductPage from "../pages/TypeProductPage/TypeProductPage";
import FooterComponent from "../components/FooterComponent/FooterComponent";
import CardPage from "../pages/CardPage/CardPage";
import { ROUTERS } from "../utils/router";
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
        path: ROUTERS.USER.LOGIN,
        page: SignInPage,
        isShowHeader: false,
    },
    {
        path: ROUTERS.USER.CART,
        page: CardPage,
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
        path: '*',
        page: NotFoundPage
    }
]
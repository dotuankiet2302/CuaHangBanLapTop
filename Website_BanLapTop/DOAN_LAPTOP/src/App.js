import React, {Fragment} from "react";
import {BrowserRouter as Router, Routes, Route} from "react-router-dom";
import {routes} from "./routes";
import DefaultComponent from "./components/DefaultComponent/DefaultComponent";
import FooterComponent from "./components/FooterComponent/FooterComponent";
import {UserProvider} from "./pages/UserContext/UserContext";
import {Provider} from "react-redux";
import store from "./redux/store";

function App() {
   return (
      <Provider store={store}>
         <UserProvider>
            <Router>
               <div>
                  <Routes>
                     {routes.map((route) => {
                        const Page = route.page;
                        const Layout = route.isShowHeader ? DefaultComponent : Fragment;
                        const Layouts = route.isShowFooter ? FooterComponent : Fragment;

                        return (
                           <Route
                              key={route.path}
                              path={route.path}
                              element={
                                 <Layout>
                                    <Page />
                                    <Layouts />
                                 </Layout>
                              }
                           />
                        );
                     })}
                  </Routes>
               </div>
            </Router>
         </UserProvider>
      </Provider>
   );
}

export default App;

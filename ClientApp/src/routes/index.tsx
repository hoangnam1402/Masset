import React, { ReactNode, lazy, Suspense, useEffect } from "react";
import { Route, Routes , Navigate } from "react-router-dom";

import { CREATE_USER, HOME, LOGIN, NOTFOUND, MANAGE_USER, EDIT_USER, MANAGE_ASSET} from "../constants/pages";
import InLineLoader from "../components/InlineLoader";
import { useAppDispatch, useAppSelector } from "../hooks/redux";
import PrivateRoute from "./PrivateRoute";
import { me } from "../containers/Authorize/reducer";

const Home = lazy(() => import("../containers/Home"));
const Login = lazy(() => import("../containers/Authorize"));
const NotFound = lazy(() => import("../containers/NotFound"));
// const User = lazy(() => import("../containers/User"));

interface Props {
  children?: ReactNode
  // any props that come into the component
}

const SusspenseLoading = ({ children } : Props) => (
  <Suspense fallback={<InLineLoader />}>{children}</Suspense>
);

const Routess = () => {
  const { isAuth, account } = useAppSelector((state) => state.authReducer);
  const dispatch = useAppDispatch();

  useEffect(() => {
    dispatch(me());
  }, []);

  return (
    <SusspenseLoading>
      <Routes>
        <Route path={"/"}>
          <Navigate to={HOME}></Navigate>
        </Route>
        
        <Route element={<PrivateRoute/>}>
          
        </Route>
        <PrivateRoute path={HOME}>
          <Home />
        </PrivateRoute>
        <Route path={LOGIN}>
          <Login />
        </Route>

        {/* <PrivateRoute path={MANAGE_USER}>
          <User />
        </PrivateRoute> */}

        <Route path="*" element={<NotFound/>} />
      </Routes>
    </SusspenseLoading>
  );
};

export default Routess;

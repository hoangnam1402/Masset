import React, { ReactNode, lazy, Suspense, useEffect } from "react";
import { Route, Routes , Navigate } from "react-router-dom";

import { HOME, LOGIN} from "../constants/pages";
import InLineLoader from "../components/InlineLoader";
import { useAppDispatch, useAppSelector } from "../hooks/redux";
import { me } from "../containers/Authorize/reducer";

const Home = lazy(() => import("../containers/Home"));
const Login = lazy(() => import("../containers/Authorize"));
const NotFound = lazy(() => import("../containers/NotFound"));

interface Props {
  children?: ReactNode
}

const SusspenseLoading = ({ children } : Props) => (
  <Suspense fallback={<InLineLoader />}>{children}</Suspense>
);

const PrivateRoute = (children: any) => {
  const { isAuth } = useAppSelector(state => state.authReducer);
  return isAuth ? children : <Navigate to={LOGIN} />;
};

const Routess = () => {
  const dispatch = useAppDispatch();

  useEffect(() => {
    dispatch(me());
  }, []);

  return (
    <SusspenseLoading>
      <Routes>
        <Route path={'/'} element={
          <PrivateRoute>
            <Home />
          </PrivateRoute>
        }/>

        <Route path={HOME} element={
          <PrivateRoute>
            <Home />
          </PrivateRoute>
        }/>

        <Route path={LOGIN} element={<Login />}/>

        <Route path="*" element={<NotFound/>} />
      </Routes>
    </SusspenseLoading>
  );
};

export default Routess;

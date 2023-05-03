import React, { ReactNode, lazy, Suspense, useEffect } from "react";
import { Route, Routes , Navigate } from "react-router-dom";

import { HOME, LOGIN} from "../constants/pages";
import InLineLoader from "../components/InlineLoader";
import { useAppDispatch } from "../hooks/redux";
import PrivateRoute from "./PrivateRoute";
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

const Routess = () => {
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
        <Route path={LOGIN}>
          <Login />
        </Route>

        <PrivateRoute path={HOME}>
          <Home />
        </PrivateRoute>
        
        <Route path="*" element={<NotFound/>} />
      </Routes>
    </SusspenseLoading>
  );
};

export default Routess;

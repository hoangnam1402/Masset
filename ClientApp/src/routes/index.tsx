import React, { lazy, Suspense, useEffect } from "react";
import { Route, Switch, Redirect } from "react-router-dom";

import { CREATE_USER, HOME, LOGIN, NOTFOUND, MANAGE_USER, EDIT_USER, MANAGE_ASSET, MANAGE_ASSIGNMENT} from "../constants/pages";
import InLineLoader from "../components/InlineLoader";
import { useAppDispatch, useAppSelector } from "../hooks/redux";
import LayoutRoute from "./LayoutRoute";
import PrivateRoute from "./PrivateRoute";
import Roles from "src/constants/roles";
import { me } from "src/containers/Authorize/reducer";
import CreateUser from "src/containers/User/Create";
import Asset from "src/containers/Asset";
import Assignment from "src/containers/Assignment";

const Home = lazy(() => import("../containers/Home"));
const Login = lazy(() => import("../containers/Authorize"));
const NotFound = lazy(() => import("../containers/NotFound"));
const User = lazy(() => import("../containers/User"));

const SusspenseLoading = ({ children }) => (
  <Suspense fallback={<InLineLoader />}>{children}</Suspense>
);

const Routes = () => {
  const { isAuth, account } = useAppSelector((state) => state.authReducer);
  const dispatch = useAppDispatch();

  useEffect(() => {
    dispatch(me());
  }, []);

  return (
    <SusspenseLoading>
      <Switch>
        <Route exact path={"/"}>
          <Redirect to={HOME}></Redirect>
        </Route>
        
        <PrivateRoute exact path={HOME}>
          <Home />
        </PrivateRoute>
        <Route exact path={LOGIN}>
          <Login />
        </Route>

        <PrivateRoute path={MANAGE_USER}>
          <User />
        </PrivateRoute>
        <PrivateRoute  path={MANAGE_ASSET}>
          <Asset />
        </PrivateRoute>
        <PrivateRoute  path={MANAGE_ASSIGNMENT}>
          <Assignment />
        </PrivateRoute>

        <Route path="*" component={NotFound} />
      </Switch>
    </SusspenseLoading>
  );
};

export default Routes;

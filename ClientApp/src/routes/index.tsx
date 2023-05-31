import React, { ReactNode, lazy, Suspense, useEffect } from "react";
import { Route, Routes } from "react-router-dom";

import { ASSET_TYPES, BRANDS, DASHBOARD, DEPRECIATIONS, LOCATIONS, LOGIN, MAINTENANCES, MANAGE_ASSETS, 
  MANAGE_COMPONENTS, SUPPLIERS, USER} from "../constants/pages";
import InLineLoader from "../components/InlineLoader";
import { useAppDispatch, useAppSelector } from "../hooks/redux";
import { me } from "../containers/Authorize/reducer";
import PrivateRoute from "./PrivateRoute";
import Asset from "../containers/Asset";
import Component from "../containers/Component";

const Dashboard = lazy(() => import("../containers/Dashboard"));
const Login = lazy(() => import("../containers/Authorize"));
const User = lazy(() => import("../containers/User"));
const Maintenance = lazy(() => import("../containers/Maintenance"));
const Depreciation = lazy(() => import("../containers/Depreciation"));
const AssetType = lazy(() => import("../containers/AssetType"));
const Brand = lazy(() => import("../containers/Brand"));
const Supplier = lazy(() => import("../containers/Supplier"));
const Location = lazy(() => import("../containers/Location"));
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
        <Route path={'/'} element={
          <PrivateRoute>
            <Dashboard />
          </PrivateRoute>
        }/>

        <Route path={DASHBOARD} element={
          <PrivateRoute>
            <Dashboard />
          </PrivateRoute>
        }/>

        <Route path={MANAGE_ASSETS} element={
          <PrivateRoute>
            <Asset />
          </PrivateRoute>
        }/>

        <Route path={MANAGE_COMPONENTS} element={
          <PrivateRoute>
            <Component />
          </PrivateRoute>
        }/>

        <Route path={MAINTENANCES} element={
          <PrivateRoute>
            <Maintenance />
          </PrivateRoute>
        }/>

        <Route path={DEPRECIATIONS} element={
          <PrivateRoute>
            <Depreciation />
          </PrivateRoute>
        }/>

        <Route path={ASSET_TYPES} element={
          <PrivateRoute>
            <AssetType />
          </PrivateRoute>
        }/>

        <Route path={BRANDS} element={
          <PrivateRoute>
            <Brand />
          </PrivateRoute>
        }/>

        <Route path={SUPPLIERS} element={
          <PrivateRoute>
            <Supplier />
          </PrivateRoute>
        }/>

        <Route path={LOCATIONS} element={
          <PrivateRoute>
            <Location />
          </PrivateRoute>
        }/>

        <Route path={USER} element={
          <PrivateRoute>
            <User />
          </PrivateRoute>
        }/>

        <Route path={LOGIN} element={<Login />}/>

        <Route path="*" element={<NotFound/>} />
      </Routes>
    </SusspenseLoading>
  );
};

export default Routess;

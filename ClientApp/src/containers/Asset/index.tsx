import React, { Fragment, lazy } from "react";
import { Route, Routes } from "react-router-dom";
import { INFO } from '../../constants/pages';

const Assets = lazy(() => import("./List"));
const AssetInfo = lazy(() => import("./Info"));

const Asset = () => {
  return (
    <>
      <Fragment>
        <Routes>
          <Route index element={<Assets />}/>
          <Route path={INFO} element={<AssetInfo />}/>
        </Routes>
      </Fragment>
    </>
  );
}

export default Asset;

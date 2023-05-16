import React, { Fragment, lazy, useEffect, useState } from "react";
import Roles from "../../constants/roles";
import { useAppDispatch, useAppSelector } from "../../hooks/redux";
import { Route, Routes } from "react-router-dom";
import { ASSET_INFO } from '../../constants/pages';

const Assets = lazy(() => import("./List"));
const AssetInfo = lazy(() => import("./Info"));

const Asset = () => {
  return (
    <>
      <Fragment>
        <Routes>
          <Route index element={<Assets />}/>
          <Route path={ASSET_INFO} element={<AssetInfo />}/>
        </Routes>
      </Fragment>
    </>
  );
}

export default Asset;

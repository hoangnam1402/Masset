import React, { Fragment, lazy, useEffect, useState } from "react";
import { Route, Routes } from "react-router-dom";
import { INFO, QRCODE } from '../../constants/pages';

const Assets = lazy(() => import("./List"));
const AssetInfo = lazy(() => import("./Info"));
const QrCodeGenerator = lazy(() => import("./QrCodeGenerator"))

const Asset = () => {
  return (
    <>
      <Fragment>
        <Routes>
          <Route index element={<Assets />}/>
          <Route path={INFO} element={<AssetInfo />}/>
          <Route path={QRCODE} element={<QrCodeGenerator />}/>
        </Routes>
      </Fragment>
    </>
  );
}

export default Asset;

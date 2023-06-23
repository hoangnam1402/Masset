import React, { Fragment, lazy } from "react";
import { Route, Routes } from "react-router-dom";
import { INFO } from '../../constants/pages';

const Components = lazy(() => import("./List"));
const ComponentInfo = lazy(() => import("./Info"));

const Component = () => {
  return (
    <>
      <Fragment>
        <Routes>
          <Route index element={<Components />}/>
          <Route path={INFO} element={<ComponentInfo />}/>
        </Routes>
      </Fragment>
    </>
  );
}

export default Component;

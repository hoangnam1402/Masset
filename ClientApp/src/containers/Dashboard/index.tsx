import React, { useEffect, useState } from "react";
import { useAppDispatch, useAppSelector } from "../../hooks/redux";
import { Route, useNavigate } from "react-router-dom";
import { logout } from "../Authorize/reducer";
import { LOGIN } from "../../constants/pages";
import { getDashboard } from "./reducer";

const Dashboard = () => {
  const { account } = useAppSelector((state) => state.authReducer);
  const dispatch = useAppDispatch();
  const role = account?.role;
  const history = useNavigate();
  if (account?.firstLogin || account?.isActive == false) {
    dispatch(logout());
    history(LOGIN);
  }

  useEffect(() => {
    dispatch(getDashboard());
    console.log(account);
	}, []);
 
  return (
    <>
        <h1>OK</h1>
        <h1></h1>
    </>
  );
};

export default Dashboard;

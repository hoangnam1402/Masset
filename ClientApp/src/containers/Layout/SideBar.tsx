import React, { Fragment } from "react";
import { HOME, MANAGE_ASSET, MANAGE_USER, REPORT, REQUEST_FOR_RETURNING } from "../../constants/pages";
import Roles from "../../constants/roles";
import { useAppSelector } from "../../hooks/redux";
import { useLocation, NavLink } from "react-router-dom";
const SideBar = () => {
  const { account } = useAppSelector((state) => state.authReducer);
  const { pathname } = useLocation();
  const pathnameSplit = pathname.split("/");
  const firstPathName = "/"+pathnameSplit[1]

  return (
    <div className="nav-left mb-5">
      <img src="/images/Logo_lk.png" alt="logo" />
      <p className="brand intro-x">Asset Management</p>

      {account?.role != Roles.Staff && (
        <Fragment>
          <NavLink className={`navItem intro-x ${firstPathName==HOME?"active":""}`} to={HOME}>
            <button className="btnCustom">Home</button>
          </NavLink>
          <NavLink className={`navItem intro-x ${firstPathName==MANAGE_USER?"active":""}`} to={MANAGE_USER}>
            <button className="btnCustom">Manage User</button>
          </NavLink>
          <NavLink className={`navItem intro-x ${firstPathName==MANAGE_ASSET?"active":""}`} to={MANAGE_ASSET}>
            <button className="btnCustom">Manage Asset</button>
          </NavLink>
          <NavLink className="navItem intro-x" to={REQUEST_FOR_RETURNING}>
            <button className="btnCustom">Request for Returning</button>
          </NavLink>
          <NavLink className="navItem intro-x" to={REPORT}>
          <button className="btnCustom">Report</button>
        </NavLink>
        </Fragment>
      )}
      {account?.role == Roles.Staff && (
        <NavLink className="navItem intro-x" to={HOME}>
          <button className="btnCustom">Home</button>
        </NavLink>
      )}
    </div>
  );
};

export default SideBar;

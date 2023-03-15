import React, { Fragment } from "react";
import { NavLink } from "react-router-dom";
import { HOME, MANAGE_ASSET, MANAGE_ASSIGNMENT, MANAGE_USER, REPORT, REQUEST_FOR_RETURNING } from "src/constants/pages";
import Roles from "src/constants/roles";
import { useAppSelector } from "src/hooks/redux";
import { Link, useHistory, useLocation } from "react-router-dom";
const SideBar = () => {
  const { account } = useAppSelector((state) => state.authReducer);
  const { pathname } = useLocation();
  const pathnameSplit = pathname.split("/");
  const firstPathName = "/"+pathnameSplit[1]

  return (
    <div className="nav-left mb-5">
      <img src="/images/Logo_lk.png" alt="logo" />
      <p className="brand intro-x">Online Asset Management</p>

      {account?.role == Roles.Admin && (
        <Fragment>
          <NavLink className={`navItem intro-x ${firstPathName==HOME?"active":""}`} exact to={HOME}>
            <button className="btnCustom">Home</button>
          </NavLink>
          <NavLink className={`navItem intro-x ${firstPathName==MANAGE_USER?"active":""}`} exact to={MANAGE_USER}>
            <button className="btnCustom">Manage User</button>
          </NavLink>
          <NavLink className={`navItem intro-x ${firstPathName==MANAGE_ASSET?"active":""}`} exact to={MANAGE_ASSET}>
            <button className="btnCustom">Manage Asset</button>
          </NavLink>
          <NavLink className={`navItem intro-x ${firstPathName==MANAGE_ASSIGNMENT?"active":""}`} exact to={MANAGE_ASSIGNMENT}>
            <button className="btnCustom">Manage Assignment</button>
          </NavLink>
          <NavLink className="navItem intro-x" exact to={REQUEST_FOR_RETURNING}>
            <button className="btnCustom">Request for Returning</button>
          </NavLink>
          <NavLink className="navItem intro-x" exact to={REPORT}>
          <button className="btnCustom">Report</button>
        </NavLink>
        </Fragment>
      )}
      {account?.role == Roles.Staff && (
        <NavLink className="navItem intro-x" exact to={HOME}>
          <button className="btnCustom">Home</button>
        </NavLink>
      )}
    </div>
  );
};

export default SideBar;

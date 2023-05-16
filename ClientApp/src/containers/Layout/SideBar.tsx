import React, { Fragment } from "react";
import { DASHBOARD, ASSETS, COMPONENTS, MAINTENANCES, DEPRECIATIONS, ASSET_TYPES, BRANDS, SUPPLIERS, LOCATIONS, EMPLOYEES, DEPARTMENTS } from "../../constants/pages";
import { useLocation, NavLink } from "react-router-dom";
const SideBar = () => {
  const { pathname } = useLocation();
  const pathnameSplit = pathname.split("/");
  const firstPathName = "/"+pathnameSplit[1]

  return (
    <div className="nav-left mb-5">
      <Fragment>
        <NavLink className={`navItem intro-x ${firstPathName===DASHBOARD?"active":""}`} to={DASHBOARD}>
          <button className="btnCustom">Dashboard</button>
        </NavLink>
        <NavLink className={`navItem intro-x ${firstPathName===ASSETS?"active":""}`} to={ASSETS}>
          <button className="btnCustom">Assets</button>
        </NavLink>
        <NavLink className={`navItem intro-x ${firstPathName===COMPONENTS?"active":""}`} to={COMPONENTS}>
          <button className="btnCustom">Components</button>
        </NavLink>
        <NavLink className={`navItem intro-x ${firstPathName===MAINTENANCES?"active":""}`} to={MAINTENANCES}>
          <button className="btnCustom">Maintenances</button>
        </NavLink>
        <NavLink className={`navItem intro-x ${firstPathName===DEPRECIATIONS?"active":""}`} to={DEPRECIATIONS}>
          <button className="btnCustom">Depreciations</button>
        </NavLink>
        <NavLink className={`navItem intro-x ${firstPathName===ASSET_TYPES?"active":""}`} to={ASSET_TYPES}>
          <button className="btnCustom">Asset Types</button>
        </NavLink>
        <NavLink className={`navItem intro-x ${firstPathName===BRANDS?"active":""}`} to={BRANDS}>
          <button className="btnCustom">Brands</button>
        </NavLink>
        <NavLink className={`navItem intro-x ${firstPathName===SUPPLIERS?"active":""}`} to={SUPPLIERS}>
          <button className="btnCustom">Supplies</button>
        </NavLink>
        <NavLink className={`navItem intro-x ${firstPathName===LOCATIONS?"active":""}`} to={LOCATIONS}>
          <button className="btnCustom">Locations</button>
        </NavLink>
        <NavLink className={`navItem intro-x ${firstPathName===EMPLOYEES?"active":""}`} to={EMPLOYEES}>
          <button className="btnCustom">Employees</button>
        </NavLink>
        <NavLink className={`navItem intro-x ${firstPathName===DEPARTMENTS?"active":""}`} to={DEPARTMENTS}>
          <button className="btnCustom">Departments</button>
        </NavLink>
      </Fragment>
    </div>
  );
};

export default SideBar;

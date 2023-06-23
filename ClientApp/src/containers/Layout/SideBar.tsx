import React, { Fragment } from "react";
import { DASHBOARD, ASSETS, COMPONENTS, MAINTENANCES, DEPRECIATIONS, ASSET_TYPES, BRANDS, SUPPLIERS, 
  LOCATIONS, USER, SETTING } from "../../constants/pages";
import { useLocation, NavLink } from "react-router-dom";
import { useAppSelector } from "../../hooks/redux";
const SideBar = () => {
  const { pathname } = useLocation();
  const pathnameSplit = pathname.split("/");
  const firstPathName = "/"+pathnameSplit[1]
  const { setting } = useAppSelector((state) => state.settingReducer);

  return (
    <div className="nav-left mb-5">
      {setting?.image && <img id="logo" src={`data:image/jpeg;base64,${setting?.image}`} alt={setting?.name} />}
      {setting && <p id="tiles" className="brand intro-x">{setting?.name}</p>}

      <Fragment>
        <NavLink className={`navItem intro-x ${firstPathName===DASHBOARD?"active":""}`} to={DASHBOARD}>
          <button className="btnCustom">Dashboard</button>
        </NavLink>
        <NavLink className={`navItem intro-x ${firstPathName===ASSETS?"active":""}`} to={ASSETS}>
          <button className="btnCustom">Properties</button>
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
        <NavLink className={`navItem intro-x ${firstPathName===USER?"active":""}`} to={USER}>
          <button className="btnCustom">Users</button>
        </NavLink>
        <NavLink className={`navItem intro-x ${firstPathName===SETTING?"active":""}`} to={SETTING}>
          <button className="btnCustom">Setting</button>
        </NavLink>
      </Fragment>
    </div>
  );
};

export default SideBar;

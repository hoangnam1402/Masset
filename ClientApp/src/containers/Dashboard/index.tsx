import React, { useEffect, useState } from "react";
import { useAppDispatch, useAppSelector } from "../../hooks/redux";
import { NavLink, Route, useNavigate } from "react-router-dom";
import { logout } from "../Authorize/reducer";
import { ASSETS, COMPONENTS, LOGIN, MAINTENANCES, USER } from "../../constants/pages";
import { getDashboard } from "./reducer";
import { Link45deg } from "react-bootstrap-icons";
import { Pie } from "react-chartjs-2";
import { Chart as ChartJS, ArcElement, Tooltip, Legend } from 'chart.js';
import { StateArchivedLabel, StateBrokenLabel, StateLostLabel, StateOutOfRepairLabel,
  StatePendingLabel, StateReadyToDeployLabel } from "../../constants/assetConstants";

const Dashboard = () => {
  ChartJS.register(ArcElement, Tooltip, Legend);
  const { account } = useAppSelector((state) => state.authReducer);
  const { dashboard } = useAppSelector((state) => state.dashboardReducer);
  const dispatch = useAppDispatch();
  const history = useNavigate();
  if (account?.firstLogin || account?.isActive == false) {
    dispatch(logout());
    history(LOGIN);
  }

  const LabelsOfType: string[] = [];
  const NumbersOfType: number[] = [];
  const ColorOfType: string[] = [];
  const Types: any[] | undefined = dashboard?.numberOfTypes;

  const LabelsOfStatus = [StateReadyToDeployLabel, StatePendingLabel, StateArchivedLabel, 
    StateBrokenLabel, StateLostLabel, StateOutOfRepairLabel];
  const NumbersOfStatus = [dashboard?.numberOfStatus1, dashboard?.numberOfStatus2, dashboard?.numberOfStatus3,
    dashboard?.numberOfStatus4, dashboard?.numberOfStatus5, dashboard?.numberOfStatus6];
  const ColorOfStatus: string[] =[];
  const dynamicColors = function() {
    var r = Math.floor(Math.random() * 255);
    var g = Math.floor(Math.random() * 255);
    var b = Math.floor(Math.random() * 255);
    return "rgb(" + r + "," + g + "," + b + ")";
  };

  for (var i in Types) {
    LabelsOfType.push(Types[i].name);
    NumbersOfType.push(Types[i].count);
    ColorOfType.push(dynamicColors());
  };

  for (var i in LabelsOfStatus) {
    ColorOfStatus.push(dynamicColors());
  };

  const AssetByType = {
    labels: LabelsOfType,
    datasets: [
      {
        data: NumbersOfType,
        backgroundColor: ColorOfType,
      },
    ],
  }

  const AssetByStatus = {
    labels: LabelsOfStatus,
    datasets: [
      {
        data: NumbersOfStatus,
        backgroundColor: ColorOfStatus,
      },
    ],
  }
  
  useEffect(() => {
    dispatch(getDashboard());
  }, []);
 
  return (
    <>
      <div className="content">
        <div className="row">
          <div className="col-lg-3 col-sm-6">
            <div className="card background-blue color-white">
              <div className="content">
                <div className="row">
                  <div className="col-md-3">
                    <div className="text-center">
                      <img src="/icon-asset.png" alt="icon-asset" className="icon-asset" />
                    </div>
                  </div>
                  <div className="col-md-1 "/>
                  <div className="col-md-7 ">
                    <div className="numbers">
                      <p>Asset</p>
                      <span className="totalhead totalasset">{dashboard?.totalAsset}</span>
                    </div>
                  </div>
                </div>

                <div className="footer">
                  <hr/>
                  <div className="stats">
                    <NavLink className="navItem intro-x color-white" to={ASSETS}>
                      <Link45deg className="text-white mx-2"/>
                      More info
                    </NavLink>
                  </div>
                </div>
              </div>
            </div>
          </div>

          <div className="col-lg-3 col-sm-6">
            <div className="card background-yellow color-white">
              <div className="content">
                <div className="row">
                  <div className="col-md-3">
                    <div className="text-center">
                      <img src="/icon-component.png" alt="icon-component" className="icon-component" />
                    </div>
                  </div>

                  <div className="col-md-1 "/>
                  <div className="col-md-7 ">
                    <div className="numbers">
                      <p>Component</p>
                      <span className="totalhead totalcomponent">{dashboard?.totalComponent}</span>
                    </div>
                  </div>
                </div>

                <div className="footer">
                  <hr/>
                  <div className="stats">
                    <NavLink className="navItem intro-x color-white" to={COMPONENTS}>
                      <Link45deg className="text-white mx-2"/>
                      More info
                    </NavLink>
                  </div>
                </div>
              </div>
            </div>
          </div>

          <div className="col-lg-3 col-sm-6">
            <div className="card background-green color-white">
              <div className="content">
                <div className="row">
                  <div className="col-md-3">
                    <div className="text-center">
                      <img src="/icon-maintenance.png" alt="icon-maintenance" className="icon-maintenance" />
                    </div>
                  </div>
                  
                  <div className="col-md-1 "/>
                  <div className="col-md-7 ">
                    <div className="numbers">
                      <p>Maintenance</p>
                      <span className="totalhead totalmaintenance">{dashboard?.totalMaintenance}</span>
                    </div>
                  </div>
                </div>

                <div className="footer">
                  <hr/>
                  <div className="stats">
                    <NavLink className="navItem intro-x color-white" to={MAINTENANCES}>
                      <Link45deg className="text-white mx-2"/>
                      More info
                    </NavLink>
                  </div>
                </div>
              </div>
            </div>
          </div>

          <div className="col-lg-3 col-sm-6">
            <div className="card background-red color-white">
              <div className="content">
                <div className="row">
                  <div className="col-md-3">
                    <div className="text-center">
                      <img src="/icon-employee.png" alt="icon-employee" className="icon-employee" />
                    </div>
                  </div>

                  <div className="col-md-2 "/>
                  <div className="col-md-7 ">
                    <div className="numbers">
                      <p>User</p>
                      <span className="totalhead totalemployee">{dashboard?.totalEmployee}</span>
                    </div>
                  </div>
                </div>

                <div className="footer">
                  <hr/>
                  <div className="stats">
                    <NavLink className="navItem intro-x color-white" to={USER}>
                      <Link45deg className="text-white mx-2"/>
                      More info
                    </NavLink>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>

        <br/>

        <div className="row">
          <div className="col-lg-6 col-sm-6">
            <div className="card">
              <div className="header">
                <h5 className="title text-center">Asset by type</h5>
              </div>
              <div className="content">
                <Pie data={AssetByType} />
              </div>
            </div>
          </div>
          <div className="col-lg-6 col-sm-6">
            <div className="card">
              <div className="header">
                <h5 className="title text-center">Asset by status</h5>
              </div>
              <div className="content">
                <Pie data={AssetByStatus} />
              </div>
            </div>
          </div>
        </div>
      </div>
    </>
  );
};

export default Dashboard;

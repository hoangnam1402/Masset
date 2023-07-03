import React, { useEffect, useState } from "react";
import { useAppDispatch, useAppSelector } from "../../hooks/redux";
import { NavLink, useNavigate } from "react-router-dom";
import { logout } from "../Authorize/reducer";
import { ASSETS, COMPONENTS, LOGIN, MAINTENANCES, USER } from "../../constants/pages";
import { getAssetChecking, getComponentChecking, getDashboard } from "./reducer";
import { Link45deg } from "react-bootstrap-icons";
import { Pie } from "react-chartjs-2";
import { Chart as ChartJS, ArcElement, Tooltip, Legend } from 'chart.js';
import { StateArchivedLabel, StateBrokenLabel, StateLostLabel, StateOutOfRepairLabel,
  StatePendingLabel, StateReadyToDeployLabel } from "../../constants/assetConstants";
import IColumnOption from "../../interfaces/IColumnOption";
import IQueryModel from "../../interfaces/IQueryModel";
import { ACCSENDING, DECSENDING, CHECKING_SORT_COLUMN_NAME } from "../../constants/paging";
import DashboardTable from "../../components/Table/DashboardTable";

const assetColumns: IColumnOption[] = [
  { columnName: "Property", columnValue: "asset.name" },
  { columnName: "Employee", columnValue: "user.userName" },
  { columnName: "Status", columnValue: "isCheckOut" },
  { columnName: "Location", columnValue: "asset.location.name" },
  { columnName: "Date", columnValue: "checkDay" },
];

const componentColumns: IColumnOption[] = [
  { columnName: "Component", columnValue: "component.name" },
  { columnName: "Property", columnValue: "asset.name" },
  { columnName: "Quantity", columnValue: "quantity" },
  { columnName: "Status", columnValue: "isCheckOut" },
  { columnName: "Location", columnValue: "component.location.name" },
];

const Dashboard = () => {
  ChartJS.register(ArcElement, Tooltip, Legend);
  const { account } = useAppSelector((state) => state.authReducer);
  const { dashboard, assetChecking, componentChecking } = useAppSelector((state) => state.dashboardReducer);
  const dispatch = useAppDispatch();
  const history = useNavigate();
  if (account?.firstLogin || account?.isActive == false) {
    dispatch(logout());
    history(LOGIN);
  }

  const [assetQuery, setAssetQuery] = useState({
    page: assetChecking?.currentPage ?? 1,
    limit: 10,
    sortOrder: DECSENDING,
    sortColumn: CHECKING_SORT_COLUMN_NAME,
  } as IQueryModel);

  const [componentQuery, setComponentQuery] = useState({
    page: componentChecking?.currentPage ?? 1,
    limit: 10,
    sortOrder: DECSENDING,
    sortColumn: CHECKING_SORT_COLUMN_NAME,
  } as IQueryModel);

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
  
  const handlePage = (page: number) => {
  };

  const handleAssetSort = (sortColumn: string) => {
    const sortOrder = assetQuery.sortOrder == ACCSENDING ? DECSENDING : ACCSENDING;

    setAssetQuery({
      ...assetQuery,
      sortColumn,
      sortOrder,
    });
  };

  const handleComponentSort = (sortColumn: string) => {
    const sortOrder = componentQuery.sortOrder == ACCSENDING ? DECSENDING : ACCSENDING;

    setComponentQuery({
      ...componentQuery,
      sortColumn,
      sortOrder,
    });
  };

  const checkStatus = (id: boolean | undefined) => {
		switch(id) {
			case true:
				return "Check Out";
			case false:
				return "Check In";
			default:
				return "";
		}
	};

  const formatDate = (date: Date) => {
    return new Date(date).toLocaleDateString();
  }
  
  useEffect(() => {
    if (account) {
      dispatch(getDashboard());
    }
  }, []);

  useEffect(() => {
    if (account) {
      dispatch(getAssetChecking(assetQuery));
      dispatch(getComponentChecking(componentQuery));
      }
  }, [assetQuery, componentQuery]);
 
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
                      <img src="/icon-asset.png" alt="icon-asset" className="icon" />
                    </div>
                  </div>
                  <div className="col-md-9 ">
                    <div className="numbers">
                      <p>Property</p>
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
                      <img src="/icon-component.png" alt="icon-component" className="icon" />
                    </div>
                  </div>

                  <div className="col-md-9 ">
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
                      <img src="/icon-maintenance.png" alt="icon-maintenance" className="icon" />
                    </div>
                  </div>
                  
                  <div className="col-md-9 ">
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
                      <img src="/icon-employee.png" alt="icon-employee" className="icon" />
                    </div>
                  </div>

                  <div className="col-md-9 ">
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
                <h5 className="title text-center">Property by type</h5>
              </div>
              <div className="content">
                <Pie data={AssetByType} />
              </div>
            </div>
          </div>
          <div className="col-lg-6 col-sm-6">
            <div className="card">
              <div className="header">
                <h5 className="title text-center">Property by status</h5>
              </div>
              <div className="content">
                <Pie data={AssetByStatus} />
              </div>
            </div>
          </div>
        </div>

        <br/>

        <div className="row">
          <div className="col-md-6">
            <div className="card">
              <div className="header">
                <h5 className="title text-center">Recent property activity</h5>
              </div>
              <div className="carbody">
                <DashboardTable
                  columns={assetColumns}
                  handleSort={handleAssetSort}
                  sortState={{
                    columnValue: assetQuery.sortColumn,
                    orderBy: assetQuery.sortOrder,
                  }}
                  page={{
                    currentPage: assetChecking?.currentPage,
                    totalPage: assetChecking?.totalPages,
                    handleChange: handlePage,
                  }}
                >
                  {assetChecking?.items.map((data, index) => (
                    <tr 
                      key={index} 
                      className=""
                    >
                      <td className="py-1 py-1-custome">{data.asset.name}</td>
                      <td className="py-1 py-1-custome">{data.user.userName} </td>
                      <td className="py-1 py-1-custome">{checkStatus(data.isCheckOut)}</td>
                      <td className="py-1 py-1-custome">{data.asset.location.name}</td>
                      <td className="py-1 py-1-custome">{formatDate(data.checkDay)}</td>
                    </tr>
                  ))}
                </DashboardTable>
              </div>
            </div>
          </div>

          <div className="col-md-6">
            <div className="card">
              <div className="header">
                <h5 className="title text-center">Recent component activity</h5>
              </div>
              <div className="carbody">
                <DashboardTable
                  columns={componentColumns}
                  handleSort={handleComponentSort}
                  sortState={{
                    columnValue: componentQuery.sortColumn,
                    orderBy: componentQuery.sortOrder,
                  }}
                  page={{
                    currentPage: componentChecking?.currentPage,
                    totalPage: componentChecking?.totalPages,
                    handleChange: handlePage,
                  }}
                >
                  {componentChecking?.items.map((data, index) => (
                    <tr 
                      key={index} 
                      className=""
                    >
                      <td className="py-1 py-1-custome">{data.component.name}</td>
                      <td className="py-1 py-1-custome">{data.asset.name} </td>
                      <td className="py-1 py-1-custome">{data.quantity}</td>
                      <td className="py-1 py-1-custome">{checkStatus(data.isCheckOut)}</td>
                      <td className="py-1 py-1-custome">{data.asset.location.name}</td>
                    </tr>
                  ))}
                </DashboardTable>
              </div>
            </div>
          </div>
        </div>
      </div>
    </>
  );
};

export default Dashboard;

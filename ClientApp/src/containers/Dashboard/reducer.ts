import { createSlice, PayloadAction } from "@reduxjs/toolkit";

import { SetStatusType } from "../../constants/status";
import IError from "../../interfaces/IError";
import IDashboard from "../../interfaces/Dashboard/IDashboard";
import IPagedModel from "../../interfaces/IPagedModel";
import IChecking from "../../interfaces/Checking/IChecking";
import IQueryModel from "../../interfaces/IQueryModel";

type DashboardState = {
  loading: boolean;
  status?: number;
  error?: IError;
  dashboard: IDashboard | null;
  assetChecking: IPagedModel<IChecking>|null;
  componentChecking: IPagedModel<IChecking>|null;
};

const initialState: DashboardState = {
  loading: false,
  dashboard: null,
  componentChecking: null,
  assetChecking: null,
};

const dashboardSlice = createSlice({
  name: "dashboard",
  initialState,
  reducers: {
    getDashboard: (state): DashboardState => {
      return {
        ...state,
        loading: true,
      };
    },

    setDashboard: (state, action: PayloadAction<IDashboard>): DashboardState => {
      const dashboard = action.payload;

      return {
        ...state,
        dashboard,
        loading: false,
      };
    },

    getAssetChecking: (state, action: PayloadAction<IQueryModel>): DashboardState => {
      return {
        ...state,
        loading: true,
      };
    },

    setAssetChecking: (state, action: PayloadAction<IPagedModel<IChecking>>): DashboardState => {
      const assetChecking = action.payload;
      return {
        ...state,
        assetChecking,
        loading: false,
      };
    },

    getComponentChecking: (state, action: PayloadAction<IQueryModel>): DashboardState => {
      return {
        ...state,
        loading: true,
      };
    },

    setComponentChecking: (state, action: PayloadAction<IPagedModel<IChecking>>): DashboardState => {
      const componentChecking = action.payload;
      return {
        ...state,
        componentChecking,
        loading: false,
      };
    },

    setStatus: (state: DashboardState, action: PayloadAction<SetStatusType>) => {
      const { status, error } = action.payload;

      return {
        ...state,
        status,
        error,
        loading: false,
      };
    },
  },
});

export const { setStatus, getDashboard, setDashboard, getAssetChecking, getComponentChecking,
  setAssetChecking, setComponentChecking } = dashboardSlice.actions;

export default dashboardSlice.reducer;

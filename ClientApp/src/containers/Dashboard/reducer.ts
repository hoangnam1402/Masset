import { createSlice, PayloadAction } from "@reduxjs/toolkit";

import { SetStatusType } from "../../constants/status";
import IError from "../../interfaces/IError";
import IDashboard from "../../interfaces/Dashboard/IDashboard";

type DashboardAssetState = {
  loading: boolean;
  status?: number;
  error?: IError;
  dashboard: IDashboard | null;
};

const initialState: DashboardAssetState = {
  loading: false,
  dashboard: null,
};

const dashboardSlice = createSlice({
  name: "dashboard",
  initialState,
  reducers: {
    getDashboard: (state): DashboardAssetState => {
      return {
        ...state,
        loading: true,
      };
    },
    setDashboard: (
      state,
      action: PayloadAction<IDashboard>
    ): DashboardAssetState => {
      const dashboard = action.payload;

      return {
        ...state,
        dashboard,
        loading: false,
      };
    },
    setStatus: (state: DashboardAssetState, action: PayloadAction<SetStatusType>) => {
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

export const { setStatus, getDashboard, setDashboard } = dashboardSlice.actions;

export default dashboardSlice.reducer;

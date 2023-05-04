import { createSlice, PayloadAction } from "@reduxjs/toolkit";

import { SetStatusType } from "../../constants/status";
import IAsset from "../../interfaces/Asset/IAsset";
import IError from "../../interfaces/IError";
import IPagedModel from "../../interfaces/IPagedModel";

import {
  getLocalStorage,
  removeLocalStorage,
  setLocalStorage,
} from "../../utils/localStorage";


type DashboardAssetState = {
  toggle:boolean;
  loading: boolean;
  status?: number;
  error?: IError;
  dashboardAssets: IPagedModel<IAsset> | null;
};

const token = getLocalStorage("token");


const initialState: DashboardAssetState = {
  toggle:false,
  loading: false,
  dashboardAssets: null,
};

const dashAssetSlice = createSlice({
  name: "dashboardAssets",
  initialState,
  reducers: {
    getDashboardAssets: (state): DashboardAssetState => {
      return {
        ...state,
        loading: true,
      };
    },
    setDashboardAssets: (
      state,
      action: PayloadAction<IPagedModel<IAsset>>
    ): DashboardAssetState => {
      const dashboardAssets = action.payload;

      return {
        ...state,
        dashboardAssets,
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
    respondToAssignment: (state): DashboardAssetState =>{
      return {
        ...state,
        loading: true,
      };
    },
    setToggle: (state: DashboardAssetState, action: PayloadAction<boolean>) => {
      const bool = {...state}

      return {
        ...state,
        toggle:!bool.toggle
      };
    },
  },
});

export const { setStatus, getDashboardAssets, setDashboardAssets,respondToAssignment,setToggle } = dashAssetSlice.actions;

export default dashAssetSlice.reducer;

import { createSlice, PayloadAction } from "@reduxjs/toolkit";

import { SetStatusType } from "../../constants/status";
import IAssignment from "../../interfaces/Assignment/IAssignment";
import IError from "../../interfaces/IError";
import IPagedModel from "../../interfaces/IPagedModel";
import IQueryAssignmentModel  from "../../interfaces/Assignment/IQueryAssignment";

import {
  getLocalStorage,
  removeLocalStorage,
  setLocalStorage,
} from "../../utils/localStorage";
import IAssignmentRespond from "../../interfaces/Assignment/IAssignmentRespond";


type HomeAssignmentState = {
  toggle:boolean;
  loading: boolean;
  status?: number;
  error?: IError;
  homeAssignments: IPagedModel<IAssignment> | null;
};

const token = getLocalStorage("token");


const initialState: HomeAssignmentState = {
  toggle:false,
  loading: false,
  homeAssignments: null,
};

const homeAssignmentSlice = createSlice({
  name: "homeAssignment",
  initialState,
  reducers: {
    getHomeAssignments: (state, action: PayloadAction<IQueryAssignmentModel>): HomeAssignmentState => {
      return {
        ...state,
        loading: true,
      };
    },
    setHomeAssignments: (
      state,
      action: PayloadAction<IPagedModel<IAssignment>>
    ): HomeAssignmentState => {
      const homeAssignments = action.payload;

      return {
        ...state,
        homeAssignments,
        loading: false,
      };
    },
    setStatus: (state: HomeAssignmentState, action: PayloadAction<SetStatusType>) => {
      const { status, error } = action.payload;

      return {
        ...state,
        status,
        error,
        loading: false,
      };
    },
    respondToAssignment: (state,action:PayloadAction<IAssignmentRespond>): HomeAssignmentState =>{
      return {
        ...state,
        loading: true,
      };
    },
    setToggle: (state: HomeAssignmentState, action: PayloadAction<boolean>) => {
      const bool = {...state}

      return {
        ...state,
        toggle:!bool.toggle
      };
    },
  },
});

export const { setStatus, getHomeAssignments, setHomeAssignments,respondToAssignment,setToggle } = homeAssignmentSlice.actions;

export default homeAssignmentSlice.reducer;

import { createSlice, PayloadAction } from "@reduxjs/toolkit";

import { SetStatusType } from "../../constants/status";
import IError from "../../interfaces/IError";
import ISetting from "../../interfaces/Setting/ISetting";
import ISettingForm from "../../interfaces/Setting/ISettingForm";

type SettingState = {
  loading: boolean;
  status?: number;
  error?: IError;
  setting: ISetting | null;
};

const initialState: SettingState = {
  loading: false,
  setting: null,
};

export type UpdateAction = {
  handleResult: Function,
  formValues: ISettingForm,
}

const settingSlice = createSlice({
  name: "setting",
  initialState,
  reducers: {
    getSetting: (state) => {
      return {
        ...state,
        loading: true,
      };
    },
    updateSetting: (state, action: PayloadAction<UpdateAction>) => {
      return {
        ...state,
        loading: true,
      }
    },
    updateLogo: (state, action: PayloadAction<File>) => {
      return {
        ...state,
        loading: true,
      }
    },
    setSetting: ( state, action: PayloadAction<ISetting>): SettingState => {
    const setting = action.payload
    return {
      ...state,
      setting,
    }},
    setStatus: (state, action: PayloadAction<SetStatusType>): SettingState => {
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

export const { setStatus, getSetting, updateSetting, setSetting, updateLogo } = settingSlice.actions;

export default settingSlice.reducer;

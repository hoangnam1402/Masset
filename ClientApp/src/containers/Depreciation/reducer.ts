import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import { SetStatusType } from "../../constants/status";
import IError from "../../interfaces/IError";
import IPagedModel from "../../interfaces/IPagedModel";
import IQueryModel from "../../interfaces/IQueryModel";
import IAsset from "../../interfaces/Asset/IAsset";
import IDepreciation from "../../interfaces/Depreciation/IDepreciation";
import IComponent from "../../interfaces/Component/IComponent";
import IDepreciationForm from "../../interfaces/Depreciation/IDepreciationForm";

type DepreciationState = {
  loading: boolean;
  depreciations: IPagedModel<IDepreciation> | null;
  depreciationResult?: IDepreciation;
  status?: number;
  error?: IError;
  components:IComponent[]|null;
  deleteDepreciation?: IDepreciation;
  assets: IAsset[]|null;
};

const initialState: DepreciationState = {
  loading: false,
  depreciations: null,
  components:null,
  deleteDepreciation: undefined,
  assets: null,
};

export type CreateAction = {
  handleResult: Function,
  formValues: IDepreciationForm,
}

export type DeleteAction = {
  handleResult: Function,
  formValues: IDepreciation,
}

const DepreciationSlice = createSlice({
  name: "Depreciation",
  initialState,
  reducers: {
    getDepreciations: (state, action: PayloadAction<IQueryModel>) => {
      return {
        ...state,
        loading: true,
      };
    },

    setDepreciations: (state, action: PayloadAction<IPagedModel<IDepreciation>>): DepreciationState => {
      const depreciations = action.payload;

      return {
          ...state,
          depreciations,
          depreciationResult: undefined,
          loading: false,
      };
    },

    deleteDepreciation: (state, action: PayloadAction<CreateAction>) => {
      return {
        ...state,
        loading: true,
      };
    },

    setDeleteDepreciation: ( state, action: PayloadAction<IDepreciation>): DepreciationState => {
      const deleteDepreciation = action.payload

      return {
        ...state,
        deleteDepreciation,
      }
    },

    updateDepreciation: (state, action: PayloadAction<CreateAction>) => {
      return {
          ...state,
          loading: true,
      }
    },

    setDepreciation: (state, action: PayloadAction<IDepreciation>): DepreciationState => {
      const depreciationResult = action.payload;

      return {
          ...state,
          depreciationResult,
          loading: false,
      }
    },

    getComponents: (state) => {
      return {
        ...state,
        loading: true,
      };
    },

    setComponents: (state, action: PayloadAction<IComponent[]>): DepreciationState => {
      const components = action.payload;
      return {
        ...state,
        components,
        loading: false,
      };
    },

    getAssets: (state) => {
      return {
        ...state,
        loading: true,
      };
    },

    setAssets: (state, action: PayloadAction<IAsset[]>): DepreciationState => {
      const assets = action.payload;
      return {
        ...state,
        assets,
        loading: false,
      };
    },

    setStatus: (state, action: PayloadAction<SetStatusType>): DepreciationState => {
      const { status, error } = action.payload;

      return {
        ...state,
        status,
        error,
        loading: false,
      };
    },

    createDepreciation: (state, action: PayloadAction<CreateAction>) => {
      return {
          ...state,
          loading: true,
      }
    },
  },
});

export const 
{ 
    setStatus, getDepreciations, getComponents, setDeleteDepreciation, setComponents, setDepreciation,
    setDepreciations, deleteDepreciation, createDepreciation, updateDepreciation, getAssets, setAssets
} = DepreciationSlice.actions;

export default DepreciationSlice.reducer;

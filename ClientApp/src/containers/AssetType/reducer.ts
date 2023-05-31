import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import { SetStatusType } from "../../constants/status";
import IError from "../../interfaces/IError";
import IPagedModel from "../../interfaces/IPagedModel";
import IQueryModel from "../../interfaces/IQueryModel";
import IType from "../../interfaces/Type/IType";
import ITypeForm from "../../interfaces/Type/ITypeForm";

type AssetTypeState = {
  loading: boolean;
  assetTypes: IPagedModel<IType> | null;
  assetTypeResult?: IType;
  status?: number;
  error?: IError;
  deleteAssetType?: IType;
};

const initialState: AssetTypeState = {
  loading: false,
  assetTypes: null,
  deleteAssetType: undefined,
};

export type CreateAction = {
  handleResult: Function,
  formValues: ITypeForm,
}

export type DeleteAction = {
  handleResult: Function,
  formValues: IType,
}

const AssetTypeSlice = createSlice({
  name: "AssetType",
  initialState,
  reducers: {
    getAssetTypes: (state, action: PayloadAction<IQueryModel>) => {
      return {
        ...state,
        loading: true,
      };
    },

    setAssetTypes: (state, action: PayloadAction<IPagedModel<IType>>): AssetTypeState => {
      const assetTypes = action.payload;
      if(state.assetTypeResult){
        assetTypes.items.unshift(state.assetTypeResult);
      }

      return {
          ...state,
          assetTypes,
          assetTypeResult: undefined,
          loading: false,
      };
    },

    deleteAssetType: (state, action: PayloadAction<CreateAction>) => {
      return {
        ...state,
        loading: true,
      };
    },

    setDeleteAssetType: ( state, action: PayloadAction<IType>): AssetTypeState => {
      const deleteAssetType = action.payload

      return {
        ...state,
        deleteAssetType,
      }
    },

    updateAssetType: (state, action: PayloadAction<CreateAction>) => {
      return {
          ...state,
          loading: true,
      }
    },

    setAssetType: (state, action: PayloadAction<IType>): AssetTypeState => {
      const assetTypeResult = action.payload;

      return {
          ...state,
          assetTypeResult,
          loading: false,
      }
    },

    setStatus: (state, action: PayloadAction<SetStatusType>): AssetTypeState => {
      const { status, error } = action.payload;

      return {
        ...state,
        status,
        error,
        loading: false,
      };
    },

    createAssetType: (state, action: PayloadAction<CreateAction>) => {
      return {
          ...state,
          loading: true,
      }
    },
  },
});

export const 
{ 
    setStatus, getAssetTypes, setAssetType, setAssetTypes, setDeleteAssetType, createAssetType,
    updateAssetType, deleteAssetType,
} = AssetTypeSlice.actions;

export default AssetTypeSlice.reducer;

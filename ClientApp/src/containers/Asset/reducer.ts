import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import { SetStatusType } from "../../constants/status";
import IAsset from "../../interfaces/Asset/IAsset";
import IAssetType from "../../interfaces/Type/IType"
import IBrand from "../../interfaces/Brand/IBrand"
import ILocation from "../../interfaces/Location/ILocation"
import ISupplier from "../../interfaces/Supplier/ISupplier"
import IError from "../../interfaces/IError";
import IPagedModel from "../../interfaces/IPagedModel";

import {
  getLocalStorage,
} from "../../utils/localStorage";
import IQueryAssetModel from "../../interfaces/Asset/IQueryAssetModel";
import IAssetForm from "../../interfaces/Asset/IAssetForm";


type AssetState = {
  loading: boolean;
  assetResult?: IAsset;
  status?: number;
  error?: IError;
  assets: IPagedModel<IAsset> | null;
  assetTypes:IAssetType[]|null;
  brands:IBrand[]|null;
  locations:ILocation[]|null;
  suppliers:ISupplier[]|null;
  deleteAsset?: IAsset;
  newAsset?:IAsset
};

const token = getLocalStorage("token");

const initialState: AssetState = {
  loading: false,
  assets: null,
  assetTypes:null,
  brands:null,
  locations:null,
  suppliers:null,
  deleteAsset: undefined,
  newAsset: undefined,
};

export type CreateAction = {
  handleResult: Function,
  formValues: IAssetForm,
}

export type DeleteAction = {
  handleResult: Function,
  formValues: IAsset,
}

export type GetByIdAction = {
  id: number,
}

const AssetSlice = createSlice({
  name: "Asset",
  initialState,
  reducers: {
    getAssets: (state, action: PayloadAction<IQueryAssetModel>): AssetState => {
      return {
        ...state,
        loading: true,
      };
    },

    setAssets: (state, action: PayloadAction<IPagedModel<IAsset>>): AssetState => {
      const assets = action.payload;
      if(state.assetResult){
          assets.items.unshift(state.assetResult);
      }

      return {
          ...state,
          assets,
          assetResult: undefined,
          loading: false,
      };
    },

    deleteAssets: (state, action: PayloadAction<CreateAction>): AssetState => {
      return {
        ...state,
        loading: true,
      };
    },

    setDeleteAsset: ( state, action: PayloadAction<IAsset>): AssetState => {
      const deleteAsset = action.payload

      return {
        ...state,
        deleteAsset,
      }
    },

    updateAsset: (state, action: PayloadAction<CreateAction>): AssetState => {
      return {
          ...state,
          loading: true,
      }
    },

    getAssetById: (state, action: PayloadAction<GetByIdAction>): AssetState => {
      return {
        ...state,
        loading: true,
      };
    },

    setAsset: (state, action: PayloadAction<IAsset>): AssetState => {
      const assetResult = action.payload;

      return {
          ...state,
          assetResult,
          loading: false,
      }
  },
    getAssetTypes: (state): AssetState => {
      return {
        ...state,
        loading: true,
      };
    },

    setAssetTypes: (state, action: PayloadAction<IAssetType[]>): AssetState => {
      const assetTypes = action.payload;
      return {
        ...state,
        assetTypes,
        loading: false,
      };
    },

    getBrands: (state): AssetState => {
      return {
        ...state,
        loading: true,
      };
    },

    setBrands: (state, action: PayloadAction<IBrand[]>): AssetState => {
      const brands = action.payload;
      return {
        ...state,
        brands,
        loading: false,
      };
    },
    getLocations: (state): AssetState => {
      return {
        ...state,
        loading: true,
      };
    },

    setLocations: (state, action: PayloadAction<ILocation[]>): AssetState => {
      const locations = action.payload;
      return {
        ...state,
        locations,
        loading: false,
      };
    },
    getSuppliers: (state): AssetState => {
      return {
        ...state,
        loading: true,
      };
    },

    setSupplies: (state, action: PayloadAction<ISupplier[]>): AssetState => {
      const suppliers = action.payload;
      return {
        ...state,
        suppliers,
        loading: false,
      };
    },

    setStatus: (state: AssetState, action: PayloadAction<SetStatusType>) => {
      const { status, error } = action.payload;

      return {
        ...state,
        status,
        error,
        loading: false,
      };
    },
    setAssetEdited: (state, action: PayloadAction<IAsset>): AssetState => {
      const assetResult = action.payload;
                      
      return {
          ...state,
          assetResult,
          loading: false,
      }
  },
    createAsset: (state, action: PayloadAction<CreateAction>): AssetState => {
      const newAsset = action.payload;
      
      return {
          ...state,
          loading: true,
      }
    },
    setNewAsset: (state: AssetState, action: PayloadAction<IAsset|undefined>) =>
    {
        const newAsset= action.payload;

        return {
            ...state,
            newAsset,
            loading: false,
        }
    },
  },
});

export const 
{ 
    setStatus, getAssets, setAssets, getAssetTypes, setAssetTypes, getBrands, getAssetById,
    setBrands, getLocations, setLocations, getSuppliers, setSupplies, setDeleteAsset, 
    deleteAssets, createAsset, setAsset, updateAsset, setAssetEdited, setNewAsset
} = AssetSlice.actions;

export default AssetSlice.reducer;

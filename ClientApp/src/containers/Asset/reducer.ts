import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import { SetStatusType } from "../../constants/status";
import IAsset from "../../interfaces/Asset/IAsset";
import IAssetType from "../../interfaces/Type/IType"
import IBrand from "../../interfaces/Brand/IBrand"
import ILocation from "../../interfaces/Location/ILocation"
import ISupplier from "../../interfaces/Supplier/ISupplier"
import IError from "../../interfaces/IError";
import IPagedModel from "../../interfaces/IPagedModel";
import IQueryAssetModel from "../../interfaces/Asset/IQueryAssetModel";
import IAssetForm from "../../interfaces/Asset/IAssetForm";
import IMaintenance from "../../interfaces/Maintenance/IMaintenance";
import IQueryModel from "../../interfaces/IQueryModel";
import IDepreciation from "../../interfaces/Depreciation/IDepreciation";


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
  maintenances:IPagedModel<IMaintenance>|null;
  deleteAsset?: IAsset;
  assetGetById?:IAsset;
  qrCode?: string;
  depreciation?: IDepreciation;
};

const initialState: AssetState = {
  loading: false,
  assets: null,
  assetTypes:null,
  brands:null,
  locations:null,
  suppliers:null,
  deleteAsset: undefined,
  assetGetById: undefined,
  qrCode:undefined,
  maintenances:null,
  depreciation:undefined,
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

export type GetMaintenanceByAssetIdAction = {
  query: IQueryModel,
  id: number,
}

export type GetByTagAction = {
  tag: string,
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

    getMaintenance: (state, action: PayloadAction<GetMaintenanceByAssetIdAction>): AssetState => {
      return {
        ...state,
        loading: true,
      };
    },

    setMaintenance: (state, action: PayloadAction<IPagedModel<IMaintenance>>): AssetState => {
      const maintenances = action.payload;
      return {
        ...state,
        maintenances,
        loading: false,
      };
    },

    getDepreciation:  (state, action: PayloadAction<GetByIdAction>): AssetState => {
      return {
        ...state,
        loading: true,
      };
    },

    setDepreciation: (state, action: PayloadAction<IDepreciation>): AssetState => {
      const depreciation = action.payload;
      return {
        ...state,
        depreciation,
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

    createAsset: (state, action: PayloadAction<CreateAction>): AssetState => {
      return {
          ...state,
          loading: true,
      }
    },

    setAssetGetById: (state: AssetState, action: PayloadAction<IAsset|undefined>) =>
    {
        const assetGetById= action.payload;

        return {
            ...state,
            assetGetById,
            loading: false,
        }
    },

    getQrCode: (state, action: PayloadAction<GetByTagAction>) =>
    {
        return {
            ...state,
            loading: false,
        }
    },

    setQrCode: (state: AssetState, action: PayloadAction<string>) =>
    {
        const qrCode= action.payload;

        return {
            ...state,
            qrCode,
            loading: false,
        }
    },
  },
});

export const 
{ 
    setStatus, getAssets, setAssets, getAssetTypes, setAssetTypes, getBrands, getAssetById,
    setBrands, getLocations, setLocations, getSuppliers, setSupplies, setDeleteAsset, 
    deleteAssets, createAsset, setAsset, updateAsset, setAssetGetById, setQrCode, getQrCode,
    getMaintenance, setMaintenance, getDepreciation, setDepreciation,
} = AssetSlice.actions;

export default AssetSlice.reducer;

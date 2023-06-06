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
import IChecking from "../../interfaces/Checking/IChecking";
import IUser from "../../interfaces/User/IUser";
import ICheckingFrom from "../../interfaces/Checking/ICheckingFrom";


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
  users:IUser[]|null;
  maintenances:IPagedModel<IMaintenance>|null;
  deleteAsset?: IAsset;
  assetGetById?:IAsset;
  qrCode?: string;
  depreciation?: IDepreciation;
  historyCheck: IPagedModel<IChecking>|null;
  componentCheck: IPagedModel<IChecking>|null;
  assetChecking?: IChecking
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
  historyCheck: null,
  componentCheck: null,
  users:null,
  assetChecking:undefined
};

export type CreateAction = {
  handleResult: Function,
  formValues: IAssetForm,
}

export type DeleteAction = {
  handleResult: Function,
  formValues: IAsset,
}

export type CheckAction = {
  handleResult: Function,
  formValues: ICheckingFrom,
}

export type GetByIdAction = {
  id: number,
}

export type GetByAssetIdAction = {
  query: IQueryModel,
  id: number,
}

export type GetByTagAction = {
  tag: string,
}

export type PutImage = {
  file: File,
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

      return {
          ...state,
          assets,
          assetResult: undefined,
          loading: false,
      };
    },

    deleteAssets: (state, action: PayloadAction<DeleteAction>): AssetState => {
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

    getUsers: (state): AssetState => {
      return {
        ...state,
        loading: true,
      };
    },

    setUsers: (state, action: PayloadAction<IUser[]>): AssetState => {
      const users = action.payload;
      return {
        ...state,
        users,
        loading: false,
      };
    },

    getMaintenance: (state, action: PayloadAction<GetByAssetIdAction>): AssetState => {
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

    getHistoryCheck:  (state, action: PayloadAction<GetByAssetIdAction>): AssetState => {
      return {
        ...state,
        loading: true,
      };
    },

    setHistoryCheck: (state, action: PayloadAction<IPagedModel<IChecking>>): AssetState => {
      const historyCheck = action.payload;
      return {
        ...state,
        historyCheck,
        loading: false,
      };
    },

    getComponentCheck:  (state, action: PayloadAction<GetByAssetIdAction>): AssetState => {
      return {
        ...state,
        loading: true,
      };
    },

    setComponentCheck: (state, action: PayloadAction<IPagedModel<IChecking>>): AssetState => {
      const componentCheck = action.payload;
      return {
        ...state,
        componentCheck,
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

    getAssetCheckIn: (state, action: PayloadAction<CheckAction>) =>
    {
        return {
            ...state,
            loading: false,
        }
    },

    getAssetCheckOut: (state, action: PayloadAction<CheckAction>) =>
    {
        return {
            ...state,
            loading: false,
        }
    },

    setAssetChecking: ( state, action: PayloadAction<IChecking>): AssetState => {
      const assetChecking = action.payload

      return {
        ...state,
        assetChecking,
      }
    },

    updateImage: (state, action: PayloadAction<PutImage>) => {
      return {
        ...state,
        loading: true,
      }
    },
  },
});

export const 
{ 
    setStatus, getAssets, setAssets, getAssetTypes, setAssetTypes, getBrands, getAssetById,
    setBrands, getLocations, setLocations, getSuppliers, setSupplies, setDeleteAsset, 
    deleteAssets, createAsset, setAsset, updateAsset, setAssetGetById, setQrCode, getQrCode,
    getMaintenance, setMaintenance, getDepreciation, setDepreciation, getHistoryCheck,
    setHistoryCheck, getComponentCheck, setComponentCheck, getAssetCheckIn, getAssetCheckOut,
    setAssetChecking, getUsers, setUsers, updateImage
} = AssetSlice.actions;

export default AssetSlice.reducer;

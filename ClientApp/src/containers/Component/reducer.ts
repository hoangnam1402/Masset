import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import { SetStatusType } from "../../constants/status";
import IAssetType from "../../interfaces/Type/IType"
import IBrand from "../../interfaces/Brand/IBrand"
import ILocation from "../../interfaces/Location/ILocation"
import ISupplier from "../../interfaces/Supplier/ISupplier"
import IError from "../../interfaces/IError";
import IPagedModel from "../../interfaces/IPagedModel";
import IQueryAssetModel from "../../interfaces/Asset/IQueryAssetModel";
import IQueryModel from "../../interfaces/IQueryModel";
import IDepreciation from "../../interfaces/Depreciation/IDepreciation";
import IComponent from "../../interfaces/Component/IComponent";
import IComponentForm from "../../interfaces/Component/IComponentForm";
import IChecking from "../../interfaces/Checking/IChecking";
import ICheckingFrom from "../../interfaces/Checking/ICheckingFrom";
import IAsset from "../../interfaces/Asset/IAsset";


type ComponentState = {
  loading: boolean;
  componentResult?: IComponent;
  status?: number;
  error?: IError;
  components: IPagedModel<IComponent> | null;
  assetTypes:IAssetType[]|null;
  brands:IBrand[]|null;
  locations:ILocation[]|null;
  suppliers:ISupplier[]|null;
  deleteComponent?: IComponent;
  compGetById?:IComponent;
  depreciation?: IDepreciation;
  componentCheck: IPagedModel<IChecking>|null;
  checkings?: IChecking;
  assets: IAsset[]|null;
};

const initialState: ComponentState = {
  loading: false,
  components: null,
  assetTypes:null,
  brands:null,
  locations:null,
  suppliers:null,
  deleteComponent: undefined,
  compGetById: undefined,
  depreciation:undefined,
  componentCheck: null,
  checkings: undefined,
  assets: null,
};

export type CreateAction = {
  handleResult: Function,
  formValues: IComponentForm,
}

export type DeleteAction = {
  handleResult: Function,
  formValues: IComponent,
}

export type GetByIdAction = {
  id: number,
}

export type CheckAction = {
  handleResult: Function,
  formValues: ICheckingFrom,
}

export type GetByComponentIdAction = {
  query: IQueryModel,
  id: number,
}

const ComponentSlice = createSlice({
  name: "Component",
  initialState,
  reducers: {
    getComponents: (state, action: PayloadAction<IQueryAssetModel>): ComponentState => {
      return {
        ...state,
      };
    },

    setComponents: (state, action: PayloadAction<IPagedModel<IComponent>>): ComponentState => {
      const components = action.payload;

      return {
        ...state,
        components,
        componentResult: undefined,
      };
    },

    deleteComponent: (state, action: PayloadAction<CreateAction>): ComponentState => {
      return {
        ...state,
      };
    },

    setDeleteComponent: ( state, action: PayloadAction<IComponent>): ComponentState => {
      const deleteComponent = action.payload

      return {
        ...state,
        deleteComponent,
      }
    },

    updateComponent: (state, action: PayloadAction<CreateAction>): ComponentState => {
      return {
        ...state,
      }
    },

    getById: (state, action: PayloadAction<GetByIdAction>): ComponentState => {
      return {
        ...state,
        loading: true,
      };
    },

    setComponent: (state, action: PayloadAction<IComponent>): ComponentState => {
      const componentResult = action.payload;

      return {
        ...state,
        componentResult,
      }
    },

    getAssetTypes: (state): ComponentState => {
      return {
        ...state,
      };
    },

    setAssetTypes: (state, action: PayloadAction<IAssetType[]>): ComponentState => {
      const assetTypes = action.payload;
      return {
        ...state,
        assetTypes,
      };
    },

    getBrands: (state): ComponentState => {
      return {
        ...state,
      };
    },

    setBrands: (state, action: PayloadAction<IBrand[]>): ComponentState => {
      const brands = action.payload;
      return {
        ...state,
        brands,
      };
    },

    getLocations: (state): ComponentState => {
      return {
        ...state,
      };
    },

    setLocations: (state, action: PayloadAction<ILocation[]>): ComponentState => {
      const locations = action.payload;
      return {
        ...state,
        locations,
      };
    },

    getSuppliers: (state): ComponentState => {
      return {
        ...state,
      };
    },

    setSupplies: (state, action: PayloadAction<ISupplier[]>): ComponentState => {
      const suppliers = action.payload;
      return {
        ...state,
        suppliers,
      };
    },

    getDepreciation:  (state, action: PayloadAction<GetByIdAction>): ComponentState => {
      return {
        ...state,
      };
    },

    setDepreciation: (state, action: PayloadAction<IDepreciation>): ComponentState => {
      const depreciation = action.payload;
      return {
        ...state,
        depreciation,
      };
    },

    setStatus: (state: ComponentState, action: PayloadAction<SetStatusType>) => {
      const { status, error } = action.payload;

      return {
        ...state,
        status,
        error,
        loading: false,
      };
    },

    createComponent: (state, action: PayloadAction<CreateAction>): ComponentState => {
      return {
          ...state,
      }
    },

    getAssets: (state): ComponentState => {
      return {
        ...state,
      };
    },

    setAssets: (state, action: PayloadAction<IAsset[]>): ComponentState => {
      const assets = action.payload;
      return {
        ...state,
        assets,
      };
    },

    setGetById: (state, action: PayloadAction<IComponent|undefined>): ComponentState =>
    {
        const compGetById= action.payload;

        return {
            ...state,
            compGetById,
            loading: false,
        }
    },

    getCheckIn: (state, action: PayloadAction<CheckAction>) =>
    {
      return {
        ...state,
      }
    },

    getCheckOut: (state, action: PayloadAction<CheckAction>) =>
    {
      return {
        ...state,
      }
    },

    setChecking: ( state, action: PayloadAction<IChecking>): ComponentState => {
      const checkings = action.payload

      return {
        ...state,
        checkings,
      }
    },

    getComponentCheck:  (state, action: PayloadAction<GetByComponentIdAction>) => {
      return {
        ...state,
      };
    },

    setComponentCheck: (state, action: PayloadAction<IPagedModel<IChecking>>): ComponentState => {
      const componentCheck = action.payload;
      return {
        ...state,
        componentCheck,
      };
    },

  },
});

export const 
{ 
    setStatus, getComponents, setComponents, getAssetTypes, setAssetTypes, getBrands, getById,
    setBrands, getLocations, setLocations, getSuppliers, setSupplies, setDeleteComponent, 
    deleteComponent, createComponent, setComponent, updateComponent, setGetById, getDepreciation, 
    setDepreciation, setComponentCheck, getCheckIn, getCheckOut, getComponentCheck, setChecking,
    getAssets, setAssets
} = ComponentSlice.actions;

export default ComponentSlice.reducer;

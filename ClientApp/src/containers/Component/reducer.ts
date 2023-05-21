import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import { SetStatusType } from "../../constants/status";
import IAssetType from "../../interfaces/Type/IType"
import IBrand from "../../interfaces/Brand/IBrand"
import ILocation from "../../interfaces/Location/ILocation"
import ISupplier from "../../interfaces/Supplier/ISupplier"
import IError from "../../interfaces/IError";
import IPagedModel from "../../interfaces/IPagedModel";
import IQueryAssetModel from "../../interfaces/Asset/IQueryAssetModel";
import IMaintenance from "../../interfaces/Maintenance/IMaintenance";
import IQueryModel from "../../interfaces/IQueryModel";
import IDepreciation from "../../interfaces/Depreciation/IDepreciation";
import IComponent from "../../interfaces/Component/IComponent";
import IComponentForm from "../../interfaces/Component/IComponentForm";


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
  maintenances:IPagedModel<IMaintenance>|null;
  deleteComponent?: IComponent;
  compGetById?:IComponent;
  qrCode?: string;
  depreciation?: IDepreciation;
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
  qrCode:undefined,
  maintenances:null,
  depreciation:undefined,
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

export type GetByTagAction = {
  tag: string,
}

const ComponentSlice = createSlice({
  name: "Component",
  initialState,
  reducers: {
    getComponents: (state, action: PayloadAction<IQueryAssetModel>): ComponentState => {
      return {
        ...state,
        loading: true,
      };
    },

    setComponents: (state, action: PayloadAction<IPagedModel<IComponent>>): ComponentState => {
      const components = action.payload;
      if(state.componentResult){
        components.items.unshift(state.componentResult);
      }

      return {
          ...state,
          components,
          componentResult: undefined,
          loading: false,
      };
    },

    deleteComponent: (state, action: PayloadAction<CreateAction>): ComponentState => {
      return {
        ...state,
        loading: true,
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
          loading: true,
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
          loading: false,
      }
  },
    getAssetTypes: (state): ComponentState => {
      return {
        ...state,
        loading: true,
      };
    },

    setAssetTypes: (state, action: PayloadAction<IAssetType[]>): ComponentState => {
      const assetTypes = action.payload;
      return {
        ...state,
        assetTypes,
        loading: false,
      };
    },

    getBrands: (state): ComponentState => {
      return {
        ...state,
        loading: true,
      };
    },

    setBrands: (state, action: PayloadAction<IBrand[]>): ComponentState => {
      const brands = action.payload;
      return {
        ...state,
        brands,
        loading: false,
      };
    },

    getLocations: (state): ComponentState => {
      return {
        ...state,
        loading: true,
      };
    },

    setLocations: (state, action: PayloadAction<ILocation[]>): ComponentState => {
      const locations = action.payload;
      return {
        ...state,
        locations,
        loading: false,
      };
    },

    getSuppliers: (state): ComponentState => {
      return {
        ...state,
        loading: true,
      };
    },

    setSupplies: (state, action: PayloadAction<ISupplier[]>): ComponentState => {
      const suppliers = action.payload;
      return {
        ...state,
        suppliers,
        loading: false,
      };
    },

    getDepreciation:  (state, action: PayloadAction<GetByIdAction>): ComponentState => {
      return {
        ...state,
        loading: true,
      };
    },

    setDepreciation: (state, action: PayloadAction<IDepreciation>): ComponentState => {
      const depreciation = action.payload;
      return {
        ...state,
        depreciation,
        loading: false,
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
          loading: true,
      }
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
  },
});

export const 
{ 
    setStatus, getComponents, setComponents, getAssetTypes, setAssetTypes, getBrands, getById,
    setBrands, getLocations, setLocations, getSuppliers, setSupplies, setDeleteComponent, 
    deleteComponent, createComponent, setComponent, updateComponent, setGetById, getDepreciation, 
    setDepreciation,
} = ComponentSlice.actions;

export default ComponentSlice.reducer;

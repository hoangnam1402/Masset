import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import { SetStatusType } from "../../constants/status";
import ISupplier from "../../interfaces/Supplier/ISupplier"
import IError from "../../interfaces/IError";
import IPagedModel from "../../interfaces/IPagedModel";
import IQueryModel from "../../interfaces/IQueryModel";
import IAsset from "../../interfaces/Asset/IAsset";
import IMaintenance from "../../interfaces/Maintenance/IMaintenance";
import IMaintenanceForm from "../../interfaces/Maintenance/IMaintenanceForm";


type MaintenanceState = {
  loading: boolean;
  maintenances: IPagedModel<IMaintenance> | null;
  maintenanceResult?: IMaintenance;
  status?: number;
  error?: IError;
  suppliers:ISupplier[]|null;
  deleteMaintenance?: IMaintenance;
  assets: IAsset[]|null;
};

const initialState: MaintenanceState = {
  loading: false,
  maintenances: null,
  suppliers:null,
  deleteMaintenance: undefined,
  assets: null,
};

export type CreateAction = {
  handleResult: Function,
  formValues: IMaintenanceForm,
}

export type DeleteAction = {
  handleResult: Function,
  formValues: IMaintenance,
}

const MaintenanceSlice = createSlice({
  name: "Maintenance",
  initialState,
  reducers: {
    getMaintenances: (state, action: PayloadAction<IQueryModel>) => {
      return {
        ...state,
        loading: true,
      };
    },

    setMaintenances: (state, action: PayloadAction<IPagedModel<IMaintenance>>): MaintenanceState => {
      const maintenances = action.payload;
      if(state.maintenanceResult){
        maintenances.items.unshift(state.maintenanceResult);
      }

      return {
          ...state,
          maintenances,
          maintenanceResult: undefined,
          loading: false,
      };
    },

    deleteMaintenance: (state, action: PayloadAction<CreateAction>) => {
      return {
        ...state,
        loading: true,
      };
    },

    setDeleteMaintenance: ( state, action: PayloadAction<IMaintenance>): MaintenanceState => {
      const deleteMaintenance = action.payload

      return {
        ...state,
        deleteMaintenance,
      }
    },

    updateMaintenance: (state, action: PayloadAction<CreateAction>) => {
      return {
          ...state,
          loading: true,
      }
    },

    setMaintenance: (state, action: PayloadAction<IMaintenance>): MaintenanceState => {
      const maintenanceResult = action.payload;

      return {
          ...state,
          maintenanceResult,
          loading: false,
      }
    },

    getSuppliers: (state) => {
      return {
        ...state,
        loading: true,
      };
    },

    setSupplies: (state, action: PayloadAction<ISupplier[]>): MaintenanceState => {
      const suppliers = action.payload;
      return {
        ...state,
        suppliers,
        loading: false,
      };
    },

    getAssets: (state) => {
      return {
        ...state,
        loading: true,
      };
    },

    setAssets: (state, action: PayloadAction<IAsset[]>): MaintenanceState => {
      const assets = action.payload;
      return {
        ...state,
        assets,
        loading: false,
      };
    },

    setStatus: (state: MaintenanceState, action: PayloadAction<SetStatusType>) => {
      const { status, error } = action.payload;

      return {
        ...state,
        status,
        error,
        loading: false,
      };
    },

    createMaintenance: (state, action: PayloadAction<CreateAction>) => {
      return {
          ...state,
          loading: true,
      }
    },
  },
});

export const 
{ 
    setStatus, getMaintenances, getSuppliers, setDeleteMaintenance, setMaintenance, setMaintenances,
    setSupplies, deleteMaintenance, createMaintenance, updateMaintenance, getAssets, setAssets
} = MaintenanceSlice.actions;

export default MaintenanceSlice.reducer;

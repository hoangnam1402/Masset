import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import { SetStatusType } from "../../constants/status";
import IError from "../../interfaces/IError";
import IPagedModel from "../../interfaces/IPagedModel";
import IQueryModel from "../../interfaces/IQueryModel";
import ISupplier from "../../interfaces/Supplier/ISupplier";
import ISupplierForm from "../../interfaces/Supplier/ISupplierForm";

type SupplierState = {
  loading: boolean;
  suppliers: IPagedModel<ISupplier> | null;
  supplierResult?: ISupplier;
  status?: number;
  error?: IError;
  deleteSupplier?: ISupplier;
};

const initialState: SupplierState = {
  loading: false,
  suppliers: null,
  deleteSupplier: undefined,
};

export type CreateAction = {
  handleResult: Function,
  formValues: ISupplierForm,
}

export type DeleteAction = {
  handleResult: Function,
  formValues: ISupplier,
}

const SupplierSlice = createSlice({
  name: "Supplier",
  initialState,
  reducers: {
    getSuppliers: (state, action: PayloadAction<IQueryModel>) => {
      return {
        ...state,
        loading: true,
      };
    },

    setSuppliers: (state, action: PayloadAction<IPagedModel<ISupplier>>): SupplierState => {
      const suppliers = action.payload;
      if(state.supplierResult){
        suppliers.items.unshift(state.supplierResult);
      }

      return {
          ...state,
          suppliers,
          supplierResult: undefined,
          loading: false,
      };
    },

    deleteSupplier: (state, action: PayloadAction<CreateAction>) => {
      return {
        ...state,
        loading: true,
      };
    },

    setDeleteSupplier: ( state, action: PayloadAction<ISupplier>): SupplierState => {
      const deleteSupplier = action.payload

      return {
        ...state,
        deleteSupplier,
      }
    },

    updateSupplier: (state, action: PayloadAction<CreateAction>) => {
      return {
          ...state,
          loading: true,
      }
    },

    setSupplier: (state, action: PayloadAction<ISupplier>): SupplierState => {
      const supplierResult = action.payload;

      return {
          ...state,
          supplierResult,
          loading: false,
      }
    },

    setStatus: (state, action: PayloadAction<SetStatusType>): SupplierState => {
      const { status, error } = action.payload;

      return {
        ...state,
        status,
        error,
        loading: false,
      };
    },

    createSupplier: (state, action: PayloadAction<CreateAction>) => {
      return {
          ...state,
          loading: true,
      }
    },
  },
});

export const 
{ 
    setStatus, getSuppliers, setSupplier, setSuppliers, setDeleteSupplier, createSupplier,
    updateSupplier, deleteSupplier,
} = SupplierSlice.actions;

export default SupplierSlice.reducer;

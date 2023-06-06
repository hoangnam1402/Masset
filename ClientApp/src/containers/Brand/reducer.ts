import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import { SetStatusType } from "../../constants/status";
import IError from "../../interfaces/IError";
import IPagedModel from "../../interfaces/IPagedModel";
import IQueryModel from "../../interfaces/IQueryModel";
import IBrand from "../../interfaces/Brand/IBrand";
import IBrandForm from "../../interfaces/Brand/IBrandForm";

type BrandState = {
  loading: boolean;
  brands: IPagedModel<IBrand> | null;
  brandResult?: IBrand;
  status?: number;
  error?: IError;
  deleteBrand?: IBrand;
};

const initialState: BrandState = {
  loading: false,
  brands: null,
  deleteBrand: undefined,
};

export type CreateAction = {
  handleResult: Function,
  formValues: IBrandForm,
}

export type DeleteAction = {
  handleResult: Function,
  formValues: IBrand,
}

const BrandSlice = createSlice({
  name: "Brand",
  initialState,
  reducers: {
    getBrands: (state, action: PayloadAction<IQueryModel>) => {
      return {
        ...state,
        loading: true,
      };
    },

    setBrands: (state, action: PayloadAction<IPagedModel<IBrand>>): BrandState => {
      const brands = action.payload;
      return {
          ...state,
          brands,
          brandResult: undefined,
          loading: false,
      };
    },

    deleteBrand: (state, action: PayloadAction<CreateAction>) => {
      return {
        ...state,
        loading: true,
      };
    },

    setDeleteBrand: ( state, action: PayloadAction<IBrand>): BrandState => {
      const deleteBrand = action.payload

      return {
        ...state,
        deleteBrand,
      }
    },

    updateBrand: (state, action: PayloadAction<CreateAction>) => {
      return {
          ...state,
          loading: true,
      }
    },

    setBrand: (state, action: PayloadAction<IBrand>): BrandState => {
      const brandResult = action.payload;

      return {
          ...state,
          brandResult,
          loading: false,
      }
    },

    setStatus: (state, action: PayloadAction<SetStatusType>): BrandState => {
      const { status, error } = action.payload;

      return {
        ...state,
        status,
        error,
        loading: false,
      };
    },

    createBrand: (state, action: PayloadAction<CreateAction>) => {
      return {
          ...state,
          loading: true,
      }
    },
  },
});

export const 
{ 
    setStatus, getBrands, setBrand, setBrands, setDeleteBrand, createBrand,
    updateBrand, deleteBrand,
} = BrandSlice.actions;

export default BrandSlice.reducer;

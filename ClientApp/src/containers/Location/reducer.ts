import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import { SetStatusType } from "../../constants/status";
import IError from "../../interfaces/IError";
import IPagedModel from "../../interfaces/IPagedModel";
import IQueryModel from "../../interfaces/IQueryModel";
import ILocationForm from "../../interfaces/Location/ILocationForm";
import ILocation from "../../interfaces/Location/ILocation";

type LocationState = {
  loading: boolean;
  locations: IPagedModel<ILocation> | null;
  locationResult?: ILocation;
  status?: number;
  error?: IError;
  deleteLocation?: ILocation;
};

const initialState: LocationState = {
  loading: false,
  locations: null,
  deleteLocation: undefined,
};

export type CreateAction = {
  handleResult: Function,
  formValues: ILocationForm,
}

export type DeleteAction = {
  handleResult: Function,
  formValues: ILocation,
}

const LocationSlice = createSlice({
  name: "Location",
  initialState,
  reducers: {
    getLocations: (state, action: PayloadAction<IQueryModel>) => {
      return {
        ...state,
        loading: true,
      };
    },

    setLocations: (state, action: PayloadAction<IPagedModel<ILocation>>): LocationState => {
      const locations = action.payload;
      if(state.locationResult){
        locations.items.unshift(state.locationResult);
      }

      return {
          ...state,
          locations,
          locationResult: undefined,
          loading: false,
      };
    },

    deleteLocation: (state, action: PayloadAction<CreateAction>) => {
      return {
        ...state,
        loading: true,
      };
    },

    setDeleteLocation: ( state, action: PayloadAction<ILocation>): LocationState => {
      const deleteLocation = action.payload

      return {
        ...state,
        deleteLocation,
      }
    },

    updateLocation: (state, action: PayloadAction<CreateAction>) => {
      return {
          ...state,
          loading: true,
      }
    },

    setLocation: (state, action: PayloadAction<ILocation>): LocationState => {
      const locationResult = action.payload;

      return {
          ...state,
          locationResult,
          loading: false,
      }
    },

    setStatus: (state, action: PayloadAction<SetStatusType>): LocationState => {
      const { status, error } = action.payload;

      return {
        ...state,
        status,
        error,
        loading: false,
      };
    },

    createLocation: (state, action: PayloadAction<CreateAction>) => {
      return {
          ...state,
          loading: true,
      }
    },
  },
});

export const 
{ 
    setStatus, getLocations, setLocation, setLocations, setDeleteLocation, createLocation,
    updateLocation, deleteLocation,
} = LocationSlice.actions;

export default LocationSlice.reducer;

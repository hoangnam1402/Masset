import { PayloadAction } from "@reduxjs/toolkit";
import { call, put } from "redux-saga/effects";

import { Status } from "../../../constants/status";
import IQueryAssetModel from "../../../interfaces/Asset/IQueryAssetModel";
import IError from "../../../interfaces/IError";
import { setStatus, setAssets, setAssetTypes, CreateAction, setDeleteAsset, setAsset, 
    DeleteAction, setAssetEdited, setLocations, setBrands, setSupplies, GetByIdAction } from "../reducer";
import { createAssetRequest, getAssetTypeRequest, getAssetsRequest, deleteAssetRequest, 
    putAssetsRequest, getBrandsRequest, getLocationRequest, getSupplierRequest, getAssetByIdRequest } from './request';

export function* handleGetAssets(action: PayloadAction<IQueryAssetModel>) {
    const query = action.payload;
    try {
        const { data } = yield call(getAssetsRequest, query);
        
        yield put(setAssets(data));

    } catch (error: any) {
        const errorModel = error.response.data as IError;
        
        console.log(errorModel);
        yield put(setStatus({
            status: Status.Failed,
            error: errorModel,
        }));
    }
}

export function* handleGetAssetById(action: PayloadAction<GetByIdAction>) {
    const {id} = action.payload;
    try {
        const { data } = yield call(getAssetByIdRequest, id);
        
        yield put(setAsset(data));

    } catch (error: any) {
        const errorModel = error.response.data as IError;
        
        yield put(setStatus({
            status: Status.Failed,
            error: errorModel,
        }));
    }
}
export function* handleGetAssetType() {
    try {
        const { data } = yield call(getAssetTypeRequest);
        yield put(setAssetTypes(data))
        

    } catch (error: any) {
        const errorModel = error.response.data as IError;
        
        console.log(errorModel);
    }
}

export function* handleGetLocation() {
    try {
        const { data } = yield call(getLocationRequest);
        yield put(setLocations(data))
        

    } catch (error: any) {
        const errorModel = error.response.data as IError;
        
        console.log(errorModel);
    }
}

export function* handleGetBrand() {
    try {
        const { data } = yield call(getBrandsRequest);
        yield put(setBrands(data))
        

    } catch (error: any) {
        const errorModel = error.response.data as IError;
        
        console.log(errorModel);
    }
}

export function* handleSupplier() {
    try {
        const { data } = yield call(getSupplierRequest);
        yield put(setSupplies(data))
        

    } catch (error: any) {
        const errorModel = error.response.data as IError;
        
        console.log(errorModel);
    }
}

export function* handleCreateAsset(action: PayloadAction<CreateAction>) {
    const {handleResult, formValues} = action.payload;
    try {        
        const { data } = yield call(createAssetRequest, formValues);
        if (data)
        {
            handleResult(true, data.name);
        }

        yield put(setStatus({
            status: Status.Success,
        }));
        yield put(setAsset(data));
        
    } catch (error: any) {
        const errorModel = error.response.data as IError;

        handleResult(false, errorModel.message);
    }
}

export function* handleDeleteAsset(action: PayloadAction<DeleteAction>) {
    const {handleResult, formValues} = action.payload;
    try {
        const { data } = yield call(deleteAssetRequest, formValues.id);
        if(data) {
            handleResult(true, formValues.name);
        }
        yield put(setStatus({
            status: Status.Success,
        }));
        yield put(setDeleteAsset(formValues));

        //window.location.reload();

    } catch (error: any) {
        const errorModel = error.response.data as IError;
        handleResult(false, errorModel.message);
    }
}
export function* handleUpdateAsset(action: PayloadAction<CreateAction>) {
    const { handleResult, formValues} = action.payload;

    try {
        const { data } = yield call(putAssetsRequest, formValues);

        handleResult(true, data);

        yield put(setAsset(data));

        if(formValues.id){
            yield put(setAssetEdited(data));
        }
        
    } catch (error: any) {

        const errorModel = error.response.data as IError;

        handleResult(false, errorModel.message);
    }
}

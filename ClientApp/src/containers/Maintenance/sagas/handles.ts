import { PayloadAction } from "@reduxjs/toolkit";
import { call, put } from "redux-saga/effects";

import { Status } from "../../../constants/status";
import IError from "../../../interfaces/IError";
import { CreateAction, DeleteAction, setAssets, setDeleteMaintenance, setMaintenance, setMaintenances, 
    setStatus, setSupplies, } from "../reducer";
import { getSupplierRequest, getAssetRequest, getByPageRequest, createRequest, deleteRequest, 
    updateRequest} from './request';
import IQueryModel from "../../../interfaces/IQueryModel";

export function* handleGetByPage(action: PayloadAction<IQueryModel>) {
    const query = action.payload;
    try {
        const { data } = yield call(getByPageRequest, query);
        
        yield put(setMaintenances(data));

    } catch (error: any) {
        console.log(error)
        const errorModel = error.response.data as IError;
        
        console.log(errorModel);
        yield put(setStatus({
            status: Status.Failed,
            error: errorModel,
        }));
    }
}

export function* handleGetSupplier() {
    try {
        const { data } = yield call(getSupplierRequest);
        yield put(setSupplies(data))
        

    } catch (error: any) {
        const errorModel = error.response.data as IError;
        
        console.log(errorModel);
    }
}

export function* handleGetAssets() {
    try {
        const { data } = yield call(getAssetRequest);
        yield put(setAssets(data))
        

    } catch (error: any) {
        const errorModel = error.response.data as IError;
        
        console.log(errorModel);
    }
}

export function* handleCreate(action: PayloadAction<CreateAction>) {
    const {handleResult, formValues} = action.payload;
    try {        
        const { data } = yield call(createRequest, formValues);
        if (data)
        {
            handleResult(true, data.name);
        }

        yield put(setStatus({
            status: Status.Success,
        }));
        yield put(setMaintenance(data));
        
    } catch (error: any) {
        const errorModel = error.response.data as IError;

        handleResult(false, errorModel.message);
    }
}

export function* handleDelete(action: PayloadAction<DeleteAction>) {
    const {handleResult, formValues} = action.payload;
    try {
        const { data } = yield call(deleteRequest, formValues.id);
        if(data) {
            handleResult(true, formValues.asset.name);
        }
        yield put(setStatus({
            status: Status.Success,
        }));
        yield put(setDeleteMaintenance(formValues));

    } catch (error: any) {
        const errorModel = error.response.data as IError;
        handleResult(false, errorModel.message);
    }
}

export function* handleUpdate(action: PayloadAction<CreateAction>) {
    const { handleResult, formValues} = action.payload;

    try {
        const { data } = yield call(updateRequest, formValues);

        handleResult(true, data);

        yield put(setMaintenance(data));
        
    } catch (error: any) {

        const errorModel = error.response.data as IError;

        handleResult(false, errorModel.message);
    }
}

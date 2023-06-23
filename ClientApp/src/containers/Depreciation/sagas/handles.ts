import { PayloadAction } from "@reduxjs/toolkit";
import { call, put } from "redux-saga/effects";

import { Status } from "../../../constants/status";
import IError from "../../../interfaces/IError";
import { CreateAction, DeleteAction, setAssets, setComponents, setDeleteDepreciation, setDepreciation,
    setDepreciations, setStatus, } from "../reducer";
import { getComponentRequest, getAssetRequest, getByPageRequest, createRequest, deleteRequest, 
    updateRequest} from './request';
import IQueryModel from "../../../interfaces/IQueryModel";

export function* handleGetByPage(action: PayloadAction<IQueryModel>) {
    const query = action.payload;
    try {
        const { data } = yield call(getByPageRequest, query);
        
        yield put(setDepreciations(data));

    } catch (error: any) {
        const errorModel = error.response.data as IError;
        
        yield put(setStatus({
            status: Status.Failed,
            error: errorModel,
        }));
    }
}

export function* handleGetComponents() {
    try {
        const { data } = yield call(getComponentRequest);
        yield put(setComponents(data))
        

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
            if (data.category === 1)
                handleResult(true, data.asset.name);
            else 
                handleResult(true, data.component.name);
        }

        yield put(setStatus({
            status: Status.Success,
        }));
        yield put(setDepreciation(data));
        
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
            if (data.category === 1)
                handleResult(true, data.asset.name);
            else 
                handleResult(true, data.component.name);
        }
        yield put(setStatus({
            status: Status.Success,
        }));
        yield put(setDeleteDepreciation(formValues));

    } catch (error: any) {
        const errorModel = error.response.data as IError;
        handleResult(false, errorModel.message);
    }
}

export function* handleUpdate(action: PayloadAction<CreateAction>) {
    const { handleResult, formValues} = action.payload;

    try {
        const { data } = yield call(updateRequest, formValues);

        if(data) {
            if (data.category === 1)
                handleResult(true, data.asset.name);
            else 
                handleResult(true, data.component.name);
        }

        yield put(setDepreciation(data));
        
    } catch (error: any) {

        const errorModel = error.response.data as IError;

        handleResult(false, errorModel.message);
    }
}

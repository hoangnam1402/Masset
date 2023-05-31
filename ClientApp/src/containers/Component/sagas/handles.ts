import { PayloadAction } from "@reduxjs/toolkit";
import { call, put } from "redux-saga/effects";

import { Status } from "../../../constants/status";
import IQueryAssetModel from "../../../interfaces/Asset/IQueryAssetModel";
import IError from "../../../interfaces/IError";
import { setStatus, setComponents, setAssetTypes, CreateAction, setDeleteComponent, setComponent,  
    DeleteAction, setLocations, setBrands, setSupplies, GetByIdAction, setComponentCheck,
    setDepreciation, setGetById, CheckAction, setChecking, GetByComponentIdAction, setAssets} from "../reducer";
import { createComponentRequest, getAssetTypeRequest, getComponentsRequest, deleteComponentRequest, 
    putComponentRequest, getBrandsRequest, getLocationRequest, getSupplierRequest, getByIdRequest, 
    getDepreciationRequest, postCheckInRequest, postCheckOutRequest, getComponentCheckRequest, 
    getAssetRequest} from './request';

export function* handleGetComponents(action: PayloadAction<IQueryAssetModel>) {
    const query = action.payload;
    try {
        const { data } = yield call(getComponentsRequest, query);
        
        yield put(setComponents(data));

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

export function* handleGetById(action: PayloadAction<GetByIdAction>) {
    const {id} = action.payload;
    try {
        const { data } = yield call(getByIdRequest, id);
        
        if (data) {
            yield put(setGetById(data));
        }

    } catch (error: any) {
        const errorModel = error.response.data as IError;
        
        yield put(setStatus({
            status: Status.Failed,
            error: errorModel,
        }));
    }
}

export function* handleGetDepreciation(action: PayloadAction<GetByIdAction>) {
    const {id} = action.payload;
    try {
        const { data } = yield call(getDepreciationRequest, id);
        
        if (data) {
            yield put(setDepreciation(data));
        }

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

export function* handleCreateComponent(action: PayloadAction<CreateAction>) {
    const {handleResult, formValues} = action.payload;
    try {        
        const { data } = yield call(createComponentRequest, formValues);
        if (data)
        {
            handleResult(true, data.name);
        }

        yield put(setStatus({
            status: Status.Success,
        }));
        yield put(setComponent(data));
        
    } catch (error: any) {
        const errorModel = error.response.data as IError;

        handleResult(false, errorModel.message);
    }
}

export function* handleDeleteComponent(action: PayloadAction<DeleteAction>) {
    const {handleResult, formValues} = action.payload;
    try {
        const { data } = yield call(deleteComponentRequest, formValues.id);
        if(data) {
            handleResult(true, formValues.name);
        }
        yield put(setStatus({
            status: Status.Success,
        }));
        yield put(setDeleteComponent(formValues));

    } catch (error: any) {
        const errorModel = error.response.data as IError;
        handleResult(false, errorModel.message);
    }
}

export function* handleUpdateComponent(action: PayloadAction<CreateAction>) {
    const { handleResult, formValues} = action.payload;

    try {
        const { data } = yield call(putComponentRequest, formValues);

        handleResult(true, data);

        yield put(setComponent(data));
        
    } catch (error: any) {

        const errorModel = error.response.data as IError;

        handleResult(false, errorModel.message);
    }
}

export function* handleCheckIn(action: PayloadAction<CheckAction>) {
    const {handleResult, formValues} = action.payload;
    try {
        const { data } = yield call(postCheckInRequest, formValues, formValues.id);
        if(data) {
            handleResult(true, data.asset.name);
        }
        yield put(setStatus({
            status: Status.Success,
        }));
        yield put(setChecking(data));

    } catch (error: any) {
        const errorModel = error.response.data as IError;
        handleResult(false, errorModel.message);
    }
}

export function* handleCheckOut(action: PayloadAction<CheckAction>) {
    const {handleResult, formValues} = action.payload;
    try {
        const { data } = yield call(postCheckOutRequest, formValues);
        if(data) {
            handleResult(true, data.asset.name);
        }
        yield put(setStatus({
            status: Status.Success,
        }));
        yield put(setChecking(data));

    } catch (error: any) {
        const errorModel = error.response.data as IError;
        handleResult(false, errorModel.message);
    }
}

export function* handleGetComponentCheck(action: PayloadAction<GetByComponentIdAction>) {
    const {query, id} = action.payload;
    try {
        const { data } = yield call(getComponentCheckRequest, query, id);
        
        if (data) {
            yield put(setComponentCheck(data));
        }

    } catch (error: any) {
        const errorModel = error.response.data as IError;
        
        yield put(setStatus({
            status: Status.Failed,
            error: errorModel,
        }));
    }
}

import { PayloadAction } from "@reduxjs/toolkit";
import { call, put } from "redux-saga/effects";

import { Status } from "../../../constants/status";
import IQueryAssetModel from "../../../interfaces/Asset/IQueryAssetModel";
import IError from "../../../interfaces/IError";
import { setStatus, setAssets, setAssetTypes, CreateAction, setDeleteAsset, setAsset, setAssetGetById, 
    setQrCode, GetByTagAction, DeleteAction, setLocations, setBrands, setSupplies, GetByIdAction, 
    setMaintenance, GetByAssetIdAction, setDepreciation, setHistoryCheck, setComponentCheck, CheckAction,
    setAssetChecking,
    setUsers} from "../reducer";
import { createAssetRequest, getAssetTypeRequest, getAssetsRequest, deleteAssetRequest, GeneratingQRCode,
    putAssetsRequest, getBrandsRequest, getLocationRequest, getSupplierRequest, getAssetByIdRequest, 
    getMaintenanceRequest, getDepreciationRequest, getHistoryCheckRequest, getComponentCheckRequest,
    postCheckInRequest, postCheckOutRequest, getUsersRequest} from './request';

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
        
        if (data) {
            yield put(setAssetGetById(data));
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
        
        yield put(setDepreciation(data));

    } catch (error: any) {
        const errorModel = error.response.data as IError;
        
        yield put(setStatus({
            status: Status.Failed,
            error: errorModel,
        }));
    }
}

export function* handleGetHistoryCheck(action: PayloadAction<GetByAssetIdAction>) {
    const {query, id} = action.payload;
    try {
        const { data } = yield call(getHistoryCheckRequest, query, id);
        
        if (data) {
            yield put(setHistoryCheck(data));
        }

    } catch (error: any) {
        const errorModel = error.response.data as IError;
        
        yield put(setStatus({
            status: Status.Failed,
            error: errorModel,
        }));
    }
}

export function* handleGetComponentCheckOfAsset(action: PayloadAction<GetByAssetIdAction>) {
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

export function* handleGetUsers() {
    try {
        const { data } = yield call(getUsersRequest);
        yield put(setUsers(data))

    } catch (error: any) {
        const errorModel = error.response.data as IError;
        
        console.log(errorModel);
    }
}

export function* handleGetMaintenance(action: PayloadAction<GetByAssetIdAction>) {
    const {query, id} = action.payload;

    try {
        const { data } = yield call(getMaintenanceRequest, query, id);
        yield put(setMaintenance(data))

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

        handleResult(false, errorModel);
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

    } catch (error: any) {
        const errorModel = error.response.data as IError;
        handleResult(false, errorModel);
    }
}

export function* handleCheckIn(action: PayloadAction<CheckAction>) {
    const {handleResult, formValues} = action.payload;
    try {
        const { data } = yield call(postCheckInRequest, formValues);
        if(data.asset) {
            handleResult(true, data.asset.name);
        } else {
            handleResult(true, data.id);
        }
        yield put(setStatus({
            status: Status.Success,
        }));
        yield put(setAssetChecking(data));

    } catch (error: any) {
        const errorModel = error.response.data as IError;
        handleResult(false, errorModel);
    }
}

export function* handleCheckOut(action: PayloadAction<CheckAction>) {
    const {handleResult, formValues} = action.payload;
    try {
        const { data } = yield call(postCheckOutRequest, formValues);
        if(data.asset) {
            handleResult(true, data.asset.name);
        } else {
            handleResult(true, data.id);
        }
        yield put(setStatus({
            status: Status.Success,
        }));
        yield put(setAssetChecking(data));

    } catch (error: any) {
        const errorModel = error.response.data as IError;
        handleResult(false, errorModel);
    }
}

export function* handleUpdateAsset(action: PayloadAction<CreateAction>) {
    const { handleResult, formValues} = action.payload;

    try {
        const { data } = yield call(putAssetsRequest, formValues);

        handleResult(true, data.name);

        yield put(setAsset(data));
        
    } catch (error: any) {

        const errorModel = error.response.data as IError;

        handleResult(false, errorModel);
    }
}

export function* handleQRCodeGenerator(action: PayloadAction<GetByTagAction>) {
    const {tag} = action.payload;
    try {
        const { data } = yield call(GeneratingQRCode, tag);

        if (data) {
            yield put(setQrCode(URL.createObjectURL(data)));
        }

    } catch (error: any) {
        const errorModel = error.response.data as IError;
        
        yield put(setStatus({
            status: Status.Failed,
            error: errorModel,
        }));
    }
}

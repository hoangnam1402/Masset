import { call, put } from "redux-saga/effects";
import { Status } from "../../../constants/status";
import IError from "../../../interfaces/IError";

import { setStatus, setSetting, UpdateAction } from "../reducer";

import {  getSettingRequest, updateSettingRequest, updateLogoRequest } from './request';
import { PayloadAction } from "@reduxjs/toolkit";

export function* handleGetSetting() {
    try {
        const { data } = yield call(getSettingRequest);
        yield put(setSetting(data));

    } catch (error: any) {
        const errorModel = error.response.data as IError;
        
        yield put(setStatus({
            status: Status.Failed,
            error: errorModel,
        }));
    }
}

export function* handleUpdateSetting(action: PayloadAction<UpdateAction>) {
    const { handleResult, formValues} = action.payload;
console.log(formValues)
    try {
        const { data } = yield call(updateSettingRequest, formValues);
        handleResult(true, data.name);
        yield put(setSetting(data));

    } catch (error: any) {
        const errorModel = error.response.data as IError;
        handleResult(false, errorModel.message);
    }
}

export function* handleUpdateLogo(action: PayloadAction<File>) {
    try {
        yield call(updateLogoRequest, action.payload);

    } catch (error: any) {
        const errorModel = error.response.data as IError;
        console.log(errorModel);
    }
}
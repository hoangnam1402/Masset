import { call, put } from "redux-saga/effects";
import { Status } from "../../../constants/status";
import IError from "../../../interfaces/IError";

import { setStatus, setDashboard, setAssetChecking, setComponentChecking } from "../reducer";

import {  getAssetCheckingRequest, getComponentCheckingRequest, getDashboardRequest } from './request';
import IQueryModel from "../../../interfaces/IQueryModel";
import { PayloadAction } from "@reduxjs/toolkit";

export function* handleGetDashboard() {
    try {
        const { data } = yield call(getDashboardRequest);
        yield put(setDashboard(data));

    } catch (error: any) {
        const errorModel = error.response.data as IError;
        
        yield put(setStatus({
            status: Status.Failed,
            error: errorModel,
        }));
    }
}

export function* handleGetAssetChecking(action: PayloadAction<IQueryModel>) {
    const query = action.payload;

    try {
        const { data } = yield call(getAssetCheckingRequest, query);
        yield put(setAssetChecking(data));

    } catch (error: any) {
        const errorModel = error.response.data as IError;
        
        yield put(setStatus({
            status: Status.Failed,
            error: errorModel,
        }));
    }
}

export function* handleGetComponentChecking(action: PayloadAction<IQueryModel>) {
    const query = action.payload;

    try {
        const { data } = yield call(getComponentCheckingRequest, query);
        yield put(setComponentChecking(data));

    } catch (error: any) {
        const errorModel = error.response.data as IError;
        
        yield put(setStatus({
            status: Status.Failed,
            error: errorModel,
        }));
    }
}
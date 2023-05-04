import { PayloadAction } from "@reduxjs/toolkit";
import { call, put } from "redux-saga/effects";

import { Status } from "../../../constants/status";
import IQueryAssetModel from "../../../interfaces/Asset/IQueryAssetModel";
import IError from "../../../interfaces/IError";


import { setStatus, setDashboardAssets, setToggle } from "../reducer";

import {  getDashboardRequest } from './request';

export function* handleGetDashboard(action: PayloadAction<IQueryAssetModel>) {
    const query = action.payload;
    try {
        const { data } = yield call(getDashboardRequest, query);
        
        yield put(setDashboardAssets(data));

    } catch (error: any) {
        const errorModel = error.response.data as IError;
        
        console.log(errorModel);
        yield put(setStatus({
            status: Status.Failed,
            error: errorModel,
        }));
    }
}
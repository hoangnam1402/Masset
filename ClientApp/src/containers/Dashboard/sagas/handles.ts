import { call, put } from "redux-saga/effects";
import { Status } from "../../../constants/status";
import IError from "../../../interfaces/IError";

import { setStatus, setDashboard } from "../reducer";

import {  getDashboardRequest } from './request';

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
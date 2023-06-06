import { PayloadAction } from "@reduxjs/toolkit";
import { call, put } from "redux-saga/effects";

import { Status } from "../../../constants/status";
import IChangePassword from "../../../interfaces/IChangePassword";
import IError from "../../../interfaces/IError";
import ILoginModel from "../../../interfaces/ILoginModel";

import { setAccount, setStatus } from "../reducer";
import { loginRequest, getMeRequest, putChangePassword } from './requests';

export function* handleLogin(action: PayloadAction<ILoginModel>) {
    const loginModel = action.payload;
    
    try {
        const {data} = yield call(loginRequest, loginModel);
        console.log(data)

        yield put(setAccount(data));

    } catch (error: any) {
        const errorModel = error.response.data as IError;

        yield put(setStatus({
            status: Status.Failed,
            error: errorModel,
        }));
    }
}

export function* handleGetMe() {
    try {
        const {data} = yield call(getMeRequest);

        if (!data.error) {
            yield put(setAccount(data));
        }

    } catch (error: any) {
    }
}

export function* handleChangePassword(action: PayloadAction<IChangePassword>) {
    const values = action.payload;
    try {
        const { data } = yield call(putChangePassword, values);

        yield put(setAccount(data));
        yield put(setStatus({
            status: Status.Success,
        }));

    } catch (error: any) {
        const errorModel = error.response.data as IError;
        yield put(setStatus({}));
    }
}



import { PayloadAction } from "@reduxjs/toolkit";
import { call, put } from "redux-saga/effects";

import { Status } from "src/constants/status";
import IChangePassword from "src/interfaces/IChangePassword";
import IError from "src/interfaces/IError";
import ILoginModel from "src/interfaces/ILoginModel";
import ISubmitAction from "src/interfaces/ISubmitActions";
import IUser from "src/interfaces/User/IUser";
import IUserForm from "src/interfaces/User/IUserForm";

import { setAccount, setStatus } from "../reducer";
import { loginRequest, getMeRequest, putChangePassword } from './requests';

export function* handleLogin(action: PayloadAction<ILoginModel>) {
    const loginModel = action.payload;
    
    try {
        const {data} = yield call(loginRequest, loginModel);
        
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



import { PayloadAction } from "@reduxjs/toolkit";
import { call, put } from "redux-saga/effects";

import { Status } from "../../../constants/status";
import IError from "../../../interfaces/IError";
import { CreateAction, DeleteAction, setDeleteUser, setUser, setStatus, setUsers } from "../reducer";
import { getByPageRequest, createRequest, deleteRequest, updateRequest} from './request';
import IQueryModel from "../../../interfaces/IQueryModel";

export function* handleGetByPage(action: PayloadAction<IQueryModel>) {
    const query = action.payload;
    try {
        const { data } = yield call(getByPageRequest, query);
        
        yield put(setUsers(data));

    } catch (error: any) {
        const errorModel = error.response.data as IError;
        
        yield put(setStatus({
            status: Status.Failed,
            error: errorModel,
        }));
    }
}

export function* handleCreate(action: PayloadAction<CreateAction>) {
    const {handleResult, formValues} = action.payload;
    try {        
        const { data } = yield call(createRequest, formValues);
        if (data)
        {
            handleResult(true, data.userName);
        }

        yield put(setStatus({
            status: Status.Success,
        }));
        yield put(setUser(data));
        
    } catch (error: any) {
        const errorModel = error.response.data as IError;

        handleResult(false, errorModel);
    }
}

export function* handleDelete(action: PayloadAction<DeleteAction>) {
    const {handleResult, formValues} = action.payload;
    try {
        const { data } = yield call(deleteRequest, formValues.id);
        if(data) {
            handleResult(true, formValues.userName);
        }
        yield put(setStatus({
            status: Status.Success,
        }));
        yield put(setDeleteUser(formValues));

    } catch (error: any) {
        const errorModel = error.response.data as IError;
        handleResult(false, errorModel);
    }
}

export function* handleUpdate(action: PayloadAction<CreateAction>) {
    const { handleResult, formValues} = action.payload;

    try {
        const { data } = yield call(updateRequest, formValues);

        handleResult(true, data.userName);

        yield put(setUser(data));
        
    } catch (error: any) {

        const errorModel = error.response.data as IError;

        handleResult(false, errorModel);
    }
}

import { PayloadAction } from "@reduxjs/toolkit";
import { call, put } from "redux-saga/effects";

import { Status } from "src/constants/status";
import IAssignmentRespond from "src/interfaces/Assignment/IAssignmentRespond";
import IQueryAssignmentModel from "src/interfaces/Assignment/IQueryAssignment";
import IError from "src/interfaces/IError";


import { setStatus, setHomeAssignments, setToggle } from "../reducer";


import {  getHomeAssignmentRequest, respondToAssignmentRequest } from './request';


export function* handleGetHomeAssignment(action: PayloadAction<IQueryAssignmentModel>) {
    const query = action.payload;
    try {
        //console.log('handleGetAsset');
        const { data } = yield call(getHomeAssignmentRequest, query);
        
        yield put(setHomeAssignments(data));

    } catch (error: any) {
        const errorModel = error.response.data as IError;
        
        console.log(errorModel);
        yield put(setStatus({
            status: Status.Failed,
            error: errorModel,
        }));
    }
}



export function* handelRespondToAssignment(action: PayloadAction<IAssignmentRespond>){
    const dto = action.payload;
    try {
    
        const { data } = yield call(respondToAssignmentRequest, dto);
        console.log(data);
        yield put(setToggle(true));
    } catch (error: any) {
        const errorModel = error.response.data as IError;
        
        console.log(errorModel);
        yield put(setStatus({
            status: Status.Failed,
            error: errorModel,
        }));
    }
}

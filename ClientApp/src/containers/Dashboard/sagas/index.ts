import { takeLatest } from 'redux-saga/effects';

import { getDashboard, getAssetChecking, getComponentChecking } from '../reducer';
import { handleGetDashboard, handleGetAssetChecking, handleGetComponentChecking } from './handles';

export default function* dashboardSagas() {
    yield takeLatest(getDashboard.type, handleGetDashboard);
    yield takeLatest(getAssetChecking.type, handleGetAssetChecking);
    yield takeLatest(getComponentChecking.type, handleGetComponentChecking);
}

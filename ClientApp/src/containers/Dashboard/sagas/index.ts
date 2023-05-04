import { takeLatest } from 'redux-saga/effects';

import { getDashboardAssets, respondToAssignment } from '../reducer';
import { handleGetDashboard} from './handles';

export default function* dashboardSagas() {
    yield takeLatest(getDashboardAssets.type, handleGetDashboard);
}

import { takeLatest } from 'redux-saga/effects';

import { getDashboard } from '../reducer';
import { handleGetDashboard} from './handles';

export default function* dashboardSagas() {
    yield takeLatest(getDashboard.type, handleGetDashboard);
}

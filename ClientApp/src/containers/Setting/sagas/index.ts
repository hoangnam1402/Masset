import { takeLatest } from 'redux-saga/effects';

import { getSetting, updateSetting, updateLogo } from '../reducer';
import { handleGetSetting, handleUpdateSetting, handleUpdateLogo} from './handles';

export default function* settingSagas() {
    yield takeLatest(getSetting.type, handleGetSetting);
    yield takeLatest(updateSetting.type, handleUpdateSetting);
    yield takeLatest(updateLogo.type, handleUpdateLogo);
}

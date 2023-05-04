import { takeLatest } from 'redux-saga/effects';

import { changePassword, login, me} from '../reducer';
import { handleLogin, handleGetMe, handleChangePassword} from './handles';

export default function* authorizeSagas() {
    yield takeLatest(login.type, handleLogin);
    yield takeLatest(me.type, handleGetMe);
    yield takeLatest(changePassword.type, handleChangePassword)
}
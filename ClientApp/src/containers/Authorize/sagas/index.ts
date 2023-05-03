import { takeLatest } from 'redux-saga/effects';

import { changePassword, login, me} from '../reducer';
import { handleLogin, handleGetMe, handleChangePassword} from './handles';

export default function* authorizeSagas() {
    yield [
        takeLatest(login.type, handleLogin),
        takeLatest(me.type, handleGetMe),
        takeLatest(changePassword.type, handleChangePassword)
    ]
}
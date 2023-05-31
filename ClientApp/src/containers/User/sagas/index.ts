import { takeLatest } from 'redux-saga/effects';

import { deleteUser, getUsers, createUser, updateUser} from '../reducer';
import { handleDelete, handleGetByPage, handleCreate, handleUpdate} from './handles';

export default function* userSagas() {
    yield takeLatest(deleteUser.type, handleDelete);
    yield takeLatest(getUsers.type, handleGetByPage);
    yield takeLatest(createUser.type,handleCreate);
    yield takeLatest(updateUser.type,handleUpdate);
}

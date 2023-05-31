import { takeLatest } from 'redux-saga/effects';

import { deleteLocation, getLocations, createLocation, updateLocation} from '../reducer';
import { handleDelete, handleGetByPage, handleCreate, handleUpdate} from './handles';

export default function* locationSagas() {
    yield takeLatest(deleteLocation.type, handleDelete);
    yield takeLatest(getLocations.type, handleGetByPage);
    yield takeLatest(createLocation.type,handleCreate);
    yield takeLatest(updateLocation.type,handleUpdate);
}

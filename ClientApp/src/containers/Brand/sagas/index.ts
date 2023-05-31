import { takeLatest } from 'redux-saga/effects';

import { deleteBrand, getBrands, createBrand, updateBrand} from '../reducer';
import { handleDelete, handleGetByPage, handleCreate, handleUpdate} from './handles';

export default function* brandSagas() {
    yield takeLatest(deleteBrand.type, handleDelete);
    yield takeLatest(getBrands.type, handleGetByPage);
    yield takeLatest(createBrand.type,handleCreate);
    yield takeLatest(updateBrand.type,handleUpdate);
}

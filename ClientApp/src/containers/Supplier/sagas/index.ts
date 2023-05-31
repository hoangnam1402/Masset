import { takeLatest } from 'redux-saga/effects';

import { deleteSupplier, getSuppliers, createSupplier, updateSupplier} from '../reducer';
import { handleDelete, handleGetByPage, handleCreate, handleUpdate} from './handles';

export default function* supplierSagas() {
    yield takeLatest(deleteSupplier.type, handleDelete);
    yield takeLatest(getSuppliers.type, handleGetByPage);
    yield takeLatest(createSupplier.type,handleCreate);
    yield takeLatest(updateSupplier.type,handleUpdate);
}

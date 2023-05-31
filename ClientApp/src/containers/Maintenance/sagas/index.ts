import { takeLatest } from 'redux-saga/effects';

import { getSuppliers, getAssets, deleteMaintenance, getMaintenances, createMaintenance, 
    updateMaintenance} from '../reducer';
import { handleGetSupplier, handleGetAssets, handleDelete, handleGetByPage, handleCreate, 
    handleUpdate} from './handles';

export default function* maintenanceSagas() {
    yield takeLatest(deleteMaintenance.type, handleDelete);
    yield takeLatest(getMaintenances.type, handleGetByPage);
    yield takeLatest(createMaintenance.type,handleCreate);
    yield takeLatest(updateMaintenance.type,handleUpdate);
    yield takeLatest(getSuppliers.type,handleGetSupplier);
    yield takeLatest(getAssets.type,handleGetAssets);
}

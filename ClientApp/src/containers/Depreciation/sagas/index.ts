import { takeLatest } from 'redux-saga/effects';

import { getComponents, getAssets, deleteDepreciation, getDepreciations, createDepreciation, 
    updateDepreciation} from '../reducer';
import { handleGetComponents, handleGetAssets, handleDelete, handleGetByPage, handleCreate, 
    handleUpdate} from './handles';

export default function* depreciationSagas() {
    yield takeLatest(deleteDepreciation.type, handleDelete);
    yield takeLatest(getDepreciations.type, handleGetByPage);
    yield takeLatest(createDepreciation.type,handleCreate);
    yield takeLatest(updateDepreciation.type,handleUpdate);
    yield takeLatest(getComponents.type,handleGetComponents);
    yield takeLatest(getAssets.type,handleGetAssets);
}

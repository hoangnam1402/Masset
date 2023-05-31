import { takeLatest } from 'redux-saga/effects';

import { deleteAssetType, getAssetTypes, createAssetType, updateAssetType} from '../reducer';
import { handleDelete, handleGetByPage, handleCreate, handleUpdate} from './handles';

export default function* assetTypeSagas() {
    yield takeLatest(deleteAssetType.type, handleDelete);
    yield takeLatest(getAssetTypes.type, handleGetByPage);
    yield takeLatest(createAssetType.type,handleCreate);
    yield takeLatest(updateAssetType.type,handleUpdate);
}

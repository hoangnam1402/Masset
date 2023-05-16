import { takeLatest } from 'redux-saga/effects';

import { getAssets, getAssetTypes, getBrands, getLocations, getAssetById,
    getSuppliers, deleteAssets, createAsset, updateAsset } from '../reducer';
import { handleGetAssets, handleGetAssetType, handleGetBrand, handleGetLocation, handleGetAssetById,
    handleSupplier, handleDeleteAsset, handleCreateAsset, handleUpdateAsset } from './handles';

export default function* assetSagas() {
    yield takeLatest(deleteAssets.type, handleDeleteAsset);
    yield takeLatest(getAssets.type, handleGetAssets);
    yield takeLatest(getAssetTypes.type,handleGetAssetType);
    yield takeLatest(createAsset.type,handleCreateAsset);
    yield takeLatest(updateAsset.type,handleUpdateAsset);
    yield takeLatest(getBrands.type,handleGetBrand);
    yield takeLatest(getLocations.type,handleGetLocation);
    yield takeLatest(getSuppliers.type,handleSupplier);
    yield takeLatest(getAssetById.type,handleGetAssetById);
}

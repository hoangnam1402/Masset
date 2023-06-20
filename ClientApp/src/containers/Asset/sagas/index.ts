import { takeLatest } from 'redux-saga/effects';

import { getAssets, getAssetTypes, getBrands, getLocations, getAssetById, getQrCode, getMaintenance,
    getSuppliers, deleteAssets, createAsset, updateAsset, getDepreciation, getHistoryCheck, 
    getComponentCheck, getAssetCheckIn, getAssetCheckOut, getUsers } from '../reducer';
import { handleGetAssets, handleGetAssetType, handleGetBrand, handleGetLocation, handleGetAssetById,
    handleQRCodeGenerator, handleGetSupplier, handleDeleteAsset, handleCreateAsset, handleUpdateAsset,
    handleGetMaintenance, handleGetDepreciation, handleGetHistoryCheck, handleGetComponentCheckOfAsset, 
    handleCheckIn, handleCheckOut, handleGetUsers } from './handles';

export default function* assetSagas() {
    yield takeLatest(deleteAssets.type, handleDeleteAsset);
    yield takeLatest(getAssets.type, handleGetAssets);
    yield takeLatest(getAssetTypes.type,handleGetAssetType);
    yield takeLatest(createAsset.type,handleCreateAsset);
    yield takeLatest(updateAsset.type,handleUpdateAsset);
    yield takeLatest(getBrands.type,handleGetBrand);
    yield takeLatest(getLocations.type,handleGetLocation);
    yield takeLatest(getSuppliers.type,handleGetSupplier);
    yield takeLatest(getAssetById.type,handleGetAssetById);
    yield takeLatest(getQrCode.type, handleQRCodeGenerator);
    yield takeLatest(getMaintenance.type, handleGetMaintenance);
    yield takeLatest(getDepreciation.type, handleGetDepreciation);
    yield takeLatest(getHistoryCheck.type,handleGetHistoryCheck);
    yield takeLatest(getComponentCheck.type,handleGetComponentCheckOfAsset);
    yield takeLatest(getAssetCheckIn.type,handleCheckIn);
    yield takeLatest(getAssetCheckOut.type,handleCheckOut);
    yield takeLatest(getUsers.type, handleGetUsers);
}

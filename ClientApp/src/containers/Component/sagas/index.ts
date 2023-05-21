import { takeLatest } from 'redux-saga/effects';

import { getComponents, getAssetTypes, getBrands, getLocations, getById, deleteComponent,
    getSuppliers, createComponent, updateComponent, getDepreciation } from '../reducer';
import { handleGetComponents, handleGetAssetType, handleGetBrand, handleGetLocation, handleGetById,
    handleGetSupplier, handleDeleteComponent, handleCreateComponent, handleUpdateComponent,
    handleGetDepreciation } from './handles';

export default function* assetSagas() {
    yield takeLatest(deleteComponent.type, handleDeleteComponent);
    yield takeLatest(getComponents.type, handleGetComponents);
    yield takeLatest(getAssetTypes.type,handleGetAssetType);
    yield takeLatest(createComponent.type,handleCreateComponent);
    yield takeLatest(updateComponent.type,handleUpdateComponent);
    yield takeLatest(getBrands.type,handleGetBrand);
    yield takeLatest(getLocations.type,handleGetLocation);
    yield takeLatest(getSuppliers.type,handleGetSupplier);
    yield takeLatest(getById.type,handleGetById);
    yield takeLatest(getDepreciation.type, handleGetDepreciation)
}

import { takeLatest } from 'redux-saga/effects';

import { getComponents, getAssetTypes, getBrands, getLocations, getById, deleteComponent,
    getSuppliers, createComponent, updateComponent, getDepreciation, getCheckIn, getComponentCheck, 
    getCheckOut, getAssets} from '../reducer';
import { handleGetComponents, handleGetAssetType, handleGetBrand, handleGetLocation, handleGetById,
    handleGetSupplier, handleDeleteComponent, handleCreateComponent, handleUpdateComponent,
    handleGetDepreciation, handleCheckOut, handleCheckIn, handleGetComponentCheck, handleGetAssets} from './handles';

export default function* componentSagas() {
    yield takeLatest(deleteComponent.type, handleDeleteComponent);
    yield takeLatest(getComponents.type, handleGetComponents);
    yield takeLatest(getAssetTypes.type,handleGetAssetType);
    yield takeLatest(createComponent.type,handleCreateComponent);
    yield takeLatest(updateComponent.type,handleUpdateComponent);
    yield takeLatest(getBrands.type,handleGetBrand);
    yield takeLatest(getLocations.type,handleGetLocation);
    yield takeLatest(getSuppliers.type,handleGetSupplier);
    yield takeLatest(getById.type,handleGetById);
    yield takeLatest(getDepreciation.type, handleGetDepreciation);
    yield takeLatest(getCheckIn.type,handleCheckIn);
    yield takeLatest(getCheckOut.type,handleCheckOut);
    yield takeLatest(getComponentCheck.type,handleGetComponentCheck);
    yield takeLatest(getAssets.type,handleGetAssets);
}

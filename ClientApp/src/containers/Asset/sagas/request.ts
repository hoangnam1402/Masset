import { AxiosResponse } from "axios";
import qs from 'qs';
import RequestService from '../../../services/request';
import EndPoints from '../../../constants/endpoints';
import IQueryAssetModel from "../../../interfaces/Asset/IQueryAssetModel";
import IAsset from "../../../interfaces/Asset/IAsset";
import IAssetForm from "../../../interfaces/Asset/IAssetForm";


export function getAssetsRequest(query: IQueryAssetModel): Promise<AxiosResponse<IAsset>> {
    return RequestService.axios.get(EndPoints.Asset, {
        params: query,
        paramsSerializer: {
            serialize: (params) => qs.stringify(params)
        }
    });
}

export function getAssetByIdRequest(assetId: number): Promise<AxiosResponse<IAsset>> {
    return RequestService.axios.get(EndPoints.AssetId(assetId ?? -1));
}

export function getAssetTypeRequest(): Promise<AxiosResponse<IAsset>> {
    return RequestService.axios.get(EndPoints.AllAssetType);
}

export function getLocationRequest(): Promise<AxiosResponse<IAsset>> {
    return RequestService.axios.get(EndPoints.AllLocation);
}

export function getBrandsRequest(): Promise<AxiosResponse<IAsset>> {
    return RequestService.axios.get(EndPoints.AllBrand);
}

export function getSupplierRequest(): Promise<AxiosResponse<IAsset>> {
    return RequestService.axios.get(EndPoints.AllSupplier);
}

export function createAssetRequest(assetForm: IAssetForm): Promise<AxiosResponse<IAsset>> {
    return RequestService.axios.post(EndPoints.Asset, assetForm, {
        paramsSerializer: {
            serialize: (params) => qs.stringify(params)
        }
    });
}

export function deleteAssetRequest(assetId: number): Promise<AxiosResponse<IAsset>> {
    return RequestService.axios.delete(EndPoints.AssetId(assetId ?? -1))
}

export function putAssetsRequest(userForm: IAssetForm): Promise<AxiosResponse<IAsset>> {
    return RequestService.axios.put(EndPoints.AssetId(userForm.id ?? -1), userForm, {
        paramsSerializer: {
            serialize: (params) => qs.stringify(params)
        }
    });
}
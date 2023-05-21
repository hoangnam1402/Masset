import { AxiosResponse } from "axios";
import qs from 'qs';
import RequestService from '../../../services/request';
import EndPoints from '../../../constants/endpoints';
import IQueryAssetModel from "../../../interfaces/Asset/IQueryAssetModel";
import IAsset from "../../../interfaces/Asset/IAsset";
import IAssetForm from "../../../interfaces/Asset/IAssetForm";
import IType from "../../../interfaces/Type/IType";
import ILocation from "../../../interfaces/Location/ILocation";
import IBrand from "../../../interfaces/Brand/IBrand";
import ISupplier from "../../../interfaces/Supplier/ISupplier";
import IMaintenance from "../../../interfaces/Maintenance/IMaintenance";
import IQueryModel from "../../../interfaces/IQueryModel";
import IDepreciation from "../../../interfaces/Depreciation/IDepreciation";

interface ImageResponse {
    data: Blob;
  }
  
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

export function getAssetTypeRequest(): Promise<AxiosResponse<IType>> {
    return RequestService.axios.get(EndPoints.AllAssetType);
}

export function getLocationRequest(): Promise<AxiosResponse<ILocation>> {
    return RequestService.axios.get(EndPoints.AllLocation);
}

export function getBrandsRequest(): Promise<AxiosResponse<IBrand>> {
    return RequestService.axios.get(EndPoints.AllBrand);
}

export function getSupplierRequest(): Promise<AxiosResponse<ISupplier>> {
    return RequestService.axios.get(EndPoints.AllSupplier);
}

export function getMaintenanceRequest(query: IQueryModel, assetId: number): Promise<AxiosResponse<IMaintenance>> {
    return RequestService.axios.post(EndPoints.MaintenanceOfAsset(assetId ?? -1), query, {
        paramsSerializer: {
            serialize: (params) => qs.stringify(params)
        }
    });
}

export function getDepreciationRequest(assetId: number): Promise<AxiosResponse<IDepreciation>> {
    return RequestService.axios.get(EndPoints.DepreciationOfAsset(assetId ?? -1))
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

export function putAssetsRequest(assetForm: IAssetForm): Promise<AxiosResponse<IAsset>> {
    return RequestService.axios.put(EndPoints.AssetId(assetForm.id ?? -1), assetForm, {
        paramsSerializer: {
            serialize: (params) => qs.stringify(params)
        }
    });
}

export function GeneratingQRCode(tag: string): Promise<AxiosResponse<ImageResponse>> {
    return RequestService.axios.get(EndPoints.generatingQRCode(tag ?? -1), { responseType: 'blob' });
}
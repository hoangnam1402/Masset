import { AxiosResponse } from "axios";
import qs from 'qs';
import RequestService from '../../../services/request';
import EndPoints from '../../../constants/endpoints';
import IQueryAssetModel from "../../../interfaces/Asset/IQueryAssetModel";
import IType from "../../../interfaces/Type/IType";
import ILocation from "../../../interfaces/Location/ILocation";
import IBrand from "../../../interfaces/Brand/IBrand";
import ISupplier from "../../../interfaces/Supplier/ISupplier";
import IDepreciation from "../../../interfaces/Depreciation/IDepreciation";
import IComponent from "../../../interfaces/Component/IComponent";
import IComponentForm from "../../../interfaces/Component/IComponentForm";

interface ImageResponse {
    data: Blob;
  }
  
export function getComponentsRequest(query: IQueryAssetModel): Promise<AxiosResponse<IComponent>> {
    return RequestService.axios.get(EndPoints.Component, {
        params: query,
        paramsSerializer: {
            serialize: (params) => qs.stringify(params)
        }
    });
}

export function getByIdRequest(id: number): Promise<AxiosResponse<IComponent>> {
    return RequestService.axios.get(EndPoints.ComponentId(id ?? -1));
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

export function getDepreciationRequest(id: number): Promise<AxiosResponse<IDepreciation>> {
    return RequestService.axios.get(EndPoints.DepreciationOfComponent(id ?? -1))
}

export function createComponentRequest(componentForm: IComponentForm): Promise<AxiosResponse<IComponent>> {
    return RequestService.axios.post(EndPoints.Component, componentForm, {
        paramsSerializer: {
            serialize: (params) => qs.stringify(params)
        }
    });
}

export function deleteComponentRequest(assetId: number): Promise<AxiosResponse<IComponent>> {
    return RequestService.axios.delete(EndPoints.ComponentId(assetId ?? -1))
}

export function putComponentRequest(componentForm: IComponentForm): Promise<AxiosResponse<IComponent>> {
    return RequestService.axios.put(EndPoints.ComponentId(componentForm.id ?? -1), componentForm, {
        paramsSerializer: {
            serialize: (params) => qs.stringify(params)
        }
    });
}

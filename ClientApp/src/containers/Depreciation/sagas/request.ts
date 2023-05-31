import { AxiosResponse } from "axios";
import qs from 'qs';
import RequestService from '../../../services/request';
import EndPoints from '../../../constants/endpoints';
import IQueryModel from "../../../interfaces/IQueryModel";
import IAsset from "../../../interfaces/Asset/IAsset";
import IDepreciation from "../../../interfaces/Depreciation/IDepreciation";
import IDepreciationForm from "../../../interfaces/Depreciation/IDepreciationForm";
import IComponent from "../../../interfaces/Component/IComponent";

export function getByPageRequest(query: IQueryModel): Promise<AxiosResponse<IDepreciation>> {
    return RequestService.axios.get(EndPoints.Depreciation, {
        params: query,
        paramsSerializer: {
            serialize: (params) => qs.stringify(params)
        }
    });
}

export function getComponentRequest(): Promise<AxiosResponse<IComponent>> {
    return RequestService.axios.get(EndPoints.AllComponent);
}

export function getAssetRequest(): Promise<AxiosResponse<IAsset>> {
    return RequestService.axios.get(EndPoints.AllAsset);
}

export function createRequest(form: IDepreciationForm): Promise<AxiosResponse<IDepreciation>> {
    return RequestService.axios.post(EndPoints.Depreciation, form, {
        paramsSerializer: {
            serialize: (params) => qs.stringify(params)
        }
    });
}

export function deleteRequest(id: number): Promise<AxiosResponse<IDepreciation>> {
    return RequestService.axios.delete(EndPoints.DepreciationId(id ?? -1))
}

export function updateRequest(form: IDepreciationForm): Promise<AxiosResponse<IDepreciation>> {
    return RequestService.axios.put(EndPoints.DepreciationId(form.id ?? -1), form, {
        paramsSerializer: {
            serialize: (params) => qs.stringify(params)
        }
    });
}

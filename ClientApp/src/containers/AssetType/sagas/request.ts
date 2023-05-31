import { AxiosResponse } from "axios";
import qs from 'qs';
import RequestService from '../../../services/request';
import EndPoints from '../../../constants/endpoints';
import IQueryModel from "../../../interfaces/IQueryModel";
import IType from "../../../interfaces/Type/IType";
import ITypeForm from "../../../interfaces/Type/ITypeForm";

export function getByPageRequest(query: IQueryModel): Promise<AxiosResponse<IType>> {
    return RequestService.axios.get(EndPoints.AssetType, {
        params: query,
        paramsSerializer: {
            serialize: (params) => qs.stringify(params)
        }
    });
}

export function createRequest(form: ITypeForm): Promise<AxiosResponse<IType>> {
    return RequestService.axios.post(EndPoints.AssetType, form, {
        paramsSerializer: {
            serialize: (params) => qs.stringify(params)
        }
    });
}

export function deleteRequest(id: number): Promise<AxiosResponse<IType>> {
    return RequestService.axios.delete(EndPoints.AssetTypeId(id ?? -1))
}

export function updateRequest(form: ITypeForm): Promise<AxiosResponse<IType>> {
    return RequestService.axios.put(EndPoints.AssetTypeId(form.id ?? -1), form, {
        paramsSerializer: {
            serialize: (params) => qs.stringify(params)
        }
    });
}

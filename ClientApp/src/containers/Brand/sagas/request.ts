import { AxiosResponse } from "axios";
import qs from 'qs';
import RequestService from '../../../services/request';
import EndPoints from '../../../constants/endpoints';
import IQueryModel from "../../../interfaces/IQueryModel";
import IBrand from "../../../interfaces/Brand/IBrand";
import IBrandForm from "../../../interfaces/Brand/IBrandForm";

export function getByPageRequest(query: IQueryModel): Promise<AxiosResponse<IBrand>> {
    return RequestService.axios.get(EndPoints.Brand, {
        params: query,
        paramsSerializer: {
            serialize: (params) => qs.stringify(params)
        }
    });
}

export function createRequest(form: IBrandForm): Promise<AxiosResponse<IBrand>> {
    return RequestService.axios.post(EndPoints.Brand, form, {
        paramsSerializer: {
            serialize: (params) => qs.stringify(params)
        }
    });
}

export function deleteRequest(id: number): Promise<AxiosResponse<IBrand>> {
    return RequestService.axios.delete(EndPoints.BrandId(id ?? -1))
}

export function updateRequest(form: IBrandForm): Promise<AxiosResponse<IBrand>> {
    return RequestService.axios.put(EndPoints.BrandId(form.id ?? -1), form, {
        paramsSerializer: {
            serialize: (params) => qs.stringify(params)
        }
    });
}

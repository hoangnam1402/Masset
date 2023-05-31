import { AxiosResponse } from "axios";
import qs from 'qs';
import RequestService from '../../../services/request';
import EndPoints from '../../../constants/endpoints';
import IQueryModel from "../../../interfaces/IQueryModel";
import ISupplierForm from "../../../interfaces/Supplier/ISupplierForm";
import ISupplier from "../../../interfaces/Supplier/ISupplier";

export function getByPageRequest(query: IQueryModel): Promise<AxiosResponse<ISupplier>> {
    return RequestService.axios.get(EndPoints.Supplier, {
        params: query,
        paramsSerializer: {
            serialize: (params) => qs.stringify(params)
        }
    });
}

export function createRequest(form: ISupplierForm): Promise<AxiosResponse<ISupplier>> {
    return RequestService.axios.post(EndPoints.Supplier, form, {
        paramsSerializer: {
            serialize: (params) => qs.stringify(params)
        }
    });
}

export function deleteRequest(id: number): Promise<AxiosResponse<ISupplier>> {
    return RequestService.axios.delete(EndPoints.SupplierId(id ?? -1))
}

export function updateRequest(form: ISupplierForm): Promise<AxiosResponse<ISupplier>> {
    return RequestService.axios.put(EndPoints.SupplierId(form.id ?? -1), form, {
        paramsSerializer: {
            serialize: (params) => qs.stringify(params)
        }
    });
}

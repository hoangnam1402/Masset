import { AxiosResponse } from "axios";
import qs from 'qs';
import RequestService from '../../../services/request';
import EndPoints from '../../../constants/endpoints';
import ISupplier from "../../../interfaces/Supplier/ISupplier";
import IQueryModel from "../../../interfaces/IQueryModel";
import IAsset from "../../../interfaces/Asset/IAsset";
import IMaintenance from "../../../interfaces/Maintenance/IMaintenance";
import IMaintenanceForm from "../../../interfaces/Maintenance/IMaintenanceForm";

export function getByPageRequest(query: IQueryModel): Promise<AxiosResponse<IMaintenance>> {
    return RequestService.axios.get(EndPoints.Maintenance, {
        params: query,
        paramsSerializer: {
            serialize: (params) => qs.stringify(params)
        }
    });
}

export function getSupplierRequest(): Promise<AxiosResponse<ISupplier>> {
    return RequestService.axios.get(EndPoints.AllSupplier);
}

export function getAssetRequest(): Promise<AxiosResponse<IAsset>> {
    return RequestService.axios.get(EndPoints.AllAsset);
}

export function createRequest(form: IMaintenanceForm): Promise<AxiosResponse<IMaintenance>> {
    return RequestService.axios.post(EndPoints.Maintenance, form, {
        paramsSerializer: {
            serialize: (params) => qs.stringify(params)
        }
    });
}

export function deleteRequest(id: number): Promise<AxiosResponse<IMaintenance>> {
    return RequestService.axios.delete(EndPoints.ComponentId(id ?? -1))
}

export function updateRequest(form: IMaintenanceForm): Promise<AxiosResponse<IMaintenance>> {
    return RequestService.axios.put(EndPoints.ComponentId(form.id ?? -1), form, {
        paramsSerializer: {
            serialize: (params) => qs.stringify(params)
        }
    });
}

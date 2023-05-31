import { AxiosResponse } from "axios";
import qs from 'qs';
import RequestService from '../../../services/request';
import EndPoints from '../../../constants/endpoints';
import IQueryModel from "../../../interfaces/IQueryModel";
import ILocation from "../../../interfaces/Location/ILocation";
import ILocationForm from "../../../interfaces/Location/ILocationForm";

export function getByPageRequest(query: IQueryModel): Promise<AxiosResponse<ILocation>> {
    return RequestService.axios.get(EndPoints.Location, {
        params: query,
        paramsSerializer: {
            serialize: (params) => qs.stringify(params)
        }
    });
}

export function createRequest(form: ILocationForm): Promise<AxiosResponse<ILocation>> {
    return RequestService.axios.post(EndPoints.Location, form, {
        paramsSerializer: {
            serialize: (params) => qs.stringify(params)
        }
    });
}

export function deleteRequest(id: number): Promise<AxiosResponse<ILocation>> {
    return RequestService.axios.delete(EndPoints.LocationId(id ?? -1))
}

export function updateRequest(form: ILocationForm): Promise<AxiosResponse<ILocation>> {
    return RequestService.axios.put(EndPoints.LocationId(form.id ?? -1), form, {
        paramsSerializer: {
            serialize: (params) => qs.stringify(params)
        }
    });
}

import { AxiosResponse } from "axios";
import qs from 'qs';
import RequestService from '../../../services/request';
import EndPoints from '../../../constants/endpoints';
import IQueryModel from "../../../interfaces/IQueryModel";
import IUser from "../../../interfaces/User/IUser";
import IUserForm from "../../../interfaces/User/IUserForm";

export function getByPageRequest(query: IQueryModel): Promise<AxiosResponse<IUser>> {
    return RequestService.axios.get(EndPoints.User, {
        params: query,
        paramsSerializer: {
            serialize: (params) => qs.stringify(params)
        }
    });
}

export function createRequest(form: IUserForm): Promise<AxiosResponse<IUser>> {
    return RequestService.axios.post(EndPoints.User, form, {
        paramsSerializer: {
            serialize: (params) => qs.stringify(params)
        }
    });
}

export function deleteRequest(id: string): Promise<AxiosResponse<IUser>> {
    return RequestService.axios.delete(EndPoints.UserId(id ?? -1))
}

export function updateRequest(form: IUserForm): Promise<AxiosResponse<IUser>> {
    return RequestService.axios.put(EndPoints.UserId(form.id ?? -1), form, {
        paramsSerializer: {
            serialize: (params) => qs.stringify(params)
        }
    });
}

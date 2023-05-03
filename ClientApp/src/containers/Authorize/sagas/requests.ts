import { AxiosResponse } from "axios";

import RequestService from '../../../services/request';
import EndPoints from '../../../constants/endpoints';
import ILoginModel from "../../../interfaces/ILoginModel";
import IAccount from "../../../interfaces/IAccount";
import IChangePassword from "../../../interfaces/IChangePassword";

export function loginRequest(login: ILoginModel): Promise<AxiosResponse<IAccount>> {
    return RequestService.axios.post(EndPoints.authorize, login);
}

export function getMeRequest(): Promise<AxiosResponse<IAccount>> {
    return RequestService.axios.get(EndPoints.me);
}

export function putChangePassword(changePasswordModel: IChangePassword): Promise<AxiosResponse<IAccount>> {
    return RequestService.axios.put(EndPoints.authorize, changePasswordModel);
}

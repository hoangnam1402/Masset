import { AxiosResponse } from "axios";
import RequestService from '../../../services/request';
import EndPoints from '../../../constants/endpoints';
import ISetting from "../../../interfaces/Setting/ISetting";
import qs from "qs";
import ISettingForm from "../../../interfaces/Setting/ISettingForm";

export function getSettingRequest(): Promise<AxiosResponse<ISetting>> {
    return RequestService.axios.get(EndPoints.Setting);
}

export function updateSettingRequest(form: ISettingForm): Promise<AxiosResponse<ISetting>> {
    return RequestService.axios.put(EndPoints.Setting, form, {
        paramsSerializer: {
            serialize: (params) => qs.stringify(params)
        }
    });
}

export function updateLogoRequest(file: File): Promise<AxiosResponse<ISetting>> {
    const formData = new FormData();
    formData.append('image', file);

    return RequestService.axios.put(EndPoints.Logo, formData, {
        headers: {
            'Content-Type': 'multipart/form-data',
        },
    });
}
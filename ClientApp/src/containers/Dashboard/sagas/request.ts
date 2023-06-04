import { AxiosResponse } from "axios";
import RequestService from '../../../services/request';
import EndPoints from '../../../constants/endpoints';
import IDashboard from "../../../interfaces/Dashboard/IDashboard";
import IChecking from "../../../interfaces/Checking/IChecking";
import IQueryModel from "../../../interfaces/IQueryModel";
import qs from "qs";

export function getDashboardRequest(): Promise<AxiosResponse<IDashboard>> {
    return RequestService.axios.get(EndPoints.Dashboard);
}

export function getAssetCheckingRequest(query: IQueryModel): Promise<AxiosResponse<IChecking>> {
    return RequestService.axios.get(EndPoints.AssetChecking, {
        params: query,
        paramsSerializer: {
            serialize: (params) => qs.stringify(params)
        }
    });
}

export function getComponentCheckingRequest(query: IQueryModel): Promise<AxiosResponse<IChecking>> {
    return RequestService.axios.get(EndPoints.ComponentChecking, {
        params: query,
        paramsSerializer: {
            serialize: (params) => qs.stringify(params)
        }
    });
}
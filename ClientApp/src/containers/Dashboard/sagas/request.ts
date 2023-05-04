import { AxiosResponse } from "axios";
import RequestService from '../../../services/request';
import EndPoints from '../../../constants/endpoints';
import IDashboard from "../../../interfaces/Dashboard/IDashboard";

export function getDashboardRequest(): Promise<AxiosResponse<IDashboard>> {
    return RequestService.axios.get(EndPoints.getDashboard);
}
  
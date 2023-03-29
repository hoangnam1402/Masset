import { AxiosResponse } from "axios";
import qs from 'qs';
import RequestService from 'src/services/request';
import EndPoints from 'src/constants/endpoints';
import IQueryAssetModel from "src/interfaces/Asset/IQueryAssetModel";
import IAsset from "src/interfaces/Asset/IAsset";
import IAssignment from "src/interfaces/Assignment/IAssignment";
import IQueryAssignmentModel from "src/interfaces/Assignment/IQueryAssignment";
import IAssignmentRespond from "src/interfaces/Assignment/IAssignmentRespond";


export function getHomeAssignmentRequest(query: IQueryAssignmentModel): Promise<AxiosResponse<IAssignment>> {
    return RequestService.axios.get(EndPoints.getUserAssignment, {
        params: query,
        paramsSerializer: params => qs.stringify(params),
    });
}
export function respondToAssignmentRequest(
    dto: IAssignmentRespond
  ): Promise<AxiosResponse<IAssignment>> {
    return RequestService.axios.post(EndPoints.respondToAssignment,dto);
  }
  
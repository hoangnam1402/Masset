import { AxiosResponse } from "axios";
import qs from 'qs';
import RequestService from '../../../services/request';
import EndPoints from '../../../constants/endpoints';
import IQueryAssetModel from "../../../interfaces/Asset/IQueryAssetModel";
import IAsset from "../../../interfaces/Asset/IAsset";
import IAssignmentRespond from "../../../interfaces/Assignment/IAssignmentRespond";


export function getHomeAssignmentRequest(query: IQueryAssetModel): Promise<AxiosResponse<IAsset>> {
    return RequestService.axios.get(EndPoints.getAsset, {
        params: query,
        paramsSerializer: {
          serialize: (params: any) => qs.stringify(params),
        }
    });
}
  
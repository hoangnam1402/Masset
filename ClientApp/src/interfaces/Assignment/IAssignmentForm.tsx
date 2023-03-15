import IAsset from "../Asset/IAsset";
import IUser from "../User/IUser";

export default interface IAssignmentForm {
    id?: number,
    assetId?:number,
    asset?:IAsset,
    assignToId?:number,
    assignTo?:IUser,
    assignDate?:Date,
    note:string,
}
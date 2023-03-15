import IAsset from "../Asset/IAsset";
import IUser from "../User/IUser";

export default interface IAssignment {
    id?: number,
    asset?:IAsset,
    assignTo?:IUser,
    assignDate?:Date,
    note:string,
}
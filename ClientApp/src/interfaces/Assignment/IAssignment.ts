import IAsset from "../Asset/IAsset";
import IUser from "../User/IUser";

export default interface IAssignment {
    id: number,
    assetID:number,
    asset:IAsset,
    assignByID:number,
    assignBy:IUser
    assignToID:number,
    assignTo:IUser,
    assignDate:Date,
    returnDate:Date,
    note:string,
    state:number,
    location:number

}
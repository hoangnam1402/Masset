import IAsset from "../Asset/IAsset";
import IComponent from "../Component/IComponent";
import IUser from "../User/IUser";

export default interface IChecking {
    id: number,
    userID:string,
    user:IUser,
    assetID:number,
    asset:IAsset,
    componentID:number,
    component:IComponent,
    quantity:number,
    checkDay:Date,
    isCheckOut:boolean,
    isEffective:boolean,
    createDay:Date,
    updateDay:Date,
}

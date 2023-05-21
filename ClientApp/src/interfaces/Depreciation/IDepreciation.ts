import IAsset from "../Asset/IAsset";
import IComponent from "../Component/IComponent";

export default interface IDepreciation {
    id: number,
    category:number,
    asset:IAsset,
    assetID:number,
    component:IComponent,
    componentID:number,
    period:number,
    value:number,
    createDay:Date,
    updateDay:Date
}
import IAsset from "../Asset/IAsset";
import ISupplier from "../Supplier/ISupplier";

export default interface IMaintenance {
    id: number,
    assetID:number,
    asset:IAsset,
    supplierID:number,
    supplier:ISupplier,
    type:number,
    startDate:Date,
    endDate:Date,
    createDay:Date,
    updateDay:Date
}
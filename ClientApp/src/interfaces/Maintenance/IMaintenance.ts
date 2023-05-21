import IAsset from "../Asset/IAsset";
import ISupplier from "../Supplier/ISupplier";

export default interface IMaintenance {
    id: number,
    assetID:number,
    asset:IAsset,
    supplierID:number,
    supplier:ISupplier,
    maintenanceType:number,
    startDate:Date,
    endDate:Date,
    createDay:Date,
    updateDay:Date
}
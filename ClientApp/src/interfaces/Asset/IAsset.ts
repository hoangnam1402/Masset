import IType from "../Type/IType"
import ISupplier from "../Supplier/ISupplier"
import ILocation from "../Location/ILocation"
import IBrand from "../Brand/IBrand"

export default interface IAsset {
    id: number,
    name:string,
    tag:string,
    typeID:number,
    type:IType,
    supplierID:number,
    supplier:ISupplier,
    locationID:number,
    location:ILocation,
    brandID:number,
    brand:IBrand,
    serial:string,
    cost:number,
    warranty:number,
    status:number,
    description:string | undefined,
    purchaseDay:Date,
    createDay:Date,
    updateDay:Date,
    isCheckOut:boolean,
    isActive:boolean | undefined,
    isDepreciation:boolean | undefined,
    image: string | undefined,
}

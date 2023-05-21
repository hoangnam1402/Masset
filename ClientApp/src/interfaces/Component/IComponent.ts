import IType from "../Type/IType"
import ISupplier from "../Supplier/ISupplier"
import ILocation from "../Location/ILocation"
import IBrand from "../Brand/IBrand"

export default interface IComponent {
    id: number,
    name: string,
    serial: string,
    quantity: number,
    availableQuantity: number,
    supplierID:number,
    supplier:ISupplier,
    locationID:number,
    location:ILocation,
    brandID:number,
    brand:IBrand,
    typeID:number,
    type:IType,
    cost:number,
    warranty:number,
    status:number,
    description:string | undefined,
    purchaseDay:Date,
    createDay:Date,
    updateDay:Date
}
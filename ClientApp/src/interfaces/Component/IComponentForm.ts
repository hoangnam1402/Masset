export default interface IComponentForm {
    id?: number;
    name: string;
    supplierID?:number;
    locationID?:number;
    brandID?:number;
    serial?:string;
    quantity?: number,
    typeID?:number;
    cost?:number;
    status?: number;
    warranty?:number;
    description?:string;
    purchaseDay?:Date;
  }
  
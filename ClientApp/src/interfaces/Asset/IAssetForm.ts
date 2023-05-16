export default interface IAssetForm {
  id?: number;
  name: string;
  tag?:string;
  supplierID?:number;
  locationID?:number;
  brandID?:number;
  serial?:string;
  typeID?:number;
  cost?:number;
  status?: number;
  warranty?:number;
  description?:string;
  purchaseDay?:Date;
}

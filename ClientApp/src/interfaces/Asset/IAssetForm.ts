import IAssetCategory from "./IAssetCategory";

export default interface IAssetForm {
  id?: number;
  name: string;
  specification: string;
  installDate?: Date;
  state?: number;
  categoryID?: number;
}

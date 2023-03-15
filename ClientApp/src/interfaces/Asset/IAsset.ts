import IAssetCategory from "./IAssetCategory"

export default interface IAsset {
    id: number,
    location: number,
    code:string,
    name:string,
    specification:string,
    installDate:Date,
    state:number,
    categoryID:number,
    category:IAssetCategory
    lastUpdate:Date

}

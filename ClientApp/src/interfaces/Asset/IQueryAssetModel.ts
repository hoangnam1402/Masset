export default interface IQueryAssetModel {
    page: number;
    category: number[];
    state:number[];
    search: string;
    sortOrder: string;
    sortColumn: string;
    limit: number;
}
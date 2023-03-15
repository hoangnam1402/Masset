export default interface IQueryUserModel {
    page: number;
    types: number[];
    search: string;
    sortOrder: string;
    sortColumn: string;
    limit: number;
}
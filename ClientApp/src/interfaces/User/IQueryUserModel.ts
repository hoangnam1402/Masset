export default interface IQueryUserModel {
    page: number;
    role: number[];
    search: string;
    sortOrder: string;
    sortColumn: string;
    limit: number;
}
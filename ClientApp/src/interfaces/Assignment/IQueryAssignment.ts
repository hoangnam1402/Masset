export default interface IQueryAssignmentModel {
    page: number;
    search: string;
    sortOrder: string;
    sortColumn: string;
    limit: number;
    assignedDate: Date|null|undefined;
    state:number[];
}
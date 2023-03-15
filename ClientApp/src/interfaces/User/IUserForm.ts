export default interface IUserForm {
    userId? : number,
    firstName: string,
    lastName: string,
    DOB?: Date,
    gender: string,
    joinDate?: Date,
    type: number,
}
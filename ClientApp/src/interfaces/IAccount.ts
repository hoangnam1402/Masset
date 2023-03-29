export default interface IAccount {
    id: string;
    token?: string;
    userName: string;
    role: string;
    isActive?: boolean;
    firstLogin?:boolean
    email?: string;
    phoneNumber?: string;
    error?:boolean
    message?:string
}
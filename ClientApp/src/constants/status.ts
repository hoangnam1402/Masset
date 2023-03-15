import IError from "../interfaces/IError";

export const Status = {
    Success: 1,
    Failed: 2,
}

export type SetStatusType = {
    status?: number;
    error?: IError;
};
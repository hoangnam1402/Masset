import { createSlice, PayloadAction } from "@reduxjs/toolkit";

import { SetStatusType } from "../../constants/status";
import IAccount from "../../interfaces/IAccount";
import IChangePassword from "../../interfaces/IChangePassword";
import IError from "../../interfaces/IError";
import ILoginModel from "../../interfaces/ILoginModel";
import request from "../../services/request";
import { getLocalStorage, removeLocalStorage, setLocalStorage } from "../../utils/localStorage";

type AuthState = {
    loading: boolean;
    isAuth: boolean,
    account?: IAccount;
    status?: number;
    error?: IError;
}

const token = getLocalStorage('token');

// mặc định
const initialState: AuthState = {
    isAuth: !!token,
    loading: false,
};

// init state of Admin
// const initialState: AuthState = {
//     isAuth: true,
//     loading: false,
//     account: {
//         id: "test",
//         userName: "admin",
//         role: "MANAGER",
//         isActive: true,
//         token: "abctoken",
//     }
// }

const AuthSlice = createSlice({
    name: 'auth',
    initialState,
    reducers: {
        setAccount: (state: AuthState, action: PayloadAction<IAccount>): AuthState => {
            const account = action.payload;
            if (account?.token) {
                setLocalStorage('token', account.token);
                request.setAuthentication(account.token);
            }

            return {
                ...state,
                // status: Status.Success,
                account,
                isAuth: true,
                loading: false,
            };
        },
        setStatus: (state: AuthState, action: PayloadAction<SetStatusType>) =>
        {
            const {status, error} = action.payload;

            return {
                ...state,
                status,
                error,
                loading: false,
            }
        },
        me: (state) => {
            if (token) {
                request.setAuthentication(token);
            }
        },
        login: (state: AuthState) => ({
            ...state,
            loading: true,
        }),
        changePassword: (state: AuthState, action: PayloadAction<IChangePassword>) => {
            return {
                ...state,
                loading: true,
            }
        },
        logout: (state: AuthState) => {

            removeLocalStorage('token');
            request.setAuthentication('')

            return {
                ...state,
                isAuth: false,
                account: undefined,
                status: undefined,
            };
        },
        cleanUp: (state) => ({
            ...state,
            loading: false,
            status: undefined,
            error: undefined,
        })
    }
});

export const {
    setAccount, login, setStatus, me, changePassword, logout, cleanUp
} = AuthSlice.actions;

export default AuthSlice.reducer;

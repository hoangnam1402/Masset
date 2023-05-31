import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import { SetStatusType } from "../../constants/status";
import IError from "../../interfaces/IError";
import IPagedModel from "../../interfaces/IPagedModel";
import IQueryModel from "../../interfaces/IQueryModel";
import IUserForm from "../../interfaces/User/IUserForm";
import IUser from "../../interfaces/User/IUser";

type UserState = {
  loading: boolean;
  users: IPagedModel<IUser> | null;
  userResult?: IUser;
  status?: number;
  error?: IError;
  deleteUser?: IUser;
};

const initialState: UserState = {
  loading: false,
  users: null,
  deleteUser: undefined,
};

export type CreateAction = {
  handleResult: Function,
  formValues: IUserForm,
}

export type DeleteAction = {
  handleResult: Function,
  formValues: IUser,
}

const UserSlice = createSlice({
  name: "User",
  initialState,
  reducers: {
    getUsers: (state, action: PayloadAction<IQueryModel>) => {
      return {
        ...state,
        loading: true,
      };
    },

    setUsers: (state, action: PayloadAction<IPagedModel<IUser>>): UserState => {
      const users = action.payload;
      if(state.userResult){
        users.items.unshift(state.userResult);
      }

      return {
          ...state,
          users,
          userResult: undefined,
          loading: false,
      };
    },

    deleteUser: (state, action: PayloadAction<CreateAction>) => {
      return {
        ...state,
        loading: true,
      };
    },

    setDeleteUser: ( state, action: PayloadAction<IUser>): UserState => {
      const deleteUser = action.payload

      return {
        ...state,
        deleteUser,
      }
    },

    updateUser: (state, action: PayloadAction<CreateAction>) => {
      return {
          ...state,
          loading: true,
      }
    },

    setUser: (state, action: PayloadAction<IUser>): UserState => {
      const userResult = action.payload;

      return {
          ...state,
          userResult,
          loading: false,
      }
    },

    setStatus: (state, action: PayloadAction<SetStatusType>): UserState => {
      const { status, error } = action.payload;

      return {
        ...state,
        status,
        error,
        loading: false,
      };
    },

    createUser: (state, action: PayloadAction<CreateAction>) => {
      return {
          ...state,
          loading: true,
      }
    },
  },
});

export const 
{ 
    setStatus, getUsers, setUser, setUsers, setDeleteUser, createUser,
    updateUser, deleteUser,
} = UserSlice.actions;

export default UserSlice.reducer;

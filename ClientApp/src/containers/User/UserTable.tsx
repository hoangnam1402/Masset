import React, { useState } from "react";
import { PencilFill, Trash3 } from "react-bootstrap-icons";
import ButtonIcon from "../../components/ButtonIcon";
import Table, { SortType } from "../../components/Table";
import IColumnOption from "../../interfaces/IColumnOption";
import IPagedModel from "../../interfaces/IPagedModel";
import { NotificationManager } from 'react-notifications';
import { useAppDispatch, useAppSelector } from "../../hooks/redux";
import { deleteUser } from "./reducer";
import DeleteModal from "../../components/DeleteModal";
import UserForm from "./UserForm";
import IUser from "../../interfaces/User/IUser";
import { ManagerUserTypeLabel, ManagerUserType, StaffUserTypeLabel, StaffUserType,
  AdminUserType, AdminUserTypeLabel } from "../../constants/UserConstants";

const columns: IColumnOption[] = [
  { columnName: "User Name", columnValue: "userName" },
  { columnName: "Email", columnValue: "email" },
  { columnName: "Role", columnValue: "role" },
  { columnName: "Phone", columnValue: "phoneNumber" },
  { columnName: "Action", columnValue: "" },
];

type Props = {
  users: IPagedModel<IUser> | null;
  handlePage: (page: number) => void;
  handleSort: (colValue: string) => void;
  sortState: SortType;
  deleteUsers?: IUser;
  handleLimit: (e: any) => void;
  limit: number;
};

const UserTable: React.FC<Props> = ({
  users,
  handlePage,
  handleSort,
  sortState,
  deleteUsers,
  handleLimit,
  limit,
}) => {
  const dispatch = useAppDispatch();
  const { account } = useAppSelector(state => state.authReducer);
  const [showConfirmDelete, setShowConfirmDelete] = useState(false);
  const [userDetail, setUserDetail] = useState(undefined as IUser | undefined);
  const [showEditForm, setShowEditForm] = useState(false);
    
  const handleResult = (result: boolean, message: string) => {
    if (result) {
      NotificationManager.success(
          `Delete Successful User ${message}`,
          `Delete Successful`,
          2000,
      );
      deleteUsers = undefined;
    } else {
      NotificationManager.error(message, 'Delete failed', 2000);
    }
  };

  const getUserRoleTypeName = (id: number | undefined) => {
		switch(id) {
			case AdminUserType:
				return AdminUserTypeLabel;
			case ManagerUserType:
				return ManagerUserTypeLabel;
			case StaffUserType:
				return StaffUserTypeLabel;
			default:
				return "";
		}
	};

  const handleCancleDelete = () => {
    setShowConfirmDelete(false);
  }
  
  const handleEdit = (a: IUser) => {
    setShowEditForm(true);
    setUserDetail(a)
  }

  const handleCloseEditForm = () => {
    setShowEditForm(false);
  }

  const handleDelete = (id: string) => {
    const a = users?.items.find((item) => item.id === id);

    if(a)
    {
      setShowConfirmDelete(true)
      setUserDetail(a)
    }
  }

  const handleAcceptDelete = () => {
    if(userDetail)
    {
      setShowConfirmDelete(false);
      dispatch(deleteUser({ handleResult, formValues: userDetail }));
    }
  }
  
  return (
    <>
      <Table
        columns={columns}
        handleSort={handleSort}
        sortState={sortState}
        handleLimit={handleLimit}
        limit={limit}
        page={{
          currentPage: users?.currentPage,
          totalPage: users?.totalPages,
          handleChange: handlePage,
        }}
      
      >
        {users?.items.map((data, index) => (
          <tr 
            key={index} 
            className=""
          >
            <td className="py-1 py-1-custome">{data.userName} </td>
            <td className="py-1 py-1-custome">{data.email}</td>
            <td className="py-1 py-1-custome">{getUserRoleTypeName(data.role)}</td>
            <td className="py-1 py-1-custome">{data.phoneNumber}</td>

            <td className="py-1 py-1-custome">
              <div className="row">
                <ButtonIcon onClick={() => handleEdit(data)} title="Edit" className="col-2"
                  disable={(account?.role === getUserRoleTypeName(data.role) && account.id !== data.id) ||
                    (account?.role === "Manager" && data.role !== 3 && account.id !== data.id) ||
                    (account?.role === "Staff" && account.id !== data.id) ? true : false}>
                  <PencilFill className="text-black" />
                </ButtonIcon>
                <ButtonIcon className="col-2" title="Delete" onClick={() => handleDelete(data.id)} 
                  disable={account?.role === getUserRoleTypeName(data.role) ||
                    (account?.role === "Manager" && data.role !== 3) ||
                    account?.role === "Staff" ? true : false}>
                  <Trash3 className="text-black" />
                </ButtonIcon>
              </div>
            </td>
          </tr>
        ))}
      </Table>
      <DeleteModal
        title="Are you sure"
        isShow={showConfirmDelete}
        onHide={handleCancleDelete}
      >
        <div>
          <div className="text-center">Do you want to delete this User?</div>
          <div className="text-center mt-3">
            <button
              className="btn btn-danger mr-3"
              onClick={handleAcceptDelete}
              type="button"
            >
              Delete
            </button>
            <button
              className="btn btn-outline-secondary"
              onClick={handleCancleDelete}
              type="button"
            >
              Cancel
            </button>
          </div>
        </div>
      </DeleteModal>
      
      { showEditForm && (
        <UserForm user={userDetail} handleClose={handleCloseEditForm} />
      )}
    </>
  );
};

export default UserTable;
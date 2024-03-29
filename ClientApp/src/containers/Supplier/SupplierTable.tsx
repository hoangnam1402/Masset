import React, { useState } from "react";
import { PencilFill, Trash3 } from "react-bootstrap-icons";
import ButtonIcon from "../../components/ButtonIcon";
import Table, { SortType } from "../../components/Table";
import IColumnOption from "../../interfaces/IColumnOption";
import IPagedModel from "../../interfaces/IPagedModel";
import { NotificationManager } from 'react-notifications';
import { useAppDispatch, useAppSelector } from "../../hooks/redux";
import { deleteSupplier } from "./reducer";
import DeleteModal from "../../components/DeleteModal";
import SupplierForm from "./SupplierForm";
import ISupplier from "../../interfaces/Supplier/ISupplier";

const columns: IColumnOption[] = [
  { columnName: "Name", columnValue: "name" },
  { columnName: "Email", columnValue: "email" },
  { columnName: "Phone", columnValue: "phone" },
  { columnName: "Address", columnValue: "address" },
  { columnName: "City", columnValue: "city" },
  { columnName: "Country", columnValue: "country" },
  { columnName: "Action", columnValue: "" },
];

type Props = {
  suppliers: IPagedModel<ISupplier> | null;
  handlePage: (page: number) => void;
  handleSort: (colValue: string) => void;
  sortState: SortType;
  deleteSuppliers?: ISupplier;
  handleLimit: (e: any) => void;
  limit: number;
};

const SupplierTable: React.FC<Props> = ({
  suppliers,
  handlePage,
  handleSort,
  sortState,
  deleteSuppliers,
  handleLimit,
  limit,
}) => {
  const dispatch = useAppDispatch();
  const { account } = useAppSelector((state) => state.authReducer);
  const [showConfirmDelete, setShowConfirmDelete] = useState(false);
  const [supplierDetail, setSupplierDetail] = useState(undefined as ISupplier | undefined);
  const [showEditForm, setShowEditForm] = useState(false);

  const handleResult = (result: boolean, message: string) => {
    if (result) {
      NotificationManager.success(
          `Delete Successful Supplier ${message}`,
          `Delete Successful`,
          2000,
      );
      deleteSuppliers = undefined;
    } else {
      NotificationManager.error(message, 'Delete failed', 2000);
    }
  };

  const handleCancleDelete = () => {
    setShowConfirmDelete(false);
  }
  
  const handleEdit = (a: ISupplier) => {
    setShowEditForm(true);
    setSupplierDetail(a)
  }

  const handleCloseEditForm = () => {
    setShowEditForm(false);
  }

  const handleDelete = (id: number) => {
    const a = suppliers?.items.find((item) => item.id == id);

    if(a)
    {
      setShowConfirmDelete(true)
      setSupplierDetail(a)
    }
  }

  const handleAcceptDelete = () => {
    if(supplierDetail)
    {
      setShowConfirmDelete(false);
      dispatch(deleteSupplier({ handleResult, formValues: supplierDetail }));
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
          currentPage: suppliers?.currentPage,
          totalPage: suppliers?.totalPages,
          handleChange: handlePage,
        }}
      
      >
        {suppliers?.items.map((data, index) => (
          <tr 
            key={index} 
            className=""
          >
            <td className="py-1 py-1-custome">{data.name} </td>
            <td className="py-1 py-1-custome">{data.email}</td>
            <td className="py-1 py-1-custome">{data.phone}</td>
            <td className="py-1 py-1-custome">{data.address}</td>
            <td className="py-1 py-1-custome">{data.city}</td>
            <td className="py-1 py-1-custome">{data.country}</td>

            <td className="py-1 py-1-custome">
              <div className="row">
                <ButtonIcon onClick={() => handleEdit(data)} title="Edit" className="col-6">
                  <PencilFill className="text-black" />
                </ButtonIcon>
                <ButtonIcon className="col-6" title="Delete" onClick={() => handleDelete(data.id)} disable={account?.role == "Staff" ? true : false}>
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
          <div className="text-center">Do you want to delete this Supplier?</div>
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
        <SupplierForm supplier={supplierDetail} handleClose={handleCloseEditForm} />
      )}
    </>
  );
};

export default SupplierTable;
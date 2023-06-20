import React, { useState } from "react";
import { PencilFill, Trash3 } from "react-bootstrap-icons";
import ButtonIcon from "../../components/ButtonIcon";
import Table, { SortType } from "../../components/Table";
import IColumnOption from "../../interfaces/IColumnOption";
import IPagedModel from "../../interfaces/IPagedModel";
import { NotificationManager } from 'react-notifications';
import { useAppDispatch, useAppSelector } from "../../hooks/redux";
import { deleteBrand } from "./reducer";
import DeleteModal from "../../components/DeleteModal";
import BrandForm from "./BrandForm";
import IBrand from "../../interfaces/Brand/IBrand";

const columns: IColumnOption[] = [
  { columnName: "Name", columnValue: "name" },
  { columnName: "Description", columnValue: "description" },
  { columnName: "Action", columnValue: "" },
];

type Props = {
  brands: IPagedModel<IBrand> | null;
  handlePage: (page: number) => void;
  handleSort: (colValue: string) => void;
  sortState: SortType;
  deleteBrands?: IBrand;
  handleLimit: (e: any) => void;
  limit: number;
};

const BrandTable: React.FC<Props> = ({
  brands,
  handlePage,
  handleSort,
  sortState,
  deleteBrands,
  handleLimit,
  limit,
}) => {
  const dispatch = useAppDispatch();
  const { account } = useAppSelector((state) => state.authReducer);
  const [showConfirmDelete, setShowConfirmDelete] = useState(false);
  const [brandDetail, setBrandDetail] = useState(undefined as IBrand | undefined);
  const [showEditForm, setShowEditForm] = useState(false);

  const handleResult = (result: boolean, message: string) => {
    if (result) {
      NotificationManager.success(
          `Delete Successful Brand ${message}`,
          `Delete Successful`,
          2000,
      );
      deleteBrands = undefined;
    } else {
      NotificationManager.error(message, 'Delete failed', 2000);
    }
  };

  const handleCancleDelete = () => {
    setShowConfirmDelete(false);
  }
  
  const handleEdit = (a: IBrand) => {
    setShowEditForm(true);
    setBrandDetail(a)
  }

  const handleCloseEditForm = () => {
    setShowEditForm(false);
  }

  const handleDelete = (id: number) => {
    const a = brands?.items.find((item) => item.id === id);

    if(a)
    {
      setShowConfirmDelete(true)
      setBrandDetail(a)
    }
  }

  const handleAcceptDelete = () => {
    if(brandDetail)
    {
      setShowConfirmDelete(false);
      dispatch(deleteBrand({ handleResult, formValues: brandDetail }));
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
          currentPage: brands?.currentPage,
          totalPage: brands?.totalPages,
          handleChange: handlePage,
        }}
      >
        {brands?.items.map((data, index) => (
          <tr 
            key={index} 
            className=""
          >
            <td className="py-1 py-1-custome">{data.name} </td>
            <td className="py-1 py-1-custome">{data.description}</td>

            <td className="py-1 py-1-custome">
              <div className="row">
                <ButtonIcon onClick={() => handleEdit(data)} title="Edit" className="col-2">
                  <PencilFill className="text-black" />
                </ButtonIcon>
                <ButtonIcon className="col-2" title="Delete" onClick={() => handleDelete(data.id)} disable={account?.role === "Staff" ? true : false}>
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
          <div className="text-center">Do you want to delete this Brand?</div>
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
        <BrandForm brand={brandDetail} handleClose={handleCloseEditForm} />
      )}
    </>
  );
};

export default BrandTable;
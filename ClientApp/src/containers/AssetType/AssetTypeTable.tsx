import React, { useState } from "react";
import { PencilFill, Trash3 } from "react-bootstrap-icons";
import ButtonIcon from "../../components/ButtonIcon";
import Table, { SortType } from "../../components/Table";
import IColumnOption from "../../interfaces/IColumnOption";
import IPagedModel from "../../interfaces/IPagedModel";
import { NotificationManager } from 'react-notifications';
import { useAppDispatch, useAppSelector } from "../../hooks/redux";
import { deleteAssetType } from "./reducer";
import DeleteModal from "../../components/DeleteModal";
import AssetTypeForm from "./AssetTypeForm";
import IType from "../../interfaces/Type/IType";

const columns: IColumnOption[] = [
  { columnName: "Name", columnValue: "name" },
  { columnName: "Description", columnValue: "description" },
  { columnName: "Action", columnValue: "" },
];

type Props = {
  assetTypes: IPagedModel<IType> | null;
  handlePage: (page: number) => void;
  handleSort: (colValue: string) => void;
  sortState: SortType;
  deleteType?: IType;
  handleLimit: (e: any) => void;
  limit: number;
};

const AssetTypeTable: React.FC<Props> = ({
  assetTypes,
  handlePage,
  handleSort,
  sortState,
  deleteType,
  handleLimit,
  limit,
}) => {
  const dispatch = useAppDispatch();
  const { account } = useAppSelector((state) => state.authReducer);
  const [showConfirmDelete, setShowConfirmDelete] = useState(false);
  const [assetTypeDetail, setAssetTypeDetail] = useState(undefined as IType | undefined);
  const [showEditForm, setShowEditForm] = useState(false);

  const handleResult = (result: boolean, message: string) => {
    if (result) {
      NotificationManager.success(
          `Delete Successful Asset Type ${message}`,
          `Delete Successful`,
          2000,
      );
      deleteType = undefined;
    } else {
      NotificationManager.error(message, 'Delete failed', 2000);
    }
  };

  const handleCancleDelete = () => {
    setShowConfirmDelete(false);
  }
  
  const handleEdit = (assetType: IType) => {
    setShowEditForm(true);
    setAssetTypeDetail(assetType)
  }

  const handleCloseEditForm = () => {
    setShowEditForm(false);
  }

  const handleDelete = (id: number) => {
    const assetType = assetTypes?.items.find((item) => item.id === id);

    if(assetType)
    {
      setShowConfirmDelete(true)
      setAssetTypeDetail(assetType)
    }
  }

  const handleAcceptDelete = () => {
    if(assetTypeDetail)
    {
      setShowConfirmDelete(false);
      dispatch(deleteAssetType({ handleResult, formValues: assetTypeDetail }));
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
          currentPage: assetTypes?.currentPage,
          totalPage: assetTypes?.totalPages,
          handleChange: handlePage,
        }}
      
      >
        {assetTypes?.items.map((data, index) => (
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
          <div className="text-center">Do you want to delete this Asset Types?</div>
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
        <AssetTypeForm assetType={assetTypeDetail} handleClose={handleCloseEditForm} />
      )}
    </>
  );
};

export default AssetTypeTable;
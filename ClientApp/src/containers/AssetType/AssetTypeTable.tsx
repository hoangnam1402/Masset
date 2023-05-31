import React, { useEffect, useState } from "react";
import { PencilFill, XCircle } from "react-bootstrap-icons";
import ButtonIcon from "../../components/ButtonIcon";
import Table, { SortType } from "../../components/Table";
import IColumnOption from "../../interfaces/IColumnOption";
import IPagedModel from "../../interfaces/IPagedModel";
import { NotificationManager } from 'react-notifications';
import { useAppDispatch } from "../../hooks/redux";
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
  deleteType?: IType
};

const AssetTypeTable: React.FC<Props> = ({
  assetTypes,
  handlePage,
  handleSort,
  sortState,
  deleteType,
}) => {
  const dispatch = useAppDispatch();

  const [showConfirmDelete, setShowConfirmDelete] = useState(false);
  const [assetTypeDetail, setAssetTypeDetail] = useState(undefined as IType | undefined);
  const [showEditForm, setShowEditForm] = useState(false);

  const handleResult = (result: boolean, message: string) => {
    if (result) {
      NotificationManager.success(
          `Delete Successful Asset Type ${message}`,
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
    const assetType = assetTypes?.items.find((item) => item.id == id);

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
            <td className="py-1">{data.name} </td>
            <td className="py-1">{data.description}</td>

            <td className="d-flex py-1">
              <ButtonIcon onClick={() => handleEdit(data)}>
                <PencilFill className="text-black mx-2" />
              </ButtonIcon>
              <ButtonIcon onClick={() => handleDelete(data.id)}>
                <XCircle className="text-danger mx-2" />
              </ButtonIcon>
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
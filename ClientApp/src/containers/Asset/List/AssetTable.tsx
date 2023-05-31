import React, { useState } from "react";
import { Check, FileEarmarkText, PencilFill, Trash3 } from "react-bootstrap-icons";
import { useNavigate } from "react-router";
import ButtonIcon from "../../../components/ButtonIcon";

import Table, { SortType } from "../../../components/Table";
import IColumnOption from "../../../interfaces/IColumnOption";
import IPagedModel from "../../../interfaces/IPagedModel";
import { NotificationManager } from 'react-notifications';

import { ASSET_ID } from "../../../constants/pages";
import IAsset from "../../../interfaces/Asset/IAsset";
import { useAppDispatch } from "../../../hooks/redux";
import { deleteAssets } from "../reducer";
import DeleteModal from "../../../components/DeleteModal";
import AssetForm from "./AssetForm";
import { Modal } from "react-bootstrap";
import CheckAssetForm from "./CheckAssetForm";

const columns: IColumnOption[] = [
  { columnName: "Asset Tag", columnValue: "tag" },
  { columnName: "Asset Name", columnValue: "name" },
  { columnName: "Type", columnValue: "type" },
  { columnName: "Brand", columnValue: "brand" },
  { columnName: "Location", columnValue: "location" },
];

type Props = {
  assets: IPagedModel<IAsset> | null;
  handlePage: (page: number) => void;
  handleSort: (colValue: string) => void;
  sortState: SortType;
  deleteAsset?: IAsset
};

const AssetTable: React.FC<Props> = ({
  assets,
  handlePage,
  handleSort,
  sortState,
  deleteAsset,
}) => {
  const dispatch = useAppDispatch();

  const [showConfirmDelete, setShowConfirmDelete] = useState(false);
  const [assetDetail, setAssetDetail] = useState(undefined as IAsset | undefined);
  const [showEditForm, setShowEditForm] = useState(false);
  const [showCheckingForm, setShowCheckingForm] = useState(false);
  const [isCheckOut, setIsCheckOut] = useState(false);
  const [showDropdown, setShowDropdown] = useState(false);

  const handleResult = (result: boolean, message: string) => {
    if (result) {
      NotificationManager.success(
          `Delete Successful Asset ${message}`,
          2000,
      );
      deleteAsset = undefined;
    } else {
      NotificationManager.error(message, 'Delete failed', 2000);
    }
  };

  const handleCancleDelete = () => {
    setShowConfirmDelete(false);
  }
  
	const history = useNavigate();
  const handleShowDetail = () => {
    if (assetDetail)
      history(ASSET_ID(assetDetail.id));
  };

  const handleEdit = () => {
    setShowEditForm(true);
    setShowDropdown(false);
  }

  const handleCloseEditForm = () => {
    setShowEditForm(false);
  }

  const handleDelete = () => {
    setShowConfirmDelete(true);
    setShowDropdown(false);
  }

  const handleAcceptDelete = () => {
    if(assetDetail)
    {
      setShowConfirmDelete(false);
      dispatch(deleteAssets({ handleResult, formValues: assetDetail }));
    }
  }

  const handleShowCheckingForm = () => {
    setShowCheckingForm(true);
    setShowDropdown(false);
  }

  const handleCloseCheckingForm = () => {
    setShowCheckingForm(false);
  }

  const handleCloseDropdown = () => {
    setShowDropdown(false);
  }

  const handleShowDropdown = (asset: IAsset) => {
    setShowDropdown(true);
    setIsCheckOut(!asset.isCheckOut);
    setAssetDetail(asset);
  }

  return (
    <>
      <Table
        columns={columns}
        handleSort={handleSort}
        sortState={sortState}
        page={{
          currentPage: assets?.currentPage,
          totalPage: assets?.totalPages,
          handleChange: handlePage,
        }}
      
      >
        {assets?.items.map((data, index) => (
          <tr 
            key={index} 
            className=""
          >
            <td className="py-1">{data.tag}</td>
            <td className="py-1">{data.name} </td>
            <td className="py-1">{data.type.name}</td>
            <td className="py-1">{data.brand.name}</td>
            <td className="py-1">{data.location.name}</td>

            <td className="d-flex py-1">
              <button
                className="btn btn-outline-secondary"
                onClick={() => handleShowDropdown(data)}
                type="button"
              >
                ...
              </button>
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
          <div className="text-center">Do you want to delete this Asset?</div>
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
        <AssetForm asset={assetDetail} handleClose={handleCloseEditForm} />
      )}

      { showCheckingForm && assetDetail && (
        <CheckAssetForm asset={assetDetail} handleClose={handleCloseCheckingForm} isCheckOut={isCheckOut} />
      )}

      { showDropdown &&
      <Modal
        show={true}
        onHide={handleCloseDropdown}
        size='sm'
        dialogClassName="containerModalErr2" 
      >
        <Modal.Body >
          <ButtonIcon onClick={() => handleShowCheckingForm()}>
            <Check className="text-black" /> {isCheckOut ? "Check Out" : "Check In"}
          </ButtonIcon>

          <hr/>

          <ButtonIcon onClick={() => handleShowDetail()}>
            <FileEarmarkText className="text-black" /> Detail
          </ButtonIcon>
          <ButtonIcon onClick={() => handleEdit()}>
            <PencilFill className="text-black" /> Edit
          </ButtonIcon>
          <ButtonIcon onClick={() => handleDelete()}>
            <Trash3 className="text-black" /> Delete
          </ButtonIcon>
        </Modal.Body>
      </Modal>}

    </>
  );
};

export default AssetTable;
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
  { columnName: "Picture", columnValue: "" },
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
  deleteAsset?: IAsset;
  handleLimit: (e: any) => void;
  limit: number;
};

const AssetTable: React.FC<Props> = ({
  assets,
  handlePage,
  handleSort,
  sortState,
  deleteAsset,
  handleLimit,
  limit,
}) => {
  const dispatch = useAppDispatch();

  const [showConfirmDelete, setShowConfirmDelete] = useState(false);
  const [assetDetail, setAssetDetail] = useState(undefined as IAsset | undefined);
  const [showEditForm, setShowEditForm] = useState(false);
  const [showCheckingForm, setShowCheckingForm] = useState(false);
  const [isCheckOut, setIsCheckOut] = useState(false);

  const handleResult = (result: boolean, message: string) => {
    if (result) {
      NotificationManager.success(
          `Delete Successful Asset ${message}`,
          `Delete Successful`,
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
  const handleShowDetail = (id: number) => {
    history(ASSET_ID(id));
  };

  const handleEdit = (asset: IAsset) => {
    setShowEditForm(true);
    setAssetDetail(asset);
  }

  const handleCloseEditForm = () => {
    setShowEditForm(false);
  }

  const handleDelete = (id: number) => {
    const asset = assets?.items.find((item) => item.id == id);

    if(asset)
    {
      setShowConfirmDelete(true)
      setAssetDetail(asset)
    }
  }

  const handleAcceptDelete = () => {
    if(assetDetail)
    {
      setShowConfirmDelete(false);
      dispatch(deleteAssets({ handleResult, formValues: assetDetail }));
    }
  }

  const handleShowCheckingForm = (asset: IAsset) => {
    setShowCheckingForm(true);
    setAssetDetail(asset);
    setIsCheckOut(!asset.isCheckOut);
  }

  const handleCloseCheckingForm = () => {
    setShowCheckingForm(false);
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
            <td className="py-1 py-1-custome">
              {data.image && <img id="image" src={`data:image/jpeg;base64,${data?.image}`} alt={data?.name} />}  
            </td>
            <td className="py-1 py-1-custome">{data.tag}</td>
            <td className="py-1 py-1-custome">{data.name} </td>
            <td className="py-1 py-1-custome">{data.type.name}</td>
            <td className="py-1 py-1-custome">{data.brand.name}</td>
            <td className="py-1 py-1-custome">{data.location.name}</td>

            <td className="d-flex py-1">
              <ButtonIcon onClick={() => handleShowCheckingForm(data)} title={data.isCheckOut ? "Check In" : "Check Out"}>
                <Check className="text-black mx-2" />
              </ButtonIcon>

              <hr/>

              <ButtonIcon onClick={() => handleShowDetail(data.id)}>
                <FileEarmarkText className="text-black mx-2" />
              </ButtonIcon>
              <ButtonIcon onClick={() => handleEdit(data)}>
                <PencilFill className="text-black mx-2" />
              </ButtonIcon>
              <ButtonIcon onClick={() => handleDelete(data.id)}>
                <Trash3 className="text-black mx-2" />
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
    </>
  );
};

export default AssetTable;
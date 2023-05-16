import React, { ReactElement, useEffect, useState } from "react";
import { PencilFill, XCircle } from "react-bootstrap-icons";
import { useNavigate } from "react-router";
import ButtonIcon from "../../../components/ButtonIcon";

import Table, { SortType } from "../../../components/Table";
import IColumnOption from "../../../interfaces/IColumnOption";
import IPagedModel from "../../../interfaces/IPagedModel";
import { NotificationManager } from 'react-notifications';

import { ASSET_ID } from "../../../constants/pages";
import IAsset from "../../../interfaces/Asset/IAsset";
import { AssetState } from "../../../constants/States";
import Info from "../Info";
import { useAppDispatch, useAppSelector } from "../../../hooks/redux";
import { deleteAssets, setNewAsset } from "../reducer";
import DeleteModal from "../../../components/DeleteModal";

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
  fetchData: Function;
  deleteAsset?: IAsset
};

const AssetTable: React.FC<Props> = ({
  assets,
  handlePage,
  handleSort,
  sortState,
  fetchData,
  deleteAsset,
}) => {
  const dispatch = useAppDispatch();

  const [showConfirmDelete, setShowConfirmDelete] = useState(false);
  const [assetDetail, setAssetDetail] = useState(null as IAsset | null);

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
  const [showDetail, setShowDetail] = useState(false);
  const handleShowInfo = (tag: string) => {
    const asset = assets?.items.find((item) => item.tag == tag);
    console.log(asset);
    if (asset) {
      setAssetDetail(asset);
      setShowDetail(true);
    }
  };

  const handleCloseDetail = () => {
    setShowDetail(false);
  }
  
	const history = useNavigate();
  const handleEdit = (id: number) => {
      history(ASSET_ID(id));
  };

  const handleDelete = (tag: string) => {
    const asset = assets?.items.find((item) => item.tag == tag);

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
  
  useEffect( () => () => {dispatch(setNewAsset(undefined))}, [] );

  const {status , newAsset} = useAppSelector((state) => state.assetReducer);
  function NewCreatedContent(): ReactElement{
    return (
      <tr
      >
        <td className="py-1">{newAsset!.tag}</td>
        <td className="py-1">{newAsset!.name}</td>
        <td className="py-1">{newAsset!.type.name}</td>
        <td className="py-1">{newAsset!.brand.name}</td>
        <td className="py-1">{newAsset!.location.name}</td>

        <td className="d-flex py-1">
          <ButtonIcon>
            <PencilFill className="text-black" />
          </ButtonIcon>
          <ButtonIcon>
            <XCircle className="text-danger mx-2" />
          </ButtonIcon>
        </td>
      </tr>
    );
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
         {newAsset && NewCreatedContent()}
        {assets?.items.map((data, index) => (
          <tr 
            key={index} 
            className=""
            onClick={() => handleShowInfo(data.tag)}
          >
            <td className="py-1">{data.tag}</td>
            <td className="py-1">{data.name} </td>
            <td className="py-1">{data.type.name}</td>
            <td className="py-1">{data.brand.name}</td>
            <td className="py-1">{data.location.name}</td>

            <td className="d-flex py-1">
              <ButtonIcon onClick={() => handleEdit(data.id)}>
                <PencilFill className="text-black" />
              </ButtonIcon>
              <ButtonIcon onClick={() => handleDelete(data.tag)}>
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

    </>
  );
};

export default AssetTable;
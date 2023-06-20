import React, { useState } from "react";
import { PencilFill, Trash3 } from "react-bootstrap-icons";
import ButtonIcon from "../../components/ButtonIcon";
import Table, { SortType } from "../../components/Table";
import IColumnOption from "../../interfaces/IColumnOption";
import IPagedModel from "../../interfaces/IPagedModel";
import { NotificationManager } from 'react-notifications';
import { useAppDispatch, useAppSelector } from "../../hooks/redux";
import { deleteDepreciation } from "./reducer";
import DeleteModal from "../../components/DeleteModal";
import IDepreciation from "../../interfaces/Depreciation/IDepreciation";
import DepreciationForm from "./DepreciationForm";
import { ComponentLabel, Component, Asset, AssetLabel } from "../../constants/depreciationCategory";

const columns: IColumnOption[] = [
  { columnName: "Name", columnValue: "name" },
  { columnName: "Cost", columnValue: "cost" },
  { columnName: "Period(Month)", columnValue: "period" },
  { columnName: "Category", columnValue: "type" },
  { columnName: "Value", columnValue: "value" },
  { columnName: "Action", columnValue: "" },
];

type Props = {
  depreciations: IPagedModel<IDepreciation> | null;
  handlePage: (page: number) => void;
  handleSort: (colValue: string) => void;
  sortState: SortType;
  deleteDepr?: IDepreciation;
  handleLimit: (e: any) => void;
  limit: number;
};

const DepreciationTable: React.FC<Props> = ({
  depreciations,
  handlePage,
  handleSort,
  sortState,
  deleteDepr,
  handleLimit,
  limit,
}) => {
  const dispatch = useAppDispatch();
  const { account } = useAppSelector((state) => state.authReducer);
  const [showConfirmDelete, setShowConfirmDelete] = useState(false);
  const [depreciationDetail, setDepreciationDetail] = useState(undefined as IDepreciation | undefined);
  const [showEditForm, setShowEditForm] = useState(false);

  const handleResult = (result: boolean, message: string) => {
    if (result) {
      NotificationManager.success(
          `Delete Successful Depreciation ${message}`,
          `Delete Successful`,
          2000,
      );
      deleteDepr = undefined;
    } else {
      NotificationManager.error(message, 'Delete failed', 2000);
    }
  };

  const handleCancleDelete = () => {
    setShowConfirmDelete(false);
  }
  
  const handleEdit = (depreciation: IDepreciation) => {
    setShowEditForm(true);
    setDepreciationDetail(depreciation)
  }

  const handleCloseEditForm = () => {
    setShowEditForm(false);
  }

  const getCategoryName = (id: number | undefined) => {
		switch(id) {
			case Component:
				return ComponentLabel;
			case Asset:
				return AssetLabel;
			default:
				return "Nan";
		}
	};

  const handleDelete = (id: number) => {
    const depreciation = depreciations?.items.find((item) => item.id === id);

    if(depreciation)
    {
      setShowConfirmDelete(true)
      setDepreciationDetail(depreciation)
    }
  }

  const handleAcceptDelete = () => {
    if(depreciationDetail)
    {
      setShowConfirmDelete(false);
      dispatch(deleteDepreciation({ handleResult, formValues: depreciationDetail }));
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
          currentPage: depreciations?.currentPage,
          totalPage: depreciations?.totalPages,
          handleChange: handlePage,
        }}
      
      >
        {depreciations?.items.map((data, index) => (
          <tr 
            key={index} 
            className=""
          >
            <td className="py-1 py-1-custome">{data.category === 1 ? data.asset.name : data.component.name} </td>
            <td className="py-1 py-1-custome">{data.category === 1 ? data.asset.cost : data.component.cost}</td>
            <td className="py-1 py-1-custome">{data.period}</td>
            <td className="py-1 py-1-custome">{getCategoryName(data.category)}</td>
            <td className="py-1 py-1-custome">{data.value}</td>

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
          <div className="text-center">Do you want to delete this Depreciation?</div>
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
        <DepreciationForm depreciation={depreciationDetail} handleClose={handleCloseEditForm} />
      )}
    </>
  );
};

export default DepreciationTable;
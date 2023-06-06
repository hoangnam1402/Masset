import React, { useEffect, useState } from "react";
import { PencilFill, XCircle } from "react-bootstrap-icons";
import ButtonIcon from "../../components/ButtonIcon";
import Table, { SortType } from "../../components/Table";
import IColumnOption from "../../interfaces/IColumnOption";
import IPagedModel from "../../interfaces/IPagedModel";
import { NotificationManager } from 'react-notifications';
import { useAppDispatch } from "../../hooks/redux";
import { deleteLocation } from "./reducer";
import DeleteModal from "../../components/DeleteModal";
import LocationForm from "./LocationForm";
import ILocation from "../../interfaces/Location/ILocation";

const columns: IColumnOption[] = [
  { columnName: "Name", columnValue: "name" },
  { columnName: "Description", columnValue: "description" },
  { columnName: "Action", columnValue: "" },
];

type Props = {
  locations: IPagedModel<ILocation> | null;
  handlePage: (page: number) => void;
  handleSort: (colValue: string) => void;
  sortState: SortType;
  deleteLocations?: ILocation;
  handleLimit: (e: any) => void;
  limit: number;
};

const LocationTable: React.FC<Props> = ({
  locations,
  handlePage,
  handleSort,
  sortState,
  deleteLocations,
  handleLimit,
  limit,
}) => {
  const dispatch = useAppDispatch();

  const [showConfirmDelete, setShowConfirmDelete] = useState(false);
  const [locationDetail, setLocationDetail] = useState(undefined as ILocation | undefined);
  const [showEditForm, setShowEditForm] = useState(false);

  const handleResult = (result: boolean, message: string) => {
    if (result) {
      NotificationManager.success(
          `Delete Successful Location ${message}`,
          `Delete Successful`,
          2000,
      );
      deleteLocations = undefined;
    } else {
      NotificationManager.error(message, 'Delete failed', 2000);
    }
  };

  const handleCancleDelete = () => {
    setShowConfirmDelete(false);
  }
  
  const handleEdit = (a: ILocation) => {
    setShowEditForm(true);
    setLocationDetail(a)
  }

  const handleCloseEditForm = () => {
    setShowEditForm(false);
  }

  const handleDelete = (id: number) => {
    const a = locations?.items.find((item) => item.id == id);

    if(a)
    {
      setShowConfirmDelete(true)
      setLocationDetail(a)
    }
  }

  const handleAcceptDelete = () => {
    if(locationDetail)
    {
      setShowConfirmDelete(false);
      dispatch(deleteLocation({ handleResult, formValues: locationDetail }));
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
          currentPage: locations?.currentPage,
          totalPage: locations?.totalPages,
          handleChange: handlePage,
        }}
      
      >
        {locations?.items.map((data, index) => (
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
          <div className="text-center">Do you want to delete this Location?</div>
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
        <LocationForm location={locationDetail} handleClose={handleCloseEditForm} />
      )}
    </>
  );
};

export default LocationTable;
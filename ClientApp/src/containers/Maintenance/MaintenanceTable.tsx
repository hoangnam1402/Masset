import React, { useEffect, useState } from "react";
import { PencilFill, XCircle } from "react-bootstrap-icons";
import ButtonIcon from "../../components/ButtonIcon";
import Table, { SortType } from "../../components/Table";
import IColumnOption from "../../interfaces/IColumnOption";
import IPagedModel from "../../interfaces/IPagedModel";
import { NotificationManager } from 'react-notifications';
import { useAppDispatch } from "../../hooks/redux";
import { deleteMaintenance } from "./reducer";
import DeleteModal from "../../components/DeleteModal";
import IMaintenance from "../../interfaces/Maintenance/IMaintenance";
import MaintenanceForm from "./MaintenanceForm";
import { TypeMaintenance, TypeCalibration, TypeCalibrationLabel, TypeHardwareSupport, TypeNull,
  TypeHardwareSupportLabel, TypeMaintenanceLabel, TypeRepair, TypeRepairLabel, TypeTesting,
  TypeSoftwareSupport, TypeSoftwareSupportLabel, TypeTestingLabel, TypeUpgrade, TypeUpgradeLabel,
} from "../../constants/maintenanceConstants";

const columns: IColumnOption[] = [
  { columnName: "Asset tag", columnValue: "tag" },
  { columnName: "Asset", columnValue: "name" },
  { columnName: "Supplier", columnValue: "supplier" },
  { columnName: "Type", columnValue: "type" },
  { columnName: "Start date", columnValue: "startDate" },
  { columnName: "End date", columnValue: "endDate" },
  { columnName: "Action", columnValue: "" },
];

type Props = {
  maintenances: IPagedModel<IMaintenance> | null;
  handlePage: (page: number) => void;
  handleSort: (colValue: string) => void;
  sortState: SortType;
  deleteMainten?: IMaintenance
};

const MaintenanceTable: React.FC<Props> = ({
  maintenances,
  handlePage,
  handleSort,
  sortState,
  deleteMainten,
}) => {
  const dispatch = useAppDispatch();

  const [showConfirmDelete, setShowConfirmDelete] = useState(false);
  const [maintenanceDetail, setMaintenanceDetail] = useState(undefined as IMaintenance | undefined);
  const [showEditForm, setShowEditForm] = useState(false);

  const handleResult = (result: boolean, message: string) => {
    if (result) {
      NotificationManager.success(
          `Delete Successful Maintenance ${message}`,
          2000,
      );
      deleteMainten = undefined;
    } else {
      NotificationManager.error(message, 'Delete failed', 2000);
    }
  };

  const getMaintenanceTypeName = (id: number | undefined) => {
		switch(id) {
			case TypeMaintenance:
				return TypeMaintenanceLabel;
			case TypeRepair:
				return TypeRepairLabel;
			case TypeUpgrade:
				return TypeUpgradeLabel;
			case TypeTesting:
				return TypeTestingLabel;
      case TypeCalibration:
        return TypeCalibrationLabel;
      case TypeSoftwareSupport:
        return TypeSoftwareSupportLabel;
      case TypeHardwareSupport:
        return TypeHardwareSupportLabel;
			default:
				return TypeNull;
		}
	};

  const handleCancleDelete = () => {
    setShowConfirmDelete(false);
  }
  
  const handleEdit = (maintenance: IMaintenance) => {
    setShowEditForm(true);
    setMaintenanceDetail(maintenance)
  }

  const handleCloseEditForm = () => {
    setShowEditForm(false);
  }


  const handleDelete = (id: number) => {
    const maintenance = maintenances?.items.find((item) => item.id == id);

    if(maintenance)
    {
      setShowConfirmDelete(true)
      setMaintenanceDetail(maintenance)
    }
  }

  const handleAcceptDelete = () => {
    if(maintenanceDetail)
    {
      setShowConfirmDelete(false);
      dispatch(deleteMaintenance({ handleResult, formValues: maintenanceDetail }));
    }
  }

  const handleDay = (day: Date) => {
    const customDay = new Date(day).toLocaleDateString();
    return customDay
  }
  
  return (
    <>
      <Table
        columns={columns}
        handleSort={handleSort}
        sortState={sortState}
        page={{
          currentPage: maintenances?.currentPage,
          totalPage: maintenances?.totalPages,
          handleChange: handlePage,
        }}
      
      >
        {maintenances?.items.map((data, index) => (
          <tr 
            key={index} 
            className=""
          >
            <td className="py-1">{data.asset.tag} </td>
            <td className="py-1">{data.asset.name}</td>
            <td className="py-1">{data.supplier.name}</td>
            <td className="py-1">{getMaintenanceTypeName(data.type)}</td>
            <td className="py-1">{handleDay(data.startDate)}</td>
            <td className="py-1">{handleDay(data.endDate)}</td>

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
          <div className="text-center">Do you want to delete this Maintenance?</div>
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
        <MaintenanceForm maintenance={maintenanceDetail} handleClose={handleCloseEditForm} />
      )}
    </>
  );
};

export default MaintenanceTable;
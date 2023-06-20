import React, { useState } from "react";
import { Check, FileEarmarkText, PencilFill, Trash3 } from "react-bootstrap-icons";
import { useNavigate } from "react-router";
import ButtonIcon from "../../../components/ButtonIcon";
import Table, { SortType } from "../../../components/Table";
import IColumnOption from "../../../interfaces/IColumnOption";
import IPagedModel from "../../../interfaces/IPagedModel";
import { NotificationManager } from 'react-notifications';
import { COMPONENT_ID } from "../../../constants/pages";
import { useAppDispatch, useAppSelector } from "../../../hooks/redux";
import { deleteComponent } from "../reducer";
import DeleteModal from "../../../components/DeleteModal";
import ComponentForm from "./ComponentForm";
import IComponent from "../../../interfaces/Component/IComponent";
import CheckComponentForm from "../CheckComponentForm";

const columns: IColumnOption[] = [
  { columnName: "Name", columnValue: "name" },
  { columnName: "Type", columnValue: "type" },
  { columnName: "Brand", columnValue: "brand" },
  { columnName: "Quantity", columnValue: "quantity" },
  { columnName: "Available Quantity", columnValue: "availableQuantity" },
  { columnName: "Action", columnValue: "" },
];

type Props = {
  components: IPagedModel<IComponent> | null;
  handlePage: (page: number) => void;
  handleSort: (colValue: string) => void;
  sortState: SortType;
  deleteComp?: IComponent;
  handleLimit: (e: any) => void;
  limit: number;
};

const ComponentTable: React.FC<Props> = ({
  components,
  handlePage,
  handleSort,
  sortState,
  deleteComp,
  handleLimit,
  limit,
}) => {
  const dispatch = useAppDispatch();
  const { account } = useAppSelector((state) => state.authReducer);
  const [showConfirmDelete, setShowConfirmDelete] = useState(false);
  const [componentDetail, setComponentDetail] = useState(undefined as IComponent | undefined);
  const [showEditForm, setShowEditForm] = useState(false);
  const [showCheckingForm, setShowCheckingForm] = useState(false);

  const handleResult = (result: boolean, message: string) => {
    if (result) {
      NotificationManager.success(
          `Delete Successful Component ${message}`,
          `Delete Successful`,
          2000,
      );
      deleteComp = undefined;
    } else {
      NotificationManager.error(message, 'Delete failed', 2000);
    }
  };

  const handleCancleDelete = () => {
    setShowConfirmDelete(false);
  }
  
	const history = useNavigate();
  const handleShowDetail = (id: number) => {
    history(COMPONENT_ID(id));
  };

  const handleEdit = (component: IComponent) => {
    setShowEditForm(true);
    setComponentDetail(component)
  }

  const handleCloseEditForm = () => {
    setShowEditForm(false);
  }


  const handleDelete = (id: number) => {
    const component = components?.items.find((item) => item.id === id);

    if(component)
    {
      setShowConfirmDelete(true)
      setComponentDetail(component)
    }
  }

  const handleAcceptDelete = () => {
    if(componentDetail)
    {
      setShowConfirmDelete(false);
      dispatch(deleteComponent({ handleResult, formValues: componentDetail }));
    }
  }

  const handleShowCheckingForm = (componet: IComponent) => {
    setShowCheckingForm(true);
    setComponentDetail(componet);
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
          currentPage: components?.currentPage,
          totalPage: components?.totalPages,
          handleChange: handlePage,
        }}
      
      >
        {components?.items.map((data, index) => (
          <tr 
            key={index} 
            className=""
          >
            <td className="py-1 py-1-custome">{data.name} </td>
            <td className="py-1 py-1-custome">{data.type.name}</td>
            <td className="py-1 py-1-custome">{data.brand.name}</td>
            <td className="py-1 py-1-custome">{data.quantity}</td>
            <td className="py-1 py-1-custome">{data.availableQuantity}</td>

            <td className="py-1 py-1-custome">
              <div className="row">
                <ButtonIcon title="Check Out" className="col-2" onClick={() => handleShowCheckingForm(data)} disable={data.availableQuantity === 0 ? true : false}>
                  <Check className="text-black" />
                </ButtonIcon>
                <ButtonIcon onClick={() => handleShowDetail(data.id)} title="Detail" className="col-2">
                  <FileEarmarkText className="text-black" />
                </ButtonIcon>
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
          <div className="text-center">Do you want to delete this Component?</div>
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
        <ComponentForm component={componentDetail} handleClose={handleCloseEditForm} />
      )}

      { showCheckingForm && componentDetail && (
        <CheckComponentForm component={componentDetail} handleClose={handleCloseCheckingForm} isCheckOut={true} checking={undefined}/>
      )}
    </>
  );
};

export default ComponentTable;
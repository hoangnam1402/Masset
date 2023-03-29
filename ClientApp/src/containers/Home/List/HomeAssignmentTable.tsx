import React, { useEffect, useState } from "react";
import { Check2, X, ArrowCounterclockwise } from "react-bootstrap-icons";

import ButtonIcon from "src/components/ButtonIcon";

import Table, { SortType } from "src/components/Table";
import IColumnOption from "src/interfaces/IColumnOption";
import IPagedModel from "src/interfaces/IPagedModel";
import Info from "../Info";
import ConfirmModal from "src/components/ConfirmModal";

import {
  StaffUserTypeLabel,
  AdminUserType,
  AdminUserTypeLabel,
} from "src/constants/User/UserConstants";
import IAsset from "src/interfaces/Asset/IAsset";
import { AssetState, AssignmentState } from "src/constants/States";
import IAssignment from "src/interfaces/Assignment/IAssignment";
import { getFormatDateTime } from "src/utils/formatDateTimeddMMyyyy";
import { useHistory } from "react-router-dom";
import { Modal } from "react-bootstrap";
import IAssignmentRespond from "src/interfaces/Assignment/IAssignmentRespond";
import { respondToAssignment } from "src/containers/Home/reducer";
import { useAppDispatch, useAppSelector } from "src/hooks/redux";

const columns: IColumnOption[] = [
  { columnName: "Asset Code", columnValue: "code" },
  { columnName: "Asset Name", columnValue: "name" },
  { columnName: "Category", columnValue: "asset.category.name" },
  { columnName: "Assign Date", columnValue: "assignDate"},
  { columnName: "State", columnValue: "state" },
];

type Props = {
  homeAssignments: IPagedModel<IAssignment> | null;
  handlePage: (page: number) => void;
  handleSort: (colValue: string) => void;
  sortState: SortType;
  fetchData: Function;
  page: number;
};

const HomeAssignmentTable: React.FC<Props> = ({
  homeAssignments,
  handlePage,
  handleSort,
  sortState,
  fetchData,
  page,
}) => {
  const [showDetail, setShowDetail] = useState(false);
  const [homeAssignmentDetail, setHomeAssignmentDetail] = useState(
    null as IAssignment | null
  );

  const handleShowInfo = (id: number) => {
    const homeAssignment = homeAssignments?.items.find(
      (item) => item.id === id
    );
    console.log(homeAssignment);

    if (homeAssignment) {
      setHomeAssignmentDetail(homeAssignment);
      setShowDetail(true);
    }
  };

  const handleCloseDetail = () => {
    setShowDetail(false);
  };

  console.log(homeAssignments);
  const dispatch = useAppDispatch();
  const { status, loading, toggle } = useAppSelector(
    (state) => state.homeReducer
  );
  const [showAcceptModal, setShowAcceptModal] = useState(false);
  const [showDeclineModal, setShowDeclineModal] = useState(false);
  const [selectedAssignment, setSelectedAssignment] = useState(0);

  function handelShowAcceptModal(id: number) {
    setShowAcceptModal(true);
    setSelectedAssignment(id);
  }
  function handelShowDeclineModal(id: number) {
    setShowDeclineModal(true);
    setSelectedAssignment(id);
  }

  function handleAcceptAssignment() {
    const dto: IAssignmentRespond = {
      response: 1,
      assignmentID: selectedAssignment,
    };
    dispatch(respondToAssignment(dto));
    setShowAcceptModal(false);
  }
  function handleDeclineAssignment() {
    const dto: IAssignmentRespond = {
      response: 0,
      assignmentID: selectedAssignment,
    };
    dispatch(respondToAssignment(dto));
    setShowDeclineModal(false);
  }

  useEffect(() => {
    fetchData();
  }, [toggle]);

  return (
    <>
      <Table
        columns={columns}
        handleSort={handleSort}
        sortState={sortState}
        page={{
          currentPage: homeAssignments?.currentPage,
          totalPage: homeAssignments?.totalPages,
          handleChange: handlePage,
        }}
      >
        {homeAssignments?.items.map((data, index) => (
          <tr key={index} className="" onClick={() => handleShowInfo(data.id)}>
            <td className="py-1">{data.asset.code} </td>
            <td className="py-1">{data.asset.name}</td>
            <td className="py-1">{data.asset.category.name}</td>
            <td className="py-1">{getFormatDateTime(new Date(data.assignDate))}</td>
            <td className="py-1">{AssignmentState[data.state]}</td>

            <td className="d-flex py-1">
              <ButtonIcon
                disable={data.state == 2 ? true : false}
                onClick={() => {
                  handelShowAcceptModal(data.id);
                }}
              >
                <Check2 className="text-danger" size={24} />
              </ButtonIcon>
              <ButtonIcon
                disable={data.state == 2 ? true : false}
                onClick={() => {
                  handelShowDeclineModal(data.id);
                }}
              >
                <X className="text-black mx-2" size={24} />
              </ButtonIcon>
              <ButtonIcon disable={data.state == 1 ? true : false}>
                <ArrowCounterclockwise
                  className={
                    data.state == 1 ? "text-secondary" : "text-primary"
                  }
                />
              </ButtonIcon>
            </td>
          </tr>
        ))}
      </Table>
      {toggle && <span></span>}
      {homeAssignmentDetail && showDetail && (
        <Info
          homeAssignment={homeAssignmentDetail}
          handleClose={handleCloseDetail}
        />
      )}

      <Modal
        show={showAcceptModal}
        dialogClassName="modal-90w"
        aria-labelledby="login-modal"
        centered
        onHide={() => {
          setShowAcceptModal(false);
        }}
      >
        <Modal.Header
          className="text-monospace lead text-danger font-weight-bold"
          closeButton
        >
          <Modal.Title className="pl-4 ml-1"> Are you sure?</Modal.Title>
        </Modal.Header>
        <Modal.Body className="border-top-5 p-4 pl-5">
          <p>
            Do you want to accept this assignment?
            <br />
          </p>
          <button
            className="btn btn-danger w-25 float-left"
            type="button"
            onClick={handleAcceptAssignment}
          >
            Accept
          </button>
          <button
            className="btn w-25 float-left btn-border ml-5 onhover-gray"
            type="button"
            onClick={() => {
              setShowAcceptModal(false);
            }}
          >
            Cancel
          </button>
        </Modal.Body>
      </Modal>

      <Modal
        show={showDeclineModal}
        dialogClassName="modal-90w"
        aria-labelledby="login-modal"
        centered
        onHide={() => {
          setShowDeclineModal(false);
        }}
      >
        <Modal.Header
          className="text-monospace lead text-danger font-weight-bold"
          closeButton
        >
          <Modal.Title className="pl-4 ml-1"> Are you sure?</Modal.Title>
        </Modal.Header>
        <Modal.Body className="border-top-5 p-4 pl-5">
          <p>
            Do you want to declined this assignment?
            <br />
          </p>
          <button
            className="btn btn-danger w-25 float-left"
            type="button"
            onClick={handleDeclineAssignment}
          >
            Decline
          </button>
          <button
            className="btn w-25 float-left btn-border ml-5 onhover-gray"
            type="button"
            onClick={() => {
              setShowDeclineModal(false);
            }}
          >
            Cancel
          </button>
        </Modal.Body>
      </Modal>
    </>
  );
};

export default HomeAssignmentTable;

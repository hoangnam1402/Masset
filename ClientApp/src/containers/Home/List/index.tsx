import React, { useEffect, useState } from "react";
import { CalendarDateFill, FunnelFill,Calendar2XFill } from "react-bootstrap-icons";
import { Search } from "react-feather";
import ReactMultiSelectCheckboxes from "react-multiselect-checkboxes";

import { useAppDispatch, useAppSelector } from "src/hooks/redux";
import IUserUserModel from "src/interfaces/User/IQueryUserModel";
// import { getAssets, getAssetCategories } from "../reducer";
import { Link } from "react-router-dom";
import IQueryUserModel from "src/interfaces/User/IQueryUserModel";
import ISelectOption from "src/interfaces/ISelectOption";
import {
  ACCSENDING,
  DECSENDING,
  DEFAULT_USER_SORT_COLUMN_NAME,
  DEFAULT_PAGE_LIMIT,
} from "src/constants/paging";
import { CREATE_ASSET, CREATE_USER } from "src/constants/pages";

import createCategorySelectOption from "src/utils/createCategorySelectOption";
import IQueryAssetModel from "src/interfaces/Asset/IQueryAssetModel";
import {
  AssetStateOptions,
  AssignmentStateOptions,
} from "src/constants/selectOptions";
import AssetTable from "src/containers/Asset/List/AssetTable";
import HomeAssignmentTable from "./HomeAssignmentTable";
import { getAssetCategories, getAssets } from "src/containers/Asset/reducer";
import IQueryAssignmentModel from "src/interfaces/Assignment/IQueryAssignment";
import { getHomeAssignments } from "../reducer";
import DateField from "src/components/FormInputs/DateField";
import DatePicker from "react-datepicker";
import IAssignmentRespond from "src/interfaces/Assignment/IAssignmentRespond";
import { Modal } from "react-bootstrap";
const HomeAssignmentList = () => {
  const dispatch = useAppDispatch();
  const { homeAssignments, loading } = useAppSelector(
    (state) => state.homeReducer
  );

  const [query, setQuery] = useState({
    page: homeAssignments?.currentPage ?? 1,
    limit: DEFAULT_PAGE_LIMIT,
    sortOrder: ACCSENDING,
    sortColumn: DEFAULT_USER_SORT_COLUMN_NAME,
    assignedDate: undefined,
  } as IQueryAssignmentModel);

  const handlePage = (page: number) => {
    setQuery({
      ...query,
      page,
    });
  };

  const handleSort = (sortColumn: string) => {
    const sortOrder = query.sortOrder === ACCSENDING ? DECSENDING : ACCSENDING;

    setQuery({
      ...query,
      sortColumn,
      sortOrder,
    });
  };

  const fetchData = () => {
    dispatch(getHomeAssignments(query));
  };

  useEffect(() => {
    fetchData();
  }, [query]);

  return (
    <>
      <div className="primaryColor text-title intro-x">My Assignment</div>

      <div>
        <HomeAssignmentTable
          page={query.page}
          homeAssignments={homeAssignments}
          handlePage={handlePage}
          handleSort={handleSort}
          sortState={{
            columnValue: query.sortColumn,
            orderBy: query.sortOrder,
          }}
          fetchData={fetchData}
        />
      </div>


 
    </>
  );
};

export default HomeAssignmentList;

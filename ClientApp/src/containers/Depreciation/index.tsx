import React, { useEffect, useState } from "react";
import { Search } from "react-feather";
import { useAppDispatch, useAppSelector } from "../../hooks/redux";
import { getDepreciations } from "./reducer";
import {
  ACCSENDING,
  DECSENDING,
  DEFAULT_SORT_COLUMN_NAME,
  DEFAULT_PAGE_LIMIT,
} from "../../constants/paging";
import IQueryModel from "../../interfaces/IQueryModel";
import DepreciationForm from "./DepreciationForm";
import DepreciationTable from "./DepreciationTable";
import { LimitOptions } from "../../constants/selectOptions";
import DepreciationFDP from "./DepreciationFDP";

const Depreciation = () => {
  const dispatch = useAppDispatch();
  const { depreciations, deleteDepreciation, depreciationResult } = useAppSelector(
    (state) => state.depreciationReducer
  );

  const [query, setQuery] = useState({
    page: depreciations?.currentPage ?? 1,
    limit: DEFAULT_PAGE_LIMIT,
    sortOrder: ACCSENDING,
    sortColumn: DEFAULT_SORT_COLUMN_NAME,
  } as IQueryModel);

  const [search, setSearch] = useState("");
  const [showCreateForm, setShowCreateForm] = useState(false);
  const [limitSelected, setLimitSelected] = useState(5);

  const handleChangeSearch = (e : any) => {
    e.preventDefault();

    const search = e.target.value;
    setSearch(search);
  };

  const handlePage = (page: number) => {
    setQuery({
      ...query,
      page,
    });
  };

  const handleSearch = () => {
    setQuery({
      ...query,
      search,
      page:1
    });
  };

  const handleLimit = (e: any) => {
    setLimitSelected(e.target.value)

    setQuery({
      ...query,
      limit: e.target.value,
      page:1
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

  const handleCreate = () => {
    setShowCreateForm(true);
  }

  const handleCloseCreateForm = () => {
    setShowCreateForm(false);
  }

  const fetchData = () => {
    dispatch(getDepreciations(query));
  };

  useEffect(() => {
    fetchData();
  }, [query, deleteDepreciation, depreciationResult]);

  return (
    <>
      <div className="primaryColor text-title intro-x">Depreciation List</div>

      <div>
        <div className="d-flex mb-5 intro-x">
          {depreciations && depreciations.items && <div className="d-flex align-items-center w-md mr-5">
            <div className="d-flex justify-content-center">
              <DepreciationFDP data={depreciations.items}/>
            </div>
          </div>}

          <div className="d-flex align-items-center w-ld ml-auto">
            <div className="input-group">
              <input
                onChange={handleChangeSearch}
                value={search}
                type="text"
                className="form-control"
              />
              <span onClick={handleSearch} className="border p-2 pointer">
                <Search />
              </span>
            </div>
          </div>

          <div className="d-flex align-items-center ml-3">
            <button type="button" onClick={() => handleCreate()} className="btn btn-danger">
              Create new Depreciation
            </button>
          </div>
        </div>

        <DepreciationTable
          depreciations={depreciations}
          deleteDepr={deleteDepreciation}
          handlePage={handlePage}
          handleSort={handleSort}
          handleLimit={handleLimit}
          limit={limitSelected}
          sortState={{
            columnValue: query.sortColumn,
            orderBy: query.sortOrder,
          }}
        />
      </div>

      { showCreateForm && (
        <DepreciationForm depreciation={undefined} handleClose={handleCloseCreateForm} />
      )}
    </>
  );
};

export default Depreciation;

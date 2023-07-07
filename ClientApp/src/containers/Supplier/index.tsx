import React, { useEffect, useState } from "react";
import { useAppDispatch, useAppSelector } from "../../hooks/redux";
import { getSuppliers } from "./reducer";
import {
  ACCSENDING,
  DECSENDING,
  DEFAULT_SORT_COLUMN_NAME,
  DEFAULT_PAGE_LIMIT,
} from "../../constants/paging";
import IQueryModel from "../../interfaces/IQueryModel";
import SupplierForm from "./SupplierForm";
import SupplierTable from "./SupplierTable";
import SupplierFDP from "./SupplierPDP";

const Supplier = () => {
  const dispatch = useAppDispatch();
  const { suppliers, deleteSupplier, supplierResult } = useAppSelector(
    (state) => state.supplierReducer
  );

  const [query, setQuery] = useState({
    page: suppliers?.currentPage ?? 1,
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
    const sortOrder = query.sortOrder == ACCSENDING ? DECSENDING : ACCSENDING;

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
    dispatch(getSuppliers(query));
  };

  useEffect(() => {
    fetchData();
  }, [query, deleteSupplier, supplierResult]);

  return (
    <>
      <div className="primaryColor text-title intro-x">Supplier List</div>

      <div>
        <div className="d-flex mb-4 intro-x">
          {suppliers && suppliers.items && <div className="d-flex align-items-center w-md mr-5">
            <div className="d-flex justify-content-center">
              <SupplierFDP data={suppliers.items}/>
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
              <span onClick={handleSearch} className="border p-2 pointer search-icon">
                <img src="/search-icon.png" alt="search-icon" className="icon" />
              </span>
            </div>
          </div>

          <div className="d-flex align-items-center ml-3">
            <button type="button" onClick={() => handleCreate()} className="btn btn-danger">
              Create new Supplier
            </button>
          </div>
        </div>

        <SupplierTable
          suppliers={suppliers}
          deleteSuppliers={deleteSupplier}
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
        <SupplierForm supplier={undefined} handleClose={handleCloseCreateForm} />
      )}
    </>
  );
};

export default Supplier;

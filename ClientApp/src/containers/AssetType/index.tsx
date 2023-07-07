import React, { useEffect, useState } from "react";
import { useAppDispatch, useAppSelector } from "../../hooks/redux";
import { getAssetTypes } from "./reducer";
import {
  ACCSENDING,
  DECSENDING,
  DEFAULT_SORT_COLUMN_NAME,
  DEFAULT_PAGE_LIMIT,
} from "../../constants/paging";
import IQueryModel from "../../interfaces/IQueryModel";
import AssetTypeForm from "./AssetTypeForm";
import AssetTypeTable from "./AssetTypeTable";
import TypeFDP from "./TypeFDP";

const AssetType = () => {
  const dispatch = useAppDispatch();
  const { assetTypes, deleteAssetType, assetTypeResult } = useAppSelector(
    (state) => state.assetTypeReducer
  );

  const [query, setQuery] = useState({
    page: assetTypes?.currentPage ?? 1,
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

  const handleSort = (sortColumn: string) => {
    const sortOrder = query.sortOrder == ACCSENDING ? DECSENDING : ACCSENDING;

    setQuery({
      ...query,
      sortColumn,
      sortOrder,
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

  const handleCreate = () => {
    setShowCreateForm(true);
  }

  const handleCloseCreateForm = () => {
    setShowCreateForm(false);
  }

  const fetchData = () => {
    dispatch(getAssetTypes(query));
  };

  useEffect(() => {
    fetchData();
  }, [query, deleteAssetType, assetTypeResult]);

  return (
    <>
      <div className="primaryColor text-title intro-x">Asset Type List</div>

      <div>        
        <div className="d-flex mb-4 intro-x">
          {assetTypes && assetTypes.items && <div className="d-flex align-items-center w-md mr-5">
            <div className="d-flex justify-content-center">
              <TypeFDP data={assetTypes.items}/>
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
              Create new Asset Type
            </button>
          </div>
        </div>

        <AssetTypeTable
          assetTypes={assetTypes}
          handleLimit={handleLimit}
          limit={limitSelected}  
          deleteType={deleteAssetType}
          handlePage={handlePage}
          handleSort={handleSort}
          sortState={{
            columnValue: query.sortColumn,
            orderBy: query.sortOrder,
          }}
        />
      </div>

      { showCreateForm && (
        <AssetTypeForm assetType={undefined} handleClose={handleCloseCreateForm} />
      )}
    </>
  );
};

export default AssetType;

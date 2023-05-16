import React, { useEffect, useState } from "react";
import { FunnelFill } from "react-bootstrap-icons";
import { Search } from "react-feather";
import { MultiSelect } from "react-multi-select-component";

import { useAppDispatch, useAppSelector } from "../../../hooks/redux";
import { getAssets } from "../reducer";
import {
  ACCSENDING,
  DECSENDING,
  DEFAULT_SORT_COLUMN_NAME,
  DEFAULT_PAGE_LIMIT,
} from "../../../constants/paging";
import { ASSET_INFO } from "../../../constants/pages";
import AssetTable from "./AssetTable";
import IQueryAssetModel from "../../../interfaces/Asset/IQueryAssetModel";
import { AssetStateOptions } from "../../../constants/selectOptions";
import AssetFormContainer from "../AssetForm";

const AssetList = () => {
  const dispatch = useAppDispatch();
  const { assets, deleteAsset } = useAppSelector(
    (state) => state.assetReducer
  );

  const [query, setQuery] = useState({
    page: assets?.currentPage ?? 1,
    limit: DEFAULT_PAGE_LIMIT,
    sortOrder: ACCSENDING,
    sortColumn: DEFAULT_SORT_COLUMN_NAME,
  } as IQueryAssetModel);

  const [stateSelected, setStateSelected] = useState(AssetStateOptions);
  const [search, setSearch] = useState("");
  const [showCreateForm, setShowCreateForm] = useState(false)

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
    dispatch(getAssets(query));
  };

  useEffect(() => {
    fetchData();
  }, [query, deleteAsset,stateSelected]);

  return (
    <>
      <div className="primaryColor text-title intro-x">Asset List</div>

      <div>
        <div className="d-flex mb-5 intro-x">
          <div className="d-flex align-items-center w-md mr-5">
            <div className="d-flex justify-content-center">
              <p className="mr-2 mt-2">State:</p>
              <MultiSelect
                options={AssetStateOptions}
                labelledBy="State"
                value={stateSelected}
                onChange={setStateSelected}
                disableSearch={true}
              />

              <div className="border p-2">
                <FunnelFill />
              </div>
            </div>
          </div>

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
              Create new Asset
            </button>
          </div>
        </div>

        <AssetTable
          assets={assets}
          deleteAsset={deleteAsset}
          handlePage={handlePage}
          handleSort={handleSort}
          sortState={{
            columnValue: query.sortColumn,
            orderBy: query.sortOrder,
          }}
          fetchData={fetchData}
        />
      </div>

      { showCreateForm && (
        <AssetFormContainer asset={undefined} handleClose={handleCloseCreateForm} />
      )}
    </>
  );
};

export default AssetList;

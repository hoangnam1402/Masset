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
import AssetTable from "./AssetTable";
import IQueryAssetModel from "../../../interfaces/Asset/IQueryAssetModel";
import { AssetStateOptions } from "../../../constants/selectOptions";
import AssetForm from "./AssetForm";
import ISelectOption from "../../../interfaces/ISelectOption";
import AssetFDP from "./AssetFDP";
import { propertyLabelConstants } from "../../../constants/PropertyLabelConstants";

const AssetList = () => {
  const dispatch = useAppDispatch();
  const { assets, deleteAsset, assetResult, assetChecking } = useAppSelector(
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
  const [showCreateForm, setShowCreateForm] = useState(false);
  const [limitSelected, setLimitSelected] = useState(5);

  const handleChangeSearch = (e : any) => {
    e.preventDefault();

    const search = e.target.value;
    setSearch(search);
  };

  const handleState = (selected: ISelectOption[]) => {
    if (selected.length == 0) {
      setQuery({
        ...query,
        state: [],
        
      });

      setStateSelected(AssetStateOptions);
      return;
    }

    const selectedAll = selected.find((item) => item.id == 0);

    setStateSelected((prevSelected) => {
      if (!prevSelected.some((item) => item.id == 0) && selectedAll) {
        setQuery({
          ...query,
          state: [],
   
        });

        return [selectedAll];
      }

      const newSelected = selected.filter((item) => item.id != 0);
      const state = newSelected.map((item) => item.value as number);

      setQuery({
        ...query,
        state,
        page:1
      });

      return newSelected;
    });
  };

  const handlePage = (page: number) => {
    setQuery({
      ...query,
      page,
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
  }, [query, deleteAsset, assetResult, assetChecking]);

  return (
    <>
      <div className="d-flex">
        <div className="d-flex primaryColor text-title intro-x">{propertyLabelConstants.TITLE}</div>
        {assets && assets.items && <AssetFDP data={assets.items}/>}
      </div>

      <div>
        <div className="d-flex mb-4 intro-x">
          <div className="d-flex align-items-center w-md mr-5">
            <div className="d-flex justify-content-center">
              <p className="mr-2 mt-3">State:</p>
              <MultiSelect
                className="mt-2"
                options={AssetStateOptions}
                labelledBy="State"
                value={stateSelected}
                onChange={handleState}
                disableSearch={true}
              />

              <div className="border p-2 mt-2">
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
              <span onClick={handleSearch} className="border p-2 pointer search-icon">
                <Search />
              </span>
            </div>
          </div>

          <div className="d-flex align-items-center ml-3">
            <button type="button" onClick={() => handleCreate()} className="btn btn-danger">
              {propertyLabelConstants.CREATE_NEW_PROPERTY}
            </button>
          </div>
        </div>

        <AssetTable
          assets={assets}
          deleteAsset={deleteAsset}
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
        <AssetForm asset={undefined} handleClose={handleCloseCreateForm} />
      )}
    </>
  );
};

export default AssetList;

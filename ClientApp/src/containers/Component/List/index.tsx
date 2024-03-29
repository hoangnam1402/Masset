import React, { useEffect, useState } from "react";
import { FunnelFill } from "react-bootstrap-icons";
import { MultiSelect } from "react-multi-select-component";

import { useAppDispatch, useAppSelector } from "../../../hooks/redux";
import { getComponents } from "../reducer";
import {
  ACCSENDING,
  DECSENDING,
  DEFAULT_SORT_COLUMN_NAME,
  DEFAULT_PAGE_LIMIT,
} from "../../../constants/paging";
import ComponentTable from "./ComponentTable";
import { AssetStateOptions } from "../../../constants/selectOptions";
import ComponentForm from "./ComponentForm";
import ISelectOption from "../../../interfaces/ISelectOption";
import IQueryAssetModel from "../../../interfaces/Asset/IQueryAssetModel";
import ComponentFDP from "./ComponentFDP";

const ComponentList = () => {
  const dispatch = useAppDispatch();
  const { components, deleteComponent, componentResult, checkings } = useAppSelector(
    (state) => state.componentReducer
  );

  const [query, setQuery] = useState({
    page: components?.currentPage ?? 1,
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
    dispatch(getComponents(query));
  };

  useEffect(() => {
    fetchData();
  }, [query, deleteComponent, stateSelected, componentResult, checkings]);

  return (
    <>
      <div className="d-flex">
        <div className="d-flex primaryColor text-title intro-x">Component List</div>
        {components && components.items && <ComponentFDP data={components.items}/>}
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
                <img src="/search-icon.png" alt="search-icon" className="icon" />
              </span>
            </div>
          </div>

          <div className="d-flex align-items-center ml-3">
            <button type="button" onClick={() => handleCreate()} className="btn btn-danger">
              Create new Component
            </button>
          </div>
        </div>

        <ComponentTable
          components={components}
          deleteComp={deleteComponent}
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
        <ComponentForm component={undefined} handleClose={handleCloseCreateForm} />
      )}
    </>
  );
};

export default ComponentList;

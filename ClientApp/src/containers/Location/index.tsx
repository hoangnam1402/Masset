import React, { useEffect, useState } from "react";
import { Search } from "react-feather";
import { useAppDispatch, useAppSelector } from "../../hooks/redux";
import { getLocations } from "./reducer";
import {
  ACCSENDING,
  DECSENDING,
  DEFAULT_SORT_COLUMN_NAME,
  DEFAULT_PAGE_LIMIT,
} from "../../constants/paging";
import IQueryModel from "../../interfaces/IQueryModel";
import LocationForm from "./LocationForm";
import LocationTable from "./LocationTable";
import LocationFDP from "./LocationFDP";

const Location = () => {
  const dispatch = useAppDispatch();
  const { locations, deleteLocation, locationResult } = useAppSelector(
    (state) => state.locationReducer
  );

  const [query, setQuery] = useState({
    page: locations?.currentPage ?? 1,
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
    const sortOrder = query.sortOrder === ACCSENDING ? DECSENDING : ACCSENDING;

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
    dispatch(getLocations(query));
  };

  useEffect(() => {
    fetchData();
  }, [query, deleteLocation, locationResult]);

  return (
    <>
      <div className="primaryColor text-title intro-x">Location List</div>

      <div>
        <div className="d-flex mb-4 intro-x">
          {locations && locations.items && <div className="d-flex align-items-center w-md mr-5">
            <div className="d-flex justify-content-center">
              <LocationFDP data={locations.items}/>
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
              Create new Location
            </button>
          </div>
        </div>

        <LocationTable
          locations={locations}
          deleteLocations={deleteLocation}
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
        <LocationForm location={undefined} handleClose={handleCloseCreateForm} />
      )}
    </>
  );
};

export default Location;

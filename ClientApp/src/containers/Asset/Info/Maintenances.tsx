import { useEffect, useState } from "react";
import { getMaintenance } from "../reducer";
import { useAppDispatch, useAppSelector } from "../../../hooks/redux";
import IColumnOption from "../../../interfaces/IColumnOption";
import Table, { SortType } from "../../../components/Table";
import IQueryModel from "../../../interfaces/IQueryModel";
import { ACCSENDING, DECSENDING, DEFAULT_PAGE_LIMIT, DEFAULT_SORT_COLUMN_NAME } from "../../../constants/paging";
import { TypeMaintenance, TypeCalibration, TypeCalibrationLabel, TypeHardwareSupport, TypeTesting,
    TypeHardwareSupportLabel, TypeMaintenanceLabel, TypeRepair, TypeRepairLabel, TypeSoftwareSupport,
    TypeSoftwareSupportLabel, TypeTestingLabel, TypeUpgrade, TypeUpgradeLabel } from "../../../constants/maintenanceConstants";
import { Search } from "react-feather";
import { LimitOptions } from "../../../constants/selectOptions";
import MaintenanceFDP from "../../Maintenance/MaintenanceFDP";

const columns: IColumnOption[] = [
    { columnName: "Asset", columnValue: "asset" },
    { columnName: "Supplier", columnValue: "supplier" },
    { columnName: "Type", columnValue: "type" },
    { columnName: "Start date", columnValue: "startDate" },
    { columnName: "End date", columnValue: "endDate" },
];
  
type Props = {
    assetID: number;
};

const Maintenances: React.FC<Props> = ({assetID}) => {
    const dispatch = useAppDispatch();
    const { maintenances } = useAppSelector(state => state.assetReducer);
    const [search, setSearch] = useState("");
    const [limitSelected, setLimitSelected] = useState(5);

    const [query, setQuery] = useState({
        page: maintenances?.currentPage ?? 1,
        limit: DEFAULT_PAGE_LIMIT,
        sortOrder: ACCSENDING,
        sortColumn: DEFAULT_SORT_COLUMN_NAME,
    } as IQueryModel);

    const handleSort = (sortColumn: string) => {
        const sortOrder = query.sortOrder === ACCSENDING ? DECSENDING : ACCSENDING;
    
        setQuery({
          ...query,
          sortColumn,
          sortOrder,
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

    const handleChangeSearch = (e : any) => {
        e.preventDefault();
    
        const search = e.target.value;
        setSearch(search);
    };

    const handleLimit = (e: any) => {
        setLimitSelected(e.target.value)
    
        setQuery({
          ...query,
          limit: e.target.value,
          page:1
        });
    };

    const getMaintenanceTypeName = (id: number | undefined) => {
		switch(id) {
			case TypeMaintenance:
				return TypeMaintenanceLabel;
			case TypeCalibration:
				return TypeCalibrationLabel;
			case TypeHardwareSupport:
				return TypeHardwareSupportLabel;
			case TypeRepair:
				return TypeRepairLabel;
            case TypeSoftwareSupport:
                return TypeSoftwareSupportLabel;
            case TypeTesting:
                return TypeTestingLabel;
			default:
				return TypeUpgradeLabel;
		}
	};
    
    const fetchData = () => {
        dispatch(getMaintenance({query: query,id: Number(assetID)}));
    };

    useEffect(() => {
    fetchData();
    }, [query, assetID]);
    
    return(
        <>
            <div>
                <div className="d-flex mb-5 intro-x">
                    {maintenances && maintenances.items && <div className="d-flex align-items-center w-md mr-5">
                        <div className="d-flex justify-content-center">
                        <MaintenanceFDP data={maintenances.items}/>
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
                </div>

                <Table
                    columns={columns}
                    handleSort={handleSort}
                    handleLimit={handleLimit}
                    limit={limitSelected}
                    sortState={{
                        columnValue: query.sortColumn,
                        orderBy: query.sortOrder,
                    }}
                    page={{
                    currentPage: maintenances?.currentPage,
                    totalPage: maintenances?.totalPages,
                    handleChange: handlePage,
                    }}
                >
                    {maintenances?.items.map((data, index) => (
                    <tr 
                        key={index} 
                        className=""
                    >
                        <td className="py-1">{data.asset.name}</td>
                        <td className="py-1">{data.supplier.name} </td>
                        <td className="py-1">{getMaintenanceTypeName(data.type)}</td>
                        <td className="py-1">{new Date(data.startDate).toLocaleDateString()}</td>
                        <td className="py-1">{new Date(data.endDate).toLocaleDateString()}</td>
                    </tr>
                    ))}
                </Table>
            </div>
        </>
    );
};

export default Maintenances;
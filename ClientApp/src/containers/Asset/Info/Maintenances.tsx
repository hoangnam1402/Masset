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
    }, []);
    
    return(
        <>
            <Table
                columns={columns}
                handleSort={handleSort}
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
                    <td className="py-1">{getMaintenanceTypeName(data.maintenanceType)}</td>
                    <td className="py-1">{new Date(data.startDate).toLocaleDateString()}</td>
                    <td className="py-1">{new Date(data.endDate).toLocaleDateString()}</td>
                </tr>
                ))}
                
            </Table>
        </>
    );
};

export default Maintenances;
import { useEffect, useState } from "react";
import { useAppDispatch, useAppSelector } from "../../../hooks/redux";
import { getDepreciation } from "../reducer";
import IColumnOption from "../../../interfaces/IColumnOption";
import { ACCSENDING, DECSENDING, DEFAULT_PAGE_LIMIT, DEFAULT_SORT_COLUMN_NAME } from "../../../constants/paging";
import IQueryModel from "../../../interfaces/IQueryModel";
import {
	StateReadyToDeploy,
	StatePending,
	StateArchived,
	StateBroken,
  StateLost,
  StateOutOfRepair,
	StateReadyToDeployLabel,
	StatePendingLabel,
	StateArchivedLabel,
	StateBrokenLabel,
  StateLostLabel,
  StateOutOfRepairLabel,
  StateNull
} from "../../../constants/assetConstants";
import Table from "../../../components/Table";

const columns: IColumnOption[] = [
    { columnName: "Name", columnValue: "name" },
    { columnName: "Type", columnValue: "type" },
    { columnName: "Brand", columnValue: "brand" },
    { columnName: "Quantity", columnValue: "quantity" },
    { columnName: "Available Quantity", columnValue: "availableQuantity" },
];

type Props = {
    assetID: number;
};

const Component: React.FC<Props> = ({assetID}) => {
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

    const getStateTypeName = (id: number | undefined) => {
		switch(id) {
			case StateReadyToDeploy:
				return StateReadyToDeployLabel;
			case StatePending:
				return StatePendingLabel;
			case StateArchived:
				return StateArchivedLabel;
			case StateBroken:
				return StateBrokenLabel;
            case StateLost:
                return StateLostLabel;
            case StateOutOfRepair:
                return StateOutOfRepairLabel;
			default:
				return StateNull;
		}
	};

    const fetchData = () => {
        dispatch(getDepreciation({id: Number(assetID)}));
    };

    useEffect(() => {
    fetchData();
    }, []);

    return (
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
                    <td className="py-1">{getStateTypeName(data.maintenanceType)}</td>
                    <td className="py-1">{new Date(data.startDate).toLocaleDateString()}</td>
                    <td className="py-1">{new Date(data.endDate).toLocaleDateString()}</td>
                </tr>
                ))}
                
            </Table>
        </>
    );
};

export default Component;
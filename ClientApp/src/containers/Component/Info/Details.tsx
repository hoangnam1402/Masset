import { useEffect, useState } from "react";
import { useAppDispatch, useAppSelector } from "../../../hooks/redux";
import { getComponentCheck, getDepreciation } from "../reducer";
import IColumnOption from "../../../interfaces/IColumnOption";
import { ACCSENDING, DECSENDING, DEFAULT_PAGE_LIMIT, DEFAULT_SORT_COLUMN_NAME } from "../../../constants/paging";
import IQueryModel from "../../../interfaces/IQueryModel";
import Table from "../../../components/Table";
import IComponent from "../../../interfaces/Component/IComponent";
import IChecking from "../../../interfaces/Checking/IChecking";
import CheckComponentForm from "../CheckComponentForm";

const columns: IColumnOption[] = [
    { columnName: "Property", columnValue: "asset.name" },
    { columnName: "Quantity", columnValue: "quantity" },
    { columnName: "Date", columnValue: "checkDay" },
    { columnName: "Action", columnValue: ""},
];

type Props = {
    component: IComponent;
};
  
const Details: React.FC<Props> = ({component}) => {
    const dispatch = useAppDispatch();
    const [showCheckingForm, setShowCheckingForm] = useState(false);
    const [checkDetail, setCheckDetail] = useState(undefined as IChecking | undefined);
    const [limitSelected, setLimitSelected] = useState(5);

    const { componentCheck } = useAppSelector(state => state.componentReducer);

    const [query, setQuery] = useState({
        page: componentCheck?.currentPage ?? 1,
        limit: DEFAULT_PAGE_LIMIT,
        sortOrder: ACCSENDING,
        sortColumn: DEFAULT_SORT_COLUMN_NAME,
    } as IQueryModel);

    const handleSort = (sortColumn: string) => {
        const sortOrder = query.sortOrder == ACCSENDING ? DECSENDING : ACCSENDING;
    
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

    
    const handleLimit = (e: any) => {
        setLimitSelected(e.target.value)

        setQuery({
        ...query,
        limit: e.target.value,
        page:1
        });
    };

    const handleDay = (day: Date) => {
        const CheckingDay = new Date(day).toLocaleDateString();
        return CheckingDay
    }

    const handleShowCheckingForm = (check: IChecking) => {
        setShowCheckingForm(true);
        setCheckDetail(check);
    }

    const handleCloseCheckingForm = () => {
    setShowCheckingForm(false);
    }    

    const fetchData = () => {
        dispatch(getComponentCheck({query: query,id: component.id}));
        dispatch(getDepreciation({id: Number(component.id)}));
    };

    useEffect(() => {
    fetchData();
    console.log(query)
    }, [query, component]);

    return (
        <>
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
                currentPage: componentCheck?.currentPage,
                totalPage: componentCheck?.totalPages,
                handleChange: handlePage,
                }}
            >
                {componentCheck?.items.map((data, index) => (
                <tr 
                    key={index} 
                    className=""
                >
                    <td className="py-1">{data.asset.name} </td>
                    <td className="py-1">{data.quantity}</td>
                    <td className="py-1">{handleDay(data.checkDay)}</td>
                    <td className="py-1">
                        <button
                            className="btn btn-outline-secondary"
                            onClick={() => handleShowCheckingForm(data)}
                            type="button"
                            >
                                Check In
                        </button>
                    </td>
                </tr>
                ))}
            </Table>

            { showCheckingForm && checkDetail && (
                <CheckComponentForm component={component} handleClose={handleCloseCheckingForm} isCheckOut={false} checking={checkDetail}/>
            )}
        </>
    );
};

export default Details;

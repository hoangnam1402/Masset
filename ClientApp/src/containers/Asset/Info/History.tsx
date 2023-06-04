import { useEffect, useState } from "react";
import { useAppDispatch, useAppSelector } from "../../../hooks/redux";
import { getHistoryCheck } from "../reducer";
import IColumnOption from "../../../interfaces/IColumnOption";
import { ACCSENDING, DECSENDING, DEFAULT_PAGE_LIMIT, DEFAULT_SORT_COLUMN_NAME } from "../../../constants/paging";
import IQueryModel from "../../../interfaces/IQueryModel";
import Table from "../../../components/Table";
import { Search } from "react-feather";
import { LimitOptions } from "../../../constants/selectOptions";
import AssetCheckFDP from "./AssetCheckFDP";

const columns: IColumnOption[] = [
    { columnName: "Date", columnValue: "checkDay" },
    { columnName: "Asset Name", columnValue: "asset.name" },
    { columnName: "User", columnValue: "user" },
    { columnName: "Action", columnValue: "" },
];

type Props = {
    assetID: number;
};

const History: React.FC<Props> = ({assetID}) => {
    const dispatch = useAppDispatch();
    const [search, setSearch] = useState("");
    const { historyCheck } = useAppSelector(state => state.assetReducer);
    const [limitSelected, setLimitSelected] = useState(5);

    const [query, setQuery] = useState({
        page: historyCheck?.currentPage ?? 1,
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

    const handleDay = (day: Date) => {
        const CheckingDay = new Date(day).toLocaleDateString();
        return CheckingDay
    }

    const handleChangeSearch = (e : any) => {
        e.preventDefault();
    
        const search = e.target.value;
        setSearch(search);
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

    const fetchData = () => {
        dispatch(getHistoryCheck({query: query,id: assetID}));
    };

    useEffect(() => {
    fetchData();
    }, [query, assetID]);

    return (
        <>
            <div>
                <div className="d-flex mb-5 intro-x">
                    {historyCheck && historyCheck.items && <div className="d-flex align-items-center w-md mr-5">
                        <div className="d-flex justify-content-center">
                        <AssetCheckFDP data={historyCheck.items}/>
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
                    currentPage: historyCheck?.currentPage,
                    totalPage: historyCheck?.totalPages,
                    handleChange: handlePage,
                    }}
                >
                    {historyCheck?.items.map((data, index) => (
                    <tr 
                        key={index} 
                        className=""
                    >
                        <td className="py-1">{handleDay(data.checkDay)}</td>
                        <td className="py-1">{data.asset.name} </td>
                        <td className="py-1">{data.user.userName}</td>
                        <td className="py-1">{data.isCheckOut ? "Check out" : "Check in"}</td>
                    </tr>
                    ))}
                </Table>
            </div>
        </>
    );
};

export default History;
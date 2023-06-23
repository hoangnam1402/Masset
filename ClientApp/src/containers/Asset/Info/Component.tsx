import { useEffect, useState } from "react";
import { useAppDispatch, useAppSelector } from "../../../hooks/redux";
import { getComponentCheck } from "../reducer";
import IColumnOption from "../../../interfaces/IColumnOption";
import { ACCSENDING, DECSENDING, DEFAULT_PAGE_LIMIT, DEFAULT_SORT_COLUMN_NAME } from "../../../constants/paging";
import IQueryModel from "../../../interfaces/IQueryModel";
import Table from "../../../components/Table";
import { Search } from "react-feather";
import ComponentCheckFDP from "./ComponentCheckFDP";

const columns: IColumnOption[] = [
    { columnName: "Name", columnValue: "component.name" },
    { columnName: "Type", columnValue: "component.type.name" },
    { columnName: "Brand", columnValue: "component.brand.name" },
    { columnName: "Quantity", columnValue: "component.quantity" },
    { columnName: "Available Quantity", columnValue: "component.availableQuantity" },
];

type Props = {
    assetID: number;
};

const Component: React.FC<Props> = ({assetID}) => {
    const dispatch = useAppDispatch();
    const [search, setSearch] = useState("");
    const { componentCheck } = useAppSelector(state => state.assetReducer);
    const [limitSelected, setLimitSelected] = useState(5);
    
    const [query, setQuery] = useState({
        page: componentCheck?.currentPage ?? 1,
        limit: DEFAULT_PAGE_LIMIT,
        sortOrder: ACCSENDING,
        sortColumn: DEFAULT_SORT_COLUMN_NAME,
    } as IQueryModel);

    const handleChangeSearch = (e : any) => {
        e.preventDefault();
    
        const search = e.target.value;
        setSearch(search);
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

    const fetchData = () => {
        dispatch(getComponentCheck({query: query,id: Number(assetID)}));
    };

    useEffect(() => {
    fetchData();
    }, [query, assetID]);

    return (
        <>
            <div>
                <div className="d-flex mb-5 intro-x">
                    {componentCheck && componentCheck.items && <div className="d-flex align-items-center w-md mr-5">
                        <div className="d-flex justify-content-center">
                        <ComponentCheckFDP data={componentCheck.items}/>
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
                        <td className="py-1">{data.component.name}</td>
                        <td className="py-1">{data.component.type.name} </td>
                        <td className="py-1">{data.component.brand.name}</td>
                        <td className="py-1">{data.component.quantity}</td>
                        <td className="py-1">{data.component.availableQuantity}</td>
                    </tr>
                    ))}
                    
                </Table>
            </div>
        </>
    );
};

export default Component;
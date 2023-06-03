import { useEffect, useState } from "react";
import { useAppDispatch, useAppSelector } from "../../../hooks/redux";
import StaticTable from "../../../components/Table/StaticTable";
import IColumnOption from "../../../interfaces/IColumnOption";
import { getDepreciation } from "../reducer";

const columns: IColumnOption[] = [
    { columnName: "Period (Month)", columnValue: "period" },
    { columnName: "Book Value", columnValue: "bookValue" },
    { columnName: "Depreciation Percentage", columnValue: "depreciationPercentage" },
    { columnName: "Amount", columnValue: "amount" },
    { columnName: "Accumulated Depreciation", columnValue: "accumulatedDepreciation" },
    { columnName: "Ending Book Value", columnValue: "endingBookValue" },
];

interface Items {
    period: number;
    bookValue: string;
    depreciationPercentage: string;
    amount: string;
    accumulatedDepreciation: string;
    endingBookValue: string;
};

type Props = {
    assetID: number;
};

const Depreciation: React.FC<Props> = ({assetID}) => {
    const dispatch = useAppDispatch();
    const { depreciation, } = useAppSelector(state => state.assetReducer);
    const [queue, setQueue] = useState<Items[]>([]);

    useEffect(() => {
        if (depreciation) {
            console.log(depreciation)
            const DepreciationPercentage = (100 / depreciation.period).toFixed(2);
            const Amount = ((depreciation.asset.cost - depreciation.value) / depreciation.period).toFixed(2);
            for(let i = 0; i < depreciation.period; i++){
                const newElement: Items = {
                    period: i,
                    bookValue: (depreciation.asset.cost - parseFloat(Amount)*i).toFixed(2),
                    depreciationPercentage: DepreciationPercentage,
                    amount: Amount,
                    accumulatedDepreciation: (parseFloat(Amount)*(i+1)).toFixed(2),
                    endingBookValue: (depreciation.asset.cost - parseFloat(Amount)*(i+1)).toFixed(2),
                }
                setQueue(prevArray => [...prevArray, newElement]);
            }
        }
    }, [depreciation]);

    useEffect(() => {
        dispatch(getDepreciation({id: assetID}));
    }, []);

    return (
        <>
            <StaticTable
                columns={columns}
            >
                {queue?.map((data, index) => (
                <tr 
                    key={index} 
                    className=""
                >
                    <td className="py-1">{data.period}</td>
                    <td className="py-1">{data.bookValue} </td>
                    <td className="py-1">{data.depreciationPercentage} %</td>
                    <td className="py-1">{data.amount}</td>
                    <td className="py-1">{data.accumulatedDepreciation}</td>
                    <td className="py-1">{data.endingBookValue}</td>
                </tr>
                ))}
            </StaticTable>
            {!depreciation && (<p className="text-center">No record</p>)}

        </>
    );
};

export default Depreciation;
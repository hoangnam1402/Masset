import React from 'react';
import { LimitOptions } from '../../constants/selectOptions';

export type LimitType = {
    handleLimit: (e: any) => void;
    limit: number;
}

const Limit: React.FC<LimitType> = ({   handleLimit, limit }) => {
    return (
        <div className="d-flex align-items-center intro-x">
            <div className="d-flex justify-content-center">
                <p className="mr-2 mt-2 ml-3">Show</p>
                <div className="col">
                <select className="custom-select" onChange={handleLimit} defaultValue={limit}>
                    {
                    LimitOptions.map(({ id, label: optionLabel, value: optionValue }) => (
                        <option key={id} value={optionValue} selected = {optionValue == limit}>
                        {optionLabel}
                        </option>
                    ))
                    }
                </select>
                </div>
                <p className="mr-2 mt-2 ml-2">Items</p>
            </div>
        </div>
    )
};

export default Limit;
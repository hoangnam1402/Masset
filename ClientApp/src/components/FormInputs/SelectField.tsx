import React, { InputHTMLAttributes } from 'react';
import { useField } from 'formik';
import ISelectOption from '../../interfaces/ISelectOption';

type InputFieldProps = InputHTMLAttributes<HTMLInputElement> & {
    label: string;
    name: string;
    isrequired?: boolean;
    options: ISelectOption[];
};

const SelectField: React.FC<InputFieldProps> = (props) => {
    const [field, { value }, { setValue }] = useField(props);

    const { options, label, isrequired, defaultValue,disabled } = props;

    const handleChange = (e: any) => {
        setValue(e.target.value)
    };

    return (
        <>
            <div className="mb-3 row">
                <label className="col-4 col-form-label d-flex">
                    {label}
                    {isrequired && (
                        <div className="invalid ml-1">(*)</div>
                    )}
                </label>

                <div className="col">
                    <select className="custom-select" onChange={handleChange} defaultValue={defaultValue} disabled={disabled}>
                        <option selected hidden>Please select type</option>
                        {
                            options.map(({ id, label: optionLabel, value: optionValue }) => (
                                <option key={id} value={optionValue} selected = {optionValue == value}>
                                    {optionLabel}
                                </option>
                            ))
                        }
                    </select>
                </div>
            </div>
        </>
    );
};
export default SelectField;
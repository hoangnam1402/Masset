import React, { InputHTMLAttributes, useEffect } from 'react';
import { useField } from 'formik';
import { Search } from 'react-bootstrap-icons';

type InputFieldProps = InputHTMLAttributes<HTMLInputElement> & {
    defaultValue?: string;
    label: string;
    placeholder?: string;
    name: string;
    isrequired?: boolean|string;
    notvalidate?: boolean;
};

const ClickToShowField: React.FC<InputFieldProps> = (props) => {
    const [field, { error, touched }, meta] = useField(props);
    const { label, isrequired, notvalidate, defaultValue } = props;

    const validateClass = () => {
        if (touched && error) return 'is-invalid';
        if (notvalidate) return '';
        // if (isrequired && value) return 'is-invalid';
        // if (touched) return 'is-valid';
    };
    
    useEffect(() => {
        if(defaultValue){
            meta.setValue(defaultValue)
        }
    }, [])

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
                    <label className="d-flex border">
                        <input className={`input-with-icon form-control ${validateClass()}`} {...field} {...props}
                            onKeyDown={(e) => e.preventDefault()}/>
                        <div className="p-2"  style={{justifyContent: "space-around"}}>
                            <img src="/search-icon.png" alt="search-icon" className="icon" />
                            {/* <Search cursor="pointer" /> */}
                        </div>
                    </label>
                    {error && touched && (
                        <div className='invalid'>{error}</div>
                    )}
                </div>
            </div>

        </>
    );
};
export default ClickToShowField;

import React, { InputHTMLAttributes, useEffect } from 'react';
import { useField } from 'formik';
import 'bootstrap'

type InputFieldProps = InputHTMLAttributes<HTMLInputElement> & {
    defaultValue?: string;
    label: string;
    placeholder?: string;
    name: string;
    isrequired?: boolean;
    notvalidate?: boolean;
    endingText?: string;
};

const TextField: React.FC<InputFieldProps> = (props) => {
    const [field, { error, touched }, meta] = useField(props);
    const { label, isrequired, notvalidate, defaultValue, endingText } = props;

    const validateClass = () => {
        if (touched && error) return 'is-invalid';
        if (notvalidate) return '';
    };
    
    useEffect(() => {
        if(defaultValue){
            meta.setValue(defaultValue)
        }
    }, [])

    return (
            <div className="mb-3 row">
                <label className="col-4 col-form-label d-flex">
                    {label}
                    {isrequired && (
                        <div className="invalid ml-1">(*)</div>
                    )}
                </label>
                <div className="col input-group">
                    <input className={`form-control ${validateClass()}`} {...field} {...props}/>
                    {endingText && <div className="input-group-append">
                        <span className="input-group-text">{endingText}</span>
                    </div> }                   
                    {error && touched && (
                        <div className='invalid'>{error}</div>
                    )}
                </div>
            </div>
    );
};
export default TextField;

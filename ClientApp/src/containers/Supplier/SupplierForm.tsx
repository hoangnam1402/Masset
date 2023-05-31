import React, { useEffect, useState } from 'react';
import { Modal } from "react-bootstrap";
import { Formik, Form } from 'formik';
import * as Yup from 'yup';
import { XSquare } from "react-bootstrap-icons";
import { NotificationManager } from 'react-notifications';
import { useAppDispatch, useAppSelector } from '../../hooks/redux';
import { createSupplier, updateSupplier } from './reducer';
import TextField from '../../components/FormInputs/TextField';
import ISupplierForm from '../../interfaces/Supplier/ISupplierForm';
import ISupplier from '../../interfaces/Supplier/ISupplier';
import TextAreaField from '../../components/FormInputs/TextAreaField';
import SelectField from '../../components/FormInputs/SelectField';
import { CountryOption } from '../../constants/countryOptions';

const initialFormValues: ISupplierForm = {
    id: undefined,
    name:undefined,
    email:undefined,
    phone:undefined,
    city:undefined,
    country:undefined,
    address:undefined,
};

const validationSchema = Yup.object().shape({
    name: Yup.string().required('Required'),
    email: Yup.string().required('Required').email(),
    phone: Yup.string().required('Required'),
    city: Yup.string().required('Required'),
    country: Yup.string().required('Required'),
    address: Yup.string(),
});

type Props = {
    supplier: ISupplier | undefined;
    handleClose: () => void;
  };
  
const SupplierForm: React.FC<Props> = ({ supplier, handleClose }) => {
    const dispatch = useAppDispatch();
    const [loading, setLoading] = useState(false);
    
    const isUpdate = supplier ? true : false;
    const initialValues = supplier ? supplier : initialFormValues;

    const handleResult = (result: boolean, message: string) => {
        if (result) {
            NotificationManager.success(
                `${isUpdate ? 'Updated' : 'Created'} Successful Supplier ${message}`,
                `${isUpdate ? 'Update' : 'Create'} Successful`,
                handleClose(),
                2000,
            );

            setTimeout(() => {
            }, 1000);

        } else {
            NotificationManager.error(message, 'Create failed', 2000);
        }
    }

    return (
        <>
        <Modal
            id='big-dialog-modal'
            show={true}
            onHide={handleClose}
            size='lg'
            dialogClassName="modal-dialog-centered" 
        >
            <Modal.Header className="align-items-center headerModal">
            {isUpdate && (<Modal.Title id="detail-modal" className="primaryColor">
                Edit Supplier
            </Modal.Title>)}
            {!isUpdate && (<Modal.Title id="detail-modal" className="primaryColor">
                Create Supplier
            </Modal.Title>)}
            <XSquare
                onClick={handleClose}
                className="primaryColor model-closeIcon"
            />
            </Modal.Header>

            <Modal.Body className="bodyModal">
                <Formik
                initialValues={initialValues}
                enableReinitialize
                validationSchema={validationSchema}
                validateOnMount={true}
                onSubmit={(values) => {
                    setLoading(true);

                    setTimeout(() => {
                        if (isUpdate) {
                            dispatch(updateSupplier({ handleResult, formValues: values }));
                        }
                        else {
                            dispatch(createSupplier({ handleResult, formValues: values }));
                        }
    
                        setLoading(false);
                    }, 1000);
                }}
                    >
                {({isValid}) => (
                    <Form className="intro-y col-lg-12 col-12">
                        <TextField id="name"
                            name="name" 
                            label="Name" 
                            isrequired={true}/>
                        <TextField id="email"
                            name="email" 
                            label="Email" 
                            isrequired={true}/>
                        <TextField id="phone"
                            name="phone" 
                            label="Phone" 
                            isrequired={true}/>
                        <TextField id="city"
                            name="city" 
                            label="City" 
                            isrequired={true}/>
                        <SelectField id="country"
                            name="country" 
                            label="Country" 
                            isrequired={true}
                            options={CountryOption}  
                            defaultValue={isUpdate ? initialFormValues.country : 0}/>
                        <TextAreaField id='address'
                            name="address"
                            label="Address"
                            isrequired={false} />

                        <div className="text-center mt-3 float-right">
                            <button
                            className="btn btn-danger mr-3"
                            type="submit"
                            disabled={(!isValid||loading)}
                            >
                                Save {(loading) && <img src="/oval.svg" className='w-4 h-4 ml-2 inline-block' />}
                            </button>
                            <button
                            className="btn btn-outline-secondary"
                            onClick={handleClose}
                            type="button"
                            >
                                Close
                            </button>
                        </div>
                    </Form>
                )}
                </Formik>
            </Modal.Body>
        </Modal>
        </>
    );
};

export default SupplierForm;

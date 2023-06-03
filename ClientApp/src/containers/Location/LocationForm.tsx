import React, { useEffect, useState } from 'react';
import { Modal } from "react-bootstrap";
import { Formik, Form } from 'formik';
import * as Yup from 'yup';
import { XSquare } from "react-bootstrap-icons";
import { NotificationManager } from 'react-notifications';
import { useAppDispatch, useAppSelector } from '../../hooks/redux';
import { createLocation, updateLocation } from './reducer';
import TextField from '../../components/FormInputs/TextField';
import ILocationForm from '../../interfaces/Location/ILocationForm';
import ILocation from '../../interfaces/Location/ILocation';
import TextAreaField from '../../components/FormInputs/TextAreaField';

const initialFormValues: ILocationForm = {
    id: undefined,
    name:undefined,
    description:undefined,
};

const validationSchema = Yup.object().shape({
    name: Yup.string().required('Required'),
    description: Yup.string(),
});

type Props = {
    location: ILocation | undefined;
    handleClose: () => void;
  };
  
const LocationForm: React.FC<Props> = ({ location, handleClose }) => {
    const dispatch = useAppDispatch();
    const [loading, setLoading] = useState(false);
    
    const isUpdate = location ? true : false;
    const initialValues = location ? location : initialFormValues;

    const handleResult = (result: boolean, message: string) => {
        if (result) {
            NotificationManager.success(
                `${isUpdate ? 'Updated' : 'Created'} Successful Location ${message}`,
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
            show={true}
            onHide={handleClose}
            size='lg'
            dialogClassName="modal-dialog-centered" 
        >
            <Modal.Header className="align-items-center headerModal">
            {isUpdate && (<Modal.Title id="detail-modal" className="primaryColor">
                Edit Location
            </Modal.Title>)}
            {!isUpdate && (<Modal.Title id="detail-modal" className="primaryColor">
                Create Location
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
                            dispatch(updateLocation({ handleResult, formValues: values }));
                        }
                        else {
                            dispatch(createLocation({ handleResult, formValues: values }));
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
                        <TextAreaField id='description'
                            name="description"
                            label="Description"
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

export default LocationForm;

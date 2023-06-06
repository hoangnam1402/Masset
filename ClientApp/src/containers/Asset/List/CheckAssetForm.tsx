import React, { useEffect, useState } from 'react';
import { Modal } from "react-bootstrap";
import { Formik, Form } from 'formik';
import * as Yup from 'yup';
import { XSquare } from "react-bootstrap-icons";
import IAsset from "../../../interfaces/Asset/IAsset";
import { NotificationManager } from 'react-notifications';
import TextField from '../../../components/FormInputs/TextField';
import DateField from '../../../components/FormInputs/DateField';
import SelectField from '../../../components/FormInputs/SelectField';
import { useAppDispatch, useAppSelector } from '../../../hooks/redux';
import { getAssetCheckIn, getUsers, getAssetCheckOut } from '../reducer';
import createSelectOption from '../../../utils/createSelectOption';
import ISelectOption from '../../../interfaces/ISelectOption';
import ICheckingFrom from '../../../interfaces/Checking/ICheckingFrom';

const initialFormValues: ICheckingFrom = {
    userID:undefined,
    assetID:undefined,
    componentID:undefined,
    quantity:undefined,
    checkDay:undefined,
    isCheckOut:false,
};

const validationForCheckOutSchema = Yup.object().shape({
    userID: Yup.string().required('Required'),
    assetID: Yup.string().required('Required'),
    checkDay: Yup.date().nullable().required('Required'),
});

const validationForCheckInSchema = Yup.object().shape({
    assetID: Yup.string().required('Required'),
    checkDay: Yup.date().nullable().required('Required'),
});

type Props = {
    asset: IAsset;
    isCheckOut: boolean;
    handleClose: () => void;
  };
  
const CheckAssetForm: React.FC<Props> = ({ asset, handleClose, isCheckOut }) => {
    const dispatch = useAppDispatch();
    const [loading, setLoading] = useState(false);

    const fetchData = () => {
        dispatch(getUsers());
    };
    
    useEffect(() => {
        fetchData();
    }, []);

    const { users } = useAppSelector(
        (state) => state.assetReducer
      );

    const userList = createSelectOption(users);

    userList.shift();

    const userSelectOptions: ISelectOption[] = userList;

    initialFormValues.assetID = asset.id;
    initialFormValues.isCheckOut = isCheckOut;

    const handleResult = (result: boolean, message: string) => {
        if (result) {
            NotificationManager.success(
                `${isCheckOut ? 'Check Out' : 'Check In'} Successful Asset ${message}`,
                `${isCheckOut ? 'Check Out' : 'Check In'} Successful`,
                handleClose(),
                2000,
            );

            setTimeout(() => {
            }, 1000);

        } else {
            NotificationManager.error(
                message, 
                `${isCheckOut ? 'Check Out' : 'Check In'} Faile`,
                2000);
        }
    }

    return (
        <>
        <Modal
            show={true}
            onHide={handleClose}
            size='lg'
        >
            <Modal.Header className="align-items-center headerModal">
            {isCheckOut && (<Modal.Title id="detail-modal" className="primaryColor">
                Check Out
            </Modal.Title>)}
            {!isCheckOut && (<Modal.Title id="detail-modal" className="primaryColor">
                Check In
            </Modal.Title>)}
            <XSquare
                onClick={handleClose}
                className="primaryColor model-closeIcon"
            />
            </Modal.Header>

            <Modal.Body className="bodyModal">
                <Formik
                initialValues={initialFormValues}
                enableReinitialize
                validationSchema={isCheckOut ? validationForCheckOutSchema : validationForCheckInSchema}
                validateOnMount={true}
                onSubmit={(values) => {
                    setLoading(true);

                    setTimeout(() => {
                        if (isCheckOut) {
                            dispatch(getAssetCheckOut({ handleResult, formValues: values }));
                        }
                        else {
                            dispatch(getAssetCheckIn({ handleResult, formValues: values }));
                        }
    
                        setLoading(false);
                    }, 1000);
                }}
                    >
                {({isValid}) => (
                    <Form className="intro-y col-lg-12 col-12">
                        <TextField id="tag"
                            name="tag" 
                            label="Asset Tag" 
                            defaultValue={asset?.tag}
                            disabled={true}/>
                        <TextField id="name"
                            name="name" 
                            label="Name"
                            disabled={true}
                            defaultValue={asset?.name}/>
                        { isCheckOut && <SelectField id="userID"
                            name="userID"
                            label="Checkout to"
                            isrequired={true}
                            options={userSelectOptions}  
                            defaultValue={0}/>}
                        <DateField id='checkDay'
                            name="checkDay"
                            label="Check day"
                            isrequired={true} />

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

export default CheckAssetForm;

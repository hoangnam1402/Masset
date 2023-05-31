import React, { useEffect, useState } from 'react';
import { Modal } from "react-bootstrap";
import { Formik, Form } from 'formik';
import * as Yup from 'yup';
import { XSquare } from "react-bootstrap-icons";
import IAsset from "../../interfaces/Asset/IAsset";
import { NotificationManager } from 'react-notifications';
import TextField from '../../components/FormInputs/TextField';
import DateField from '../../components/FormInputs/DateField';
import SelectField from '../../components/FormInputs/SelectField';
import { useAppDispatch, useAppSelector } from '../../hooks/redux';
import { getAssets, getCheckOut, getCheckIn } from './reducer';
import createSelectOption from '../../utils/createSelectOption';
import ISelectOption from '../../interfaces/ISelectOption';
import ICheckingFrom from '../../interfaces/Checking/ICheckingFrom';
import IComponent from '../../interfaces/Component/IComponent';
import IChecking from '../../interfaces/Checking/IChecking';

const initialFormValues: ICheckingFrom = {
    userID:undefined,
    assetID:undefined,
    componentID:undefined,
    quantity:undefined,
    checkDay:undefined,
    isCheckOut:false,
};

type Props = {
    component: IComponent;
    isCheckOut: boolean;
    checking: IChecking | undefined;
    handleClose: () => void;
  };
  
const CheckComponentForm: React.FC<Props> = ({ component, handleClose, isCheckOut, checking }) => {
    const dispatch = useAppDispatch();
    const [loading, setLoading] = useState(false);

    const validationForCheckOutSchema = Yup.object().shape({
        assetID: Yup.string().required('Required'),
        quantity: Yup.string().required('Required').max(component.availableQuantity).min(1),
        checkDay: Yup.date().nullable().required('Required'),
    });
    
    const validationForCheckInSchema = Yup.object().shape({
        checkDay: Yup.date().nullable().required('Required'),
        quantity: Yup.string().required('Required').max(checking ? checking.quantity : 100).min(1),
    });

    const fetchData = () => {
        dispatch(getAssets());
    };
    
    useEffect(() => {
        fetchData();
    }, []);

    const { assets } = useAppSelector(
        (state) => state.componentReducer
      );

    const assetList = createSelectOption(assets);

    assetList.shift();

    const assetSelectOptions: ISelectOption[] = assetList;

    initialFormValues.componentID = component?.id;
    initialFormValues.isCheckOut = isCheckOut;

    const handleResult = (result: boolean, message: string) => {
        if (result) {
            NotificationManager.success(
                `${isCheckOut ? 'Check Out' : 'Check In'} Successful for Asset ${message}`,
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
            {isCheckOut == true && (<Modal.Title id="detail-modal" className="primaryColor">
                Check Out
            </Modal.Title>)}
            {isCheckOut == false && (<Modal.Title id="detail-modal" className="primaryColor">
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
                            dispatch(getCheckOut({ handleResult, formValues: values }));
                        }
                        else {
                            dispatch(getCheckIn({ handleResult, formValues: values }));
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
                            disabled={true}
                            defaultValue={component?.name}/>
                        { isCheckOut && <SelectField id="assetID"
                            name="assetID"
                            label="Checkout to"
                            isrequired={true}
                            options={assetSelectOptions}  
                            defaultValue={0}/>}
                        <TextField id="quantity"
                            name="quantity" 
                            label="Quantity"
                            isrequired={true}/>
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

export default CheckComponentForm;

import React, { useEffect, useState } from 'react';
import { Modal } from "react-bootstrap";
import { Formik, Form } from 'formik';
import * as Yup from 'yup';
import { XSquare } from "react-bootstrap-icons";
import { NotificationManager } from 'react-notifications';
import TextField from '../../../components/FormInputs/TextField';
import DateField from '../../../components/FormInputs/DateField';
import SelectField from '../../../components/FormInputs/SelectField';
import { useAppDispatch, useAppSelector } from '../../../hooks/redux';
import { createComponent, getAssetTypes, getBrands, getLocations, getSuppliers, updateComponent } from '../reducer';
import IComponentForm from '../../../interfaces/Component/IComponentForm';
import TextAreaField from '../../../components/FormInputs/TextAreaField';
import { AssetStateOptions } from "../../../constants/selectOptions";
import createSelectOption from '../../../utils/createSelectOption';
import ISelectOption from '../../../interfaces/ISelectOption';
import IComponent from '../../../interfaces/Component/IComponent';

const initialFormValues: IComponentForm = {
    name: "",
    supplierID:undefined,
    locationID:undefined,
    brandID:undefined,
    serial:undefined,
    typeID:undefined,
    cost:undefined,
    status:undefined,
    warranty:undefined,
    description:undefined,
    purchaseDay:undefined,
    quantity:undefined,
};

const validationSchema = Yup.object().shape({
    name: Yup.string().required('Required'),
    quantity: Yup.string().required('Required'),
    supplierID: Yup.string().required('Required'),
    brandID: Yup.string().required('Required'),
    locationID: Yup.string().required('Required'),
    typeID: Yup.string().required('Required'),
    serial: Yup.string().required('Required'),
    cost: Yup.number().typeError("Number only").required('Required'),
    warranty: Yup.string().required('Required'),
    description: Yup.string(),
    status: Yup.string().required('Required'),
    purchaseDay: Yup.date().nullable().required('Required'),
});

type Props = {
    component: IComponent | undefined;
    handleClose: () => void;
  };
  
const ComponentForm: React.FC<Props> = ({ component, handleClose }) => {
    const dispatch = useAppDispatch();
    const [loading, setLoading] = useState(false);
    const { setting } = useAppSelector((state) => state.settingReducer);

    const fetchData = () => {
        dispatch(getAssetTypes());
        dispatch(getBrands());
        dispatch(getLocations());
        dispatch(getSuppliers());
    };
    
    useEffect(() => {
        fetchData();
    }, []);

    const { assetTypes, locations, brands, suppliers } = useAppSelector(
        (state) => state.componentReducer
      );

    const typeList = createSelectOption(assetTypes);
    const locationList = createSelectOption(locations);
    const brandList = createSelectOption(brands);
    const supplierList = createSelectOption(suppliers);

    typeList.shift();
    locationList.shift();
    brandList.shift();
    supplierList.shift();

    const typeSelectOptions: ISelectOption[] = typeList;
    const locationSelectOptions: ISelectOption[] = locationList;
    const brandSelectOptions: ISelectOption[] = brandList;
    const supplierSelectOptions: ISelectOption[] = supplierList;

    const isUpdate = component ? true : false;
    const initialComponentValues = component ? component : initialFormValues;

    const handleResult = (result: boolean, message: string) => {
        if (result) {
            NotificationManager.success(
                `${isUpdate ? 'Updated' : 'Created'} Successful Component ${message}`,
                `${isUpdate ? 'Update' : 'Create'} Successful`,
                handleClose(),
                2000,
            );
        } else {
            NotificationManager.error(message, 'Create failed', 2000);
            setLoading(false);
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
            {isUpdate === true && (<Modal.Title id="detail-modal" className="primaryColor">
                Edit Component
            </Modal.Title>)}
            {isUpdate === false && (<Modal.Title id="detail-modal" className="primaryColor">
                Create Component
            </Modal.Title>)}
            <XSquare
                onClick={handleClose}
                className="primaryColor model-closeIcon"
            />
            </Modal.Header>

            <Modal.Body className="bodyModal">
                <Formik
                initialValues={initialComponentValues}
                enableReinitialize
                validationSchema={validationSchema}
                validateOnMount={true}
                onSubmit={(values) => {
                    setLoading(true);

                    setTimeout(() => {
                        if (isUpdate) {
                            dispatch(updateComponent({ handleResult, formValues: values }));
                        }
                        else {
                            dispatch(createComponent({ handleResult, formValues: values }));
                        }
                    }, 1000);
                }}
                    >
                {({isValid}) => (
                    <Form className="intro-y col-lg-12 col-12">
                        <TextField id="name"
                            name="name" 
                            label="Name" 
                            isrequired={true}/>
                        <TextField id="serial"
                            name="serial" 
                            label="Serial" 
                            isrequired={true}/>
                        <TextField id="quantity"
                            name="quantity" 
                            label="Quantity" 
                            isrequired={true}/>
                        <SelectField id="typeID"
                            name="typeID"
                            label="Component type"
                            isrequired={true}
                            options={typeSelectOptions}  
                            defaultValue={isUpdate ? initialFormValues.typeID : 0}/>
                        <SelectField id="supplierID"
                            name="supplierID"
                            label="Supplier"
                            isrequired={true}
                            options={supplierSelectOptions}  
                            defaultValue={isUpdate ? initialFormValues.supplierID : 0}/>
                        <SelectField id="locationID"
                            name="locationID"
                            label="Location"
                            isrequired={true}
                            options={locationSelectOptions}  
                            defaultValue={isUpdate ? initialFormValues.locationID : 0}/>
                        <SelectField id="brandID"
                            name="brandID"
                            label="Brand"
                            isrequired={true}
                            options={brandSelectOptions}  
                            defaultValue={isUpdate ? initialFormValues.brandID : 0}/>
                        <TextField id="cost"
                            name="cost" 
                            label="Cost" 
                            endingText={setting?.currency}
                            isrequired={true}/>
                        <DateField id='purchaseDay'
                            name="purchaseDay"
                            label="Purchase day"
                            isrequired={true} />
                        <TextField id="warranty"
                            name="warranty" 
                            label="Warranty" 
                            endingText="Month(s)"
                            isrequired={true}/>
                        <SelectField id="status"
                            name="status"
                            label="Status"
                            isrequired={true}
                            options={AssetStateOptions}  
                            defaultValue={isUpdate ? initialFormValues.status : 0}/>
                        <TextAreaField id="description"
                            name="description" 
                            isrequired={isUpdate ? true : false}
                            label="Description"/>

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

export default ComponentForm;

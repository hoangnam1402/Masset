import React, { useEffect, useState } from 'react';
import { Modal } from "react-bootstrap";
import { Formik, Form } from 'formik';
import * as Yup from 'yup';
import { XSquare } from "react-bootstrap-icons";
import { NotificationManager } from 'react-notifications';
import DateField from '../../components/FormInputs/DateField';
import SelectField from '../../components/FormInputs/SelectField';
import { useAppDispatch, useAppSelector } from '../../hooks/redux';
import { getAssets, getSuppliers, createMaintenance, updateMaintenance } from './reducer';
import { MaintenanceTypeOption } from "../../constants/selectOptions";
import createSelectOption from '../../utils/createSelectOption';
import ISelectOption from '../../interfaces/ISelectOption';
import IMaintenance from '../../interfaces/Maintenance/IMaintenance';
import IMaintenanceForm from '../../interfaces/Maintenance/IMaintenanceForm';

const initialFormValues: IMaintenanceForm = {
    assetID:undefined,
    supplierID:undefined,
    type:undefined,
    startDate:undefined,
    endDate:undefined,
  };

const validationSchema = Yup.object().shape({
    assetID: Yup.string().required('Required'),
    type: Yup.string().required('Required'),
    supplierID: Yup.string().required('Required'),
    startDate: Yup.date().nullable().required('Required').test(
        'test-startDate', 
        'End Date must be greater than Start Date',
        function(value) {
            const { endDate } = this.parent;
            if (endDate)
                return endDate > value;
            return true
        }
    ),
    endDate: Yup.date().nullable().required('Required').test(
        'test-endDate', 
        'End Date must be greater than Start Date',
        function(value) {
            const { startDate } = this.parent;
            if (startDate)
                return startDate && value > startDate;
            return true;
        }
    ),
});

type Props = {
    maintenance: IMaintenance | undefined;
    handleClose: () => void;
  };
  
const MaintenanceForm: React.FC<Props> = ({ maintenance, handleClose }) => {
    const dispatch = useAppDispatch();
    const [loading, setLoading] = useState(false);

    const fetchData = () => {
        dispatch(getAssets());
        dispatch(getSuppliers());
    };
    
    useEffect(() => {
        fetchData();
    }, []);

    const { assets, suppliers } = useAppSelector(
        (state) => state.maintenenceReducer
      );

    const assetList = createSelectOption(assets);
    const supplierList = createSelectOption(suppliers);

    assetList.shift();
    supplierList.shift();

    const assetSelectOptions: ISelectOption[] = assetList;
    const supplierSelectOptions: ISelectOption[] = supplierList;

    const isUpdate = maintenance ? true : false;
    const initialValues = maintenance ? maintenance : initialFormValues;

    const handleResult = (result: boolean, message: string) => {
        if (result) {
            NotificationManager.success(
                `${isUpdate ? 'Updated' : 'Created'} Successful Maintenance ${message}`,
                `${isUpdate ? 'Update' : 'Create'} Successful`,
                handleClose(),
                2000,
            );
        } else {
            NotificationManager.error(message, `${isUpdate ? 'Update' : 'Create'} Failed`, 2000);
            setLoading(false);
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
                Edit Maintenance
            </Modal.Title>)}
            {!isUpdate && (<Modal.Title id="detail-modal" className="primaryColor">
                Create Maintenance
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
                            dispatch(updateMaintenance({ handleResult, formValues: values }));
                        }
                        else {
                            dispatch(createMaintenance({ handleResult, formValues: values }));
                        }
                    }, 1000);
                }}
                    >
                {({isValid}) => (
                    <Form className="intro-y col-lg-12 col-12">
                        <SelectField id="assetID"
                            name="assetID"
                            label="Property"
                            isrequired={true}
                            options={assetSelectOptions}  
                            defaultValue={isUpdate ? initialFormValues.assetID : 0}/>
                        <SelectField id="supplierID"
                            name="supplierID"
                            label="Supplier"
                            isrequired={true}
                            options={supplierSelectOptions}  
                            defaultValue={isUpdate ? initialFormValues.supplierID : 0}/>
                        <SelectField id="type"
                            name="type"
                            label="Type"
                            isrequired={true}
                            options={MaintenanceTypeOption}  
                            defaultValue={isUpdate ? initialFormValues.type : 0}/>
                        <DateField id='startDate'
                            name="startDate"
                            label="Start date"
                            isrequired={true} />
                        <DateField id='endDate'
                            name="endDate"
                            label="End date"
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

export default MaintenanceForm;

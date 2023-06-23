import React, { useEffect, useState } from 'react';
import { Modal } from "react-bootstrap";
import { Formik, Form } from 'formik';
import * as Yup from 'yup';
import { XSquare } from "react-bootstrap-icons";
import { NotificationManager } from 'react-notifications';
import SelectField from '../../components/FormInputs/SelectField';
import { useAppDispatch, useAppSelector } from '../../hooks/redux';
import { getAssets, getComponents, createDepreciation, updateDepreciation } from './reducer';
import { DepreciationCategoryOption } from "../../constants/selectOptions";
import createSelectOption from '../../utils/createSelectOption';
import ISelectOption from '../../interfaces/ISelectOption';
import IDepreciationForm from '../../interfaces/Depreciation/IDepreciationForm';
import IDepreciation from '../../interfaces/Depreciation/IDepreciation';
import TextField from '../../components/FormInputs/TextField';

const initialFormValues: IDepreciationForm = {
    id: undefined,
    category: undefined,
    assetID:undefined,
    componentID:undefined,
    period:undefined,
    value:undefined,
};

type Props = {
    depreciation: IDepreciation | undefined;
    handleClose: () => void;
  };
  
const DepreciationForm: React.FC<Props> = ({ depreciation, handleClose }) => {
    const dispatch = useAppDispatch();
    const [loading, setLoading] = useState(false);
    const { setting } = useAppSelector((state) => state.settingReducer);

    const fetchData = () => {
        dispatch(getAssets());
        dispatch(getComponents());
    };
    
    useEffect(() => {
        fetchData();
    }, []);
    
    const { assets, components } = useAppSelector(
        (state) => state.depreciationReducer
      );

      const validationSchema = Yup.object().shape({
        category: Yup.number().required('Required'),
        period: Yup.number().required('Required'),
        value: Yup.number().required('Required').test(
            'test-value', 
            'Input value is too large',
            function(value) {
                const { category, assetID, componentID } = this.parent;
                if (category === 1) {
                    return Yup.number().max((Number)(assets?.find(item => item.id === Number(assetID))?.cost)).isValidSync(value); 
                } else if (category === 2) {
                    return Yup.number().max((Number)(components?.find(item => item.id === Number(componentID))?.cost)).isValidSync(value); 
                } else {
                    return true;
                }
            }
        ),
        assetID: Yup.number().test('test-assetID', 'Required',
            function(value, context)
            {
                if (!value && context.parent.category === 1) {
                    return false;
                } else {
                    return true;
                }
            }
        ),
        componentID: Yup.number().test('test-componentID', 'Required',
        function(value, context)
        {
            if (!value && context.parent.category === 2) {
                return false;
            } else {
                return true;
            }
        }
    ),
    });

    const assetList = createSelectOption(assets);
    const componentList = createSelectOption(components);

    assetList.shift();
    componentList.shift();

    const assetSelectOptions: ISelectOption[] = assetList;
    const componentSelectOptions: ISelectOption[] = componentList;

    const isUpdate = depreciation ? true : false;
    const initialValues = depreciation ? depreciation : initialFormValues;

    const handleResult = (result: boolean, message: string) => {
        if (result) {
            NotificationManager.success(
                `${isUpdate ? 'Updated' : 'Created'} Successful Depreciation ${message}`,
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
            show={true}
            onHide={handleClose}
            size='lg'
            dialogClassName="modal-dialog-centered" 
        >
            <Modal.Header className="align-items-center headerModal">
            {isUpdate && (<Modal.Title id="detail-modal" className="primaryColor">
                Edit Depreciation
            </Modal.Title>)}
            {!isUpdate && (<Modal.Title id="detail-modal" className="primaryColor">
                Create Depreciation
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
                            dispatch(updateDepreciation({ handleResult, formValues: values }));
                        }
                        else {
                            if (values.category === 1) 
                            {
                                values.componentID = undefined;
                            } else {
                                values.assetID = undefined;
                            }
                            dispatch(createDepreciation({ handleResult, formValues: values }));
                        }
                    }, 1000);
                }}
                    >
                {({isValid, values}) => (
                    <Form className="intro-y col-lg-12 col-12">
                        <SelectField id="category"
                            name="category"
                            label="Category"
                            isrequired={true}
                            options={DepreciationCategoryOption}  
                            defaultValue={isUpdate ? initialFormValues.category : 0}/>
                        {values.category === 1 && <SelectField id="assetID"
                            name="assetID"
                            label="Property"
                            isrequired={true}
                            options={assetSelectOptions}  
                            defaultValue={isUpdate ? initialFormValues.assetID : values.assetID}/>}
                        {values.category === 2 && <SelectField id="componentID"
                            name="componentID"
                            label="Component"
                            isrequired={true}
                            options={componentSelectOptions}  
                            defaultValue={isUpdate ? initialFormValues.componentID : values.componentID}/>}
                        <TextField id="period"
                            name="period" 
                            endingText="Month(s)"
                            label="Period" 
                            isrequired={true}/>
                        <TextField id='value'
                            name="value"
                            label="Value"
                            endingText={setting?.currency}
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

export default DepreciationForm;

import React, { useEffect, useState } from 'react';
import { Modal } from "react-bootstrap";
import { Formik, Form } from 'formik';
import * as Yup from 'yup';
import { XSquare } from "react-bootstrap-icons";
import { NotificationManager } from 'react-notifications';
import { useAppDispatch, useAppSelector } from '../../hooks/redux';
import { createUser, updateUser } from './reducer';
import TextField from '../../components/FormInputs/TextField';
import IUserForm from '../../interfaces/User/IUserForm';
import IUser from '../../interfaces/User/IUser';
import SelectField from '../../components/FormInputs/SelectField';
import { UserRoleOptions } from '../../constants/selectOptions';

const initialFormValues: IUserForm = {
    id: undefined,
    userName:undefined,
    role: undefined,
    email: undefined,
    phoneNumber: undefined,
};

const validationSchema = Yup.object().shape({
    userName: Yup.string().required('Required'),
    role: Yup.string().required('Required'),
    email: Yup.string().required('Required'),
    phoneNumber: Yup.string().required('Required'),
});

type Props = {
    user: IUser | undefined;
    handleClose: () => void;
  };
  
const UserForm: React.FC<Props> = ({ user, handleClose }) => {
    const dispatch = useAppDispatch();
    const [loading, setLoading] = useState(false);
    const { account } = useAppSelector(state => state.authReducer);
    const isUpdate = user ? true : false;
    const initialValues = user ? user : initialFormValues;

    const handleResult = (result: boolean, message: string) => {
        if (result) {
            NotificationManager.success(
                `${isUpdate ? 'Updated' : 'Created'} Successful User ${message}`,
                `${isUpdate ? 'Update' : 'Create'} Successful`,
                handleClose(),
                2000,
            );
        } else {
            NotificationManager.error(message, `${isUpdate ? 'Update' : 'Create'} failed`, 2000);
            setLoading(false);
        };
    }

    useEffect(() => {
        if (account?.role == "manager")
            UserRoleOptions.shift();
    }, []);    

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
                Edit User
            </Modal.Title>)}
            {!isUpdate && (<Modal.Title id="detail-modal" className="primaryColor">
                Create User
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
                            dispatch(updateUser({ handleResult, formValues: values }));
                        }
                        else {
                            dispatch(createUser({ handleResult, formValues: values }));
                        }
                    }, 1000);
                }}
                    >
                {({isValid}) => (
                    <Form className="intro-y col-lg-12 col-12">
                        <TextField id="userName"
                            name="userName" 
                            label="User Name" 
                            isrequired={true}/>
                        <SelectField id="role"
                            name="role"
                            label="Role"
                            isrequired={true}
                            options={UserRoleOptions}  
                            defaultValue={isUpdate ? initialFormValues.role : 0}/>                            
                        <TextField id="email"
                            name="email" 
                            label="Email" 
                            isrequired={true}/>
                        <TextField id="phoneNumber"
                            name="phoneNumber" 
                            label="Phone Number" 
                            isrequired={true}/>

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

export default UserForm;

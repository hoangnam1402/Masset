import React, { useEffect, useState } from "react";
import { useAppDispatch, useAppSelector } from "../../hooks/redux";
import { getSetting, updateSetting, updateLogo } from "./reducer";
import * as Yup from 'yup';
import { NotificationManager } from 'react-notifications';
import { Form, Formik } from "formik";
import TextField from "../../components/FormInputs/TextField";
import TextAreaField from "../../components/FormInputs/TextAreaField";
import ISettingForm from "../../interfaces/Setting/ISettingForm";

const Setting = () => {
  const { account } = useAppSelector((state) => state.authReducer);
  const { setting } = useAppSelector((state) => state.settingReducer);
  const [loading, setLoading] = useState(false);
  const [selectedFile, setSelectedFile] = useState<File>();
  const dispatch = useAppDispatch();

  const initialFormValues: ISettingForm = {
    id: setting?.id,
    name: setting?.name,
    address: setting?.address,
    email: setting?.email,
    phone: setting?.phone,
    image:undefined,
  };

  const validationSchema = Yup.object().shape({
    name: Yup.string().required('Required'),
    address: Yup.string().required('Required'),
    email: Yup.string().required('Required'),
    phone: Yup.string().required('Required'),
  });

  const fetchData = () => {
    dispatch(getSetting());
  };

  const handleResult = (result: boolean, message: string) => {
    if (result) {
        NotificationManager.success(
          'Update Successful',
          fetchData,
          2000,
        );

        setTimeout(() => {
        }, 1000);

    } else {
        NotificationManager.error(message, 'Update failed', 2000);
    }
  }

  return (
    <>
      <div className="primaryColor text-title intro-x">Setting</div>

      <Formik
        initialValues={initialFormValues}
        enableReinitialize
        validationSchema={validationSchema}
        validateOnMount={true}
        onSubmit={(values) => {
          setLoading(true);
          setTimeout(() => {
            if (selectedFile)
            {
              dispatch(updateLogo(selectedFile));
            }
            dispatch(updateSetting({ handleResult, formValues: values }));
            setLoading(false);
          }, 1000);
        }}
      >
      {({isValid}) => (
        <Form className="intro-y col-lg-12 col-12">
          <TextField id="name"
            name="name" 
            label="Name" />
          <TextField id="email"
            name="email" 
            label="Email" />
          <TextField id="phone"
            name="phone" 
            label="Phone" />
          <TextAreaField id='address'
            name="address"
            label="Address"/>
          <div className="mb-3 row">
            <label className="col-4 col-form-label d-flex">
                Logo
            </label>
            <div className="col">
              <input className={`form-control`} name="image" type="file" onChange={(e) => {
              const input = e.target as HTMLInputElement;
              if (input.files && input.files[0])
                setSelectedFile(input.files[0])}} />
            </div>
          </div>

          <div className="text-center mt-3 float-right">
            <button
            className="btn btn-danger mr-3"
            type="submit"
            disabled={(!isValid||loading||account?.role != 'Admin')}
            >
              Update {(loading) && <img src="/oval.svg" className='w-4 h-4 ml-2 inline-block' />}
            </button>
          </div>
        </Form>
      )}
      </Formik>
    </>
  );
};

export default Setting;

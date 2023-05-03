import React, { InputHTMLAttributes, useEffect, useState } from "react";
import { useField } from "formik";
import { EyeFill, EyeSlashFill } from "react-bootstrap-icons";
type PasswordFieldProps = InputHTMLAttributes<HTMLInputElement> & {
	label: string;
	placeholder?: string;
	name: string;
	isrequired?: boolean | string;
	notvalidate?: boolean;
};

const PasswordField: React.FC<PasswordFieldProps> = (props) => {
	const [field, { error, touched }, meta] = useField(props);
	const { label, isrequired, notvalidate } = props;
	const [passwordShown, setPasswordShown] = useState(false);
	const eye = passwordShown ? <EyeFill /> : <EyeSlashFill />;
	const togglePasswordVisibility = () => {
		setPasswordShown(passwordShown ? false : true);
	};
	const validateClass = () => {
		if (touched && error) return "is-invalid";
		if (notvalidate) return "";

		return "";
	};

	return (
		<>
			<div className="mb-3 row">
				<label className="col-4 col-form-label d-flex">
					{label}
					{isrequired && <div className="invalid ml-1">(*)</div>}
				</label>
				<div className="col">
					<div className="pass-wrapper">
						<input
							type={passwordShown ? "text" : "password"}
							className={`form-control ${validateClass()}`}
							{...field}
							{...props}
						/>
						{error && touched && <div className="invalid">{error}</div>}
						<i className="iconPassEye" onClick={togglePasswordVisibility}>{eye}</i>
					</div>
				</div>
			</div>
		</>
	);
};
export default PasswordField;

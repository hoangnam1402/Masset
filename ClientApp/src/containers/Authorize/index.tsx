import React, { useEffect, useState } from "react";
import { Card, Modal } from "react-bootstrap";
import { Form, Formik } from "formik";
import Header from "../Layout/Header";
import TextField from "../../components/FormInputs/TextField";
import ILoginModel from "../../interfaces/ILoginModel";
import { useAppDispatch, useAppSelector } from "../../hooks/redux";
import { changePassword, cleanUp, login, logout } from "./reducer";
import { useNavigate } from "react-router-dom";
import IChangePassword from "../../interfaces/IChangePassword";
import ErrorMessage from "../../constants/errorMessage";
import PasswordField from "../../components/FormInputs/PasswordField";
import { DASHBOARD } from "../../constants/pages";

const initialValues: ILoginModel = {
	userName: "",
	password: "",
};

const Login = () => {
	const [username, setUsername] = useState("");
	const [pass, setPass] = useState("");
	const [newpass, setNewPass] = useState("");
	const dispatch = useAppDispatch();
	const { loading, error, isAuth, account } = useAppSelector(
		(state) => state.authReducer,
	);
	const history = useNavigate();
	const [isShow, setShow] = useState(false);
	const [notification, setNotification] = useState("");
	const [notificationNewPass, setNotificationNewPass] = useState("");

	useEffect(() => {
		return () => {
			dispatch(cleanUp());
		};
	}, []);

	const SubmitButton = () => {
		if (username && pass) {
			return false;
		} else {
			return true;
		}
	};

	const SubmitButtonNewPass = () => {
		return newpass ? false : true;
	};
	const handleShow = () => {
		setShow(true);
		setNotificationNewPass("");
	};
	useEffect(() => {
		if (isAuth) {
			if (account?.firstLogin) {
				handleShow();
			} else if (!(account?.isActive)) {
				setNotification(ErrorMessage.DisableAccount);
				dispatch(logout());
			} else if (account?.error) {
				if (account.message == ErrorMessage.WrongPassword) {
					setNotification(ErrorMessage.WrongPassword);
					dispatch(logout());
				}
				if (account.message == ErrorMessage.SamePassword) {
					setNotificationNewPass(ErrorMessage.SamePassword);
				}
			} else {
				history(DASHBOARD);
			}
		}
	}, [isAuth, account]);

	return (
		<>
			<Header></Header>
			<div className="container d-flex justify-content-center flex-column align-items-center mt-5">
				<Card>
					<Card.Header className="text-monospace text-center lead text-danger font-weight-bold">
						Welcome to Masset
					</Card.Header>
					<Card.Body>
						<p className="lead text-danger text-center">
							{notification.length > 0 ? notification : ""}
						</p>
						<Formik
							initialValues={initialValues}
							enableReinitialize
							onSubmit={(values) => {
								const a: any = {
									password: pass,
									userName: username,
								};
								dispatch(login(a));
							}}
						>
							{(actions) => (
								<Form className="intro-y">
									<TextField
										name="userName"
										label="Username"
										isrequired="true"
										onChange={(e) => setUsername(e.target.value)}
										value={username}
									/>
									<PasswordField
										name="password"
										label="Password"
										isrequired="true"
										onChange={(e) => setPass(e.target.value)}
										value={pass}
									/>

									{error?.error && (
										<div className="invalid">{error.message}</div>
									)}
									<button
										className="btn btn-danger w-25 float-right"
										type="submit"
										disabled={SubmitButton()}
									>
										Login
									</button>
								</Form>
							)}
						</Formik>
					</Card.Body>
				</Card>
			</div>

			<div className="container">
				<Modal
					show={isShow}
					dialogClassName="modal-90w"
					aria-labelledby="login-modal"
				>
					<Card>
						<Card.Header className="text-monospace lead text-danger font-weight-bold">
							Change password
						</Card.Header>
						<Card.Body>
							<Card.Text>
								This is the first time you logged in.
								<br />
								You have to change your password to continue
								<br />
								<p className="lead text-danger text-center">
									{notificationNewPass.length > 0 ? notificationNewPass : ""}
								</p>
							</Card.Text>

							<Formik
								initialValues={initialValues}
								enableReinitialize
								onSubmit={(values, actions) => {
									if (newpass.length < 5) {
										setNotificationNewPass("Password min length 5 characters");
										return;
									}
									const a: IChangePassword = {
										currentPassword: pass,
										newPassword: newpass,
									};
									dispatch(changePassword(a));
								}}
							>
								{(actions) => (
									<Form className="intro-y">
										<PasswordField
											name="newPassword"
											label="New password"
											isrequired="true"
											onChange={(e) => setNewPass(e.target.value)}
										/>

										{error?.error && (
											<div className="invalid">{error.message}</div>
										)}
										<button
											className="btn btn-danger w-25 float-right"
											type="submit"
											disabled={SubmitButtonNewPass()}
										>
											Save
										</button>
									</Form>
								)}
							</Formik>
						</Card.Body>
					</Card>
				</Modal>
			</div>
		</>
	);
};

export default Login;

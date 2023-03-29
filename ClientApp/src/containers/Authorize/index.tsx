import React, { useEffect, useState } from "react";
import { Checkbox, Button, Modal, Form, Input } from "antd";
import { Formik } from "formik";
import Header from "../Layout/Header";
import ILoginModel from "../../interfaces/ILoginModel";
import { useAppDispatch, useAppSelector } from "../../hooks/redux";
import { changePassword, cleanUp, login, logout } from "./reducer";
import { useNavigate } from "react-router-dom";
import IChangePassword from "../../interfaces/IChangePassword";
import ErrorMessage from "../../constants/errorMessage";
import { HOME } from "../../constants/pages";

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
	const onFinish = (values : ILoginModel) => {
		dispatch(login(values));
	};
	useEffect(() => {
		if (isAuth) {
			if (account?.firstLogin) {
				handleShow();
			} else if (account?.isActive) {
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
				history(HOME);
			}
		}
	}, [isAuth, account]);

	return (
		<>
			<Header></Header>
			<Form
				name="basic"
				labelCol={{
				span: 8,
				}}
				wrapperCol={{
				span: 16,
				}}
				style={{
				maxWidth: 600,
				}}
				initialValues={{
				remember: true,
				}}
				onFinish={onFinish}
				autoComplete="off"
			>
				<Form.Item
					label="Username"
					name="username"
					rules={[
						{
						required: true,
						message: 'Please input your username!',
						},
					]}
				>
					<Input />
				</Form.Item>

				<Form.Item
					label="Password"
					name="password"
					rules={[
						{
						required: true,
						message: 'Please input your password!',
						},
					]}
				>
					<Input.Password />
				</Form.Item>

				<Form.Item
					name="remember"
					valuePropName="checked"
					wrapperCol={{
						offset: 8,
						span: 16,
					}}
				>
				<Checkbox>Remember me</Checkbox>
				</Form.Item>

				<Form.Item
					wrapperCol={{
						offset: 8,
						span: 16,
					}}
				>
				<Button type="primary" htmlType="submit" disabled={SubmitButton()}>
					Save
				</Button>
				</Form.Item>
			</Form>
		</>
	);
};

export default Login;

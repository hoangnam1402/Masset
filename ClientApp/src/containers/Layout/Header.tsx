import React, { useState, useEffect } from "react";
import { Dropdown, Modal, Card } from "react-bootstrap";
import { useNavigate, useLocation } from "react-router-dom";
import { Form, Formik } from "formik";
import ConfirmModal from "../../components/ConfirmModal";
import { DASHBOARD } from "../../constants/pages";
import { useAppDispatch, useAppSelector } from "../../hooks/redux";
import { logout, changePassword } from "../Authorize/reducer";
import IChangePassword from "../../interfaces/IChangePassword";
import PasswordField from "../../components/FormInputs/PasswordField";
import { getSetting } from "../Setting/reducer";

// eslint-disable-next-line react/display-name
const CustomToggle = React.forwardRef<any, any>(
  ({ children, onClick }, ref): any => (
    <a
      className="btn btn-link dropdownButton"
      ref={ref as any}
      onClick={(e) => {
        e.preventDefault();
        onClick(e);
      }}
    >
      {children} <span>&#x25bc;</span>
    </a>
  )
);

const initialChangePasswordValues: IChangePassword = {
	currentPassword: "",
	newPassword: "",
};

const Header = () => {
  const history = useNavigate();
  const { pathname } = useLocation();
  const { error, account } = useAppSelector((state) => state.authReducer);
  const dispatch = useAppDispatch();

  const [showModalChangePasswod, setShowModalChangePasswod] = useState(false);
  const [showConfirmLogout, setShowConfirmLogout] = useState(false);
  const [notificationNewPass, setNotificationNewPass] = useState("");
  const [newpass, setNewPass] = useState("");
  const [pass, setPass] = useState("");

  const headerName = () => {
    const pathnameSplit = pathname.split("/");
    pathnameSplit.shift();
    if (pathnameSplit.join(" > ").toString() === "login") {
      return "Masset";
    }
    return pathnameSplit.join(" > ").toString() || "Dashboard";
  };

  const openChangePasswordModal = () => {
    setShowModalChangePasswod(true);
    setNotificationNewPass("");
    setPass("");
		setNewPass("");
  };

  const handleChange = () => {
		return (newpass && pass) ? false : true;
  };

  const handleCanceChange = () =>{
    setShowModalChangePasswod(false);
  }

  const handleLogout = () => {
    setShowConfirmLogout(true);
  };

  const handleCancleLogout = () => {
    setShowConfirmLogout(false);
  };

  const handleConfirmedLogout = () => {
    history(DASHBOARD);
    dispatch(logout());
  };

  useEffect(() => {
    if (!account) {
      handleConfirmedLogout();
    }
    if (account) {
      dispatch(getSetting());
    }
  }, [] );

  return (
    <>
      <div className="header align-items-center font-weight-bold">
        <div className="container-lg-min container-fluid d-flex pt-2">
          <p className="headText">{`${headerName()}`}</p>

          <div className="ml-auto text-white">
            {account && (
              <Dropdown>
                <Dropdown.Toggle as={CustomToggle}>
                  {account?.userName}
                </Dropdown.Toggle>

                <Dropdown.Menu>
                  <Dropdown.Item onClick={openChangePasswordModal}>Change Password</Dropdown.Item>
                  <Dropdown.Item onClick={handleLogout}>Logout</Dropdown.Item>
                </Dropdown.Menu>
              </Dropdown>
            )}
            {!account && (
              <p className="headText">
                Login
              </p>
            )}
          </div>
        </div>
      </div>

      <ConfirmModal
        title="Are you sure"
        isShow={showConfirmLogout}
        onHide={handleCancleLogout}
      >
        <div>
          <div className="text-center">Do you want to log out?</div>
          <div className="text-center mt-3">
            <button
              className="btn btn-danger mr-3"
              onClick={handleConfirmedLogout}
              type="button"
            >
              Log out
            </button>
            <button
              className="btn btn-outline-secondary"
              onClick={handleCancleLogout}
              type="button"
            >
              Cancel
            </button>
          </div>
        </div>
      </ConfirmModal>
      
      <Modal
        show={showModalChangePasswod}
        dialogClassName="modal-90w"
        aria-labelledby="login-modal"
      >
        <Card>
          <Card.Header className="text-monospace lead text-danger font-weight-bold">
            Change password
          </Card.Header>
          <Card.Body>
            <Card.Text>
              <p className="lead text-danger text-center">
                {notificationNewPass.length > 0 ? notificationNewPass : ""}
              </p>
            </Card.Text>

            <Formik
              initialValues={initialChangePasswordValues}
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
                    name="currentPassword"
                    label="Curr password"
                    isrequired={true}
                    onChange={(e) => setPass(e.target.value)}
                    value={pass}
                  />

                  <PasswordField
                    name="newPassword"
                    label="New password"
                    isrequired={true}
                    onChange={(e) => setNewPass(e.target.value)}
                    value={newpass}
                  />

                  {error?.error && (
                    <div className="invalid">{error.message}</div>
                  )}
                  <div className="text-center mt-3">
                    <button
                      className="btn btn-danger mr-3"
                      type="submit"
                      disabled={handleChange()}
                    >
                      Save
                    </button>
                    <button
                      className="btn btn-outline-secondary"
                      onClick={handleCanceChange}
                      type="button"
                    >
                      Cancel
                    </button>
                  </div>
                </Form>
              )}
            </Formik>
          </Card.Body>
        </Card>
      </Modal>    
    </>
  );
};

export default Header;

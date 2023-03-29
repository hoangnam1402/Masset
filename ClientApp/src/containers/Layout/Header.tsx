import React, { useState } from "react";
import { Dropdown, Menu, Space } from "antd";
import { LockOutlined, PoweroffOutlined, DownOutlined} from "@ant-design/icons";
import { Link, useNavigate, useLocation } from "react-router-dom";
import ConfirmModal from "../../components/ConfirmModal";
import { HOME } from "../../constants/pages";

import { useAppDispatch, useAppSelector } from "../../hooks/redux";
import { logout } from "../Authorize/reducer";

const Header = () => {
  const history = useNavigate();
  const { pathname } = useLocation();
  const { account } = useAppSelector((state) => state.authReducer);
  const dispatch = useAppDispatch();

  const [showModalChangePasswod, setShowModalChangePasswod] = useState(false);
  const [showConfirmLogout, setShowConfirmLogout] = useState(false);

  const headerName = () => {
    const pathnameSplit = pathname.split("/");
    pathnameSplit.shift();
    if (pathnameSplit.join(" > ").toString() == "login") {
      return "Online Asset Management";
    }
    return pathnameSplit.join(" > ").toString() || "Home";
  };

  const openModal = () => {
    setShowModalChangePasswod(true);
  };

  const handleHide = () => {
    setShowModalChangePasswod(false);
  };

  const handleLogout = () => {
    setShowConfirmLogout(true);
  };

  const handleCancleLogout = () => {
    setShowConfirmLogout(false);
  };

  const handleConfirmedLogout = () => {
    history(HOME);
    dispatch(logout());
  };

  const handleMenuClick = (e: any) => {
    if(e.key == 1)
    {
      openModal
    }
    if(e.key == 2)
    {
      handleLogout
    }
  };

  const items = [
    {
      label: 'Change password',
      key: '1',
      icon: <LockOutlined />,
    },
    {
      label: 'Sign out',
      key: '2',
      icon: <PoweroffOutlined />,
    },
  ]

  const menuProps = {
    items,
    onClick: handleMenuClick,
  };

  return (
    <>
      <div className="header align-items-center font-weight-bold">
        <div className="container-lg-min container-fluid d-flex pt-2">
          <img src="/images/Logo_lk.png" alt="logo" className="app_logo me-2" />
          <p className="headText">{`${headerName()}`}</p>

          <div className="ml-auto text-white">
            {account && (
              <Dropdown menu={menuProps} placement="bottomRight" trigger={['click']}>
                <Space>
                  <div>{account?.userName}</div>
                  <DownOutlined />
                </Space>
              </Dropdown>
            )}
            {!account && (
              <Link className="headText" to={"/login"}>
                Login
              </Link>
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
    </>
  );
};

export default Header;

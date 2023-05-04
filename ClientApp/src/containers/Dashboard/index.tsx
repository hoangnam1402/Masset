import { useAppDispatch, useAppSelector } from "../../hooks/redux";
import { Route, useNavigate } from "react-router-dom";
import { logout } from "../Authorize/reducer";
import { DASHBOARD, LOGIN } from "../../constants/pages";


const Dashboard = () => {
  const { isAuth, account } = useAppSelector((state) => state.authReducer);
  const dispatch = useAppDispatch();
  const role = account?.role;
  const history = useNavigate();
  if (account?.firstLogin || account?.isActive) {
    dispatch(logout());
    history(LOGIN);
  }

 
  return (
    <>
      <Route path={DASHBOARD}>
        <h1>OK</h1>
      </Route>
    </>
  );
};

export default Dashboard;

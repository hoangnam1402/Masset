import { useAppDispatch, useAppSelector } from "../../hooks/redux";
import { Route, useNavigate } from "react-router-dom";
import { logout } from "../Authorize/reducer";
import HomeAssignmentList from "./List";
import { HOME } from "../../constants/pages";


const Home = () => {
  const { isAuth, account } = useAppSelector((state) => state.authReducer);
  const dispatch = useAppDispatch();
  const role = account?.role;
  const history = useNavigate();
  if (account?.firstLogin || account?.isActive) {
    dispatch(logout());
    history("/login");
  }

 
  return (
    <>
      <Route path={HOME}>
        <HomeAssignmentList/>
      </Route>
    </>
  );
};

export default Home;

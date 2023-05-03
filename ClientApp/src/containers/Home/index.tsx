import { useAppDispatch, useAppSelector } from "../../hooks/redux";
import { Route, useNavigate } from "react-router-dom";
import { logout } from "../Authorize/reducer";
import { HOME, LOGIN } from "../../constants/pages";


const Home = () => {
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
      <Route path={HOME}>
        <h1>OK</h1>
      </Route>
    </>
  );
};

export default Home;

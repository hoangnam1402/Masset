import { NotificationContainer } from 'react-notifications';
import Header from "./Header";
import SideBar from "./SideBar";

const Layout = ({ children }: any) => {
  return (
    <>
      <NotificationContainer />
      <Header />

      <div className="container-lg-min container-fluid">
        <div className="row mt-4 mb-5">

          <div className="col-lg-3 col-md-4 col-12 mr-5">
            <SideBar />
          </div>

          <div className="col-lg-8 col-md-7 ms-5">
            {children}
          </div>
        </div>
      </div>
    </>
  );
};

export default Layout;

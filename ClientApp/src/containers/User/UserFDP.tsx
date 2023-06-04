import jsPDF from 'jspdf';
import 'jspdf-autotable';
import autoTable from 'jspdf-autotable';
import { FilePdf } from 'react-bootstrap-icons';
import IUser from '../../interfaces/User/IUser';
import { ManagerUserTypeLabel, ManagerUserType, StaffUserTypeLabel, StaffUserType,
    AdminUserType, AdminUserTypeLabel } from "../../constants/UserConstants";
  
type Props = {
    data: IUser[];
};

const UserFDP: React.FC<Props> = ({ data }) => {
    const handleClick = () => {
        const doc = new jsPDF();

        const getUserRoleTypeName = (id: number | undefined) => {
            switch(id) {
                case AdminUserType:
                    return AdminUserTypeLabel;
                case ManagerUserType:
                    return ManagerUserTypeLabel;
                case StaffUserType:
                    return StaffUserTypeLabel;
                default:
                    return "";
            }
        };

        const header = [[ 'Name', 'Role', 'Email', 'Phone']];
        const rows = data.map(x => [ x.userName, getUserRoleTypeName(x.role), x.email, x.phoneNumber]);

        autoTable(doc, {
            head: header,
            body: rows,
        });

        doc.save('User-PDF.pdf');
    }
    return (
        <button className='btn btn-info' onClick={handleClick}>PDF <FilePdf/></button>
    );
};

export default UserFDP;

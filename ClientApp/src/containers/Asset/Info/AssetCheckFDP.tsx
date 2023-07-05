import jsPDF from 'jspdf';
import 'jspdf-autotable';
import autoTable from 'jspdf-autotable';
import { FilePdf } from 'react-bootstrap-icons';
import IChecking from '../../../interfaces/Checking/IChecking';

type Props = {
    data: IChecking[];
};

const AssetCheckFDP: React.FC<Props> = ({ data }) => {
    const handleClick = () => {
        const doc = new jsPDF();

        const formatDate = (date: Date) => {
            return new Date(date).toLocaleDateString();
        }

        const header = [['No.', 'User', 'Asset', 'Check Day', 'Still Effective?']];
        const rows = data.map((x, index) => [ index, x.user.userName, x.asset.name, formatDate(x.checkDay), x.isEffective]);

        autoTable(doc, {
            head: header,
            body: rows,
        });

        doc.save('Asset-Checking-PDF.pdf');
    }
    return (
        <button className='btn btn-info' onClick={handleClick}>PDF <FilePdf/></button>
    );
};

export default AssetCheckFDP;

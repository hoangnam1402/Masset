import jsPDF from 'jspdf';
import 'jspdf-autotable';
import autoTable from 'jspdf-autotable';
import { FilePdf } from 'react-bootstrap-icons';
import IChecking from '../../../interfaces/Checking/IChecking';

type Props = {
    data: IChecking[];
};

const ComponentCheckFDP: React.FC<Props> = ({ data }) => {
    const handleClick = () => {
        const doc = new jsPDF();

        const formatDate = (date: Date) => {
            return new Date(date).toLocaleDateString();
        }

        const header = [[ 'Asset', 'Component', 'Quantity', 'Check Day']];
        const rows = data.map(x => [ x.asset.name, x.component.name, x.quantity, formatDate(x.checkDay)]);

        autoTable(doc, {
            head: header,
            body: rows,
        });

        doc.save('Component-Checking-PDF.pdf');
    }
    return (
        <button className='btn btn-info' onClick={handleClick}>PDF <FilePdf/></button>
    );
};

export default ComponentCheckFDP;

import jsPDF from 'jspdf';
import 'jspdf-autotable';
import autoTable from 'jspdf-autotable';
import { FilePdf } from 'react-bootstrap-icons';
import IBrand from '../../interfaces/Brand/IBrand';

type Props = {
    data: IBrand[];
};

const BrandFDP: React.FC<Props> = ({ data }) => {
    const handleClick = () => {
        const doc = new jsPDF();

        const formatDate = (date: Date) => {
            return new Date(date).toLocaleDateString();
        }

        const header = [['No.', 'Name', 'Description', 'Create Day', 'Update Day']];
        const rows = data.map((x, index) => [ index, x.name, x.description, formatDate(x.createDay), formatDate(x.updateDay)]);

        autoTable(doc, {
            head: header,
            body: rows,
        });

        doc.save('Brand-PDF.pdf');
    }
    return (
        <button className='btn btn-info' onClick={handleClick}>PDF <FilePdf/></button>
    );
};

export default BrandFDP;

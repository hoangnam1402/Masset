import jsPDF from 'jspdf';
import 'jspdf-autotable';
import autoTable from 'jspdf-autotable';
import { FilePdf } from 'react-bootstrap-icons';
import ISupplier from '../../interfaces/Supplier/ISupplier';

type Props = {
    data: ISupplier[];
};

const SupplierFDP: React.FC<Props> = ({ data }) => {
    const handleClick = () => {
        const doc = new jsPDF();

        const header = [['No.', 'Name', 'Email', 'Phone', 'City', 'Country', 'Address']];
        const rows = data.map((x, index) => [ index, x.name, x.email, x.phone, x.city, x.country, x.address]);

        autoTable(doc, {
            head: header,
            body: rows,
        });

        doc.save('Supplier-PDF.pdf');
    }
    return (
        <button className='btn btn-info' onClick={handleClick}>PDF <FilePdf/></button>
    );
};

export default SupplierFDP;

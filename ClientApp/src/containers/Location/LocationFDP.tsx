import jsPDF from 'jspdf';
import 'jspdf-autotable';
import autoTable from 'jspdf-autotable';
import { FilePdf } from 'react-bootstrap-icons';
import ILocation from '../../interfaces/Location/ILocation';

type Props = {
    data: ILocation[];
};

const LocationFDP: React.FC<Props> = ({ data }) => {
    const handleClick = () => {
        const doc = new jsPDF();

        const formatDate = (date: Date) => {
            return new Date(date).toLocaleDateString();
        }

        const header = [[ 'Name', 'Description', 'Create Day', 'Update Day']];
        const rows = data.map(x => [ x.name, x.description, formatDate(x.createDay), formatDate(x.updateDay)]);

        autoTable(doc, {
            head: header,
            body: rows,
        });

        doc.save('Location-PDF.pdf');
    }
    return (
        <button className='btn btn-info' onClick={handleClick}>PDF <FilePdf/></button>
    );
};

export default LocationFDP;

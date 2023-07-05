import jsPDF from 'jspdf';
import 'jspdf-autotable';
import autoTable from 'jspdf-autotable';
import { FilePdf } from 'react-bootstrap-icons';
import IDepreciation from '../../interfaces/Depreciation/IDepreciation';

type Props = {
    data: IDepreciation[];
};

const DepreciationFDP: React.FC<Props> = ({ data }) => {
    const handleClick = () => {
        const doc = new jsPDF();

        const header = [['No.', 'Asset', 'Component', 'Period (Months)', 'Value']];
        const rows = data.map((x, index) => [ index, x.asset.name, x.component.name, x.period, x.value]);

        autoTable(doc, {
            head: header,
            body: rows,
        });

        doc.save('Depreciation-PDF.pdf');
    }
    return (
        <button className='btn btn-info' onClick={handleClick}>PDF <FilePdf/></button>
    );
};

export default DepreciationFDP;

import jsPDF from 'jspdf';
import 'jspdf-autotable';
import autoTable from 'jspdf-autotable';
import { FilePdf } from 'react-bootstrap-icons';
import IMaintenance from '../../interfaces/Maintenance/IMaintenance';
import { TypeMaintenance, TypeCalibration, TypeCalibrationLabel, TypeHardwareSupport, TypeNull,
    TypeHardwareSupportLabel, TypeMaintenanceLabel, TypeRepair, TypeRepairLabel, TypeTesting,
    TypeSoftwareSupport, TypeSoftwareSupportLabel, TypeTestingLabel, TypeUpgrade, TypeUpgradeLabel,
    } from "../../constants/maintenanceConstants";
  
type Props = {
    data: IMaintenance[];
};

const MaintenanceFDP: React.FC<Props> = ({ data }) => {
    const handleClick = () => {
        const doc = new jsPDF();

        const formatDate = (date: Date) => {
            return new Date(date).toLocaleDateString();
        }

        const getMaintenanceTypeName = (id: number | undefined) => {
            switch(id) {
                case TypeMaintenance:
                    return TypeMaintenanceLabel;
                case TypeRepair:
                    return TypeRepairLabel;
                case TypeUpgrade:
                    return TypeUpgradeLabel;
                case TypeTesting:
                    return TypeTestingLabel;
                case TypeCalibration:
                    return TypeCalibrationLabel;
                case TypeSoftwareSupport:
                    return TypeSoftwareSupportLabel;
                case TypeHardwareSupport:
                    return TypeHardwareSupportLabel;
                default:
                    return TypeNull;
            }
        };

        const header = [['No.', 'Asset', 'Supplier', 'Type', 'Start Day', 'End Day']];
        const rows = data.map((x, index) => [ index, x.asset.name, x.supplier.name, getMaintenanceTypeName(x.type), 
            formatDate(x.startDate), formatDate(x.endDate)]);

        autoTable(doc, {
            head: header,
            body: rows,
        });

        doc.save('Maintenance-PDF.pdf');
    }
    return (
        <button className='btn btn-info' onClick={handleClick}>PDF <FilePdf/></button>
    );
};

export default MaintenanceFDP;

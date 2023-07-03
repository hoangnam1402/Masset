import jsPDF from 'jspdf';
import 'jspdf-autotable';
import autoTable from 'jspdf-autotable';
import { FilePdf } from 'react-bootstrap-icons';
import IComponent from '../../../interfaces/Component/IComponent';
import { StateReadyToDeploy, StatePending, StateArchived, StateBroken, StateLost, StateOutOfRepair,
	StateReadyToDeployLabel, StatePendingLabel, StateArchivedLabel, StateBrokenLabel,
  StateLostLabel, StateOutOfRepairLabel, StateNull } from "../../../constants/assetConstants";

type Props = {
    data: IComponent[];
};

const ComponentFDP: React.FC<Props> = ({ data }) => {
    const handleClick = () => {
        const doc = new jsPDF();

        const getAssetStateTypeName = (id: number | undefined) => {
            switch(id) {
                case StateReadyToDeploy:
                    return StateReadyToDeployLabel;
                case StatePending:
                    return StatePendingLabel;
                case StateArchived:
                    return StateArchivedLabel;
                case StateBroken:
                    return StateBrokenLabel;
                case StateLost:
                    return StateLostLabel;
                case StateOutOfRepair:
                    return StateOutOfRepairLabel;
                default:
                    return StateNull;
            }
        };

        const formatDate = (date: Date) => {
            return new Date(date).toLocaleDateString();
        }

        const header = [[ 'Name', 'Cost', 'Quantity', 'Available Quantity', 'Type', 'Brand', 'Location',
            'status', 'Purchase Day']];
        const rows = data.map(x => [ x.name, x.cost.toLocaleString(), x.quantity, x.availableQuantity, x.type.name,
            x.brand.name, x.location.name, getAssetStateTypeName(x.status), formatDate(x.purchaseDay)]);

        autoTable(doc, {
            head: header,
            body: rows,
        });

        doc.save('Component-PDF.pdf');
    }
    return (
        <div className='d-flex intro-x ml-auto align-items-center mb-4'>
          <button className='btn btn-info' onClick={handleClick}>PDF <FilePdf/></button>
        </div>
    );
};

export default ComponentFDP;

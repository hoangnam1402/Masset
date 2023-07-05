import jsPDF from 'jspdf';
import 'jspdf-autotable';
import IAsset from '../../../interfaces/Asset/IAsset';
import { StateReadyToDeploy, StatePending, StateArchived, StateBroken, StateLost, StateOutOfRepair,
	StateReadyToDeployLabel, StatePendingLabel, StateArchivedLabel, StateBrokenLabel,
  StateLostLabel, StateOutOfRepairLabel, StateNull } from "../../../constants/assetConstants";
import autoTable from 'jspdf-autotable';
import { FilePdf } from 'react-bootstrap-icons';

type Props = {
    data: IAsset[];
};

const AssetFDP: React.FC<Props> = ({ data }) => {
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

        const header = [['No.', 'Name', 'Tag', 'Type', 'Brand', 'Location', 'Cost', 'Status', 'Purchase Day']];
        const rows = data.map((x, index) => [ index, x.name, x.tag, x.type.name, x.brand.name, x.location.name, 
            x.cost.toLocaleString(), getAssetStateTypeName(x.status), formatDate(x.purchaseDay)]);

        autoTable(doc, {
            head: header,
            body: rows,
        });

        doc.save('Asset-PDF.pdf');
    }
    return (
        <div className='d-flex intro-x ml-auto align-items-center mb-4'>
          <button className='btn btn-info' onClick={handleClick}>PDF <FilePdf/></button>
        </div>
    );
};

export default AssetFDP;

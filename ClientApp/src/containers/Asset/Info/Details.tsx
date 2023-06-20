import { CurrencyDollar } from "react-bootstrap-icons";
import IAsset from "../../../interfaces/Asset/IAsset";

type Props = {
    asset: IAsset;
};
  
const Details: React.FC<Props> = ({asset}) => {
    const daysInMonth = (year: number, month: number) => {
        return new Date(year, month + 1, 0).getDate();
    }
    const addMonths = (date: Date, months: number) => {
        var target_month = date.getMonth() + months;
        var year = date.getFullYear() + target_month / 12;
        var month = target_month % 12;
        var day = date.getDate();
        var last_day = daysInMonth(year, month);
        if (day > last_day)
        {
            day = last_day;
        }
        var new_date = new Date(year, month, day);
        return new_date;
    };

    const purchaseDay = new Date(asset.purchaseDay);
    const outOfWarrantyDay = addMonths(purchaseDay, asset.warranty);
    const updateDay = new Date(asset.updateDay); 
    const createDay = new Date(asset.createDay);

    return (
        <>
            <div className="row">
                <div className="col-md-9 pt-3">
                    <table className="table">
                        <tbody>
                            <tr>
                                <td width="200">
                                    <p className="mb-0 font-bold">Serial: </p>
                                </td>
                                <td>
                                    <p className="mb-0">{asset.serial}</p>
                                </td>
                            </tr>
                            <tr>
                                <td width="200">
                                    <p className="mb-0 font-bold">Brand: </p>
                                </td>
                                <td>
                                    <p className="mb-0">{asset.brand.name}</p>
                                </td>
                            </tr>
                            <tr>
                                <td width="200">
                                    <p className="mb-0 font-bold">Purchase day: </p>
                                </td>
                                <td>
                                    <p className="mb-0">{purchaseDay.toLocaleDateString()}</p>
                                </td>
                            </tr>
                            <tr>
                                <td width="200">
                                    <p className="mb-0 font-bold">Cost: </p>
                                </td>
                                <td>
                                    <p className="mb-0">{asset.cost.toLocaleString()} <CurrencyDollar/></p>
                                </td>
                            </tr>
                            <tr>
                                <td width="200">
                                    <p className="mb-0 font-bold">Warranty: </p>
                                </td>
                                <td>
                                    <p className="mb-0">{asset.warranty} Month(s) - {outOfWarrantyDay.toLocaleDateString()}</p>
                                </td>
                            </tr>
                            <tr>
                                <td width="200">
                                    <p className="mb-0 font-bold">Location: </p>
                                </td>
                                <td>
                                    <p className="mb-0">{asset.location.name}</p>
                                </td>
                            </tr>
                            <tr>
                                <td width="200">
                                    <p className="mb-0 font-bold">Supplier: </p>
                                </td>
                                <td>
                                    <p className="mb-0">{asset.supplier.name}</p>
                                </td>
                            </tr>
                            <tr>
                                <td width="200">
                                    <p className="mb-0 font-bold">Updated day: </p>
                                </td>
                                <td>
                                    <p className="mb-0">{updateDay.toLocaleDateString()}</p>
                                </td>
                            </tr>
                            <tr>
                                <td width="200">
                                    <p className="mb-0 font-bold">Created day: </p>
                                </td>
                                <td>
                                    <p className="mb-0">{createDay.toLocaleDateString()}</p>
                                </td>
                            </tr>
                            <tr>
                                <td width="200">
                                    <p className="mb-0 font-bold">Description: </p>
                                </td>
                                <td>
                                    <p className="mb-0">{asset.description}</p>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
                {asset.image && <div className="col-md-3 pt-2 text-center">
                    <img id="detailImage" src={`data:image/jpeg;base64,${asset?.image}`} alt={asset?.name} />
                </div>}
            </div>
        </>
    );
};

export default Details;

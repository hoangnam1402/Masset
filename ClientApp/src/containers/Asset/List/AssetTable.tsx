import React, { useState } from "react";
import { Check, FileEarmarkText, PencilFill, Trash3 } from "react-bootstrap-icons";
import { useNavigate } from "react-router";
import ButtonIcon from "../../../components/ButtonIcon";

import Table, { SortType } from "../../../components/Table";
import IColumnOption from "../../../interfaces/IColumnOption";
import IPagedModel from "../../../interfaces/IPagedModel";
import { NotificationManager } from "react-notifications";

import { ASSET_ID } from "../../../constants/pages";
import IAsset from "../../../interfaces/Asset/IAsset";
import { useAppDispatch, useAppSelector } from "../../../hooks/redux";
import { deleteAssets } from "../reducer";
import DeleteModal from "../../../components/DeleteModal";
import AssetForm from "./AssetForm";
import CheckAssetForm from "./CheckAssetForm";

const columns: IColumnOption[] = [
    { columnName: "Picture", columnValue: "" },
    { columnName: "Tag", columnValue: "tag" },
    { columnName: "Asset Name", columnValue: "name" },
    { columnName: "Type", columnValue: "type" },
    { columnName: "Brand", columnValue: "brand" },
    { columnName: "Location", columnValue: "location" },
    { columnName: "Action", columnValue: "" },
];

type Props = {
    assets: IPagedModel<IAsset> | null;
    handlePage: (page: number) => void;
    handleSort: (colValue: string) => void;
    sortState: SortType;
    deleteAsset?: IAsset;
    handleLimit: (e: any) => void;
    limit: number;
};

const AssetTable: React.FC<Props> = ({ assets, handlePage, handleSort, sortState, deleteAsset, handleLimit, limit }) => {
    const dispatch = useAppDispatch();
    const { account } = useAppSelector((state) => state.authReducer);
    const [showConfirmDelete, setShowConfirmDelete] = useState(false);
    const [assetDetail, setAssetDetail] = useState(undefined as IAsset | undefined);
    const [showEditForm, setShowEditForm] = useState(false);
    const [showCheckingForm, setShowCheckingForm] = useState(false);
    const [isCheckOut, setIsCheckOut] = useState(false);

    const handleResult = (result: boolean, message: string) => {
        if (result) {
            NotificationManager.success(`Delete Successful Asset ${message}`, `Delete Successful`, 2000);
            deleteAsset = undefined;
        } else {
            NotificationManager.error(message, "Delete failed", 2000);
        }
    };

    const handleCancleDelete = () => {
        setShowConfirmDelete(false);
    };

    const history = useNavigate();
    const handleShowDetail = (id: number) => {
        history(ASSET_ID(id));
    };

    const handleEdit = (asset: IAsset) => {
        setShowEditForm(true);
        setAssetDetail(asset);
    };

    const handleCloseEditForm = () => {
        setShowEditForm(false);
    };

    const handleDelete = (id: number) => {
        const asset = assets?.items.find((item) => item.id === id);

        if (asset) {
            setShowConfirmDelete(true);
            setAssetDetail(asset);
        }
    };

    const handleAcceptDelete = () => {
        if (assetDetail) {
            setShowConfirmDelete(false);
            dispatch(deleteAssets({ handleResult, formValues: assetDetail }));
        }
    };

    const handleShowCheckingForm = (asset: IAsset) => {
        setShowCheckingForm(true);
        setAssetDetail(asset);
        setIsCheckOut(!asset.isCheckOut);
    };

    const handleCloseCheckingForm = () => {
        setShowCheckingForm(false);
    };

    return (
        <>
            <Table
                columns={columns}
                handleSort={handleSort}
                sortState={sortState}
                handleLimit={handleLimit}
                limit={limit}
                page={{
                    currentPage: assets?.currentPage,
                    totalPage: assets?.totalPages,
                    handleChange: handlePage,
                }}
            >
                {assets?.items.map((data, index) => (
                    <tr key={index} className="">
                        <td className="py-1 py-1-custome">
                            {data.image && <img id="image" src={`data:image/jpeg;base64,${data?.image}`} alt={data?.name} />}
                        </td>
                        <td className="py-1 py-1-custome">{data.tag}</td>
                        <td className="py-1 py-1-custome">{data.name} </td>
                        <td className="py-1 py-1-custome">{data.type.name}</td>
                        <td className="py-1 py-1-custome">{data.brand.name}</td>
                        <td className="py-1 py-1-custome">{data.location.name}</td>

                        <td className="py-1 py-1-custome">
                            <div className="dropdown">
                                <button
                                    className="btn btn-secondary btn-sm dropdown-toggle"
                                    type="button"
                                    id="dropdownMenuButton1"
                                    data-bs-toggle="dropdown"
                                    aria-expanded="false"
                                ></button>
                                <ul className="dropdown-menu" aria-labelledby="dropdownMenuButton1">
                                    <li>
                                        <ButtonIcon
                                            className="dropdown-item"
                                            onClick={() => handleShowCheckingForm(data)}
                                        >
                                            <Check className="text-black" />
                                            <span className="p-2">{data.isCheckOut ? "Check-in" : "Check-out"}</span>
                                        </ButtonIcon>
                                    </li>
                                    <li>
                                        <div className="dropdown-divider"></div>
                                    </li>
                                    <li>
                                        <ButtonIcon onClick={() => handleShowDetail(data.id)} title="Detail" className="dropdown-item">
                                            <FileEarmarkText className="text-black" />
                                            <span className="p-2">Detail</span>
                                        </ButtonIcon>
                                    </li>
                                    <li>
                                        <ButtonIcon onClick={() => handleEdit(data)} title="Edit" className="dropdown-item">
                                            <PencilFill className="text-black" />
                                            <span className="p-2">Edit</span>
                                        </ButtonIcon>
                                    </li>
                                    <li>
                                        <ButtonIcon
                                            className="dropdown-item"
                                            title="Delete"
                                            onClick={() => handleDelete(data.id)}
                                            disable={account?.role === "Staff" ? true : false}
                                        >
                                            <Trash3 className="text-black" />
                                            <span className="p-2">Delete</span>
                                        </ButtonIcon>
                                    </li>
                                </ul>
                            </div>
                        </td>
                    </tr>
                ))}
            </Table>

            <DeleteModal title="Are you sure" isShow={showConfirmDelete} onHide={handleCancleDelete}>
                <div>
                    <div className="text-center">Do you want to delete this Asset?</div>
                    <div className="text-center mt-3">
                        <button className="btn btn-danger mr-3" onClick={handleAcceptDelete} type="button">
                            Delete
                        </button>
                        <button className="btn btn-outline-secondary" onClick={handleCancleDelete} type="button">
                            Cancel
                        </button>
                    </div>
                </div>
            </DeleteModal>
            {showEditForm && <AssetForm asset={assetDetail} handleClose={handleCloseEditForm} />}
            {showCheckingForm && assetDetail && <CheckAssetForm asset={assetDetail} handleClose={handleCloseCheckingForm} isCheckOut={isCheckOut} />}
        </>
    );
};

export default AssetTable;

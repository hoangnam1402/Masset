import React, { useEffect } from 'react';
import { useAppDispatch, useAppSelector } from '../../../hooks/redux';
import { getQrCode } from '../reducer';
import IAsset from "../../../interfaces/Asset/IAsset";
import { Modal } from 'react-bootstrap';
import { XSquare } from 'react-bootstrap-icons';

type Props = {
    asset: IAsset;
    handleClose: () => void;
};

const QrCodeGenerator: React.FC<Props> = ({ asset, handleClose }) => {
    const { qrCode } = useAppSelector(
        (state) => state.assetReducer
    );

    const dispatch = useAppDispatch();

    const fetchData = () => {
        dispatch(getQrCode({tag: asset.tag as string}));
    };
    
    useEffect(() => {
        fetchData();
    }, [asset]);

    return (
        <>
            <Modal
                show={true}
                onHide={handleClose}
                dialogClassName="containerModalErr"
            >
                <Modal.Header className="align-items-center headerModal">
                    <Modal.Title id="detail-modal" className="primaryColor">
                        Asset QR Code
                    </Modal.Title>
                    <XSquare
                        onClick={handleClose}
                        className="primaryColor model-closeIcon"
                    />
                </Modal.Header>

                <Modal.Body className="bodyModal">
                    <div>
                    {qrCode !== undefined && <img src={qrCode} alt="qr code" width="100%" height="100%"/>}
                    </div>
                </Modal.Body>
            </Modal>
        </>
    );
};

export default QrCodeGenerator;
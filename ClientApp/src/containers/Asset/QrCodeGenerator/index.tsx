import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router';
import { useAppDispatch, useAppSelector } from '../../../hooks/redux';
import { getQrCode } from '../reducer';

const QrCodeGenerator = () => {
    const { qrCode } = useAppSelector(
        (state) => state.assetReducer
    );

    const dispatch = useAppDispatch();
    const { tag } = useParams<{ tag: string }>();

    const fetchData = () => {
        dispatch(getQrCode({tag: tag as string}));
    };
    
    useEffect(() => {
        fetchData();
    }, []);

    return (
        <>
            <div>
            {qrCode !== undefined && <img src={qrCode} alt="qr code" />}
            </div>
        </>
    );
};

export default QrCodeGenerator;
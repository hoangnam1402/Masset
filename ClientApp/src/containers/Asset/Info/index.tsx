import React, { useEffect, useState } from "react";
import { useParams } from 'react-router';
import IAsset from "../../../interfaces/Asset/IAsset";
import {
	StateReadyToDeploy,
	StatePending,
	StateArchived,
	StateBroken,
  StateLost,
  StateOutOfRepair,
	StateReadyToDeployLabel,
	StatePendingLabel,
	StateArchivedLabel,
	StateBrokenLabel,
  StateLostLabel,
  StateOutOfRepairLabel,
  StateNull
} from "../../../constants/assetConstants";
import { ASSETS, QRCODEGENERATOR } from "../../../constants/pages";
import IAssetForm from '../../../interfaces/Asset/IAssetForm';
import { useAppSelector, useAppDispatch } from '../../../hooks/redux';
import { getAssetById } from "../reducer";
import { useNavigate } from "react-router-dom";

const AssetInfo = () => {
  const dispatch = useAppDispatch();
  const { assetGetById } = useAppSelector(state => state.assetReducer);
  const [asset, setAsset] = useState(undefined as IAssetForm | undefined);
  const { id } = useParams<{ id: string }>();
	const history = useNavigate();

  const handleShowQrCode = (tag: string | undefined) => {
    if (tag) {
      history(QRCODEGENERATOR(tag));
    } else {
      history(ASSETS);
    }
  }

  const fetchData = () => {
    dispatch(getAssetById({id: Number(id)}));
  };

  useEffect(() => {
    fetchData();
  }, [id]);

  return (
    <>
      <div className='ml-5'>
        <div className='primaryColor text-title intro-x row'>
          <div className='col-md-9'>Asset detail</div>
          <div className="col-md-3 text-md-right">
            <a type="button" onClick={() => handleShowQrCode(assetGetById?.tag)} className="btn btn-danger"> Generate label</a>
          </div>
        </div>
  
        <div className='row'>
          OK
        </div>
      </div>
    </>
  );
};

export default AssetInfo;
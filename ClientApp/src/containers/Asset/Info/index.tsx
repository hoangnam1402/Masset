import React, { useEffect, useState } from "react";
import { useParams, useNavigate } from 'react-router';
import { Button, Modal } from "react-bootstrap";
import { XSquare } from "react-bootstrap-icons";
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
import { ASSETS } from "../../../constants/pages";
import IAssetForm from '../../../interfaces/Asset/IAssetForm';
import { useAppSelector, useAppDispatch } from '../../../hooks/redux';
import { getAssetById } from "../reducer";

const AssetInfo = () => {
  const history = useNavigate();
  const dispatch = useAppDispatch();
  const { assetResult } = useAppSelector(state => state.assetReducer);
  const [asset, setAsset] = useState(undefined as IAssetForm | undefined);
  const { id } = useParams<{ id: string }>();

  useEffect(() => {
    dispatch(getAssetById({id: Number(id)}));
    if (assetResult) {
        setAsset(assetResult);
    } else {
      history(ASSETS);
    }
  }, [assetResult]);

  return (
    <>
      <div className='ml-5'>
        <div className='primaryColor text-title intro-x row'>
          <div className='col-md-8'>Asset detail</div>
          <div className="col-md-4 text-md-right">
            <a type="button" className="btn btn-danger"> Generate label</a>
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
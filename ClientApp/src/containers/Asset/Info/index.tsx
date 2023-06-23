import React, { useEffect, useState } from "react";
import { useParams } from 'react-router';
import { StateReadyToDeploy, StatePending, StateArchived, StateBroken, StateLost, StateOutOfRepair,
	StateReadyToDeployLabel, StatePendingLabel, StateArchivedLabel, StateBrokenLabel,
  StateLostLabel, StateOutOfRepairLabel, StateNull } from "../../../constants/assetConstants";
import { useAppSelector, useAppDispatch } from '../../../hooks/redux';
import { getAssetById, getDepreciation } from "../reducer";
import QrCodeGenerator from "./QrCodeGenerator";
import { Dot } from "react-bootstrap-icons";
import { Tab, Tabs } from "react-bootstrap";
import Details from "./Details";
import Maintenances from "./Maintenances";
import Depreciation from "./Depreciation";
import Component from "./Component";
import History from "./History";

const AssetInfo = () => {
  const dispatch = useAppDispatch();
  const { assetGetById } = useAppSelector(state => state.assetReducer);
  const { id } = useParams<{ id: string }>();
  const [showQrCode, setShowQrCode] = useState(false);

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

  const handleShowQrCode = () => {
    setShowQrCode(true);
  }

  const handleCloseQrCode = () => {
    setShowQrCode(false);
  }

  const fetchData = () => {
    dispatch(getAssetById({id: Number(id)}));
    dispatch(getDepreciation({id: Number(id)}));

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
            <a type="button" onClick={() => handleShowQrCode()} className="btn btn-danger"> 
              Generate QR Code
            </a>
          </div>
        </div>
  
        <div className='row'>
          <div className="col-md-12">
            <div className="card">
              <div className="card-body p-4">
                <div className="row">
                  <div className="col-md-9">
                    <p className="title-detail font-bold">
                      <span className="assetName">{assetGetById?.name}</span>
                      <span className="assetTag"> ({assetGetById?.tag})</span>
                    </p>
                    <p className="assetDetail">
                      <span className="assetType">{assetGetById?.type.name}</span>
                      <span className="assetStatus">
                        <Dot/>
                        {getAssetStateTypeName(assetGetById?.status)}
                        </span>
                    </p>
                  </div>
                </div>
                <div className="row">
                  <div className="col-md-12">
                    <Tabs
                      transition={false}
                      defaultActiveKey="details"
                      className="mb-3"
                      justify
                    >
                      <Tab eventKey="details" title="Details">
                        {assetGetById &&<Details asset={assetGetById}/>}
                      </Tab>
                      <Tab eventKey="components" title="Components">
                        {assetGetById &&<Component assetID={assetGetById.id}/>}
                      </Tab>
                      <Tab eventKey="maintenances" title="Maintenances" >
                        {assetGetById &&<Maintenances assetID={assetGetById.id}/>}
                      </Tab>
                      <Tab eventKey="history" title="History">
                        {assetGetById &&<History assetID={assetGetById.id}/>}
                      </Tab>
                      <Tab eventKey="depreciation" title="Depreciation" >
                        {assetGetById &&<Depreciation assetID={assetGetById.id}/>}
                      </Tab>
                    </Tabs>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>

      {assetGetById && showQrCode && (
        <QrCodeGenerator asset={assetGetById} handleClose={handleCloseQrCode} />
      )}
    </>
  );
};

export default AssetInfo;
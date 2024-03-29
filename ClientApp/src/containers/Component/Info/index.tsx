import React, { useEffect } from "react";
import { useParams } from 'react-router';
import { useAppSelector, useAppDispatch } from '../../../hooks/redux';
import { getById } from "../reducer";
import { Tab, Tabs } from "react-bootstrap";
import Details from "./Details";
import Depreciation from "./Depreciation";

const ComponentInfo = () => {
  const dispatch = useAppDispatch();
  const { compGetById, checkings, loading } = useAppSelector(state => state.componentReducer);
  const { id } = useParams<{ id: string }>();

  const fetchData = () => {
    dispatch(getById({id: Number(id)}));
  };

  useEffect(() => {
    fetchData();
  }, [id, checkings]);

  return (
    <>
      {loading && <div className="text-center">
        <div className="spinner-border" role="status"/>
        <div> Loading </div>
      </div>}

      {!loading && <div className='ml-5'>
        <div className='primaryColor text-title intro-x row'>
          <div className='col-md-9'>Component detail</div>
        </div>
  
        <div className='row'>
          <div className="col-md-12">
            <div className="card">
              <div className="card-body p-4">
                <div className="row">
                  <div className="col-md-9">
                    <p className="title-detail font-bold">
                      <span className="componentName">{compGetById?.name}</span>
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
                        {compGetById &&<Details component={compGetById}/>}
                      </Tab>
                      <Tab eventKey="depreciation" title="Depreciation">
                        {compGetById &&<Depreciation componentID={compGetById.id}/>}
                      </Tab>
                    </Tabs>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>}
    </>
  );
};

export default ComponentInfo;
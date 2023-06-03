import { configureStore, getDefaultMiddleware, combineReducers } from '@reduxjs/toolkit';
import createSagaMiddleware from 'redux-saga';

import authReducer from '../containers/Authorize/reducer';
import userReducer from '../containers/User/reducer';
import assetReducer from '../containers/Asset/reducer';
import componentReducer from '../containers/Component/reducer';
import dashboardReducer from '../containers/Dashboard/reducer';
import maintenenceReducer from '../containers/Maintenance/reducer';
import depreciationReducer from '../containers/Depreciation/reducer';
import assetTypeReducer from '../containers/AssetType/reducer';
import brandReducer from '../containers/Brand/reducer';
import supplierReducer from '../containers/Supplier/reducer';
import locationReducer from '../containers/Location/reducer';
import settingReducer from '../containers/Setting/reducer';
import rootSaga from './sagas/rootSaga';

const reducer = combineReducers({
    authReducer, dashboardReducer, assetReducer, componentReducer, maintenenceReducer, userReducer,
    depreciationReducer, assetTypeReducer, brandReducer, supplierReducer, locationReducer, settingReducer
});

const sagaMiddleware = createSagaMiddleware();

const store = configureStore({
    reducer,
    middleware: [
        ...getDefaultMiddleware({
            thunk: false,
            serializableCheck: false,
        }),
        sagaMiddleware
    ],
});

rootSaga.map(saga => sagaMiddleware.run(saga))  // Register all sagas

// sagaMiddleware.run(watcherSaga);

export default store;

export type RootState = ReturnType<typeof store.getState>;
export type RootDispatch = typeof store.dispatch;

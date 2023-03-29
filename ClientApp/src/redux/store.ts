import { configureStore, getDefaultMiddleware, combineReducers } from '@reduxjs/toolkit';
import createSagaMiddleware from 'redux-saga';

import authReducer from '../containers/Authorize/reducer';
// import userReducer from '../containers/User/reducer';
// import assetReducer from 'src/containers/Asset/reducer';
// import assignmentReducer from 'src/containers/Assignment/reducer';
import homeReducer from '../containers/Home/reducer';
import rootSaga from './sagas/rootSaga';

const reducer = combineReducers({
    authReducer,homeReducer
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

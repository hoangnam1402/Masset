import AuthorizeSagas from '../../containers/Authorize/sagas';
import DashboardSagas from '../../containers/Dashboard/sagas';
import assetSagas from '../../containers/Asset/sagas';

export default [
    AuthorizeSagas,
    DashboardSagas,
    assetSagas
];

import authorizeSagas from '../../containers/Authorize/sagas';
import dashboardSagas from '../../containers/Dashboard/sagas';
import assetSagas from '../../containers/Asset/sagas';
import componentSagas from '../../containers/Component/sagas';
import maintenanceSagas from '../../containers/Maintenance/sagas';
import depreciationSagas from '../../containers/Depreciation/sagas';
import assetTypeSagas from '../../containers/AssetType/sagas';
import brandSagas from '../../containers/Brand/sagas';
import supplierSagas from '../../containers/Supplier/sagas';
import locationSagas from '../../containers/Location/sagas';
import userSagas from '../../containers/User/sagas';

export default [
    authorizeSagas,
    dashboardSagas,
    assetSagas,
    componentSagas,
    maintenanceSagas,
    depreciationSagas,
    assetTypeSagas,
    brandSagas,
    supplierSagas,
    locationSagas,
    userSagas
];

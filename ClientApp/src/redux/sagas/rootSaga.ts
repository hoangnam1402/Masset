import assetSagas from 'src/containers/Asset/sagas';
import assignmentSagas from 'src/containers/Assignment/sagas';
import AuthorizeSagas from 'src/containers/Authorize/sagas';
import homeSagas from 'src/containers/Home/sagas';
import UserSagas from 'src/containers/User/sagas';

export default [
    AuthorizeSagas,
    UserSagas,
    assetSagas,
    assignmentSagas,
    homeSagas
];

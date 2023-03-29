import { takeLatest } from 'redux-saga/effects';

import { getHomeAssignments, respondToAssignment } from '../reducer';
import { handelRespondToAssignment, handleGetHomeAssignment} from './handles';

export default function* homeSagas() {
    yield takeLatest(getHomeAssignments.type, handleGetHomeAssignment);
    yield takeLatest(respondToAssignment.type,handelRespondToAssignment);
}

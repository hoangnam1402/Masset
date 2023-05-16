import ISelectOption from "../interfaces/ISelectOption";
import {
  StaffUserType,
  ManagerUserType,
  AdminUserType,
  AllUserType,
  StaffUserTypeLabel,
  ManagerUserTypeLabel,
  AdminUserTypeLabel,
  AllUserTypeLabel,
} from "./UserConstants";
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
} from "./assetConstants"

export const UserTypeOptions: ISelectOption[] = [
  { id: 1, label: AllUserTypeLabel, value: AllUserType },
  { id: 2, label: AdminUserTypeLabel, value: AdminUserType },
  { id: 3, label: ManagerUserTypeLabel, value: ManagerUserType },
  { id: 4, label: StaffUserTypeLabel, value: StaffUserType },
];

export const AssetStateOptions: ISelectOption[] = [
  { id: 1, label: StateReadyToDeployLabel, value: 1 },
  { id: 2, label: StatePendingLabel, value: 2 },
  { id: 3, label: StateArchivedLabel, value: 3 },
  { id: 4, label: StateBrokenLabel, value: 4 },
  { id: 5, label: StateLostLabel, value: 5 },
  { id: 6, label: StateOutOfRepairLabel, value: 6 },
];
export const AssignmentStateOptions: ISelectOption[] = [
  { id: 0, label: "All", value: 0 },
  { id: 1, label: "Waiting For Acceptance", value: 1 },
  { id: 2, label: "Accepted", value: 2 },
  // { id: 3, label: "Request For Returning", value: 3 },
  // { id: 4, label: "Returned", value: 4 },

];
export const AssetStateCreateOptions: ISelectOption[] = [
  { id: 1, label: StateReadyToDeployLabel, value: StateReadyToDeploy },
  { id: 2, label: StatePendingLabel, value: StatePending },
  { id: 3, label: StateArchivedLabel, value: StateArchived },
  { id: 4, label: StateBrokenLabel, value: StateBroken },
  { id: 5, label: StateLostLabel, value: StateLost },
  { id: 6, label: StateOutOfRepairLabel, value: StateOutOfRepair },
]

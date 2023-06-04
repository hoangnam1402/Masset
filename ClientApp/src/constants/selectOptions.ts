import ISelectOption from "../interfaces/ISelectOption";
import { StaffUserType, ManagerUserType, AdminUserType, StaffUserTypeLabel,
  ManagerUserTypeLabel, AdminUserTypeLabel} from "./UserConstants";
import { StateReadyToDeploy, StatePending, StateArchived, StateBroken, StateLost,
  StateOutOfRepair, StateReadyToDeployLabel, StatePendingLabel, StateArchivedLabel,
	StateBrokenLabel, StateLostLabel, StateOutOfRepairLabel} from "./assetConstants"
import { ComponentLabel, Component, Asset, AssetLabel } from "./depreciationCategory";
import { TypeMaintenance, TypeCalibration, TypeCalibrationLabel, TypeHardwareSupport,
  TypeHardwareSupportLabel, TypeMaintenanceLabel, TypeRepair, TypeRepairLabel,
  TypeSoftwareSupport, TypeSoftwareSupportLabel, TypeTesting, TypeTestingLabel,
  TypeUpgrade, TypeUpgradeLabel} from "./maintenanceConstants"

export const UserRoleOptions: ISelectOption[] = [
  { id: 1, label: AdminUserTypeLabel, value: AdminUserType },
  { id: 2, label: ManagerUserTypeLabel, value: ManagerUserType },
  { id: 3, label: StaffUserTypeLabel, value: StaffUserType },
];

export const AssetStateOptions: ISelectOption[] = [
  { id: 1, label: StateReadyToDeployLabel, value: StateReadyToDeploy },
  { id: 2, label: StatePendingLabel, value: StatePending },
  { id: 3, label: StateArchivedLabel, value: StateArchived },
  { id: 4, label: StateBrokenLabel, value: StateBroken },
  { id: 5, label: StateLostLabel, value: StateLost },
  { id: 6, label: StateOutOfRepairLabel, value: StateOutOfRepair },
]

export const MaintenanceTypeOption: ISelectOption[] = [
  { id: 1, label: TypeMaintenanceLabel, value: TypeMaintenance },
  { id: 2, label: TypeRepairLabel, value: TypeRepair },
  { id: 3, label: TypeUpgradeLabel, value: TypeUpgrade },
  { id: 4, label: TypeTestingLabel, value: TypeTesting },
  { id: 5, label: TypeCalibrationLabel, value: TypeCalibration },
  { id: 6, label: TypeSoftwareSupportLabel, value: TypeSoftwareSupport },
  { id: 7, label: TypeHardwareSupportLabel, value: TypeHardwareSupport },
]

export const DepreciationCategoryOption: ISelectOption[] = [
  { id: 1, label: AssetLabel, value: Asset },
  { id: 2, label: ComponentLabel, value: Component },
]

export const LimitOptions: ISelectOption[] = [
  { id: 1, label: "5", value: 5 },
  { id: 2, label: "10", value: 10 },
  { id: 3, label: "25", value: 25 },
  { id: 4, label: "50", value: 50 },
]
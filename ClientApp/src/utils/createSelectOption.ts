import IType from "../interfaces/Type/IType";
import ISelectOption from "../interfaces/ISelectOption";
import ISupplier from "../interfaces/Supplier/ISupplier";
import IBrand from "../interfaces/Brand/IBrand";
import ILocation from "../interfaces/Location/ILocation";

export default (list: IType[] | ISupplier[] | IBrand[] | ILocation[] | ISelectOption[] | null): ISelectOption[] => {
  let selectOptions: ISelectOption[] = [{ id: 0, label: "All", value: 0 }];
  if (list) {
    list.forEach((element) => {
      const a = { id: element.id, label: element.name, value: element.id };
      selectOptions = [...selectOptions, a];
    });
  }

  return selectOptions;
};

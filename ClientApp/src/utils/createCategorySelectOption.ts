import IAssetCategory from "../interfaces/Asset/IAssetCategory";
import ISelectOption from "../interfaces/ISelectOption";

export default (list: IAssetCategory[] | null): ISelectOption[] => {
  let selectOptions: ISelectOption[] = [{ id: 0, label: "All", value: 0 }];
  if (list) {
    list.forEach((element) => {
      const a = { id: element.id, label: element.name, value: element.id };
      selectOptions = [...selectOptions, a];
    });
  }
  //console.log(list);

  return selectOptions;
};

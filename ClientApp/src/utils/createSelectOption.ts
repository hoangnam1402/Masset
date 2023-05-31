import ISelectOption from "../interfaces/ISelectOption";

export default (list: any[] | null): ISelectOption[] => {
  let selectOptions: ISelectOption[] = [{ id: 0, label: "All", value: 0 }];
  if (list) {
    list.forEach((element) => {
      const a = { id: element.id, label: element.name || element.userName, value: element.id };
      selectOptions = [...selectOptions, a];
    });
  }

  return selectOptions;
};

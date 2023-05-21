import React from "react";
import { CaretDownFill, CaretUpFill } from "react-bootstrap-icons";
import IColumnOption from "../../interfaces/IColumnOption";

import Paging, { PageType } from "./Paging";

export type SortType = {
  columnValue: string;
  orderBy: string;
};

type ColumnIconType = {
  colValue: string;
  sortState: SortType;
};

const ColumnIcon: React.FC<ColumnIconType> = ({ colValue, sortState }) => {
  if (colValue === sortState.columnValue && sortState.orderBy === "Decsending")
    return <CaretUpFill />;

  return <CaretDownFill />;
};

type Props = {
  columns: IColumnOption[];
  children: React.ReactNode;
  sortState: SortType;
  handleSort: (colValue: string) => void;
  page?: PageType;
};

const Table: React.FC<Props> = ({
  columns,
  children,
  page,
  sortState,
  handleSort,
}) => {

  return (
    <>
      <div className="table-container">
        <table className="table">
          <thead>
            <tr className="text center text-lg-nowrap">
              {columns.map((col, i) => (
                <th key={i}>
                  {col.columnValue != "" && (
                    <div className="d-flex align-items-center">
                      <a
                        className="btn"
                        onClick={() => handleSort!(col.columnValue)}
                      >
                        {col.columnName}
                      </a>
                      <ColumnIcon
                        colValue={col.columnValue}
                        sortState={sortState}
                      />
                    </div>
                  )}
                  {col.columnValue == "" && col.columnName != "" && (
                    <div className="d-flex align-items-center">
                      <a
                        className="btn"
                      >
                        {col.columnName}
                      </a>
                    </div>
                  )}
                  {col.columnValue == "" && col.columnName == "" && (
                    <div className="d-flex">
                    </div>
                  )}
                </th>
              ))}
            </tr>
          </thead>

          <tbody>{children}</tbody>
        </table>
      </div>

      {!!(page && page.totalPage && page.totalPage >= 1) && (
        <Paging {...page} />
      )}
      {!!!(page && page.totalPage && page.totalPage >= 1) && (
        <p className="text-center">No record</p>
      )}
    </>
  );
};

export default Table;

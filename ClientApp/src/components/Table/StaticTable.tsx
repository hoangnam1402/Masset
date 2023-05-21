import React from "react";
import IColumnOption from "../../interfaces/IColumnOption";

type Props = {
  columns: IColumnOption[];
  children: React.ReactNode;
};

const StaticTable: React.FC<Props> = ({
  columns,
  children,
}) => {

  return (
    <>
      <div className="">
        <table className="table table-bordered">
          <thead>
            <tr className="text center text-lg-nowrap">
              {columns.map((col, i) => (
                <th key={i}>
                  {col.columnValue != "" && (
                    <div className="d-flex align-items-center">
                      <a className="btn">
                        {col.columnName}
                      </a>
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
    </>
  );
};

export default StaticTable;

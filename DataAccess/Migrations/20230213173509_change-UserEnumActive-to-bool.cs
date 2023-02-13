using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class changeUserEnumActivetobool : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("b2f76edf-646f-4ccc-8b88-4072ce863e07"));

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "NewAccount",
                table: "Users",
                newName: "IsActive");

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Address", "DepartmentID", "Email", "JobRole", "Password", "Phone", "UserName" },
                values: new object[] { new Guid("3f568040-2482-4df2-bf21-ae402636759e"), null, null, null, null, "staff", null, "staff" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("3f568040-2482-4df2-bf21-ae402636759e"));

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Users",
                newName: "NewAccount");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Address", "DepartmentID", "Email", "JobRole", "Password", "Phone", "UserName" },
                values: new object[] { new Guid("b2f76edf-646f-4ccc-8b88-4072ce863e07"), null, null, null, null, "staff", null, "staff" });
        }
    }
}

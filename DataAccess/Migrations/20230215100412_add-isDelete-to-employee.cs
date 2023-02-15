using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class addisDeletetoemployee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("3f568040-2482-4df2-bf21-ae402636759e"));

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Employees",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Address", "DepartmentID", "Email", "IsDelete", "JobRole", "Password", "Phone", "UserName" },
                values: new object[] { new Guid("1f41f6b5-6f2c-422c-834a-e09f8330fe52"), null, null, null, false, null, "test", null, "test1" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Address", "DepartmentID", "Email", "IsDelete", "JobRole", "Password", "Phone", "UserName" },
                values: new object[] { new Guid("8cbfc86f-8ad8-4d94-b2f8-d1f2cccffe7b"), null, null, null, true, null, "test", null, "test2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("1f41f6b5-6f2c-422c-834a-e09f8330fe52"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("8cbfc86f-8ad8-4d94-b2f8-d1f2cccffe7b"));

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Employees");

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Address", "DepartmentID", "Email", "JobRole", "Password", "Phone", "UserName" },
                values: new object[] { new Guid("3f568040-2482-4df2-bf21-ae402636759e"), null, null, null, null, "staff", null, "staff" });
        }
    }
}

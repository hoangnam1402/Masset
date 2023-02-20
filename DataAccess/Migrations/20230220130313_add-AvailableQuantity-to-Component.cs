using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class addAvailableQuantitytoComponent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("085a6120-1859-4255-90e9-0e54a605366b"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("6b392053-f50f-4d40-9c95-06446d65b0ed"));

            migrationBuilder.AddColumn<int>(
                name: "AvailableQuantity",
                table: "Components",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Address", "DepartmentID", "Email", "IsDeleted", "JobRole", "Password", "Phone", "UserName" },
                values: new object[] { new Guid("4eb4f527-a704-4c8f-bc7a-14bfda10bb10"), null, null, null, false, null, "test", null, "test1" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Address", "DepartmentID", "Email", "IsDeleted", "JobRole", "Password", "Phone", "UserName" },
                values: new object[] { new Guid("84289c96-caf2-4a41-9999-156fcc52990a"), null, null, null, true, null, "test", null, "test2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("4eb4f527-a704-4c8f-bc7a-14bfda10bb10"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("84289c96-caf2-4a41-9999-156fcc52990a"));

            migrationBuilder.DropColumn(
                name: "AvailableQuantity",
                table: "Components");

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Address", "DepartmentID", "Email", "IsDeleted", "JobRole", "Password", "Phone", "UserName" },
                values: new object[] { new Guid("085a6120-1859-4255-90e9-0e54a605366b"), null, null, null, false, null, "test", null, "test1" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Address", "DepartmentID", "Email", "IsDeleted", "JobRole", "Password", "Phone", "UserName" },
                values: new object[] { new Guid("6b392053-f50f-4d40-9c95-06446d65b0ed"), null, null, null, true, null, "test", null, "test2" });
        }
    }
}

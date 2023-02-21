using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class changeAssetTypetoAssetStatusEnumsatMaintenance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Maintenances_AssetTypes_TypeID",
                table: "Maintenances");

            migrationBuilder.DropIndex(
                name: "IX_Maintenances_TypeID",
                table: "Maintenances");

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("6186b522-d2bf-4926-9f2c-bccb8d74f083"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("86073254-02e8-4742-a0af-03ccf71c50c3"));

            migrationBuilder.RenameColumn(
                name: "TypeID",
                table: "Maintenances",
                newName: "Type");

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Address", "DepartmentID", "Email", "IsDeleted", "JobRole", "Password", "Phone", "UserName" },
                values: new object[] { new Guid("4367b750-c7d9-4e58-88c7-74579deda45a"), null, null, null, false, null, "test", null, "test1" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Address", "DepartmentID", "Email", "IsDeleted", "JobRole", "Password", "Phone", "UserName" },
                values: new object[] { new Guid("a3707e3f-2e93-49b2-b470-68616c02a0ee"), null, null, null, true, null, "test", null, "test2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("4367b750-c7d9-4e58-88c7-74579deda45a"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("a3707e3f-2e93-49b2-b470-68616c02a0ee"));

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Maintenances",
                newName: "TypeID");

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Address", "DepartmentID", "Email", "IsDeleted", "JobRole", "Password", "Phone", "UserName" },
                values: new object[] { new Guid("6186b522-d2bf-4926-9f2c-bccb8d74f083"), null, null, null, false, null, "test", null, "test1" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Address", "DepartmentID", "Email", "IsDeleted", "JobRole", "Password", "Phone", "UserName" },
                values: new object[] { new Guid("86073254-02e8-4742-a0af-03ccf71c50c3"), null, null, null, true, null, "test", null, "test2" });

            migrationBuilder.CreateIndex(
                name: "IX_Maintenances_TypeID",
                table: "Maintenances",
                column: "TypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Maintenances_AssetTypes_TypeID",
                table: "Maintenances",
                column: "TypeID",
                principalTable: "AssetTypes",
                principalColumn: "Id");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class addIsDeletedtoalltable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("4eb4f527-a704-4c8f-bc7a-14bfda10bb10"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("84289c96-caf2-4a41-9999-156fcc52990a"));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Suppliers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Maintenances",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Locations",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "Period",
                table: "Depreciations",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AssetID",
                table: "Depreciations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ComponentID",
                table: "Depreciations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Depreciations",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Departments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Components",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Brands",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AssetTypes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Address", "DepartmentID", "Email", "IsDeleted", "JobRole", "Password", "Phone", "UserName" },
                values: new object[] { new Guid("6186b522-d2bf-4926-9f2c-bccb8d74f083"), null, null, null, false, null, "test", null, "test1" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Address", "DepartmentID", "Email", "IsDeleted", "JobRole", "Password", "Phone", "UserName" },
                values: new object[] { new Guid("86073254-02e8-4742-a0af-03ccf71c50c3"), null, null, null, true, null, "test", null, "test2" });

            migrationBuilder.CreateIndex(
                name: "IX_Depreciations_AssetID",
                table: "Depreciations",
                column: "AssetID");

            migrationBuilder.CreateIndex(
                name: "IX_Depreciations_ComponentID",
                table: "Depreciations",
                column: "ComponentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Depreciations_Assets_AssetID",
                table: "Depreciations",
                column: "AssetID",
                principalTable: "Assets",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Depreciations_Components_ComponentID",
                table: "Depreciations",
                column: "ComponentID",
                principalTable: "Components",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Depreciations_Assets_AssetID",
                table: "Depreciations");

            migrationBuilder.DropForeignKey(
                name: "FK_Depreciations_Components_ComponentID",
                table: "Depreciations");

            migrationBuilder.DropIndex(
                name: "IX_Depreciations_AssetID",
                table: "Depreciations");

            migrationBuilder.DropIndex(
                name: "IX_Depreciations_ComponentID",
                table: "Depreciations");

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("6186b522-d2bf-4926-9f2c-bccb8d74f083"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("86073254-02e8-4742-a0af-03ccf71c50c3"));

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Maintenances");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "AssetID",
                table: "Depreciations");

            migrationBuilder.DropColumn(
                name: "ComponentID",
                table: "Depreciations");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Depreciations");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Components");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AssetTypes");

            migrationBuilder.AlterColumn<string>(
                name: "Period",
                table: "Depreciations",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Address", "DepartmentID", "Email", "IsDeleted", "JobRole", "Password", "Phone", "UserName" },
                values: new object[] { new Guid("4eb4f527-a704-4c8f-bc7a-14bfda10bb10"), null, null, null, false, null, "test", null, "test1" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Address", "DepartmentID", "Email", "IsDeleted", "JobRole", "Password", "Phone", "UserName" },
                values: new object[] { new Guid("84289c96-caf2-4a41-9999-156fcc52990a"), null, null, null, true, null, "test", null, "test2" });
        }
    }
}

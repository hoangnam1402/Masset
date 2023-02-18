using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class addCreateDayandUpdateDayforasset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("1664cdc4-4d01-4f5f-9d1a-898ba1479512"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("206766f4-ff50-4935-814a-460dafb63426"));

            migrationBuilder.RenameColumn(
                name: "IsDelete",
                table: "Employees",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "IsDelete",
                table: "Assets",
                newName: "IsDeleted");

            migrationBuilder.AlterColumn<DateTime>(
                name: "PurchaseDay",
                table: "Assets",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDay",
                table: "Assets",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDay",
                table: "Assets",
                type: "datetime2",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Address", "DepartmentID", "Email", "IsDeleted", "JobRole", "Password", "Phone", "UserName" },
                values: new object[] { new Guid("58a2df31-e3f1-496d-ad57-34acce452544"), null, null, null, true, null, "test", null, "test2" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Address", "DepartmentID", "Email", "IsDeleted", "JobRole", "Password", "Phone", "UserName" },
                values: new object[] { new Guid("b43abeda-b020-42fb-9d50-db84c55342b3"), null, null, null, false, null, "test", null, "test1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("58a2df31-e3f1-496d-ad57-34acce452544"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("b43abeda-b020-42fb-9d50-db84c55342b3"));

            migrationBuilder.DropColumn(
                name: "CreateDay",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "UpdateDay",
                table: "Assets");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "Employees",
                newName: "IsDelete");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "Assets",
                newName: "IsDelete");

            migrationBuilder.AlterColumn<DateTime>(
                name: "PurchaseDay",
                table: "Assets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Address", "DepartmentID", "Email", "IsDelete", "JobRole", "Password", "Phone", "UserName" },
                values: new object[] { new Guid("1664cdc4-4d01-4f5f-9d1a-898ba1479512"), null, null, null, true, null, "test", null, "test2" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Address", "DepartmentID", "Email", "IsDelete", "JobRole", "Password", "Phone", "UserName" },
                values: new object[] { new Guid("206766f4-ff50-4935-814a-460dafb63426"), null, null, null, false, null, "test", null, "test1" });
        }
    }
}

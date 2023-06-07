using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addCurrencytoSetting : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "38f47051-cffb-458d-8646-16f91c7b60a3");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "f63d9bf0-9e82-4345-b1c4-bca9f54f7be5");

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "5d2d9fa3-3a1b-47b7-b9d2-292683c1abcc", "2d81233d-154f-49e3-a097-69634dce0c85" });

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "5d2d9fa3-3a1b-47b7-b9d2-292683c1abcc");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "2d81233d-154f-49e3-a097-69634dce0c85");

            migrationBuilder.AddColumn<string>(
                name: "Currency",
                table: "Setting",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6e3fba3d-18ed-44ef-a5b8-6da01d9ecb96", "796db313-53a7-4ea2-809e-1a1b4a86f05c", "Manager", "MANAGER" },
                    { "9df9eeca-3786-4729-8401-190e14220eba", "999395c9-13f9-43b8-9db1-5eb93ccf43de", "Staff", "STAFF" },
                    { "b7f4cd31-b83b-43b6-a0e2-3db549073aa0", "9f5b634e-0696-421b-825d-3874a1fa42c2", "Admin", "ADMIN" }
                });

            migrationBuilder.UpdateData(
                table: "Setting",
                keyColumn: "Id",
                keyValue: 1,
                column: "Currency",
                value: "USD");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreateDay", "Email", "EmailConfirmed", "FirstLogin", "IsActive", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UpdateDay", "UserName" },
                values: new object[] { "6d4bfd66-a4ee-4c83-af50-bdf64171bc68", 0, "c1bd862e-5fde-4127-a407-1a6860d260f5", new DateTime(2023, 6, 7, 20, 47, 13, 173, DateTimeKind.Local).AddTicks(279), null, false, false, true, false, null, null, "TEST", "AQAAAAEAACcQAAAAEMpX9ndtS1GhVaTWV8udOHHPMaoOB15jVpWqysQn4LUvD+Snvy0e4WPk0FKpkVs39A==", null, false, 1, "4af6ae20-59bf-4eca-b052-f2ef579afd6d", false, new DateTime(2023, 6, 7, 20, 47, 13, 173, DateTimeKind.Local).AddTicks(288), "Test" });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "b7f4cd31-b83b-43b6-a0e2-3db549073aa0", "6d4bfd66-a4ee-4c83-af50-bdf64171bc68" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "6e3fba3d-18ed-44ef-a5b8-6da01d9ecb96");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "9df9eeca-3786-4729-8401-190e14220eba");

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b7f4cd31-b83b-43b6-a0e2-3db549073aa0", "6d4bfd66-a4ee-4c83-af50-bdf64171bc68" });

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "b7f4cd31-b83b-43b6-a0e2-3db549073aa0");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "6d4bfd66-a4ee-4c83-af50-bdf64171bc68");

            migrationBuilder.DropColumn(
                name: "Currency",
                table: "Setting");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "38f47051-cffb-458d-8646-16f91c7b60a3", "a3e8f15a-4a79-4d77-a403-a218a1931268", "Manager", "MANAGER" },
                    { "5d2d9fa3-3a1b-47b7-b9d2-292683c1abcc", "043ba7b9-5718-4f9c-9672-e4cb529cf816", "Admin", "ADMIN" },
                    { "f63d9bf0-9e82-4345-b1c4-bca9f54f7be5", "9aa74a50-c548-48bb-9e34-efe9d4294da8", "Staff", "STAFF" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreateDay", "Email", "EmailConfirmed", "FirstLogin", "IsActive", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UpdateDay", "UserName" },
                values: new object[] { "2d81233d-154f-49e3-a097-69634dce0c85", 0, "7ed2962b-44be-44cd-b05e-89e59b06b3d7", new DateTime(2023, 6, 7, 0, 47, 21, 165, DateTimeKind.Local).AddTicks(8276), null, false, false, true, false, null, null, "TEST", "AQAAAAEAACcQAAAAEMW1eoFSJkbHu+p/wOLc3cUK+IzijlKtRzhBOQwGCgNjnrUINwkw98Jbs6tEH5P4jw==", null, false, 1, "d58b2b11-d78a-44c0-b5df-332410978bee", false, new DateTime(2023, 6, 7, 0, 47, 21, 165, DateTimeKind.Local).AddTicks(8285), "Test" });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "5d2d9fa3-3a1b-47b7-b9d2-292683c1abcc", "2d81233d-154f-49e3-a097-69634dce0c85" });
        }
    }
}

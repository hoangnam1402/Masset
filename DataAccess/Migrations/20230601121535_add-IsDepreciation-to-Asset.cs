using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addIsDepreciationtoAsset : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "55f9e456-f5df-4619-a77e-04d93e4a5b9e");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "8a757ade-a74e-4371-8ce7-61b38aeca279");

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "0b39d804-875b-4cc5-b248-3ef26ed4d7b1", "400d885b-33db-4eb5-8a88-f7660bb0ac41" });

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "0b39d804-875b-4cc5-b248-3ef26ed4d7b1");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "400d885b-33db-4eb5-8a88-f7660bb0ac41");

            migrationBuilder.AddColumn<bool>(
                name: "IsDepreciation",
                table: "Assets",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "66875bf3-7597-41db-8f8a-a5efbe27caa8", "cb3fb83a-7972-4b6b-a414-ee9caf112086", "Admin", "ADMIN" },
                    { "a8b4ea85-240e-4534-9fcc-1e4e801e58a9", "b6763d13-751a-4512-9286-92d2092227da", "Manager", "MANAGER" },
                    { "df1f85f2-c8ff-4e83-8c4e-e8b44741ac19", "6ee8796b-501f-4f9d-8eca-3d2b351057a2", "Staff", "STAFF" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreateDay", "Email", "EmailConfirmed", "FirstLogin", "IsActive", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UpdateDay", "UserName" },
                values: new object[] { "35e37116-62e1-4e4c-9e73-0a82b3427383", 0, "3e5b3ec7-2cae-4e29-8cbd-077c3378810b", new DateTime(2023, 6, 1, 19, 15, 34, 708, DateTimeKind.Local).AddTicks(7753), null, false, false, true, false, null, null, "TEST", "AQAAAAEAACcQAAAAEDsaY2OTlDDDT1nOcaey8fjzzb9aD0eyjQrSYLRQcoGGh3H3XNkT30hyhLTl2Vm4nA==", null, false, 1, "f8140d3b-c935-483f-b6af-b0cc23156d3b", false, new DateTime(2023, 6, 1, 19, 15, 34, 708, DateTimeKind.Local).AddTicks(7764), "Test" });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "66875bf3-7597-41db-8f8a-a5efbe27caa8", "35e37116-62e1-4e4c-9e73-0a82b3427383" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "a8b4ea85-240e-4534-9fcc-1e4e801e58a9");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "df1f85f2-c8ff-4e83-8c4e-e8b44741ac19");

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "66875bf3-7597-41db-8f8a-a5efbe27caa8", "35e37116-62e1-4e4c-9e73-0a82b3427383" });

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "66875bf3-7597-41db-8f8a-a5efbe27caa8");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "35e37116-62e1-4e4c-9e73-0a82b3427383");

            migrationBuilder.DropColumn(
                name: "IsDepreciation",
                table: "Assets");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0b39d804-875b-4cc5-b248-3ef26ed4d7b1", "5f90dfa8-523c-46e7-8532-daccedf6137b", "Admin", "ADMIN" },
                    { "55f9e456-f5df-4619-a77e-04d93e4a5b9e", "326d873f-cad3-47bc-a8a3-41834a908453", "Manager", "MANAGER" },
                    { "8a757ade-a74e-4371-8ce7-61b38aeca279", "05b8a476-7408-454c-81ee-3c0a5fc8f854", "Staff", "STAFF" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreateDay", "Email", "EmailConfirmed", "FirstLogin", "IsActive", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UpdateDay", "UserName" },
                values: new object[] { "400d885b-33db-4eb5-8a88-f7660bb0ac41", 0, "0b55ba5a-0851-4ca8-9ffc-05bf3c6eb7f6", new DateTime(2023, 5, 23, 13, 56, 12, 172, DateTimeKind.Local).AddTicks(2712), null, false, false, true, false, null, null, "TEST", "AQAAAAEAACcQAAAAEOvSEtcAcNrZZPHPtpyu6GWV8UhLc8zB9Pwbsj34TvkyvNpgg8hS0puJqOO6kovfew==", null, false, 1, "7758d860-e12e-4014-bc35-5798f5cb2f49", false, new DateTime(2023, 5, 23, 13, 56, 12, 172, DateTimeKind.Local).AddTicks(2723), "Test" });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "0b39d804-875b-4cc5-b248-3ef26ed4d7b1", "400d885b-33db-4eb5-8a88-f7660bb0ac41" });
        }
    }
}

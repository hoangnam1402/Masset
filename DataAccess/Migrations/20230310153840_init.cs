﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AssetTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDay = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDay = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDay = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDay = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDay = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDay = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Setting",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FormatDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Logo = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Setting", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Supplier",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDay = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDay = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplier", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    CreateDay = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDay = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Assets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tag = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeID = table.Column<int>(type: "int", nullable: false),
                    SupplierID = table.Column<int>(type: "int", nullable: false),
                    LocationID = table.Column<int>(type: "int", nullable: false),
                    BrandID = table.Column<int>(type: "int", nullable: false),
                    Serial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cost = table.Column<int>(type: "int", nullable: true),
                    Warranty = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PurchaseDay = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateDay = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDay = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Assets_AssetTypes_TypeID",
                        column: x => x.TypeID,
                        principalTable: "AssetTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Assets_Brands_BrandID",
                        column: x => x.BrandID,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Assets_Locations_LocationID",
                        column: x => x.LocationID,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Assets_Supplier_SupplierID",
                        column: x => x.SupplierID,
                        principalTable: "Supplier",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Components",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Serial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: true),
                    AvailableQuantity = table.Column<int>(type: "int", nullable: true),
                    TypeID = table.Column<int>(type: "int", nullable: false),
                    SupplierID = table.Column<int>(type: "int", nullable: false),
                    LocationID = table.Column<int>(type: "int", nullable: false),
                    BrandID = table.Column<int>(type: "int", nullable: false),
                    Cost = table.Column<int>(type: "int", nullable: false),
                    PurchaseDay = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateDay = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDay = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Warranty = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Components", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Components_AssetTypes_TypeID",
                        column: x => x.TypeID,
                        principalTable: "AssetTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Components_Brands_BrandID",
                        column: x => x.BrandID,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Components_Locations_LocationID",
                        column: x => x.LocationID,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Components_Supplier_SupplierID",
                        column: x => x.SupplierID,
                        principalTable: "Supplier",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Maintenances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssetID = table.Column<int>(type: "int", nullable: false),
                    SupplierID = table.Column<int>(type: "int", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateDay = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDay = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maintenances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Maintenances_Assets_AssetID",
                        column: x => x.AssetID,
                        principalTable: "Assets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Maintenances_Supplier_SupplierID",
                        column: x => x.SupplierID,
                        principalTable: "Supplier",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Depreciations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category = table.Column<int>(type: "int", nullable: false),
                    AssetID = table.Column<int>(type: "int", nullable: true),
                    ComponentID = table.Column<int>(type: "int", nullable: true),
                    Period = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false),
                    CreateDay = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDay = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Depreciations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Depreciations_Assets_AssetID",
                        column: x => x.AssetID,
                        principalTable: "Assets",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Depreciations_Components_ComponentID",
                        column: x => x.ComponentID,
                        principalTable: "Components",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "356132cd-14f9-487e-88c8-2e064ec79c45", "41827f58-66ce-4807-867c-fbf190ab7ef4", "Admin", "ADMIN" },
                    { "9bb70653-3dd3-43ae-9ac8-83ca76fde891", "c1bb2d73-e747-4fbe-8f1c-df1150904afb", "Manager", "MANAGER" },
                    { "f239c2e0-e801-4bf7-9bd4-c82923a5ac8d", "93dac17c-3f22-4801-8f26-e7e4c013c9b6", "Staff", "STAFF" }
                });

            migrationBuilder.InsertData(
                table: "Setting",
                columns: new[] { "Id", "Address", "Currency", "Department", "Email", "FormatDate", "Language", "Logo", "Name", "Phone" },
                values: new object[] { 1, "University street", "$", "Equipment room", "University@gmail.com", "dd-mm-yyyy", "en", new byte[] { 137, 80, 78, 71, 13, 10, 26, 10, 0, 0, 0, 13, 73, 72, 68, 82, 0, 0, 0, 197, 0, 0, 0, 157, 8, 6, 0, 0, 0, 4, 229, 188, 106, 0, 0, 0, 1, 115, 82, 71, 66, 0, 174, 206, 28, 233, 0, 0, 0, 4, 103, 65, 77, 65, 0, 0, 177, 143, 11, 252, 97, 5, 0, 0, 0, 9, 112, 72, 89, 115, 0, 0, 14, 195, 0, 0, 14, 195, 1, 199, 111, 168, 100, 0, 0, 74, 223, 73, 68, 65, 84, 120, 94, 237, 125, 5, 152, 91, 215, 181, 245, 244, 235, 251, 95, 219, 215, 87, 122, 197, 20, 94, 210, 64, 155, 164, 73, 218, 64, 157, 244, 37, 77, 98, 135, 236, 36, 118, 156, 152, 29, 51, 179, 29, 51, 51, 51, 51, 51, 140, 153, 153, 97, 64, 35, 13, 106, 70, 195, 204, 60, 227, 25, 83, 214, 191, 215, 145, 174, 163, 40, 146, 70, 154, 209, 128, 109, 237, 47, 251, 203, 88, 186, 186, 247, 220, 123, 247, 58, 27, 207, 62, 62, 240, 146, 151, 188, 244, 45, 242, 130, 194, 75, 94, 178, 33, 47, 40, 188, 228, 37, 27, 242, 130, 194, 75, 94, 178, 33, 47, 40, 188, 228, 37, 27, 242, 130, 194, 75, 94, 178, 33, 47, 40, 188, 228, 37, 27, 242, 130, 194, 75, 94, 178, 33, 47, 40, 188, 228, 37, 27, 242, 130, 194, 75, 94, 178, 33, 47, 40, 188, 84, 35, 244, 245, 215, 95, 227, 238, 189, 123, 138, 249, 119, 93, 38, 47, 40, 188, 84, 109, 116, 247, 222, 215, 40, 43, 191, 135, 252, 226, 59, 72, 203, 43, 71, 124, 70, 137, 226, 140, 252, 91, 40, 40, 185, 35, 223, 221, 197, 61, 57, 166, 174, 145, 23, 20, 94, 170, 22, 186, 123, 247, 107, 36, 100, 148, 98, 227, 233, 76, 116, 90, 16, 131, 191, 12, 10, 131, 79, 151, 96, 197, 127, 31, 18, 142, 238, 139, 76, 216, 114, 58, 85, 129, 133, 224, 169, 75, 228, 5, 133, 135, 169, 252, 206, 61, 228, 21, 223, 66, 114, 118, 25, 162, 83, 74, 17, 96, 204, 199, 153, 128, 108, 236, 191, 156, 133, 173, 167, 211, 176, 230, 120, 26, 86, 30, 51, 243, 154, 227, 233, 216, 116, 58, 11, 91, 206, 167, 195, 247, 98, 6, 142, 95, 207, 66, 96, 100, 62, 74, 202, 239, 224, 94, 29, 55, 49, 156, 81, 114, 86, 25, 86, 29, 73, 65, 189, 177, 81, 240, 233, 25, 2, 159, 47, 245, 240, 105, 22, 8, 159, 207, 44, 220, 92, 39, 159, 5, 201, 119, 193, 168, 55, 94, 192, 113, 38, 19, 169, 57, 183, 44, 191, 174, 125, 242, 130, 162, 10, 84, 126, 75, 204, 130, 220, 82, 132, 198, 21, 226, 180, 46, 15, 219, 206, 101, 97, 222, 129, 52, 12, 221, 146, 140, 142, 43, 18, 208, 118, 65, 28, 26, 79, 51, 225, 157, 113, 70, 188, 60, 50, 2, 127, 25, 18, 138, 223, 125, 21, 134, 255, 145, 89, 243, 87, 3, 195, 240, 167, 126, 161, 120, 182, 111, 24, 94, 28, 22, 134, 110, 139, 162, 176, 230, 112, 18, 252, 34, 242, 112, 243, 150, 152, 21, 2, 138, 252, 226, 219, 8, 142, 45, 198, 145, 27, 185, 56, 30, 152, 135, 144, 184, 98, 100, 137, 233, 113, 235, 246, 61, 203, 8, 234, 30, 69, 36, 150, 98, 214, 158, 20, 185, 55, 1, 67, 99, 1, 64, 163, 0, 248, 124, 42, 220, 196, 10, 20, 252, 155, 159, 125, 44, 44, 199, 60, 255, 85, 56, 150, 30, 206, 64, 108, 106, 153, 229, 44, 181, 75, 94, 80, 184, 65, 84, 243, 133, 165, 119, 16, 151, 118, 19, 55, 140, 69, 216, 123, 45, 27, 115, 14, 36, 97, 192, 202, 24, 188, 63, 209, 136, 95, 247, 21, 65, 104, 39, 179, 224, 23, 22, 97, 248, 192, 223, 204, 31, 201, 223, 13, 133, 249, 25, 249, 67, 249, 140, 255, 254, 60, 16, 63, 233, 24, 140, 127, 140, 138, 194, 168, 77, 137, 56, 41, 26, 37, 62, 189, 84, 204, 142, 50, 92, 8, 47, 194, 154, 147, 153, 232, 183, 36, 14, 245, 71, 68, 160, 195, 188, 40, 108, 22, 77, 19, 145, 88, 140, 82, 177, 197, 53, 34, 64, 104, 170, 212, 5, 162, 175, 48, 119, 111, 42, 254, 95, 87, 131, 220, 163, 220, 31, 65, 161, 1, 193, 17, 19, 32, 242, 60, 254, 220, 63, 12, 203, 143, 100, 32, 183, 176, 246, 53, 134, 23, 20, 21, 16, 173, 24, 10, 94, 97, 233, 93, 36, 100, 150, 227, 148, 62, 15, 99, 54, 196, 226, 165, 175, 66, 225, 211, 66, 0, 64, 129, 127, 207, 34, 228, 156, 249, 56, 3, 82, 24, 108, 5, 66, 205, 142, 218, 255, 229, 152, 182, 65, 248, 116, 106, 164, 0, 33, 7, 121, 69, 183, 69, 208, 239, 41, 161, 242, 143, 42, 194, 148, 109, 9, 240, 233, 45, 246, 247, 39, 114, 92, 3, 225, 207, 116, 104, 49, 61, 18, 59, 206, 103, 8, 96, 110, 138, 134, 50, 143, 39, 35, 255, 14, 66, 227, 197, 121, 77, 47, 83, 255, 190, 83, 139, 224, 224, 115, 218, 113, 62, 19, 47, 200, 172, 239, 243, 190, 60, 15, 235, 123, 119, 133, 229, 55, 245, 134, 135, 227, 184, 95, 102, 173, 71, 167, 188, 160, 112, 66, 124, 55, 249, 37, 183, 197, 52, 202, 65, 143, 101, 177, 240, 233, 42, 130, 218, 148, 154, 64, 184, 169, 188, 72, 10, 184, 6, 0, 254, 77, 182, 247, 194, 9, 6, 130, 70, 102, 196, 63, 246, 15, 193, 164, 237, 137, 184, 26, 94, 32, 66, 125, 91, 69, 103, 162, 211, 74, 177, 226, 112, 42, 234, 139, 80, 248, 52, 148, 99, 9, 180, 14, 58, 116, 152, 107, 194, 110, 17, 52, 83, 114, 137, 152, 77, 183, 81, 82, 118, 87, 0, 112, 19, 123, 175, 100, 161, 235, 194, 24, 248, 180, 145, 25, 185, 129, 104, 155, 182, 6, 244, 93, 25, 47, 90, 164, 168, 86, 124, 17, 94, 178, 184, 236, 14, 234, 143, 53, 89, 38, 6, 171, 123, 119, 149, 249, 155, 214, 114, 207, 243, 162, 229, 153, 220, 170, 85, 96, 120, 65, 97, 135, 138, 111, 222, 81, 182, 252, 226, 131, 169, 104, 48, 53, 26, 63, 25, 32, 194, 218, 78, 156, 69, 10, 189, 178, 145, 229, 255, 206, 64, 64, 214, 142, 229, 108, 223, 81, 143, 70, 83, 163, 48, 231, 96, 26, 78, 235, 243, 17, 39, 130, 205, 25, 255, 84, 96, 46, 6, 175, 78, 192, 91, 131, 35, 224, 211, 89, 0, 215, 205, 128, 15, 71, 27, 49, 109, 87, 42, 246, 95, 207, 69, 72, 108, 9, 82, 196, 97, 143, 77, 43, 193, 65, 1, 66, 79, 241, 83, 222, 28, 106, 196, 143, 187, 136, 153, 214, 197, 128, 223, 245, 54, 160, 203, 236, 24, 44, 218, 151, 134, 75, 97, 5, 40, 16, 0, 87, 85, 148, 110, 223, 185, 35, 62, 205, 29, 53, 25, 36, 102, 222, 132, 206, 84, 40, 218, 49, 27, 123, 46, 167, 99, 211, 169, 52, 172, 56, 154, 134, 5, 190, 169, 152, 184, 57, 9, 195, 214, 38, 96, 192, 170, 120, 153, 48, 226, 240, 229, 2, 153, 52, 218, 11, 72, 121, 191, 246, 158, 135, 43, 44, 191, 125, 102, 64, 24, 130, 162, 11, 80, 86, 139, 126, 147, 23, 20, 22, 82, 90, 65, 28, 219, 235, 17, 133, 88, 120, 40, 29, 95, 204, 141, 197, 15, 196, 17, 86, 47, 75, 19, 110, 103, 32, 32, 243, 123, 106, 141, 79, 44, 220, 61, 24, 13, 167, 71, 99, 202, 158, 84, 156, 10, 202, 67, 106, 142, 56, 229, 241, 69, 216, 125, 57, 7, 35, 214, 37, 225, 163, 145, 70, 252, 119, 23, 61, 254, 222, 39, 4, 159, 205, 136, 193, 132, 221, 169, 56, 30, 144, 43, 194, 88, 138, 152, 212, 82, 156, 9, 202, 199, 130, 125, 233, 232, 52, 63, 14, 255, 18, 7, 253, 183, 61, 13, 120, 81, 108, 239, 198, 147, 163, 209, 119, 99, 178, 10, 119, 6, 68, 22, 33, 61, 175, 220, 45, 33, 226, 189, 222, 190, 115, 87, 205, 238, 169, 185, 229, 8, 21, 7, 254, 156, 46, 23, 7, 175, 230, 138, 208, 167, 99, 220, 174, 20, 244, 89, 159, 132, 78, 139, 227, 241, 217, 204, 104, 188, 61, 193, 136, 151, 70, 132, 225, 41, 49, 25, 25, 32, 240, 233, 109, 6, 165, 79, 135, 32, 153, 44, 132, 219, 138, 230, 108, 101, 165, 61, 237, 61, 27, 87, 152, 207, 89, 180, 241, 174, 11, 25, 50, 49, 125, 227, 55, 213, 52, 61, 242, 160, 160, 185, 81, 36, 47, 32, 60, 241, 38, 214, 159, 203, 66, 219, 249, 98, 150, 240, 133, 211, 132, 177, 68, 71, 92, 122, 209, 26, 24, 104, 90, 201, 139, 125, 108, 68, 36, 38, 237, 72, 198, 181, 136, 2, 21, 158, 101, 84, 230, 160, 191, 128, 97, 77, 28, 94, 29, 18, 134, 239, 183, 215, 227, 233, 46, 161, 104, 54, 35, 26, 235, 78, 164, 139, 102, 42, 66, 82, 214, 77, 21, 97, 58, 36, 199, 77, 223, 158, 140, 79, 39, 69, 226, 23, 221, 68, 67, 181, 10, 194, 19, 61, 194, 208, 115, 81, 156, 2, 66, 176, 28, 83, 36, 218, 204, 29, 162, 115, 158, 93, 112, 11, 113, 105, 101, 50, 251, 23, 11, 72, 115, 177, 249, 82, 54, 102, 31, 72, 67, 191, 85, 113, 104, 52, 41, 2, 175, 12, 21, 141, 40, 32, 85, 225, 83, 154, 123, 244, 149, 180, 64, 129, 22, 44, 224, 51, 225, 4, 65, 182, 54, 27, 171, 2, 6, 141, 121, 206, 78, 6, 204, 217, 157, 164, 18, 126, 181, 69, 143, 52, 40, 232, 152, 230, 138, 147, 75, 211, 163, 219, 34, 81, 255, 205, 101, 214, 227, 139, 119, 69, 43, 104, 204, 227, 40, 28, 74, 64, 116, 120, 124, 96, 56, 230, 237, 75, 70, 114, 78, 153, 18, 220, 180, 188, 91, 56, 46, 102, 82, 143, 197, 2, 182, 86, 114, 204, 187, 34, 100, 98, 138, 245, 18, 31, 229, 106, 88, 190, 114, 226, 57, 43, 198, 136, 73, 181, 235, 98, 6, 218, 206, 52, 42, 219, 90, 29, 39, 0, 123, 115, 76, 56, 150, 30, 72, 68, 100, 114, 177, 152, 53, 174, 105, 3, 154, 80, 140, 72, 209, 33, 47, 18, 7, 60, 183, 232, 14, 252, 196, 129, 167, 35, 60, 118, 67, 60, 26, 200, 57, 125, 186, 200, 189, 114, 102, 103, 148, 136, 142, 49, 35, 98, 154, 63, 224, 108, 34, 208, 0, 96, 143, 237, 29, 239, 14, 243, 218, 95, 234, 229, 93, 68, 139, 166, 44, 83, 247, 91, 27, 25, 239, 71, 26, 20, 52, 27, 134, 109, 76, 52, 107, 134, 207, 68, 16, 173, 103, 62, 123, 47, 205, 150, 121, 60, 65, 244, 142, 31, 254, 62, 56, 20, 203, 142, 164, 137, 198, 41, 53, 151, 48, 136, 176, 251, 158, 207, 192, 235, 227, 163, 68, 184, 69, 0, 69, 248, 254, 32, 62, 192, 226, 3, 169, 98, 51, 23, 35, 167, 240, 182, 154, 13, 195, 19, 139, 49, 101, 75, 18, 158, 162, 223, 210, 88, 198, 32, 199, 61, 63, 32, 24, 51, 118, 38, 225, 74, 88, 161, 74, 106, 21, 202, 249, 110, 223, 97, 205, 144, 101, 224, 21, 80, 217, 237, 219, 48, 38, 21, 99, 219, 217, 12, 244, 94, 28, 139, 191, 13, 20, 51, 176, 163, 220, 99, 11, 2, 193, 98, 230, 144, 239, 131, 217, 138, 237, 221, 35, 153, 2, 75, 208, 88, 2, 6, 10, 72, 212, 36, 245, 253, 204, 204, 207, 24, 85, 179, 253, 125, 101, 184, 165, 14, 245, 70, 132, 99, 179, 140, 63, 85, 38, 151, 154, 166, 71, 14, 20, 52, 151, 10, 75, 111, 41, 147, 229, 163, 137, 38, 177, 139, 9, 8, 121, 17, 182, 9, 38, 103, 204, 227, 104, 255, 54, 211, 225, 5, 49, 57, 230, 137, 163, 123, 62, 152, 102, 82, 185, 204, 232, 165, 88, 123, 66, 192, 48, 78, 28, 116, 58, 207, 157, 244, 168, 63, 206, 136, 249, 226, 87, 156, 51, 152, 143, 97, 166, 123, 199, 133, 44, 116, 152, 23, 139, 151, 122, 137, 141, 222, 206, 128, 223, 138, 255, 242, 229, 220, 24, 44, 63, 152, 142, 11, 33, 133, 42, 87, 81, 34, 38, 143, 43, 56, 32, 96, 146, 50, 203, 112, 204, 47, 7, 147, 182, 37, 225, 227, 169, 209, 120, 102, 136, 104, 156, 94, 2, 6, 6, 8, 152, 55, 161, 96, 43, 95, 71, 198, 109, 13, 4, 237, 158, 148, 224, 203, 119, 252, 158, 247, 70, 225, 39, 243, 111, 2, 72, 124, 135, 95, 244, 11, 193, 91, 227, 141, 104, 187, 192, 132, 190, 98, 114, 141, 216, 148, 132, 105, 226, 7, 205, 221, 159, 134, 182, 115, 162, 205, 153, 107, 79, 0, 131, 227, 106, 46, 220, 35, 24, 45, 196, 167, 217, 116, 38, 83, 229, 135, 106, 42, 178, 246, 72, 129, 130, 66, 166, 139, 41, 198, 72, 153, 153, 159, 16, 199, 85, 217, 255, 156, 253, 92, 5, 3, 5, 135, 66, 210, 66, 135, 167, 7, 71, 160, 207, 202, 4, 236, 22, 187, 156, 89, 230, 208, 248, 98, 108, 56, 155, 141, 238, 75, 19, 240, 210, 0, 17, 198, 54, 58, 52, 24, 29, 133, 177, 155, 146, 113, 76, 57, 207, 55, 21, 24, 54, 159, 203, 198, 128, 101, 9, 248, 231, 96, 185, 126, 231, 32, 188, 210, 55, 20, 173, 231, 197, 97, 209, 225, 116, 92, 55, 22, 34, 79, 156, 253, 138, 136, 38, 69, 145, 8, 73, 132, 56, 237, 71, 111, 228, 98, 206, 222, 52, 116, 94, 18, 47, 166, 86, 164, 248, 51, 2, 114, 142, 147, 62, 0, 199, 234, 40, 82, 102, 253, 239, 207, 133, 101, 118, 86, 14, 179, 8, 226, 51, 195, 34, 240, 206, 100, 19, 62, 155, 19, 139, 14, 43, 18, 49, 116, 115, 10, 102, 9, 240, 55, 136, 63, 115, 196, 63, 87, 198, 153, 175, 238, 55, 54, 181, 84, 102, 242, 114, 117, 255, 167, 196, 15, 250, 49, 65, 200, 235, 90, 95, 199, 29, 230, 152, 52, 192, 242, 255, 13, 69, 251, 52, 215, 225, 9, 153, 120, 134, 108, 75, 65, 128, 169, 72, 249, 127, 213, 77, 143, 12, 40, 152, 32, 59, 23, 82, 128, 158, 34, 200, 234, 161, 107, 51, 166, 189, 151, 99, 203, 60, 142, 76, 16, 117, 9, 86, 165, 27, 155, 207, 102, 138, 86, 40, 17, 231, 184, 92, 206, 91, 136, 145, 235, 226, 241, 120, 127, 17, 10, 153, 45, 159, 239, 27, 134, 129, 171, 226, 113, 57, 180, 64, 190, 103, 13, 212, 77, 28, 245, 203, 195, 216, 117, 9, 120, 170, 95, 48, 190, 215, 70, 143, 103, 122, 132, 162, 141, 56, 245, 123, 47, 101, 169, 99, 88, 51, 229, 140, 56, 73, 210, 71, 97, 162, 238, 170, 177, 8, 91, 46, 100, 99, 200, 154, 88, 252, 107, 164, 152, 93, 76, 34, 210, 148, 161, 64, 90, 107, 2, 235, 123, 208, 4, 77, 211, 136, 4, 1, 193, 192, 191, 69, 155, 176, 20, 165, 187, 152, 90, 211, 118, 36, 99, 231, 197, 44, 92, 11, 47, 84, 249, 17, 214, 113, 85, 148, 20, 36, 72, 115, 10, 111, 225, 125, 214, 58, 217, 187, 182, 43, 204, 223, 240, 249, 114, 92, 212, 108, 154, 111, 163, 153, 109, 98, 246, 117, 95, 26, 135, 179, 250, 124, 228, 137, 233, 89, 157, 244, 208, 131, 130, 175, 147, 14, 219, 209, 27, 57, 120, 151, 246, 61, 5, 135, 15, 219, 222, 139, 177, 199, 124, 89, 20, 36, 121, 97, 116, 162, 215, 30, 75, 69, 118, 129, 57, 3, 29, 26, 87, 130, 153, 187, 147, 205, 161, 201, 250, 254, 248, 69, 71, 189, 8, 106, 28, 252, 34, 11, 148, 73, 195, 44, 243, 165, 224, 124, 12, 90, 41, 78, 60, 203, 63, 222, 244, 195, 247, 58, 25, 48, 98, 109, 60, 110, 132, 231, 137, 35, 236, 252, 229, 18, 8, 20, 72, 70, 142, 232, 44, 95, 18, 199, 124, 194, 150, 68, 115, 214, 152, 247, 64, 32, 80, 27, 56, 187, 31, 142, 159, 204, 99, 200, 252, 187, 101, 16, 254, 77, 48, 81, 171, 124, 46, 227, 18, 127, 102, 203, 249, 172, 42, 155, 40, 234, 89, 244, 178, 100, 226, 237, 141, 197, 25, 243, 55, 162, 165, 62, 30, 31, 129, 223, 246, 145, 115, 240, 51, 13, 24, 234, 29, 8, 203, 51, 110, 36, 224, 229, 187, 100, 16, 161, 186, 232, 161, 7, 5, 31, 222, 234, 35, 201, 248, 223, 1, 98, 174, 208, 153, 230, 3, 182, 125, 33, 142, 152, 47, 164, 129, 63, 158, 16, 91, 154, 69, 110, 225, 73, 102, 39, 218, 36, 102, 195, 124, 223, 20, 212, 163, 153, 244, 177, 28, 35, 102, 199, 240, 53, 49, 184, 18, 154, 143, 220, 194, 59, 42, 244, 121, 62, 56, 23, 45, 102, 137, 207, 210, 74, 236, 108, 177, 229, 159, 148, 115, 204, 223, 155, 10, 255, 168, 2, 49, 55, 202, 213, 184, 42, 202, 218, 150, 148, 221, 129, 62, 186, 16, 115, 247, 38, 227, 205, 209, 34, 196, 180, 217, 57, 155, 210, 198, 215, 198, 231, 232, 126, 248, 57, 103, 88, 134, 84, 27, 136, 35, 220, 69, 47, 246, 121, 20, 22, 29, 76, 193, 69, 209, 96, 41, 217, 183, 148, 185, 214, 145, 81, 55, 70, 187, 196, 17, 95, 115, 34, 69, 229, 60, 42, 75, 212, 120, 189, 214, 136, 38, 230, 76, 239, 14, 48, 56, 78, 25, 195, 144, 245, 137, 42, 63, 19, 26, 95, 40, 0, 75, 130, 79, 55, 1, 7, 253, 26, 205, 79, 225, 253, 10, 56, 94, 31, 22, 142, 157, 231, 211, 45, 87, 245, 60, 61, 212, 160, 160, 105, 51, 207, 55, 21, 191, 236, 19, 98, 158, 17, 57, 219, 216, 190, 16, 91, 214, 132, 137, 47, 85, 52, 64, 95, 49, 183, 14, 92, 207, 69, 108, 90, 169, 202, 44, 51, 163, 251, 206, 4, 179, 131, 254, 120, 247, 96, 244, 94, 28, 7, 223, 27, 121, 136, 74, 42, 49, 103, 158, 101, 22, 235, 185, 36, 14, 79, 118, 147, 107, 182, 9, 194, 219, 163, 34, 49, 109, 123, 42, 78, 235, 105, 74, 149, 171, 10, 88, 103, 96, 160, 25, 197, 108, 247, 182, 179, 230, 12, 246, 223, 71, 138, 159, 64, 225, 160, 89, 209, 216, 34, 32, 142, 128, 64, 161, 161, 16, 81, 131, 136, 105, 244, 71, 49, 231, 58, 46, 138, 193, 220, 131, 233, 56, 36, 230, 27, 163, 94, 44, 235, 102, 185, 8, 135, 64, 13, 20, 96, 42, 198, 232, 205, 34, 128, 157, 244, 248, 121, 123, 61, 38, 111, 79, 68, 120, 98, 137, 101, 52, 238, 209, 173, 187, 247, 224, 39, 215, 232, 187, 54, 209, 60, 94, 142, 133, 206, 189, 189, 241, 242, 51, 190, 15, 30, 211, 74, 135, 129, 98, 90, 114, 44, 119, 228, 28, 76, 44, 178, 156, 101, 231, 149, 28, 241, 107, 44, 161, 108, 30, 199, 223, 240, 189, 52, 11, 196, 27, 163, 34, 112, 34, 48, 87, 221, 139, 167, 233, 161, 5, 69, 116, 114, 25, 230, 248, 166, 225, 135, 162, 146, 181, 25, 198, 161, 48, 105, 204, 227, 8, 8, 177, 177, 63, 152, 100, 82, 81, 21, 22, 220, 153, 146, 75, 177, 231, 90, 46, 186, 44, 139, 199, 19, 61, 229, 124, 157, 13, 248, 112, 162, 9, 243, 246, 165, 67, 39, 206, 31, 157, 227, 147, 244, 25, 54, 36, 225, 141, 225, 17, 74, 192, 254, 41, 2, 217, 123, 101, 18, 246, 94, 203, 83, 96, 168, 200, 42, 161, 118, 97, 8, 118, 201, 161, 116, 229, 52, 63, 59, 68, 206, 67, 205, 160, 141, 201, 209, 216, 121, 95, 252, 158, 96, 17, 225, 122, 70, 126, 215, 116, 102, 12, 134, 111, 76, 194, 198, 51, 153, 8, 140, 42, 84, 185, 24, 71, 126, 1, 63, 143, 16, 13, 56, 125, 103, 10, 30, 235, 16, 140, 191, 246, 52, 96, 194, 166, 68, 113, 226, 139, 45, 71, 184, 71, 212, 128, 134, 216, 18, 140, 221, 42, 154, 116, 148, 81, 180, 168, 89, 83, 42, 51, 207, 154, 249, 89, 235, 32, 188, 58, 210, 136, 241, 226, 68, 235, 99, 74, 212, 132, 97, 77, 12, 140, 92, 146, 103, 50, 96, 141, 128, 140, 19, 3, 159, 5, 153, 192, 16, 7, 252, 189, 201, 81, 42, 17, 105, 93, 53, 236, 9, 122, 40, 65, 145, 152, 81, 142, 217, 123, 82, 241, 179, 238, 50, 91, 51, 57, 85, 17, 24, 180, 89, 139, 139, 95, 122, 133, 162, 171, 8, 255, 185, 160, 60, 229, 216, 242, 101, 45, 218, 159, 142, 122, 35, 228, 5, 55, 211, 225, 247, 221, 66, 49, 116, 77, 188, 248, 13, 133, 202, 212, 208, 153, 74, 196, 207, 200, 68, 253, 209, 34, 196, 109, 197, 183, 16, 51, 228, 195, 233, 209, 56, 112, 53, 75, 153, 90, 206, 136, 126, 71, 122, 78, 25, 252, 162, 138, 177, 250, 68, 6, 154, 207, 142, 134, 79, 123, 57, 7, 115, 0, 142, 124, 5, 142, 85, 19, 14, 254, 91, 4, 203, 71, 180, 210, 83, 67, 141, 104, 57, 47, 22, 59, 47, 100, 170, 40, 151, 187, 130, 194, 156, 201, 66, 121, 102, 79, 118, 9, 193, 179, 221, 13, 152, 180, 41, 1, 41, 153, 229, 149, 74, 158, 241, 23, 188, 254, 81, 191, 28, 51, 192, 135, 69, 226, 71, 125, 197, 124, 101, 116, 74, 152, 127, 63, 45, 159, 181, 89, 20, 143, 195, 215, 115, 42, 28, 107, 162, 140, 99, 234, 118, 241, 87, 8, 12, 45, 191, 194, 247, 37, 60, 110, 91, 18, 162, 228, 126, 61, 25, 174, 125, 168, 64, 193, 231, 66, 167, 122, 250, 78, 62, 64, 113, 34, 9, 8, 91, 161, 178, 101, 13, 16, 194, 175, 13, 13, 135, 239, 149, 108, 21, 73, 201, 17, 103, 250, 162, 248, 8, 255, 166, 176, 83, 64, 155, 234, 196, 71, 136, 82, 197, 106, 116, 72, 115, 10, 203, 113, 232, 122, 54, 154, 50, 215, 241, 198, 13, 245, 251, 70, 83, 140, 242, 146, 51, 156, 58, 208, 124, 117, 156, 157, 139, 69, 237, 199, 164, 222, 196, 170, 195, 137, 120, 158, 101, 232, 52, 141, 8, 6, 103, 182, 184, 45, 32, 100, 22, 254, 98, 186, 9, 155, 79, 103, 168, 53, 30, 158, 160, 37, 7, 211, 4, 24, 193, 248, 121, 107, 61, 22, 90, 202, 45, 170, 42, 112, 12, 217, 178, 176, 240, 172, 62, 71, 113, 128, 252, 205, 50, 121, 119, 136, 239, 85, 249, 25, 98, 178, 170, 103, 196, 103, 192, 255, 183, 215, 97, 203, 249, 12, 1, 150, 231, 34, 82, 15, 21, 40, 24, 17, 90, 121, 36, 29, 63, 238, 35, 66, 70, 65, 167, 16, 217, 10, 150, 53, 243, 161, 82, 141, 139, 16, 76, 216, 154, 160, 234, 147, 40, 172, 134, 232, 34, 140, 88, 29, 111, 118, 106, 229, 28, 13, 38, 70, 202, 12, 156, 133, 204, 60, 70, 157, 238, 226, 156, 46, 11, 159, 207, 180, 56, 209, 226, 188, 127, 60, 54, 2, 190, 87, 115, 84, 169, 134, 217, 94, 119, 44, 68, 4, 12, 5, 100, 162, 204, 124, 191, 103, 193, 161, 150, 93, 214, 4, 222, 118, 204, 252, 55, 239, 133, 192, 164, 211, 252, 101, 16, 26, 79, 142, 196, 242, 67, 169, 170, 116, 131, 201, 64, 150, 114, 84, 20, 54, 117, 149, 10, 74, 238, 98, 133, 152, 112, 207, 50, 138, 212, 60, 8, 43, 143, 165, 32, 45, 183, 242, 206, 55, 73, 53, 48, 184, 125, 79, 61, 59, 50, 255, 118, 119, 93, 54, 31, 41, 1, 58, 74, 85, 32, 200, 115, 215, 76, 202, 143, 2, 208, 97, 65, 12, 252, 141, 133, 150, 35, 171, 78, 15, 13, 40, 88, 54, 177, 239, 90, 22, 30, 99, 185, 4, 133, 89, 155, 77, 237, 49, 191, 99, 104, 182, 93, 16, 190, 16, 71, 110, 219, 165, 28, 101, 114, 68, 167, 148, 96, 233, 145, 52, 52, 28, 19, 137, 95, 183, 51, 224, 31, 3, 66, 49, 126, 87, 42, 206, 135, 22, 138, 19, 205, 213, 118, 133, 24, 189, 33, 17, 47, 19, 116, 226, 132, 255, 123, 180, 17, 243, 247, 166, 201, 11, 41, 114, 106, 183, 243, 133, 82, 187, 48, 111, 49, 92, 94, 234, 235, 163, 197, 121, 102, 182, 155, 121, 2, 190, 92, 71, 99, 37, 104, 9, 6, 185, 159, 23, 134, 132, 163, 191, 152, 109, 155, 207, 101, 33, 32, 178, 24, 41, 2, 134, 114, 203, 178, 85, 79, 83, 146, 152, 43, 52, 25, 191, 223, 81, 143, 31, 138, 198, 101, 17, 98, 122, 94, 221, 88, 67, 205, 164, 97, 135, 37, 113, 230, 103, 70, 230, 243, 19, 115, 111, 206, 129, 84, 49, 71, 61, 83, 68, 248, 80, 128, 130, 182, 255, 201, 160, 124, 212, 147, 25, 91, 9, 147, 51, 64, 112, 214, 149, 7, 249, 199, 254, 97, 24, 41, 206, 232, 165, 16, 115, 21, 235, 153, 160, 92, 12, 88, 25, 143, 159, 200, 236, 77, 231, 188, 195, 204, 88, 236, 185, 144, 173, 102, 226, 144, 216, 34, 153, 49, 211, 209, 88, 124, 5, 130, 225, 165, 126, 33, 232, 183, 60, 30, 251, 197, 30, 174, 40, 132, 73, 211, 225, 130, 92, 99, 134, 111, 42, 62, 154, 42, 191, 23, 39, 221, 167, 137, 188, 72, 109, 166, 179, 29, 31, 199, 174, 249, 19, 98, 67, 191, 53, 33, 10, 189, 214, 38, 97, 215, 197, 108, 209, 100, 37, 234, 94, 107, 130, 76, 169, 101, 24, 191, 69, 204, 149, 22, 58, 188, 54, 54, 18, 59, 174, 84, 108, 251, 215, 4, 221, 189, 123, 15, 123, 175, 229, 224, 165, 225, 226, 227, 209, 60, 86, 224, 8, 64, 235, 5, 177, 96, 247, 16, 79, 208, 3, 15, 10, 206, 206, 55, 34, 139, 84, 100, 232, 126, 216, 206, 86, 208, 52, 97, 227, 119, 173, 130, 240, 212, 160, 8, 213, 73, 35, 86, 108, 250, 184, 244, 50, 236, 16, 225, 111, 60, 214, 146, 25, 238, 29, 138, 65, 155, 147, 85, 41, 55, 179, 224, 87, 100, 86, 30, 181, 78, 156, 197, 190, 50, 179, 183, 209, 227, 207, 195, 35, 177, 254, 116, 186, 138, 201, 59, 154, 164, 105, 26, 112, 193, 79, 96, 116, 9, 86, 30, 207, 192, 103, 51, 196, 212, 98, 9, 5, 95, 162, 35, 179, 142, 227, 227, 119, 12, 29, 11, 112, 158, 146, 151, 62, 102, 179, 128, 54, 56, 95, 105, 161, 154, 38, 222, 67, 66, 102, 25, 90, 177, 166, 169, 77, 16, 26, 206, 138, 193, 117, 209, 136, 117, 129, 88, 90, 178, 244, 112, 250, 55, 190, 197, 71, 254, 248, 219, 176, 8, 28, 188, 150, 109, 57, 162, 106, 244, 192, 131, 130, 14, 219, 144, 77, 50, 163, 105, 69, 111, 182, 194, 70, 166, 16, 242, 1, 170, 48, 158, 73, 28, 220, 18, 85, 174, 205, 226, 61, 54, 12, 80, 11, 100, 254, 237, 143, 247, 197, 169, 230, 98, 32, 206, 198, 233, 57, 183, 212, 67, 246, 97, 142, 67, 108, 249, 223, 183, 15, 198, 52, 153, 57, 233, 132, 59, 178, 135, 9, 18, 230, 25, 210, 114, 111, 225, 68, 96, 54, 234, 141, 8, 51, 251, 11, 52, 213, 28, 129, 149, 159, 147, 45, 128, 248, 165, 104, 176, 245, 167, 82, 144, 156, 85, 34, 128, 175, 221, 153, 153, 19, 14, 243, 51, 79, 51, 87, 34, 207, 168, 189, 204, 198, 116, 120, 171, 193, 98, 115, 155, 130, 100, 194, 121, 110, 160, 188, 27, 62, 67, 106, 221, 78, 122, 12, 22, 63, 208, 19, 244, 192, 131, 130, 89, 226, 239, 81, 112, 41, 244, 182, 2, 71, 38, 80, 68, 168, 159, 28, 24, 166, 102, 151, 212, 92, 243, 90, 103, 223, 203, 153, 120, 157, 203, 64, 155, 8, 32, 196, 110, 94, 188, 55, 81, 229, 35, 242, 139, 111, 225, 156, 33, 23, 237, 103, 201, 12, 249, 145, 252, 182, 89, 32, 186, 46, 137, 197, 57, 49, 207, 242, 138, 238, 56, 117, 16, 185, 132, 115, 159, 0, 233, 227, 73, 34, 68, 44, 209, 166, 176, 107, 26, 202, 118, 92, 26, 16, 232, 60, 183, 214, 161, 237, 156, 40, 53, 166, 196, 172, 91, 202, 255, 96, 18, 171, 182, 101, 143, 215, 191, 125, 231, 107, 236, 17, 211, 233, 53, 230, 77, 196, 207, 98, 118, 189, 58, 18, 102, 238, 82, 134, 76, 60, 171, 142, 166, 154, 195, 232, 52, 55, 229, 253, 191, 56, 44, 210, 242, 109, 213, 232, 129, 5, 5, 95, 22, 59, 95, 252, 155, 78, 171, 38, 252, 214, 66, 199, 127, 83, 232, 154, 233, 208, 124, 78, 172, 90, 2, 74, 103, 57, 44, 161, 4, 99, 69, 59, 60, 219, 61, 4, 127, 16, 51, 165, 205, 236, 24, 108, 191, 154, 163, 236, 209, 144, 184, 34, 76, 220, 153, 140, 151, 148, 0, 232, 241, 246, 176, 112, 229, 120, 7, 197, 22, 43, 65, 181, 71, 116, 116, 185, 172, 243, 232, 141, 44, 49, 225, 226, 240, 3, 58, 250, 90, 54, 215, 94, 246, 153, 255, 230, 75, 228, 223, 61, 131, 149, 217, 183, 229, 124, 14, 244, 209, 197, 117, 162, 189, 139, 61, 98, 211, 132, 89, 187, 83, 241, 103, 241, 181, 158, 232, 22, 162, 2, 14, 181, 13, 12, 38, 250, 88, 14, 194, 122, 41, 245, 76, 69, 27, 255, 164, 119, 24, 18, 197, 228, 163, 108, 84, 133, 30, 72, 80, 112, 182, 230, 138, 182, 246, 244, 35, 152, 245, 165, 250, 180, 22, 60, 10, 35, 205, 150, 94, 33, 232, 181, 50, 65, 213, 250, 208, 84, 58, 224, 151, 135, 142, 139, 227, 84, 212, 233, 5, 249, 110, 220, 250, 68, 92, 231, 66, 158, 220, 114, 181, 30, 186, 231, 194, 56, 252, 74, 4, 245, 87, 61, 67, 208, 105, 126, 44, 14, 223, 96, 251, 153, 91, 14, 19, 88, 76, 206, 249, 137, 63, 51, 75, 156, 232, 119, 233, 228, 139, 237, 173, 198, 66, 48, 90, 143, 135, 204, 23, 199, 239, 56, 174, 222, 193, 104, 49, 55, 70, 0, 151, 1, 125, 12, 51, 178, 181, 183, 72, 223, 85, 50, 200, 56, 251, 242, 121, 127, 18, 136, 190, 43, 226, 96, 76, 186, 89, 171, 154, 140, 97, 239, 252, 146, 91, 248, 120, 90, 148, 57, 129, 73, 127, 173, 107, 48, 46, 232, 115, 170, 12, 216, 7, 18, 20, 140, 87, 31, 242, 207, 85, 142, 239, 119, 52, 4, 205, 40, 209, 14, 79, 12, 14, 87, 107, 164, 185, 142, 129, 249, 3, 134, 21, 223, 30, 47, 90, 165, 101, 16, 30, 239, 19, 134, 213, 199, 210, 84, 24, 150, 142, 246, 206, 11, 57, 248, 116, 156, 121, 133, 220, 75, 3, 194, 48, 109, 87, 10, 34, 157, 212, 255, 112, 9, 41, 75, 184, 247, 138, 134, 233, 186, 56, 246, 27, 205, 96, 47, 162, 196, 127, 115, 140, 116, 160, 59, 24, 240, 194, 104, 35, 166, 251, 138, 35, 47, 90, 169, 58, 194, 169, 213, 69, 204, 190, 31, 213, 229, 227, 23, 204, 173, 200, 253, 110, 61, 155, 173, 222, 67, 109, 18, 223, 195, 44, 86, 230, 50, 161, 71, 51, 180, 163, 1, 91, 79, 38, 163, 160, 138, 227, 122, 224, 64, 65, 57, 10, 50, 21, 171, 69, 253, 202, 110, 183, 6, 5, 255, 150, 25, 227, 237, 81, 70, 113, 146, 115, 149, 163, 200, 50, 239, 201, 59, 68, 59, 176, 124, 162, 73, 0, 222, 153, 24, 165, 150, 128, 210, 209, 166, 41, 53, 130, 142, 54, 171, 68, 223, 242, 71, 219, 153, 38, 149, 75, 40, 187, 109, 127, 166, 161, 194, 160, 163, 25, 41, 96, 26, 185, 49, 65, 102, 38, 1, 229, 7, 2, 4, 91, 96, 106, 172, 1, 130, 213, 185, 98, 174, 45, 245, 77, 18, 16, 150, 42, 1, 123, 16, 41, 83, 180, 243, 166, 147, 233, 240, 169, 31, 128, 86, 83, 77, 42, 156, 93, 155, 184, 230, 251, 61, 26, 144, 139, 223, 12, 18, 45, 77, 80, 180, 215, 99, 193, 174, 68, 49, 67, 171, 22, 173, 123, 224, 64, 145, 37, 55, 188, 252, 68, 166, 89, 232, 40, 112, 20, 60, 178, 37, 227, 203, 6, 1, 87, 197, 36, 98, 56, 149, 62, 71, 115, 170, 215, 70, 129, 248, 125, 23, 86, 128, 154, 133, 146, 89, 107, 223, 107, 233, 120, 117, 36, 29, 109, 249, 173, 248, 22, 235, 142, 166, 169, 78, 23, 206, 162, 43, 20, 138, 53, 199, 196, 185, 27, 68, 191, 129, 32, 179, 92, 219, 22, 12, 218, 216, 234, 251, 225, 39, 226, 196, 143, 217, 156, 8, 125, 92, 137, 154, 89, 239, 136, 189, 251, 0, 41, 136, 111, 17, 205, 86, 62, 163, 55, 197, 215, 162, 0, 14, 223, 145, 82, 99, 121, 19, 123, 68, 179, 214, 152, 84, 130, 23, 199, 200, 59, 230, 26, 113, 49, 165, 135, 174, 137, 117, 187, 132, 196, 150, 30, 56, 80, 208, 246, 255, 96, 178, 60, 4, 154, 43, 20, 60, 141, 123, 132, 136, 208, 167, 168, 242, 104, 54, 27, 91, 118, 50, 11, 143, 143, 16, 109, 210, 92, 135, 79, 198, 70, 98, 189, 0, 137, 181, 70, 52, 153, 198, 109, 74, 194, 95, 197, 111, 248, 94, 135, 32, 52, 153, 30, 141, 29, 226, 132, 179, 148, 193, 81, 70, 154, 85, 176, 135, 252, 114, 205, 237, 111, 228, 58, 247, 51, 230, 182, 128, 224, 191, 105, 190, 209, 167, 17, 191, 133, 101, 231, 190, 114, 110, 174, 188, 123, 80, 181, 131, 45, 209, 94, 223, 125, 41, 11, 62, 93, 66, 240, 127, 163, 34, 213, 82, 219, 218, 34, 78, 46, 76, 158, 178, 183, 150, 122, 230, 109, 245, 232, 183, 44, 166, 202, 217, 247, 7, 10, 20, 76, 98, 77, 146, 217, 73, 57, 180, 74, 248, 68, 8, 191, 8, 196, 227, 195, 34, 48, 99, 111, 154, 90, 135, 96, 76, 42, 197, 108, 223, 52, 252, 153, 17, 36, 153, 205, 154, 207, 140, 193, 17, 17, 104, 70, 158, 206, 133, 22, 162, 223, 42, 49, 151, 68, 96, 159, 21, 59, 116, 168, 8, 45, 179, 205, 182, 37, 203, 26, 209, 230, 15, 139, 47, 81, 157, 196, 235, 9, 176, 124, 90, 200, 245, 28, 37, 8, 57, 22, 2, 69, 252, 134, 250, 98, 162, 77, 223, 147, 170, 204, 179, 186, 144, 5, 246, 36, 105, 75, 79, 91, 203, 115, 253, 45, 215, 147, 172, 136, 87, 218, 162, 54, 180, 31, 47, 201, 133, 88, 157, 24, 60, 97, 175, 42, 113, 184, 251, 44, 141, 81, 225, 218, 170, 208, 3, 5, 138, 75, 33, 249, 42, 249, 118, 63, 51, 44, 14, 245, 63, 70, 68, 96, 237, 169, 12, 21, 65, 138, 16, 1, 158, 180, 45, 25, 255, 205, 205, 65, 58, 25, 208, 93, 245, 87, 45, 70, 90, 118, 57, 14, 220, 200, 197, 167, 51, 101, 70, 145, 7, 247, 88, 175, 80, 44, 63, 144, 138, 196, 12, 251, 237, 83, 52, 95, 196, 47, 178, 24, 67, 215, 139, 239, 32, 231, 98, 214, 84, 205, 70, 182, 96, 32, 64, 56, 22, 182, 143, 233, 27, 134, 30, 34, 36, 231, 245, 121, 150, 51, 61, 188, 180, 237, 108, 38, 254, 58, 48, 92, 149, 203, 232, 76, 230, 229, 183, 181, 65, 156, 184, 134, 172, 147, 119, 68, 191, 176, 85, 16, 6, 172, 136, 125, 116, 52, 5, 103, 168, 113, 98, 155, 171, 10, 73, 102, 136, 69, 16, 185, 206, 248, 98, 112, 158, 204, 198, 183, 17, 28, 83, 140, 30, 11, 100, 54, 151, 239, 126, 42, 62, 194, 252, 253, 169, 202, 236, 97, 216, 116, 251, 233, 12, 252, 156, 155, 135, 200, 76, 254, 138, 168, 124, 86, 169, 58, 90, 227, 203, 38, 98, 44, 35, 216, 113, 33, 19, 207, 14, 144, 223, 48, 162, 68, 127, 197, 153, 239, 240, 73, 32, 62, 29, 31, 133, 67, 215, 115, 196, 111, 168, 249, 146, 140, 218, 160, 148, 156, 50, 116, 94, 40, 51, 116, 219, 32, 76, 220, 28, 235, 48, 143, 83, 19, 164, 106, 180, 68, 251, 51, 26, 201, 5, 82, 153, 50, 161, 85, 133, 30, 8, 80, 208, 193, 99, 104, 245, 213, 209, 226, 75, 48, 202, 32, 126, 2, 187, 83, 135, 197, 151, 42, 27, 247, 68, 64, 30, 62, 27, 39, 128, 120, 63, 0, 13, 68, 115, 28, 190, 145, 167, 156, 90, 218, 242, 195, 215, 197, 203, 241, 2, 164, 14, 122, 53, 163, 176, 89, 153, 121, 125, 180, 229, 228, 54, 20, 24, 89, 136, 254, 162, 97, 84, 243, 48, 2, 193, 158, 239, 64, 166, 249, 70, 176, 116, 10, 198, 92, 1, 32, 227, 246, 140, 104, 85, 102, 81, 206, 131, 72, 212, 166, 27, 196, 111, 251, 43, 67, 180, 162, 153, 227, 51, 74, 229, 61, 213, 142, 182, 152, 176, 213, 2, 10, 241, 41, 22, 236, 77, 126, 52, 162, 79, 76, 110, 109, 61, 147, 41, 130, 45, 102, 81, 59, 3, 134, 173, 73, 80, 14, 117, 129, 204, 78, 43, 142, 101, 224, 95, 67, 35, 240, 63, 242, 121, 123, 49, 143, 78, 233, 242, 85, 237, 209, 41, 113, 200, 219, 205, 22, 199, 88, 204, 154, 151, 7, 134, 98, 225, 126, 110, 120, 226, 56, 28, 202, 26, 255, 77, 167, 51, 209, 104, 138, 121, 253, 181, 2, 3, 217, 22, 12, 252, 140, 145, 14, 49, 195, 62, 158, 17, 141, 205, 151, 114, 212, 202, 176, 170, 102, 81, 31, 68, 98, 22, 190, 215, 34, 209, 22, 141, 2, 225, 123, 49, 19, 57, 5, 181, 147, 145, 159, 72, 80, 112, 187, 176, 118, 122, 108, 62, 153, 242, 104, 228, 41, 178, 10, 239, 168, 53, 209, 47, 15, 12, 195, 152, 245, 137, 48, 68, 21, 33, 61, 255, 22, 166, 30, 200, 80, 5, 116, 63, 237, 26, 140, 94, 162, 202, 175, 133, 22, 168, 104, 196, 182, 139, 57, 248, 104, 146, 8, 183, 60, 164, 247, 5, 48, 27, 78, 101, 170, 18, 112, 123, 218, 129, 142, 112, 112, 66, 41, 166, 138, 163, 254, 236, 144, 112, 229, 167, 40, 45, 96, 171, 29, 148, 239, 32, 159, 139, 57, 245, 155, 62, 33, 24, 180, 58, 65, 117, 252, 115, 228, 164, 63, 10, 68, 109, 188, 246, 184, 76, 86, 242, 108, 90, 207, 50, 33, 36, 174, 114, 13, 15, 170, 74, 227, 216, 120, 161, 141, 188, 55, 153, 204, 78, 250, 101, 138, 198, 126, 200, 65, 193, 172, 37, 103, 248, 199, 7, 70, 96, 202, 206, 36, 149, 9, 54, 165, 222, 196, 34, 209, 16, 62, 173, 197, 44, 106, 111, 192, 160, 53, 137, 170, 212, 155, 26, 98, 219, 197, 108, 252, 238, 171, 8, 245, 221, 71, 227, 77, 56, 31, 68, 159, 195, 190, 118, 160, 207, 193, 133, 241, 253, 215, 137, 175, 194, 54, 141, 170, 68, 67, 216, 26, 12, 100, 205, 132, 106, 25, 132, 31, 12, 136, 80, 61, 99, 217, 214, 210, 75, 144, 231, 87, 36, 190, 151, 57, 203, 125, 224, 122, 94, 141, 59, 220, 52, 173, 149, 163, 45, 239, 239, 63, 187, 132, 136, 73, 93, 164, 180, 126, 85, 168, 206, 131, 130, 139, 116, 142, 250, 113, 211, 16, 118, 210, 43, 87, 185, 134, 113, 92, 196, 78, 19, 230, 115, 29, 166, 139, 61, 79, 127, 131, 43, 209, 214, 49, 219, 106, 201, 33, 52, 23, 181, 206, 196, 142, 61, 162, 198, 224, 131, 59, 236, 151, 165, 122, 163, 86, 152, 149, 166, 230, 144, 151, 222, 104, 74, 20, 194, 18, 138, 29, 58, 233, 143, 34, 49, 212, 61, 113, 147, 8, 229, 91, 254, 88, 224, 155, 166, 222, 87, 77, 17, 223, 35, 195, 193, 221, 151, 137, 9, 215, 52, 0, 79, 244, 14, 147, 9, 176, 234, 187, 32, 213, 121, 80, 208, 60, 225, 202, 56, 70, 145, 130, 76, 69, 232, 182, 84, 156, 96, 102, 147, 197, 113, 230, 106, 176, 84, 209, 14, 212, 30, 163, 55, 201, 231, 44, 167, 16, 53, 58, 213, 55, 21, 145, 2, 30, 123, 173, 40, 239, 137, 51, 152, 95, 204, 126, 80, 201, 248, 67, 95, 153, 225, 40, 248, 12, 169, 218, 130, 129, 76, 160, 188, 239, 143, 159, 246, 48, 96, 170, 104, 41, 102, 195, 169, 185, 170, 248, 204, 31, 42, 226, 123, 57, 234, 159, 163, 252, 138, 174, 11, 98, 16, 40, 166, 109, 77, 17, 223, 3, 219, 122, 54, 153, 37, 190, 99, 179, 64, 124, 48, 62, 170, 202, 128, 32, 213, 121, 80, 48, 154, 67, 27, 145, 139, 244, 191, 156, 23, 11, 182, 205, 103, 79, 164, 77, 23, 178, 85, 46, 225, 162, 33, 79, 181, 155, 255, 149, 124, 254, 68, 239, 96, 44, 63, 154, 161, 204, 43, 123, 106, 156, 2, 205, 50, 240, 30, 203, 228, 33, 178, 127, 19, 215, 72, 211, 92, 178, 235, 63, 8, 55, 12, 80, 61, 86, 215, 157, 204, 84, 51, 98, 109, 69, 87, 234, 50, 49, 10, 21, 149, 114, 83, 149, 202, 208, 140, 218, 124, 54, 203, 242, 77, 245, 19, 115, 20, 201, 89, 55, 241, 54, 123, 216, 202, 36, 57, 114, 67, 130, 229, 155, 170, 81, 157, 7, 5, 227, 223, 220, 52, 177, 221, 28, 1, 68, 39, 3, 222, 28, 109, 196, 70, 121, 240, 244, 7, 46, 6, 23, 160, 243, 236, 104, 60, 222, 213, 128, 55, 196, 73, 94, 47, 14, 53, 107, 163, 236, 45, 4, 98, 45, 212, 113, 93, 62, 218, 47, 17, 141, 194, 68, 15, 77, 34, 123, 38, 19, 1, 193, 207, 219, 232, 241, 225, 20, 19, 246, 93, 203, 113, 106, 18, 112, 102, 162, 54, 99, 189, 21, 51, 216, 21, 245, 122, 114, 151, 84, 119, 241, 196, 18, 181, 79, 183, 167, 207, 237, 41, 98, 211, 136, 230, 51, 34, 225, 211, 49, 8, 99, 182, 166, 168, 224, 69, 77, 16, 223, 51, 251, 111, 189, 216, 63, 28, 207, 245, 9, 85, 61, 175, 60, 65, 117, 26, 20, 165, 162, 33, 174, 132, 138, 224, 207, 51, 41, 65, 101, 245, 235, 238, 203, 217, 74, 240, 253, 141, 197, 104, 57, 53, 10, 223, 23, 135, 250, 221, 97, 225, 216, 122, 54, 211, 110, 41, 54, 63, 226, 75, 219, 123, 45, 23, 239, 51, 220, 170, 249, 8, 182, 218, 65, 3, 4, 185, 163, 1, 77, 231, 198, 170, 238, 122, 44, 16, 116, 70, 20, 212, 147, 250, 124, 180, 153, 19, 141, 193, 107, 19, 176, 227, 82, 182, 152, 115, 37, 234, 154, 85, 217, 223, 154, 29, 3, 67, 227, 75, 213, 170, 55, 102, 213, 235, 143, 141, 80, 173, 47, 115, 10, 235, 30, 48, 152, 159, 89, 121, 56, 73, 205, 214, 29, 22, 198, 43, 115, 183, 38, 136, 97, 240, 237, 231, 51, 241, 155, 78, 33, 104, 56, 38, 74, 5, 91, 60, 65, 117, 26, 20, 250, 232, 2, 244, 93, 40, 130, 252, 134, 31, 94, 30, 20, 138, 203, 161, 133, 202, 79, 184, 17, 94, 132, 134, 163, 34, 224, 243, 182, 191, 218, 77, 212, 81, 81, 26, 65, 194, 158, 72, 108, 45, 255, 189, 126, 225, 142, 235, 150, 52, 64, 16, 44, 109, 131, 48, 98, 3, 179, 162, 21, 59, 140, 124, 41, 151, 101, 44, 62, 157, 196, 199, 225, 185, 45, 61, 92, 95, 31, 25, 134, 93, 23, 51, 213, 46, 68, 52, 217, 92, 77, 232, 241, 176, 114, 57, 39, 247, 96, 216, 122, 62, 29, 13, 198, 201, 61, 210, 196, 107, 32, 231, 173, 239, 135, 167, 251, 135, 192, 87, 64, 82, 215, 114, 34, 52, 85, 131, 162, 11, 213, 30, 126, 141, 199, 70, 34, 32, 178, 192, 242, 77, 245, 18, 3, 30, 99, 54, 139, 147, 223, 94, 143, 78, 139, 19, 80, 82, 238, 153, 9, 163, 78, 131, 98, 213, 241, 76, 60, 211, 47, 24, 175, 15, 14, 85, 11, 213, 89, 242, 189, 95, 102, 124, 46, 19, 101, 196, 168, 229, 12, 35, 206, 133, 228, 171, 153, 202, 30, 177, 182, 105, 250, 182, 56, 245, 208, 148, 73, 100, 207, 92, 34, 243, 115, 17, 234, 31, 137, 67, 189, 242, 88, 154, 42, 97, 176, 103, 130, 217, 210, 241, 192, 124, 212, 35, 56, 233, 151, 88, 159, 159, 11, 138, 154, 5, 225, 201, 126, 161, 152, 187, 55, 69, 85, 230, 186, 66, 76, 2, 174, 56, 158, 1, 159, 62, 97, 230, 112, 51, 207, 67, 176, 106, 231, 254, 68, 180, 229, 88, 35, 246, 94, 241, 76, 215, 10, 79, 17, 181, 49, 251, 190, 214, 235, 19, 161, 150, 249, 110, 56, 149, 97, 249, 166, 250, 136, 111, 135, 147, 199, 123, 19, 34, 81, 79, 76, 231, 213, 226, 75, 218, 179, 20, 42, 67, 117, 22, 20, 156, 97, 151, 31, 73, 87, 219, 70, 177, 146, 149, 91, 114, 177, 75, 223, 123, 220, 173, 167, 157, 168, 233, 89, 209, 106, 191, 6, 102, 181, 237, 145, 94, 64, 52, 156, 249, 7, 238, 29, 65, 161, 117, 20, 97, 162, 118, 248, 66, 135, 215, 134, 71, 168, 86, 55, 12, 237, 186, 50, 179, 211, 159, 105, 61, 87, 28, 118, 123, 93, 68, 248, 111, 150, 128, 112, 233, 105, 183, 96, 52, 153, 26, 141, 165, 135, 210, 69, 232, 237, 111, 206, 194, 173, 185, 86, 157, 96, 43, 28, 6, 0, 204, 53, 90, 118, 125, 30, 126, 214, 66, 135, 79, 185, 192, 39, 56, 223, 101, 13, 84, 19, 68, 121, 108, 50, 49, 26, 143, 137, 127, 199, 12, 115, 117, 19, 229, 131, 75, 140, 127, 216, 214, 92, 201, 112, 85, 100, 196, 83, 84, 103, 65, 65, 85, 200, 170, 88, 174, 147, 166, 227, 198, 60, 197, 187, 35, 141, 248, 131, 8, 89, 7, 17, 198, 235, 97, 246, 55, 32, 103, 91, 24, 58, 189, 253, 86, 137, 90, 237, 204, 126, 178, 98, 122, 56, 50, 153, 40, 100, 50, 35, 191, 55, 193, 164, 214, 61, 208, 212, 170, 136, 248, 242, 217, 47, 170, 207, 10, 113, 216, 197, 134, 86, 9, 63, 123, 231, 38, 243, 186, 188, 126, 115, 29, 154, 77, 143, 18, 31, 161, 200, 110, 6, 156, 13, 19, 218, 115, 173, 6, 19, 136, 206, 198, 75, 230, 245, 218, 234, 209, 110, 97, 172, 67, 144, 213, 22, 113, 163, 252, 255, 237, 29, 172, 246, 188, 224, 184, 170, 19, 178, 172, 111, 242, 21, 153, 240, 249, 60, 8, 147, 183, 38, 171, 77, 248, 61, 69, 117, 22, 20, 92, 18, 202, 234, 215, 236, 130, 114, 156, 49, 20, 40, 159, 130, 194, 208, 73, 132, 231, 134, 49, 223, 114, 212, 55, 68, 97, 37, 120, 2, 163, 10, 208, 110, 190, 185, 129, 151, 178, 243, 237, 9, 22, 153, 154, 163, 101, 16, 26, 77, 137, 198, 225, 235, 174, 45, 148, 225, 204, 204, 104, 216, 188, 125, 169, 230, 197, 70, 90, 87, 14, 71, 76, 13, 37, 90, 232, 177, 254, 97, 106, 245, 29, 147, 140, 20, 22, 154, 129, 140, 134, 105, 11, 236, 217, 91, 105, 242, 142, 100, 252, 97, 160, 152, 133, 76, 62, 114, 108, 142, 128, 193, 207, 149, 239, 163, 199, 162, 195, 52, 245, 88, 190, 82, 55, 52, 198, 202, 35, 105, 120, 254, 171, 48, 188, 61, 33, 10, 217, 78, 26, 62, 120, 130, 88, 236, 201, 181, 19, 63, 239, 29, 130, 29, 151, 115, 61, 58, 57, 212, 105, 159, 130, 49, 112, 214, 23, 253, 185, 151, 204, 248, 226, 108, 246, 92, 18, 163, 28, 58, 123, 68, 64, 132, 196, 23, 227, 237, 81, 20, 44, 17, 156, 138, 102, 112, 1, 76, 171, 153, 38, 92, 49, 124, 23, 96, 142, 136, 66, 204, 173, 187, 20, 32, 104, 218, 56, 155, 209, 249, 221, 71, 254, 120, 85, 252, 159, 29, 231, 179, 238, 11, 8, 157, 100, 54, 3, 62, 120, 45, 75, 181, 138, 225, 191, 41, 211, 212, 32, 7, 174, 231, 224, 229, 33, 226, 79, 104, 235, 69, 236, 157, 151, 172, 93, 183, 101, 32, 14, 235, 242, 80, 90, 71, 234, 175, 14, 95, 207, 70, 61, 49, 67, 185, 253, 49, 251, 242, 58, 90, 201, 88, 85, 226, 243, 98, 121, 9, 139, 0, 251, 46, 139, 67, 112, 172, 103, 107, 174, 234, 52, 40, 216, 124, 224, 205, 161, 34, 228, 239, 249, 163, 215, 162, 24, 4, 68, 210, 252, 248, 238, 140, 64, 129, 58, 35, 54, 246, 75, 60, 150, 5, 125, 206, 4, 150, 179, 172, 8, 93, 135, 121, 49, 42, 154, 117, 211, 50, 91, 187, 66, 44, 15, 103, 199, 111, 117, 13, 71, 66, 203, 235, 82, 131, 188, 229, 135, 214, 2, 58, 86, 237, 114, 31, 108, 141, 182, 158, 201, 18, 193, 145, 115, 180, 210, 227, 231, 162, 25, 54, 159, 74, 83, 225, 91, 190, 104, 58, 142, 215, 35, 138, 240, 217, 84, 249, 94, 59, 143, 189, 107, 144, 249, 125, 67, 127, 180, 156, 109, 82, 155, 54, 214, 5, 186, 46, 62, 30, 67, 163, 79, 119, 99, 96, 132, 128, 175, 30, 211, 142, 43, 48, 215, 157, 200, 84, 123, 224, 237, 18, 63, 147, 207, 207, 147, 84, 103, 65, 113, 57, 36, 15, 109, 196, 161, 252, 175, 54, 122, 149, 160, 35, 32, 236, 69, 153, 88, 251, 178, 245, 98, 54, 94, 225, 114, 81, 205, 233, 117, 4, 8, 106, 15, 49, 153, 232, 188, 95, 17, 64, 184, 179, 48, 134, 197, 134, 236, 11, 171, 66, 164, 142, 174, 193, 207, 120, 13, 17, 248, 254, 75, 227, 229, 30, 10, 84, 37, 41, 133, 195, 40, 78, 225, 87, 107, 19, 204, 38, 82, 115, 49, 237, 148, 35, 174, 195, 127, 117, 15, 193, 176, 117, 9, 106, 115, 24, 2, 163, 164, 236, 158, 234, 98, 222, 103, 121, 156, 217, 39, 114, 164, 241, 120, 45, 154, 103, 226, 120, 115, 23, 162, 140, 252, 170, 181, 203, 247, 4, 49, 201, 216, 122, 178, 56, 219, 237, 67, 112, 66, 151, 91, 97, 142, 167, 178, 116, 45, 188, 8, 253, 150, 196, 226, 185, 62, 33, 106, 167, 41, 79, 131, 175, 206, 130, 98, 233, 129, 20, 188, 63, 34, 12, 173, 38, 69, 201, 236, 89, 160, 162, 13, 214, 68, 1, 98, 103, 62, 2, 226, 85, 246, 108, 162, 160, 80, 72, 108, 133, 71, 99, 106, 136, 47, 185, 25, 34, 187, 125, 136, 147, 238, 70, 3, 50, 94, 235, 176, 174, 0, 47, 50, 242, 69, 71, 216, 54, 42, 68, 166, 144, 242, 243, 206, 193, 106, 247, 158, 112, 75, 225, 32, 65, 123, 65, 102, 242, 222, 226, 132, 170, 242, 102, 45, 124, 203, 223, 80, 219, 240, 124, 29, 130, 208, 147, 203, 88, 173, 218, 235, 176, 206, 107, 48, 247, 142, 163, 169, 198, 177, 219, 94, 79, 227, 15, 252, 241, 175, 145, 70, 248, 94, 173, 253, 48, 45, 155, 63, 116, 157, 19, 135, 31, 180, 54, 96, 235, 217, 140, 251, 62, 147, 39, 137, 190, 195, 202, 67, 25, 120, 107, 80, 56, 230, 112, 65, 81, 145, 231, 147, 153, 117, 22, 20, 11, 247, 167, 96, 252, 198, 56, 156, 12, 248, 238, 203, 102, 60, 154, 179, 252, 17, 177, 167, 255, 42, 2, 161, 132, 195, 25, 32, 40, 124, 50, 163, 126, 62, 51, 26, 23, 244, 174, 251, 16, 26, 81, 61, 15, 217, 154, 226, 124, 214, 166, 160, 119, 48, 160, 163, 8, 119, 152, 101, 191, 56, 142, 241, 148, 248, 68, 45, 22, 196, 154, 53, 12, 127, 111, 79, 195, 80, 107, 180, 8, 196, 103, 50, 190, 243, 2, 88, 10, 19, 125, 16, 99, 66, 9, 70, 179, 121, 116, 123, 209, 24, 142, 156, 111, 126, 38, 247, 214, 113, 81, 156, 90, 92, 67, 0, 215, 22, 21, 221, 188, 141, 126, 139, 5, 252, 45, 130, 100, 82, 75, 86, 230, 160, 167, 41, 62, 163, 12, 131, 150, 37, 224, 149, 62, 225, 170, 201, 93, 117, 36, 50, 235, 44, 40, 174, 4, 231, 32, 60, 206, 126, 218, 158, 209, 155, 171, 81, 133, 230, 162, 62, 238, 245, 96, 111, 230, 214, 152, 66, 243, 81, 0, 62, 158, 102, 196, 105, 67, 142, 229, 12, 238, 17, 247, 101, 251, 63, 154, 103, 92, 27, 110, 239, 252, 150, 235, 247, 17, 51, 136, 157, 5, 249, 154, 232, 100, 158, 49, 228, 226, 47, 212, 46, 4, 131, 179, 217, 158, 204, 239, 27, 7, 224, 215, 3, 216, 8, 160, 80, 153, 138, 20, 112, 134, 127, 167, 239, 16, 96, 168, 115, 200, 113, 246, 128, 209, 48, 0, 127, 30, 20, 129, 211, 186, 28, 151, 146, 142, 213, 69, 101, 183, 111, 99, 224, 74, 209, 110, 45, 117, 152, 177, 61, 238, 91, 190, 148, 39, 136, 207, 99, 211, 233, 44, 180, 23, 243, 119, 164, 60, 235, 234, 162, 58, 11, 10, 58, 192, 246, 242, 16, 116, 170, 79, 201, 108, 255, 204, 87, 97, 230, 217, 215, 158, 144, 104, 204, 217, 85, 102, 97, 38, 187, 24, 214, 37, 152, 220, 37, 106, 165, 206, 203, 229, 69, 179, 91, 135, 173, 115, 205, 107, 83, 80, 197, 113, 31, 190, 41, 17, 134, 216, 98, 101, 230, 177, 136, 143, 13, 21, 212, 98, 39, 71, 61, 162, 108, 89, 3, 151, 248, 69, 63, 232, 23, 138, 131, 254, 185, 170, 9, 2, 237, 101, 102, 196, 135, 111, 22, 109, 195, 253, 51, 236, 133, 153, 149, 105, 24, 132, 206, 11, 98, 236, 62, 179, 154, 34, 2, 114, 208, 186, 100, 101, 166, 78, 219, 158, 36, 160, 240, 156, 166, 32, 32, 184, 231, 71, 147, 41, 49, 104, 57, 35, 6, 134, 152, 234, 43, 81, 175, 179, 160, 176, 71, 180, 39, 217, 170, 230, 93, 241, 51, 84, 182, 152, 130, 228, 72, 216, 44, 57, 130, 87, 134, 134, 227, 164, 46, 95, 57, 188, 238, 18, 77, 24, 93, 100, 33, 94, 230, 254, 12, 246, 76, 31, 154, 61, 226, 52, 119, 22, 167, 90, 167, 26, 37, 223, 85, 166, 22, 119, 56, 122, 114, 152, 21, 32, 172, 127, 227, 140, 53, 96, 136, 246, 123, 126, 184, 17, 91, 47, 100, 171, 246, 254, 20, 244, 200, 148, 18, 116, 95, 20, 109, 94, 160, 111, 27, 149, 178, 140, 235, 71, 189, 67, 16, 18, 87, 236, 150, 191, 228, 73, 226, 4, 50, 104, 163, 152, 153, 237, 244, 24, 181, 62, 193, 163, 85, 189, 172, 9, 219, 123, 37, 7, 205, 167, 153, 48, 115, 87, 106, 181, 248, 43, 26, 61, 48, 160, 96, 166, 250, 88, 96, 30, 62, 157, 33, 130, 193, 198, 87, 206, 204, 17, 10, 150, 104, 145, 191, 12, 230, 206, 252, 89, 149, 182, 109, 105, 175, 78, 149, 25, 143, 107, 56, 190, 227, 79, 240, 250, 50, 115, 127, 60, 33, 82, 53, 81, 160, 32, 82, 8, 88, 141, 251, 239, 137, 2, 90, 10, 174, 59, 128, 208, 152, 2, 110, 113, 198, 95, 31, 31, 133, 237, 151, 190, 233, 162, 125, 45, 212, 92, 141, 171, 54, 153, 177, 189, 127, 254, 187, 101, 16, 22, 236, 75, 81, 133, 136, 181, 65, 10, 20, 155, 83, 21, 40, 134, 172, 142, 171, 212, 68, 100, 143, 168, 129, 216, 101, 190, 137, 104, 136, 97, 27, 18, 112, 61, 162, 122, 67, 208, 15, 4, 40, 40, 156, 134, 152, 66, 52, 154, 34, 51, 54, 75, 33, 156, 1, 194, 50, 219, 254, 172, 127, 168, 8, 72, 170, 229, 12, 238, 19, 95, 4, 103, 253, 151, 135, 91, 146, 129, 214, 2, 110, 249, 155, 27, 65, 30, 188, 106, 174, 225, 103, 164, 233, 180, 152, 117, 141, 8, 90, 154, 56, 149, 1, 132, 53, 91, 128, 241, 218, 216, 40, 156, 11, 49, 55, 27, 163, 9, 113, 76, 204, 170, 134, 108, 27, 74, 95, 202, 90, 115, 241, 122, 159, 235, 240, 250, 240, 48, 5, 210, 234, 204, 38, 59, 162, 251, 160, 104, 207, 158, 174, 158, 3, 5, 207, 195, 74, 232, 159, 12, 8, 199, 150, 11, 57, 202, 132, 174, 78, 170, 243, 160, 224, 187, 77, 207, 187, 141, 166, 10, 16, 50, 67, 218, 206, 216, 182, 76, 192, 180, 209, 97, 202, 142, 100, 17, 212, 202, 39, 117, 232, 232, 94, 137, 40, 48, 71, 126, 108, 77, 167, 134, 254, 120, 110, 96, 24, 182, 138, 211, 71, 162, 48, 68, 38, 151, 160, 225, 52, 1, 132, 5, 148, 223, 26, 83, 101, 153, 192, 16, 51, 241, 149, 161, 17, 170, 114, 247, 150, 56, 239, 188, 214, 17, 191, 60, 252, 186, 183, 140, 139, 247, 106, 61, 46, 11, 239, 23, 19, 147, 85, 171, 53, 77, 28, 219, 87, 27, 196, 124, 18, 159, 98, 228, 134, 56, 143, 152, 79, 156, 8, 66, 98, 75, 208, 114, 186, 17, 179, 118, 154, 119, 155, 170, 110, 170, 243, 160, 136, 74, 186, 137, 254, 76, 100, 209, 209, 165, 176, 217, 17, 130, 251, 204, 239, 133, 199, 236, 72, 81, 225, 186, 170, 212, 4, 177, 213, 230, 194, 61, 98, 58, 113, 61, 184, 166, 153, 120, 109, 254, 221, 90, 135, 249, 7, 210, 84, 23, 114, 106, 148, 60, 177, 251, 91, 177, 98, 150, 27, 200, 216, 58, 227, 85, 101, 222, 147, 140, 225, 243, 105, 145, 106, 217, 167, 26, 91, 110, 57, 86, 159, 204, 48, 251, 44, 28, 147, 246, 76, 120, 236, 7, 254, 152, 229, 155, 162, 138, 5, 107, 154, 8, 138, 193, 107, 5, 20, 98, 222, 77, 221, 230, 153, 232, 19, 179, 215, 92, 88, 246, 220, 192, 80, 149, 224, 172, 137, 64, 66, 157, 6, 69, 116, 82, 41, 166, 179, 115, 7, 139, 251, 156, 1, 130, 159, 83, 24, 229, 152, 246, 139, 227, 224, 23, 85, 172, 204, 141, 170, 16, 219, 234, 124, 54, 201, 248, 141, 233, 196, 107, 240, 255, 114, 157, 190, 171, 226, 97, 144, 217, 139, 128, 96, 63, 169, 241, 91, 18, 205, 253, 102, 173, 5, 212, 83, 172, 157, 179, 153, 8, 218, 206, 84, 68, 167, 112, 251, 170, 123, 10, 32, 189, 89, 9, 204, 141, 107, 172, 65, 251, 97, 128, 218, 209, 180, 54, 74, 63, 40, 176, 3, 151, 203, 68, 34, 19, 216, 226, 125, 73, 46, 85, 29, 87, 68, 103, 12, 249, 24, 182, 46, 30, 11, 15, 166, 170, 61, 7, 107, 130, 234, 44, 40, 216, 36, 119, 241, 193, 52, 252, 222, 178, 59, 169, 83, 97, 163, 80, 136, 208, 212, 27, 101, 196, 165, 176, 2, 21, 18, 173, 10, 81, 232, 206, 6, 139, 233, 196, 109, 126, 105, 58, 209, 105, 38, 139, 205, 254, 87, 49, 101, 46, 200, 53, 104, 94, 113, 47, 184, 29, 231, 179, 225, 211, 81, 4, 147, 227, 32, 104, 108, 199, 230, 9, 230, 189, 139, 159, 242, 155, 62, 161, 88, 121, 44, 19, 217, 249, 183, 84, 9, 5, 125, 135, 183, 152, 63, 97, 45, 22, 199, 73, 230, 179, 234, 25, 140, 45, 231, 178, 4, 180, 53, 27, 133, 202, 45, 186, 133, 222, 243, 227, 241, 163, 86, 6, 108, 62, 93, 245, 140, 118, 90, 118, 25, 86, 28, 77, 197, 16, 241, 79, 168, 249, 170, 171, 192, 208, 150, 234, 28, 40, 104, 241, 48, 180, 185, 237, 98, 22, 94, 24, 46, 51, 53, 19, 102, 206, 0, 97, 153, 197, 159, 30, 24, 174, 182, 248, 245, 68, 168, 142, 229, 35, 140, 116, 177, 79, 172, 234, 41, 203, 149, 123, 236, 86, 46, 66, 185, 235, 108, 134, 202, 28, 83, 40, 143, 7, 228, 225, 195, 9, 34, 148, 92, 134, 234, 105, 179, 201, 30, 139, 22, 248, 215, 248, 40, 236, 191, 158, 123, 95, 19, 174, 57, 150, 142, 231, 6, 135, 155, 115, 24, 108, 247, 41, 26, 235, 103, 253, 195, 177, 238, 76, 150, 28, 83, 179, 126, 5, 91, 0, 181, 155, 30, 139, 199, 190, 12, 86, 109, 111, 170, 82, 251, 68, 241, 223, 123, 37, 19, 51, 119, 37, 138, 249, 84, 115, 29, 66, 72, 117, 14, 20, 204, 69, 232, 99, 138, 240, 203, 161, 2, 8, 7, 142, 228, 183, 152, 51, 120, 79, 3, 230, 236, 78, 182, 156, 161, 234, 196, 240, 111, 118, 193, 77, 248, 27, 243, 176, 255, 114, 26, 86, 31, 76, 194, 184, 245, 241, 152, 189, 43, 89, 153, 76, 164, 152, 212, 82, 244, 97, 15, 170, 119, 253, 204, 99, 212, 76, 44, 123, 99, 244, 20, 211, 241, 150, 103, 242, 206, 244, 24, 164, 230, 154, 55, 183, 231, 98, 172, 229, 71, 210, 208, 99, 113, 52, 86, 28, 74, 193, 145, 27, 89, 240, 143, 42, 84, 141, 15, 106, 154, 216, 232, 161, 169, 104, 174, 167, 59, 135, 154, 59, 187, 87, 210, 132, 229, 19, 166, 41, 214, 99, 89, 60, 166, 239, 73, 83, 190, 74, 77, 82, 157, 2, 5, 213, 35, 107, 91, 26, 176, 131, 56, 103, 62, 10, 129, 61, 225, 208, 152, 160, 17, 167, 110, 200, 250, 4, 164, 100, 155, 157, 80, 71, 196, 7, 203, 48, 165, 53, 59, 122, 214, 116, 208, 239, 222, 189, 167, 52, 22, 157, 69, 174, 242, 162, 83, 205, 62, 83, 26, 17, 20, 203, 14, 167, 170, 46, 27, 106, 201, 43, 1, 193, 80, 44, 185, 162, 113, 187, 202, 4, 26, 207, 71, 147, 136, 247, 218, 78, 167, 90, 252, 204, 246, 77, 133, 73, 174, 207, 241, 243, 190, 88, 20, 199, 220, 4, 199, 73, 211, 177, 76, 198, 237, 168, 147, 136, 250, 141, 205, 115, 80, 236, 232, 97, 184, 65, 151, 244, 121, 120, 127, 116, 36, 158, 233, 27, 166, 162, 113, 149, 53, 119, 152, 243, 97, 190, 101, 219, 185, 76, 181, 228, 180, 166, 169, 78, 129, 130, 77, 204, 212, 6, 139, 98, 170, 40, 33, 115, 54, 243, 90, 4, 166, 229, 252, 88, 92, 14, 47, 176, 107, 63, 243, 101, 179, 84, 98, 253, 177, 12, 76, 218, 150, 164, 186, 116, 176, 239, 168, 198, 163, 54, 38, 170, 77, 94, 184, 65, 253, 150, 51, 153, 247, 67, 136, 156, 101, 67, 98, 139, 16, 26, 87, 172, 26, 54, 151, 148, 221, 86, 218, 195, 154, 40, 124, 108, 225, 201, 53, 25, 190, 87, 115, 49, 125, 127, 26, 186, 173, 140, 195, 27, 4, 73, 23, 49, 183, 52, 144, 208, 206, 119, 213, 215, 224, 111, 40, 252, 52, 25, 153, 177, 239, 172, 199, 171, 35, 195, 209, 125, 89, 12, 166, 200, 249, 153, 200, 187, 40, 215, 51, 37, 223, 84, 197, 134, 214, 34, 71, 13, 70, 179, 143, 145, 41, 150, 112, 179, 6, 139, 99, 39, 81, 224, 15, 92, 201, 197, 2, 185, 207, 169, 219, 147, 213, 125, 91, 63, 135, 225, 235, 19, 85, 59, 251, 85, 71, 211, 101, 114, 169, 188, 134, 241, 189, 152, 141, 215, 71, 24, 241, 207, 145, 145, 74, 147, 105, 90, 213, 29, 226, 68, 196, 10, 227, 185, 123, 146, 148, 230, 169, 141, 22, 165, 117, 6, 20, 220, 146, 105, 13, 215, 43, 136, 32, 84, 104, 138, 240, 123, 17, 182, 159, 245, 15, 195, 158, 107, 185, 14, 215, 69, 208, 191, 8, 136, 44, 196, 63, 7, 133, 153, 103, 115, 150, 72, 124, 41, 26, 72, 99, 238, 152, 218, 49, 8, 191, 237, 19, 140, 246, 115, 162, 238, 103, 130, 175, 134, 23, 98, 216, 218, 120, 116, 152, 23, 139, 193, 107, 146, 112, 69, 28, 235, 155, 183, 238, 168, 151, 204, 107, 197, 166, 138, 192, 229, 148, 169, 23, 168, 17, 55, 134, 15, 137, 47, 194, 129, 235, 217, 152, 177, 39, 21, 45, 23, 198, 227, 37, 250, 68, 204, 134, 51, 130, 69, 51, 143, 126, 135, 189, 251, 178, 220, 143, 170, 229, 234, 106, 192, 139, 35, 34, 209, 118, 81, 28, 166, 236, 74, 81, 235, 144, 67, 98, 11, 85, 104, 146, 51, 47, 219, 126, 150, 138, 201, 196, 6, 109, 81, 34, 248, 28, 143, 6, 136, 160, 232, 34, 12, 95, 157, 136, 206, 11, 98, 49, 97, 75, 18, 206, 91, 42, 130, 249, 125, 191, 229, 241, 248, 189, 220, 167, 122, 190, 188, 111, 235, 231, 32, 26, 136, 207, 225, 79, 226, 160, 115, 11, 131, 202, 250, 2, 51, 100, 188, 127, 29, 24, 134, 102, 179, 99, 228, 217, 187, 95, 177, 203, 73, 140, 29, 255, 118, 156, 75, 199, 89, 125, 174, 10, 100, 212, 6, 213, 9, 80, 112, 54, 216, 119, 53, 7, 111, 141, 17, 33, 122, 191, 130, 72, 19, 191, 163, 112, 53, 15, 82, 230, 11, 187, 111, 56, 162, 244, 156, 114, 117, 140, 234, 49, 171, 182, 231, 146, 223, 81, 0, 53, 166, 153, 195, 217, 188, 153, 14, 159, 79, 49, 170, 89, 146, 166, 19, 247, 220, 86, 130, 243, 150, 248, 11, 242, 219, 245, 39, 179, 204, 166, 148, 8, 224, 133, 144, 60, 204, 220, 145, 128, 37, 114, 222, 195, 226, 104, 27, 98, 75, 213, 142, 161, 204, 126, 151, 223, 98, 101, 235, 215, 42, 201, 198, 89, 250, 152, 56, 155, 99, 55, 37, 226, 29, 70, 136, 184, 229, 24, 67, 203, 188, 7, 142, 67, 99, 222, 15, 195, 170, 93, 67, 80, 111, 84, 164, 58, 254, 164, 46, 79, 53, 20, 99, 113, 33, 103, 121, 218, 215, 92, 211, 205, 235, 4, 152, 138, 112, 84, 151, 139, 85, 39, 51, 48, 106, 109, 2, 46, 24, 242, 20, 96, 88, 44, 119, 228, 70, 142, 104, 26, 57, 223, 219, 126, 248, 85, 183, 96, 44, 57, 152, 166, 158, 3, 207, 209, 74, 237, 213, 33, 207, 129, 224, 164, 54, 178, 126, 14, 100, 126, 254, 111, 63, 204, 17, 109, 194, 68, 97, 101, 168, 237, 156, 24, 252, 174, 167, 94, 52, 79, 229, 42, 88, 185, 89, 188, 95, 100, 30, 214, 29, 75, 246, 120, 133, 173, 59, 84, 39, 64, 17, 149, 82, 138, 22, 108, 139, 201, 40, 14, 95, 144, 45, 16, 172, 153, 130, 44, 47, 151, 251, 104, 103, 84, 48, 147, 68, 36, 149, 162, 253, 124, 147, 243, 194, 60, 10, 102, 219, 111, 118, 213, 44, 187, 125, 71, 4, 62, 77, 37, 232, 24, 237, 25, 186, 50, 22, 198, 120, 115, 57, 56, 115, 23, 77, 38, 137, 121, 212, 80, 198, 73, 59, 191, 121, 32, 254, 183, 111, 48, 122, 44, 137, 198, 22, 153, 221, 34, 18, 185, 58, 208, 50, 163, 91, 77, 147, 20, 218, 211, 98, 111, 211, 25, 86, 201, 64, 154, 71, 92, 92, 100, 41, 69, 111, 43, 38, 32, 187, 150, 104, 230, 14, 137, 150, 7, 253, 2, 2, 49, 42, 165, 4, 251, 175, 100, 170, 223, 255, 133, 91, 142, 113, 51, 123, 118, 74, 127, 227, 6, 154, 79, 142, 192, 229, 16, 179, 70, 160, 166, 235, 52, 55, 202, 18, 137, 10, 194, 196, 173, 223, 4, 31, 6, 175, 138, 55, 135, 142, 29, 249, 59, 4, 167, 140, 169, 163, 90, 246, 235, 126, 142, 131, 183, 251, 207, 193, 145, 120, 172, 107, 48, 150, 30, 114, 191, 188, 134, 191, 247, 55, 21, 168, 173, 156, 11, 229, 25, 122, 194, 199, 169, 44, 213, 58, 40, 168, 50, 7, 48, 9, 197, 176, 39, 5, 212, 222, 11, 179, 102, 49, 51, 126, 56, 40, 2, 126, 98, 111, 218, 174, 198, 179, 37, 157, 169, 4, 255, 28, 38, 166, 19, 237, 115, 71, 160, 224, 172, 41, 215, 158, 187, 195, 188, 41, 57, 155, 0, 76, 219, 43, 160, 224, 111, 62, 215, 169, 150, 152, 204, 73, 176, 119, 45, 171, 86, 149, 153, 195, 223, 104, 179, 60, 1, 199, 108, 59, 103, 251, 238, 33, 168, 63, 33, 18, 211, 228, 92, 87, 194, 242, 239, 135, 135, 149, 121, 35, 231, 160, 38, 186, 22, 89, 132, 233, 187, 18, 209, 125, 177, 73, 249, 57, 151, 228, 223, 9, 153, 229, 34, 252, 119, 191, 229, 152, 6, 153, 10, 177, 192, 55, 25, 159, 176, 206, 169, 71, 168, 249, 252, 44, 115, 97, 131, 52, 142, 155, 215, 231, 236, 46, 99, 152, 225, 155, 166, 204, 39, 106, 51, 94, 87, 29, 47, 192, 225, 190, 29, 26, 77, 228, 98, 37, 154, 114, 28, 187, 237, 51, 32, 243, 94, 68, 107, 190, 55, 193, 168, 250, 214, 186, 67, 28, 55, 3, 15, 207, 245, 8, 195, 59, 67, 194, 112, 202, 223, 253, 16, 42, 187, 146, 4, 137, 31, 199, 173, 14, 40, 19, 181, 73, 181, 10, 10, 10, 205, 174, 75, 89, 106, 55, 34, 245, 82, 200, 246, 94, 152, 198, 242, 210, 88, 30, 61, 203, 55, 85, 213, 246, 56, 155, 76, 248, 221, 85, 99, 17, 126, 211, 75, 132, 73, 43, 51, 183, 119, 78, 10, 121, 7, 3, 150, 236, 75, 86, 38, 10, 65, 49, 126, 187, 152, 92, 34, 128, 220, 157, 135, 209, 48, 206, 90, 116, 168, 155, 76, 23, 173, 99, 189, 28, 85, 27, 51, 5, 84, 51, 73, 56, 139, 119, 51, 224, 249, 33, 17, 120, 111, 102, 172, 218, 63, 227, 90, 228, 55, 77, 219, 24, 166, 140, 75, 187, 137, 224, 152, 34, 229, 168, 107, 133, 126, 116, 242, 217, 198, 126, 209, 161, 52, 124, 58, 35, 14, 127, 231, 30, 224, 61, 196, 228, 98, 69, 44, 175, 193, 113, 242, 58, 188, 134, 118, 93, 178, 104, 155, 15, 167, 153, 112, 222, 210, 28, 141, 154, 229, 203, 121, 98, 42, 137, 179, 223, 101, 105, 188, 186, 38, 105, 214, 206, 100, 243, 162, 44, 158, 199, 246, 25, 104, 247, 34, 207, 247, 69, 17, 106, 154, 178, 238, 16, 55, 197, 217, 127, 37, 11, 255, 217, 41, 24, 45, 166, 71, 43, 141, 233, 14, 149, 223, 17, 63, 45, 77, 204, 208, 244, 155, 106, 249, 110, 109, 83, 173, 129, 130, 126, 4, 23, 157, 191, 57, 78, 252, 8, 87, 194, 175, 20, 134, 102, 129, 232, 37, 47, 218, 36, 102, 81, 69, 164, 64, 17, 94, 132, 159, 246, 112, 1, 20, 29, 13, 88, 118, 144, 160, 144, 217, 86, 64, 49, 122, 155, 128, 162, 115, 48, 14, 95, 203, 82, 165, 10, 124, 81, 11, 14, 164, 155, 77, 42, 87, 198, 201, 115, 18, 60, 244, 87, 68, 16, 251, 173, 142, 197, 149, 208, 60, 135, 32, 102, 248, 151, 235, 208, 217, 74, 254, 199, 20, 92, 250, 85, 52, 173, 120, 30, 13, 128, 142, 152, 62, 68, 103, 3, 70, 110, 73, 22, 211, 207, 172, 153, 184, 62, 250, 213, 145, 17, 104, 189, 224, 27, 80, 204, 221, 35, 160, 144, 9, 165, 34, 80, 60, 251, 85, 168, 234, 87, 235, 14, 177, 138, 117, 128, 152, 153, 108, 14, 247, 213, 218, 36, 21, 241, 115, 149, 232, 131, 177, 251, 35, 77, 71, 2, 186, 46, 80, 173, 128, 130, 15, 130, 219, 99, 205, 97, 83, 177, 166, 34, 104, 156, 101, 29, 9, 45, 153, 223, 137, 169, 240, 226, 176, 112, 236, 185, 236, 250, 11, 11, 136, 44, 54, 111, 251, 203, 115, 56, 18, 46, 11, 40, 150, 31, 50, 131, 130, 201, 48, 238, 127, 247, 146, 56, 189, 236, 144, 65, 187, 222, 16, 83, 140, 182, 115, 229, 165, 55, 160, 227, 109, 231, 28, 182, 204, 241, 242, 158, 24, 117, 18, 112, 125, 58, 195, 132, 189, 151, 50, 28, 154, 5, 183, 196, 143, 161, 79, 65, 71, 213, 167, 163, 128, 66, 243, 129, 156, 61, 19, 141, 45, 207, 230, 149, 177, 81, 48, 38, 137, 233, 33, 207, 150, 154, 136, 90, 162, 211, 146, 111, 28, 94, 87, 65, 241, 230, 232, 112, 28, 243, 115, 173, 57, 28, 137, 215, 99, 15, 220, 63, 138, 111, 245, 179, 238, 242, 28, 143, 184, 215, 14, 159, 19, 69, 65, 169, 121, 133, 97, 93, 161, 90, 1, 5, 133, 96, 255, 117, 214, 12, 137, 45, 206, 153, 215, 217, 203, 231, 119, 52, 27, 100, 230, 156, 234, 155, 34, 118, 185, 235, 145, 145, 208, 184, 18, 52, 158, 44, 154, 200, 153, 79, 65, 33, 161, 249, 180, 223, 12, 138, 66, 121, 65, 187, 197, 164, 155, 188, 213, 108, 143, 83, 140, 151, 238, 79, 199, 79, 123, 57, 17, 40, 107, 230, 120, 57, 123, 55, 240, 71, 3, 17, 176, 189, 87, 205, 123, 105, 184, 66, 116, 200, 185, 110, 224, 205, 17, 22, 115, 210, 149, 235, 145, 233, 91, 116, 215, 99, 222, 158, 132, 251, 194, 197, 156, 3, 67, 164, 26, 41, 80, 244, 170, 192, 124, 18, 237, 214, 97, 110, 52, 252, 194, 93, 239, 203, 74, 63, 230, 154, 56, 230, 156, 220, 62, 158, 100, 194, 89, 125, 205, 116, 28, 175, 78, 170, 21, 80, 112, 137, 103, 143, 197, 50, 43, 210, 188, 112, 6, 8, 178, 101, 198, 124, 123, 108, 132, 178, 235, 221, 153, 81, 226, 211, 203, 48, 102, 99, 188, 121, 230, 117, 100, 246, 40, 80, 232, 177, 120, 79, 18, 242, 196, 209, 38, 40, 216, 219, 245, 90, 68, 190, 154, 197, 152, 200, 107, 60, 75, 180, 4, 199, 89, 145, 41, 195, 115, 241, 58, 98, 2, 45, 18, 95, 130, 187, 133, 210, 87, 112, 53, 137, 197, 227, 104, 174, 197, 166, 149, 137, 230, 74, 195, 147, 95, 133, 155, 39, 132, 138, 192, 193, 113, 137, 9, 250, 190, 152, 162, 121, 197, 230, 6, 209, 244, 79, 46, 135, 138, 159, 193, 155, 16, 154, 186, 85, 64, 209, 205, 9, 40, 120, 142, 119, 253, 84, 98, 207, 157, 53, 11, 12, 123, 175, 98, 216, 251, 93, 127, 140, 221, 144, 168, 124, 131, 7, 157, 106, 28, 20, 133, 98, 159, 211, 60, 185, 223, 232, 203, 25, 40, 248, 29, 103, 93, 17, 234, 181, 167, 51, 84, 200, 212, 29, 162, 173, 123, 52, 32, 71, 124, 1, 241, 43, 28, 153, 104, 252, 252, 75, 61, 70, 175, 139, 83, 201, 34, 130, 142, 182, 45, 227, 254, 52, 157, 78, 250, 229, 224, 79, 131, 35, 238, 71, 122, 190, 243, 123, 141, 233, 67, 116, 50, 160, 237, 130, 88, 236, 20, 155, 60, 57, 139, 37, 222, 174, 129, 193, 30, 165, 102, 149, 171, 196, 100, 187, 197, 113, 10, 180, 106, 2, 33, 64, 28, 141, 129, 66, 221, 37, 88, 128, 144, 167, 124, 32, 130, 145, 154, 199, 130, 9, 213, 253, 194, 167, 147, 229, 57, 56, 250, 189, 220, 227, 250, 51, 153, 242, 220, 92, 127, 206, 58, 83, 49, 154, 176, 196, 94, 222, 229, 230, 179, 158, 41, 200, 172, 109, 170, 113, 80, 92, 52, 20, 224, 45, 238, 113, 93, 17, 32, 200, 124, 81, 205, 131, 84, 181, 108, 100, 138, 253, 125, 236, 156, 17, 67, 133, 9, 153, 101, 248, 219, 48, 121, 105, 74, 91, 200, 249, 120, 77, 107, 38, 232, 90, 5, 125, 43, 163, 173, 209, 173, 219, 95, 99, 216, 26, 75, 124, 95, 27, 175, 45, 115, 140, 194, 127, 232, 27, 34, 90, 41, 73, 173, 99, 168, 40, 84, 236, 42, 209, 52, 241, 139, 44, 194, 88, 113, 162, 159, 26, 36, 90, 131, 254, 23, 199, 193, 107, 218, 142, 131, 194, 46, 207, 106, 242, 150, 4, 36, 137, 141, 111, 77, 4, 70, 151, 69, 162, 237, 218, 138, 185, 170, 77, 14, 214, 108, 121, 46, 172, 182, 189, 22, 81, 40, 26, 203, 181, 241, 51, 2, 184, 235, 162, 76, 58, 109, 116, 248, 155, 252, 246, 170, 209, 220, 239, 234, 65, 167, 26, 3, 5, 95, 12, 103, 145, 193, 43, 101, 198, 98, 137, 179, 163, 25, 203, 154, 41, 0, 221, 67, 84, 249, 7, 227, 252, 149, 33, 150, 44, 204, 223, 155, 34, 246, 180, 248, 4, 141, 45, 215, 164, 143, 161, 49, 133, 66, 76, 143, 250, 98, 255, 115, 75, 98, 141, 104, 130, 48, 75, 253, 194, 80, 209, 18, 108, 148, 96, 251, 59, 237, 223, 2, 40, 159, 129, 17, 88, 127, 42, 205, 45, 127, 199, 29, 226, 172, 191, 231, 82, 38, 94, 38, 184, 153, 252, 179, 29, 11, 153, 247, 33, 142, 253, 191, 6, 135, 64, 23, 85, 124, 223, 100, 227, 115, 191, 115, 247, 30, 26, 77, 149, 137, 168, 133, 229, 56, 219, 223, 18, 100, 109, 130, 176, 234, 72, 42, 216, 30, 212, 85, 82, 181, 106, 27, 146, 148, 191, 183, 112, 95, 138, 104, 71, 199, 213, 5, 15, 18, 213, 24, 40, 56, 123, 6, 68, 230, 227, 215, 108, 3, 201, 108, 48, 95, 108, 69, 252, 145, 63, 94, 24, 98, 172, 82, 91, 119, 218, 212, 44, 78, 107, 207, 46, 125, 172, 127, 82, 181, 62, 242, 127, 141, 45, 181, 63, 207, 13, 10, 65, 124, 198, 55, 47, 149, 0, 190, 65, 7, 178, 55, 19, 103, 54, 191, 209, 126, 215, 41, 8, 159, 77, 139, 68, 82, 182, 251, 90, 172, 50, 20, 158, 88, 132, 238, 75, 229, 62, 168, 185, 108, 199, 195, 250, 37, 142, 169, 125, 16, 14, 250, 229, 222, 143, 247, 51, 210, 87, 90, 94, 142, 255, 155, 20, 105, 62, 198, 222, 239, 58, 7, 161, 209, 68, 163, 152, 167, 238, 237, 0, 203, 124, 198, 27, 108, 106, 221, 68, 167, 194, 235, 149, 45, 21, 175, 107, 84, 99, 160, 96, 217, 117, 251, 185, 50, 91, 177, 2, 214, 21, 45, 193, 99, 196, 49, 100, 97, 155, 171, 142, 170, 35, 162, 25, 69, 7, 48, 32, 186, 64, 149, 18, 232, 172, 56, 192, 194, 33, 113, 133, 170, 198, 72, 35, 229, 244, 138, 96, 25, 98, 139, 212, 247, 214, 191, 33, 243, 60, 250, 184, 98, 149, 141, 38, 32, 56, 35, 87, 55, 49, 183, 67, 109, 198, 141, 38, 109, 199, 195, 49, 106, 247, 70, 95, 194, 250, 153, 113, 98, 136, 72, 46, 177, 123, 31, 252, 140, 153, 100, 58, 247, 212, 40, 174, 18, 35, 106, 3, 214, 139, 150, 16, 63, 170, 221, 236, 104, 245, 126, 107, 226, 25, 212, 4, 213, 8, 40, 216, 153, 143, 203, 68, 213, 42, 54, 10, 60, 85, 184, 45, 8, 108, 89, 180, 73, 253, 9, 38, 92, 12, 118, 191, 247, 171, 61, 226, 12, 200, 242, 111, 103, 108, 251, 78, 249, 146, 153, 88, 179, 119, 44, 153, 21, 171, 53, 77, 28, 35, 181, 166, 189, 241, 104, 76, 16, 216, 222, 139, 179, 251, 231, 119, 238, 10, 244, 89, 93, 142, 218, 173, 246, 7, 221, 66, 112, 224, 106, 118, 149, 86, 217, 213, 53, 170, 17, 80, 208, 246, 28, 189, 41, 209, 12, 6, 58, 117, 246, 64, 96, 205, 22, 187, 119, 168, 204, 68, 180, 235, 61, 77, 156, 69, 141, 73, 165, 170, 29, 255, 249, 224, 2, 92, 12, 117, 143, 47, 24, 10, 84, 219, 198, 172, 90, 106, 127, 207, 114, 20, 150, 137, 95, 10, 177, 63, 62, 103, 204, 253, 3, 185, 95, 31, 183, 6, 96, 121, 134, 187, 68, 240, 176, 239, 210, 144, 53, 241, 248, 83, 119, 3, 90, 76, 139, 86, 107, 56, 42, 107, 222, 214, 69, 170, 118, 80, 208, 180, 56, 26, 144, 135, 159, 114, 55, 34, 45, 106, 98, 15, 8, 214, 252, 73, 160, 202, 144, 86, 215, 238, 253, 12, 149, 30, 245, 203, 198, 216, 13, 9, 104, 61, 51, 74, 217, 211, 13, 39, 71, 162, 225, 20, 215, 248, 125, 57, 190, 215, 210, 104, 28, 188, 154, 85, 227, 139, 96, 184, 183, 248, 89, 125, 30, 186, 47, 142, 17, 231, 217, 254, 248, 236, 178, 220, 95, 163, 73, 70, 180, 152, 30, 133, 225, 107, 226, 112, 196, 63, 87, 153, 89, 238, 18, 253, 6, 246, 204, 125, 172, 79, 152, 218, 253, 117, 195, 201, 234, 223, 9, 181, 166, 169, 218, 65, 145, 154, 83, 142, 41, 123, 82, 205, 113, 124, 103, 113, 118, 141, 249, 189, 152, 78, 220, 183, 206, 175, 26, 219, 35, 82, 91, 176, 19, 199, 43, 12, 117, 114, 221, 132, 86, 111, 196, 124, 128, 43, 252, 174, 31, 62, 20, 243, 206, 40, 182, 122, 77, 82, 128, 49, 95, 133, 143, 185, 246, 193, 238, 184, 28, 49, 131, 27, 50, 230, 255, 233, 42, 147, 205, 233, 244, 74, 135, 141, 169, 185, 251, 210, 217, 111, 174, 67, 215, 197, 241, 213, 22, 113, 171, 77, 170, 118, 80, 156, 8, 204, 195, 251, 140, 124, 240, 197, 184, 162, 37, 120, 140, 8, 232, 156, 3, 105, 200, 200, 119, 47, 89, 231, 46, 49, 185, 71, 115, 162, 239, 202, 120, 243, 170, 55, 134, 128, 237, 229, 50, 236, 49, 3, 1, 173, 130, 208, 104, 70, 140, 152, 19, 230, 197, 73, 213, 77, 105, 185, 101, 232, 186, 76, 198, 170, 181, 180, 177, 55, 46, 91, 230, 253, 112, 66, 106, 17, 168, 246, 176, 96, 235, 30, 154, 95, 149, 25, 46, 147, 154, 167, 117, 185, 162, 241, 131, 240, 207, 65, 161, 216, 121, 49, 187, 70, 162, 110, 53, 77, 213, 10, 10, 38, 159, 102, 238, 101, 197, 169, 222, 53, 95, 66, 227, 86, 129, 240, 189, 158, 235, 177, 36, 152, 51, 98, 132, 41, 72, 204, 1, 130, 240, 41, 173, 189, 127, 69, 217, 107, 141, 121, 79, 157, 12, 88, 188, 55, 249, 91, 77, 13, 170, 131, 232, 60, 79, 219, 157, 2, 181, 207, 182, 6, 8, 123, 99, 178, 102, 150, 156, 200, 24, 31, 239, 31, 138, 169, 187, 146, 225, 31, 101, 127, 139, 52, 87, 41, 48, 186, 4, 77, 166, 154, 155, 71, 79, 222, 145, 162, 202, 234, 31, 70, 170, 86, 80, 68, 139, 105, 193, 178, 7, 149, 52, 115, 229, 37, 242, 24, 113, 176, 95, 28, 28, 170, 202, 190, 107, 96, 242, 85, 68, 83, 138, 33, 70, 46, 67, 109, 60, 197, 4, 118, 205, 118, 73, 240, 232, 35, 201, 120, 127, 221, 35, 88, 252, 139, 28, 181, 72, 169, 58, 136, 130, 124, 206, 144, 143, 63, 170, 172, 182, 229, 186, 246, 198, 163, 49, 191, 39, 32, 218, 234, 85, 4, 111, 221, 137, 12, 85, 118, 226, 78, 14, 194, 150, 184, 1, 254, 236, 61, 2, 202, 47, 2, 81, 111, 68, 56, 46, 137, 105, 107, 189, 40, 234, 97, 162, 106, 5, 197, 190, 75, 89, 230, 140, 48, 109, 117, 123, 47, 207, 150, 45, 66, 214, 105, 129, 9, 97, 9, 174, 217, 234, 220, 191, 129, 126, 75, 146, 188, 116, 87, 152, 54, 48, 205, 50, 235, 56, 190, 53, 93, 13, 206, 71, 183, 37, 113, 223, 14, 31, 59, 3, 7, 199, 252, 97, 0, 154, 76, 137, 194, 89, 93, 190, 106, 47, 227, 73, 162, 35, 207, 78, 128, 31, 140, 23, 19, 148, 102, 147, 163, 194, 70, 141, 53, 192, 180, 215, 163, 241, 28, 75, 167, 19, 7, 194, 155, 89, 112, 203, 238, 51, 250, 46, 151, 99, 237, 137, 116, 188, 62, 36, 84, 149, 203, 236, 62, 159, 166, 10, 37, 31, 86, 170, 86, 80, 12, 91, 155, 96, 206, 190, 86, 244, 34, 53, 230, 113, 2, 138, 153, 123, 18, 212, 70, 236, 174, 208, 225, 128, 76, 76, 219, 17, 139, 17, 107, 76, 46, 241, 184, 77, 209, 88, 114, 52, 81, 105, 6, 71, 243, 28, 67, 140, 43, 143, 167, 131, 251, 84, 43, 223, 193, 149, 153, 249, 35, 127, 116, 91, 254, 205, 126, 119, 158, 162, 232, 228, 82, 76, 220, 156, 104, 94, 147, 93, 145, 9, 202, 113, 208, 161, 238, 168, 195, 44, 223, 100, 149, 201, 119, 68, 156, 19, 214, 158, 76, 193, 136, 245, 246, 159, 147, 53, 51, 90, 245, 91, 238, 234, 218, 90, 135, 142, 243, 77, 170, 236, 228, 97, 166, 106, 1, 5, 99, 214, 156, 193, 95, 30, 45, 246, 39, 95, 84, 69, 66, 165, 49, 5, 176, 169, 14, 123, 46, 103, 32, 167, 208, 181, 153, 40, 34, 169, 4, 61, 57, 179, 115, 54, 231, 82, 80, 102, 204, 157, 49, 151, 119, 182, 9, 18, 112, 36, 169, 254, 73, 246, 232, 206, 157, 175, 149, 54, 57, 23, 90, 160, 214, 44, 171, 218, 39, 106, 59, 103, 26, 131, 2, 43, 19, 192, 168, 173, 201, 30, 91, 65, 198, 49, 204, 228, 138, 63, 49, 131, 212, 51, 116, 118, 125, 75, 144, 224, 131, 241, 70, 28, 246, 207, 83, 21, 197, 188, 15, 123, 148, 83, 112, 7, 19, 55, 38, 153, 151, 187, 114, 213, 163, 189, 231, 100, 205, 172, 183, 146, 247, 242, 247, 209, 236, 124, 94, 236, 80, 243, 60, 44, 84, 45, 160, 96, 135, 183, 43, 193, 121, 230, 186, 33, 87, 157, 86, 30, 67, 80, 180, 8, 194, 105, 131, 227, 94, 78, 182, 196, 93, 138, 118, 94, 204, 193, 43, 220, 176, 157, 97, 85, 158, 131, 2, 234, 136, 249, 61, 5, 168, 83, 48, 134, 172, 73, 84, 171, 243, 236, 145, 150, 164, 186, 24, 92, 168, 26, 134, 125, 159, 171, 214, 156, 69, 208, 248, 185, 240, 239, 190, 10, 199, 234, 99, 233, 150, 179, 84, 158, 88, 114, 178, 254, 84, 38, 158, 160, 249, 201, 241, 218, 187, 38, 153, 96, 161, 134, 237, 30, 162, 182, 24, 102, 98, 145, 51, 185, 61, 177, 189, 117, 151, 57, 134, 18, 213, 252, 76, 181, 220, 209, 158, 185, 189, 231, 164, 49, 171, 136, 69, 251, 60, 37, 227, 216, 196, 166, 205, 110, 148, 130, 60, 168, 84, 45, 160, 96, 168, 115, 145, 168, 111, 101, 151, 59, 123, 161, 214, 204, 23, 196, 23, 252, 165, 1, 87, 141, 230, 109, 115, 93, 165, 84, 54, 82, 59, 149, 165, 4, 67, 19, 78, 187, 215, 208, 152, 223, 179, 15, 84, 39, 3, 122, 45, 139, 7, 187, 238, 17, 0, 142, 28, 251, 112, 241, 111, 24, 69, 123, 150, 85, 170, 236, 168, 193, 192, 129, 61, 237, 71, 33, 98, 247, 243, 17, 17, 240, 143, 112, 239, 30, 108, 137, 27, 211, 127, 56, 89, 156, 126, 158, 215, 222, 181, 248, 25, 159, 173, 204, 244, 191, 29, 110, 196, 184, 221, 169, 106, 113, 144, 3, 87, 73, 156, 245, 59, 170, 91, 122, 63, 238, 231, 205, 194, 72, 130, 193, 222, 121, 173, 153, 207, 137, 147, 154, 104, 148, 217, 251, 83, 213, 242, 220, 71, 129, 170, 5, 20, 220, 121, 168, 213, 76, 75, 241, 31, 5, 197, 222, 3, 119, 196, 157, 13, 8, 136, 46, 82, 66, 234, 14, 113, 157, 48, 55, 8, 84, 145, 35, 87, 128, 65, 230, 204, 47, 38, 87, 67, 113, 146, 207, 136, 16, 50, 172, 234, 40, 162, 194, 14, 128, 135, 253, 114, 240, 14, 251, 220, 114, 115, 22, 254, 222, 158, 80, 81, 216, 4, 24, 95, 206, 50, 138, 127, 225, 126, 229, 40, 175, 207, 190, 181, 221, 24, 181, 163, 217, 100, 111, 82, 225, 117, 201, 162, 85, 217, 119, 119, 207, 229, 108, 181, 40, 202, 30, 209, 148, 165, 230, 56, 109, 200, 199, 23, 220, 47, 143, 38, 166, 43, 19, 21, 159, 31, 175, 209, 60, 8, 19, 183, 39, 170, 222, 176, 143, 10, 85, 11, 40, 98, 51, 202, 205, 185, 9, 237, 225, 218, 62, 112, 71, 204, 28, 65, 247, 202, 129, 130, 196, 222, 73, 157, 230, 203, 139, 103, 215, 13, 87, 53, 148, 50, 19, 228, 216, 246, 65, 216, 113, 41, 75, 181, 163, 116, 68, 140, 88, 177, 140, 125, 244, 122, 203, 154, 16, 130, 202, 222, 57, 9, 140, 127, 223, 80, 27, 228, 51, 122, 227, 14, 241, 250, 11, 247, 137, 189, 79, 59, 222, 222, 249, 249, 60, 121, 111, 34, 172, 67, 100, 214, 103, 117, 171, 179, 208, 53, 151, 183, 178, 164, 69, 181, 17, 226, 125, 186, 26, 244, 224, 61, 52, 209, 169, 118, 155, 142, 124, 175, 135, 149, 60, 14, 10, 102, 56, 3, 163, 139, 205, 179, 12, 31, 172, 189, 7, 238, 140, 43, 169, 41, 72, 20, 90, 38, 148, 218, 205, 143, 49, 3, 195, 149, 235, 107, 90, 133, 241, 127, 17, 244, 1, 43, 227, 197, 244, 41, 84, 201, 50, 91, 226, 39, 116, 50, 185, 66, 111, 235, 217, 76, 252, 75, 28, 79, 37, 184, 182, 26, 67, 19, 92, 241, 91, 150, 159, 204, 116, 217, 63, 98, 166, 121, 239, 181, 108, 243, 194, 37, 77, 27, 88, 159, 151, 247, 35, 32, 126, 122, 112, 4, 54, 156, 206, 80, 161, 82, 71, 9, 78, 106, 40, 174, 211, 30, 164, 58, 3, 138, 255, 192, 38, 106, 218, 189, 90, 159, 211, 30, 115, 236, 162, 229, 219, 138, 102, 33, 32, 172, 75, 234, 31, 5, 242, 56, 40, 212, 139, 189, 42, 47, 150, 182, 168, 171, 179, 53, 153, 47, 139, 66, 80, 9, 159, 194, 154, 40, 203, 108, 136, 220, 138, 192, 208, 182, 22, 118, 69, 16, 52, 65, 22, 63, 232, 3, 177, 229, 185, 167, 29, 155, 115, 57, 42, 99, 200, 20, 63, 230, 160, 95, 30, 218, 114, 13, 181, 118, 29, 107, 33, 230, 249, 68, 128, 95, 23, 243, 102, 239, 213, 156, 10, 19, 145, 188, 206, 113, 93, 62, 222, 24, 43, 126, 11, 159, 157, 237, 185, 24, 253, 106, 163, 67, 243, 121, 177, 106, 91, 98, 246, 73, 114, 116, 78, 99, 66, 17, 22, 30, 74, 67, 125, 250, 36, 12, 137, 219, 142, 205, 25, 243, 25, 180, 9, 66, 179, 89, 209, 184, 97, 44, 146, 113, 85, 48, 240, 135, 144, 60, 14, 10, 54, 60, 102, 47, 81, 21, 181, 112, 101, 166, 214, 152, 47, 158, 199, 51, 250, 164, 119, 61, 250, 100, 143, 184, 70, 224, 84, 80, 30, 190, 144, 23, 171, 108, 104, 154, 12, 238, 0, 67, 180, 198, 127, 244, 14, 70, 127, 49, 79, 88, 223, 195, 217, 146, 37, 43, 182, 196, 207, 168, 21, 123, 172, 78, 196, 127, 247, 19, 243, 132, 235, 192, 173, 65, 72, 65, 148, 235, 115, 147, 72, 38, 224, 156, 17, 27, 0, 116, 97, 93, 147, 54, 14, 109, 76, 52, 239, 248, 239, 30, 162, 197, 86, 37, 8, 224, 217, 158, 254, 187, 99, 225, 122, 6, 130, 120, 247, 229, 28, 244, 89, 17, 139, 159, 245, 13, 49, 255, 222, 213, 137, 73, 187, 247, 86, 129, 104, 42, 207, 237, 120, 160, 123, 173, 51, 31, 38, 242, 56, 40, 226, 82, 111, 98, 202, 86, 177, 185, 41, 16, 238, 58, 217, 20, 168, 166, 58, 121, 177, 174, 231, 41, 28, 17, 129, 193, 221, 116, 154, 76, 21, 19, 135, 14, 63, 95, 186, 181, 176, 57, 99, 30, 199, 177, 188, 231, 143, 159, 138, 48, 142, 217, 146, 164, 10, 233, 232, 204, 83, 131, 217, 174, 29, 160, 217, 182, 242, 72, 186, 121, 13, 53, 251, 202, 242, 222, 181, 107, 41, 237, 163, 199, 192, 213, 241, 202, 89, 183, 23, 227, 103, 121, 200, 104, 246, 122, 229, 172, 174, 9, 177, 54, 222, 230, 58, 252, 186, 95, 40, 22, 239, 75, 68, 70, 238, 183, 163, 63, 60, 19, 23, 112, 209, 140, 98, 4, 109, 42, 91, 99, 118, 147, 235, 243, 28, 174, 134, 194, 201, 60, 142, 99, 22, 80, 55, 154, 30, 137, 147, 250, 71, 23, 16, 36, 143, 131, 130, 27, 157, 116, 95, 36, 130, 168, 61, 104, 123, 47, 193, 17, 115, 70, 151, 89, 122, 250, 158, 4, 36, 184, 152, 209, 118, 70, 172, 245, 201, 202, 191, 169, 178, 176, 202, 199, 160, 160, 216, 187, 174, 51, 38, 56, 234, 251, 169, 223, 119, 95, 28, 141, 235, 17, 249, 170, 136, 208, 158, 207, 113, 221, 88, 136, 214, 170, 214, 75, 126, 71, 193, 212, 132, 146, 215, 109, 43, 142, 252, 153, 100, 5, 12, 91, 218, 122, 194, 178, 225, 165, 117, 57, 12, 127, 255, 121, 32, 26, 76, 137, 82, 77, 147, 109, 112, 168, 76, 39, 70, 170, 174, 133, 231, 163, 191, 104, 6, 181, 222, 90, 156, 123, 183, 192, 64, 230, 177, 22, 115, 141, 229, 53, 92, 124, 245, 168, 147, 199, 65, 193, 78, 18, 95, 76, 19, 80, 80, 48, 220, 5, 5, 143, 215, 106, 159, 226, 171, 30, 2, 164, 28, 113, 221, 49, 215, 81, 143, 223, 38, 51, 49, 251, 180, 178, 140, 218, 157, 113, 81, 104, 52, 243, 139, 90, 160, 189, 1, 13, 39, 70, 98, 214, 238, 100, 92, 10, 201, 87, 209, 40, 141, 168, 69, 66, 100, 220, 243, 15, 166, 169, 142, 125, 247, 163, 61, 218, 245, 58, 27, 112, 84, 103, 238, 203, 68, 226, 44, 127, 85, 132, 90, 245, 149, 98, 251, 26, 21, 9, 19, 254, 64, 52, 84, 175, 96, 76, 221, 157, 2, 131, 156, 143, 199, 145, 8, 68, 106, 80, 118, 240, 91, 178, 47, 5, 239, 77, 136, 50, 55, 56, 211, 58, 124, 184, 106, 38, 106, 204, 99, 9, 190, 46, 6, 140, 219, 154, 136, 232, 148, 155, 53, 190, 104, 170, 46, 146, 199, 65, 113, 45, 188, 8, 111, 143, 145, 151, 92, 25, 80, 88, 94, 232, 83, 3, 66, 113, 78, 4, 174, 42, 85, 157, 182, 196, 25, 112, 201, 225, 116, 188, 54, 74, 0, 75, 96, 88, 219, 254, 174, 48, 143, 229, 111, 56, 171, 210, 79, 17, 128, 189, 48, 58, 18, 205, 22, 198, 97, 166, 8, 239, 206, 243, 25, 8, 140, 44, 68, 124, 198, 77, 185, 86, 137, 106, 82, 252, 249, 12, 17, 90, 38, 202, 180, 103, 33, 2, 216, 104, 186, 73, 102, 126, 58, 176, 247, 20, 128, 62, 98, 41, 54, 133, 90, 243, 29, 90, 235, 209, 98, 102, 52, 182, 158, 205, 66, 136, 104, 93, 238, 56, 170, 51, 21, 97, 255, 149, 92, 85, 58, 222, 70, 174, 247, 50, 163, 94, 108, 129, 169, 53, 166, 174, 236, 189, 200, 152, 158, 25, 22, 129, 89, 251, 82, 213, 222, 114, 142, 138, 36, 31, 53, 242, 56, 40, 184, 238, 249, 117, 238, 9, 193, 7, 239, 206, 139, 210, 152, 191, 249, 34, 16, 27, 207, 112, 15, 58, 207, 150, 98, 179, 167, 209, 142, 75, 57, 120, 123, 188, 152, 83, 108, 12, 70, 65, 213, 132, 209, 222, 88, 28, 49, 143, 215, 236, 118, 254, 187, 139, 30, 47, 13, 13, 69, 235, 121, 49, 170, 251, 247, 194, 195, 25, 216, 122, 62, 27, 195, 215, 196, 224, 231, 253, 197, 44, 98, 163, 101, 254, 134, 2, 220, 60, 16, 195, 197, 127, 56, 30, 144, 139, 169, 187, 82, 148, 102, 84, 223, 145, 89, 5, 43, 96, 27, 191, 49, 30, 107, 79, 100, 170, 243, 12, 223, 156, 172, 202, 239, 255, 73, 32, 116, 21, 237, 163, 173, 247, 176, 54, 207, 220, 97, 222, 51, 1, 33, 126, 214, 187, 147, 76, 88, 123, 58, 211, 237, 92, 202, 195, 78, 158, 215, 20, 2, 138, 183, 134, 11, 40, 248, 240, 43, 243, 210, 248, 27, 113, 112, 135, 172, 79, 172, 22, 251, 150, 249, 15, 22, 17, 118, 88, 40, 118, 56, 77, 15, 10, 101, 101, 128, 65, 230, 111, 52, 33, 99, 190, 130, 26, 136, 2, 75, 16, 136, 134, 248, 199, 208, 48, 252, 146, 107, 211, 233, 207, 104, 191, 145, 239, 255, 83, 252, 135, 255, 27, 21, 142, 239, 247, 180, 148, 193, 240, 60, 228, 86, 58, 252, 74, 62, 251, 219, 224, 80, 115, 242, 83, 91, 97, 199, 10, 89, 158, 183, 178, 207, 148, 172, 93, 131, 160, 234, 96, 80, 57, 8, 118, 31, 180, 23, 201, 122, 212, 201, 227, 160, 240, 139, 40, 194, 251, 227, 196, 124, 162, 160, 241, 37, 218, 123, 65, 206, 152, 47, 78, 4, 224, 111, 131, 195, 176, 231, 82, 182, 229, 172, 213, 67, 187, 206, 165, 227, 239, 92, 35, 192, 66, 194, 202, 206, 188, 142, 88, 3, 139, 189, 103, 192, 207, 41, 228, 252, 191, 245, 231, 188, 62, 159, 27, 199, 162, 61, 63, 79, 141, 137, 231, 36, 112, 7, 132, 97, 231, 197, 180, 135, 166, 113, 89, 117, 144, 199, 65, 97, 136, 41, 65, 59, 238, 164, 195, 151, 89, 25, 80, 144, 149, 112, 4, 96, 224, 234, 196, 106, 45, 66, 99, 162, 145, 179, 37, 119, 70, 82, 221, 70, 40, 56, 218, 140, 108, 111, 92, 238, 178, 35, 129, 230, 231, 26, 187, 243, 157, 59, 204, 223, 107, 0, 19, 240, 61, 63, 60, 28, 179, 15, 164, 33, 80, 222, 79, 101, 215, 104, 63, 42, 228, 113, 80, 208, 97, 27, 186, 62, 206, 44, 88, 124, 41, 246, 94, 152, 43, 220, 208, 31, 127, 30, 28, 142, 77, 226, 91, 84, 39, 177, 132, 129, 27, 200, 236, 21, 199, 184, 223, 170, 4, 252, 70, 156, 124, 101, 254, 112, 86, 165, 15, 96, 111, 108, 117, 153, 53, 48, 240, 249, 139, 57, 246, 27, 209, 132, 131, 54, 39, 225, 128, 95, 46, 18, 51, 217, 5, 208, 139, 134, 138, 200, 227, 160, 224, 131, 159, 195, 130, 54, 154, 6, 85, 17, 42, 190, 212, 22, 58, 52, 157, 22, 173, 18, 130, 213, 253, 50, 153, 144, 139, 18, 95, 99, 213, 241, 12, 229, 216, 62, 198, 245, 208, 92, 144, 196, 251, 32, 115, 60, 85, 157, 189, 171, 147, 53, 237, 66, 31, 169, 77, 16, 254, 159, 56, 248, 205, 231, 155, 176, 230, 116, 186, 90, 159, 237, 53, 151, 92, 39, 143, 131, 130, 107, 119, 183, 93, 200, 188, 175, 182, 237, 190, 64, 87, 153, 179, 181, 56, 133, 204, 9, 112, 37, 89, 77, 172, 248, 98, 46, 128, 209, 152, 157, 114, 15, 205, 184, 241, 99, 183, 16, 21, 169, 81, 194, 86, 215, 192, 97, 13, 4, 58, 208, 205, 133, 187, 234, 209, 120, 74, 36, 22, 29, 76, 132, 33, 246, 155, 77, 91, 188, 228, 58, 121, 28, 20, 92, 221, 165, 139, 41, 54, 131, 130, 108, 239, 101, 186, 202, 124, 225, 20, 196, 102, 58, 181, 29, 24, 109, 225, 154, 36, 198, 237, 245, 209, 133, 152, 184, 57, 1, 63, 103, 164, 136, 153, 237, 6, 150, 8, 19, 193, 97, 111, 204, 53, 193, 124, 46, 154, 191, 64, 102, 65, 98, 199, 32, 188, 54, 52, 20, 195, 54, 70, 227, 122, 84, 190, 199, 150, 196, 62, 138, 228, 113, 80, 112, 98, 98, 6, 249, 197, 65, 98, 155, 243, 101, 85, 85, 120, 180, 217, 176, 103, 8, 54, 159, 207, 174, 150, 222, 178, 206, 136, 69, 127, 44, 21, 215, 139, 131, 202, 94, 84, 99, 182, 38, 225, 37, 182, 159, 167, 223, 193, 168, 213, 135, 22, 193, 212, 52, 136, 198, 246, 238, 197, 93, 230, 121, 120, 94, 50, 39, 7, 94, 71, 139, 90, 137, 105, 201, 157, 76, 255, 212, 47, 68, 254, 31, 140, 46, 75, 163, 113, 66, 151, 171, 180, 28, 51, 235, 222, 68, 92, 229, 201, 227, 160, 32, 153, 11, 220, 196, 217, 230, 134, 241, 85, 213, 22, 100, 139, 160, 253, 97, 136, 17, 115, 14, 164, 43, 191, 165, 166, 137, 62, 7, 203, 51, 162, 82, 110, 226, 120, 96, 62, 86, 28, 203, 192, 8, 113, 96, 91, 207, 139, 197, 43, 204, 146, 51, 175, 64, 243, 133, 2, 76, 193, 101, 29, 19, 255, 207, 251, 167, 16, 147, 233, 99, 57, 98, 237, 24, 30, 79, 179, 145, 172, 61, 59, 230, 57, 186, 27, 240, 183, 97, 97, 120, 109, 108, 184, 92, 47, 28, 47, 14, 14, 195, 115, 3, 67, 48, 104, 101, 44, 214, 139, 223, 112, 195, 84, 168, 150, 1, 123, 173, 165, 170, 83, 181, 128, 130, 9, 178, 243, 161, 185, 248, 25, 87, 123, 241, 69, 123, 98, 230, 228, 57, 68, 72, 126, 49, 32, 28, 147, 119, 36, 139, 89, 83, 84, 171, 139, 95, 88, 133, 155, 145, 95, 6, 255, 168, 66, 248, 94, 206, 193, 148, 157, 41, 232, 190, 34, 1, 159, 206, 137, 197, 235, 19, 77, 106, 115, 248, 63, 112, 35, 199, 62, 162, 49, 153, 36, 228, 122, 117, 238, 93, 247, 165, 248, 39, 204, 166, 115, 35, 152, 182, 100, 249, 155, 165, 32, 220, 143, 142, 199, 245, 13, 195, 147, 95, 69, 224, 213, 209, 145, 168, 55, 193, 132, 119, 38, 155, 240, 197, 180, 40, 180, 156, 30, 129, 143, 39, 135, 227, 147, 41, 225, 232, 56, 63, 10, 163, 215, 199, 99, 180, 128, 242, 156, 33, 239, 161, 238, 193, 84, 27, 84, 45, 160, 160, 115, 87, 92, 118, 7, 77, 103, 197, 152, 139, 232, 170, 18, 154, 181, 101, 206, 160, 173, 116, 232, 177, 216, 132, 43, 17, 133, 202, 1, 175, 43, 43, 195, 56, 14, 230, 85, 194, 18, 138, 85, 101, 43, 183, 228, 90, 124, 48, 5, 147, 182, 36, 98, 248, 234, 4, 244, 91, 30, 139, 206, 11, 98, 208, 126, 110, 52, 190, 20, 230, 255, 59, 206, 139, 70, 159, 165, 177, 24, 188, 58, 14, 19, 54, 37, 96, 190, 111, 10, 182, 158, 76, 195, 254, 43, 153, 216, 121, 49, 83, 117, 6, 153, 182, 45, 17, 61, 22, 70, 226, 73, 106, 135, 193, 225, 232, 179, 60, 14, 151, 244, 121, 223, 41, 97, 247, 146, 103, 168, 90, 64, 161, 209, 158, 115, 25, 234, 37, 42, 65, 182, 39, 224, 149, 101, 106, 31, 150, 84, 136, 115, 57, 115, 119, 146, 152, 52, 117, 175, 220, 153, 226, 74, 83, 198, 85, 166, 15, 144, 91, 116, 11, 220, 93, 104, 155, 128, 162, 231, 34, 19, 126, 221, 91, 180, 75, 67, 185, 207, 127, 221, 80, 90, 101, 202, 206, 100, 132, 39, 154, 11, 247, 228, 39, 94, 170, 38, 170, 86, 80, 176, 69, 37, 19, 98, 202, 225, 246, 132, 9, 165, 49, 207, 69, 219, 157, 97, 200, 47, 245, 120, 101, 184, 17, 227, 101, 54, 190, 30, 81, 240, 64, 148, 62, 51, 50, 196, 106, 90, 127, 99, 1, 182, 159, 205, 192, 152, 141, 9, 104, 62, 211, 132, 191, 177, 132, 188, 75, 136, 0, 64, 76, 41, 106, 215, 86, 129, 120, 123, 84, 24, 230, 239, 74, 20, 51, 173, 88, 57, 252, 15, 211, 142, 65, 117, 149, 170, 21, 20, 76, 184, 29, 190, 145, 139, 6, 236, 131, 202, 62, 75, 158, 4, 6, 153, 231, 163, 214, 96, 36, 168, 155, 1, 245, 198, 70, 162, 139, 216, 245, 171, 79, 165, 171, 253, 223, 216, 26, 179, 54, 137, 91, 234, 178, 207, 109, 112, 108, 145, 170, 138, 93, 123, 60, 29, 227, 183, 165, 160, 211, 178, 4, 52, 156, 25, 35, 227, 141, 194, 239, 6, 138, 223, 213, 69, 52, 2, 251, 73, 241, 25, 189, 39, 220, 62, 8, 77, 167, 152, 48, 123, 79, 170, 90, 86, 155, 152, 193, 126, 78, 94, 221, 80, 83, 84, 173, 160, 32, 169, 190, 172, 98, 23, 171, 232, 12, 5, 152, 51, 188, 61, 1, 175, 10, 107, 224, 96, 180, 71, 0, 242, 219, 65, 33, 104, 189, 32, 26, 83, 118, 165, 98, 221, 153, 28, 113, 70, 11, 84, 143, 215, 52, 209, 92, 218, 130, 157, 170, 18, 69, 148, 107, 34, 216, 83, 137, 25, 227, 216, 212, 155, 8, 142, 41, 1, 183, 11, 219, 121, 57, 23, 139, 78, 100, 99, 198, 222, 116, 140, 216, 148, 140, 78, 139, 99, 81, 127, 98, 36, 30, 235, 47, 78, 55, 87, 200, 17, 196, 92, 195, 206, 8, 21, 123, 191, 242, 255, 173, 131, 240, 187, 190, 161, 2, 134, 104, 181, 172, 244, 114, 104, 129, 138, 226, 121, 169, 230, 169, 218, 65, 65, 138, 73, 45, 21, 103, 51, 94, 204, 1, 17, 8, 130, 194, 211, 26, 195, 154, 121, 110, 130, 131, 57, 4, 10, 220, 23, 58, 188, 57, 38, 2, 3, 87, 197, 96, 217, 225, 20, 213, 103, 53, 48, 174, 84, 108, 243, 155, 170, 103, 18, 215, 93, 115, 54, 207, 18, 135, 157, 61, 151, 178, 242, 111, 91, 88, 254, 150, 207, 8, 106, 54, 99, 224, 58, 232, 184, 244, 50, 68, 38, 139, 240, 39, 220, 68, 64, 108, 41, 206, 135, 21, 97, 247, 213, 28, 44, 56, 144, 138, 41, 219, 146, 208, 107, 89, 28, 222, 102, 55, 14, 241, 117, 212, 24, 26, 48, 217, 103, 181, 75, 18, 63, 35, 24, 180, 192, 3, 75, 195, 153, 45, 239, 30, 130, 47, 230, 196, 96, 251, 249, 76, 25, 139, 119, 109, 67, 109, 83, 141, 128, 130, 196, 238, 123, 3, 184, 150, 152, 66, 64, 225, 176, 21, 230, 234, 96, 2, 68, 203, 27, 112, 77, 130, 202, 72, 11, 83, 40, 187, 5, 225, 189, 177, 225, 232, 56, 47, 10, 67, 86, 199, 98, 222, 142, 4, 204, 223, 147, 132, 249, 190, 22, 150, 191, 249, 217, 248, 13, 209, 248, 106, 101, 52, 186, 44, 48, 161, 241, 196, 8, 60, 211, 79, 76, 157, 246, 34, 204, 204, 45, 48, 187, 253, 174, 229, 156, 4, 160, 150, 91, 208, 52, 162, 53, 248, 191, 53, 22, 57, 182, 105, 32, 94, 30, 18, 170, 174, 197, 104, 21, 19, 110, 94, 11, 169, 110, 80, 141, 129, 130, 254, 5, 103, 229, 241, 91, 216, 113, 66, 156, 73, 70, 143, 172, 5, 184, 186, 152, 194, 168, 9, 164, 150, 36, 35, 40, 232, 164, 107, 29, 183, 219, 8, 211, 185, 101, 59, 76, 107, 102, 14, 65, 229, 20, 132, 121, 28, 151, 161, 242, 119, 172, 53, 250, 214, 249, 44, 231, 212, 128, 160, 129, 129, 255, 231, 231, 4, 11, 253, 133, 102, 129, 42, 27, 62, 108, 67, 34, 246, 93, 203, 85, 145, 164, 140, 92, 179, 243, 236, 245, 25, 234, 14, 213, 24, 40, 52, 138, 16, 179, 101, 238, 222, 52, 60, 63, 36, 194, 44, 80, 100, 77, 136, 106, 138, 53, 193, 165, 16, 91, 11, 183, 61, 166, 80, 107, 172, 29, 239, 108, 188, 252, 142, 191, 163, 185, 68, 48, 116, 48, 224, 181, 17, 17, 232, 188, 48, 90, 109, 33, 118, 196, 47, 15, 145, 2, 6, 111, 109, 82, 221, 165, 26, 7, 5, 137, 91, 69, 173, 59, 157, 137, 87, 38, 152, 204, 165, 32, 236, 226, 77, 65, 170, 105, 112, 120, 130, 57, 102, 2, 134, 102, 19, 77, 35, 106, 146, 174, 6, 252, 121, 136, 17, 239, 136, 211, 60, 122, 115, 50, 246, 94, 202, 18, 39, 188, 192, 220, 26, 199, 155, 112, 171, 243, 84, 43, 160, 32, 49, 92, 105, 136, 45, 82, 217, 220, 95, 244, 16, 115, 138, 33, 73, 10, 153, 173, 9, 82, 151, 88, 27, 151, 181, 198, 160, 41, 197, 172, 125, 27, 1, 119, 135, 96, 188, 54, 220, 136, 209, 155, 18, 112, 44, 32, 23, 201, 217, 101, 53, 178, 153, 165, 151, 60, 75, 181, 6, 10, 146, 150, 201, 189, 97, 44, 64, 215, 197, 226, 132, 211, 102, 103, 156, 158, 102, 7, 103, 223, 186, 2, 12, 13, 8, 28, 19, 199, 70, 71, 153, 17, 37, 106, 6, 209, 116, 93, 197, 9, 223, 126, 46, 29, 166, 228, 34, 148, 150, 223, 86, 218, 128, 247, 230, 213, 9, 15, 38, 213, 42, 40, 52, 98, 228, 37, 46, 189, 28, 103, 130, 11, 48, 119, 127, 42, 26, 176, 241, 1, 139, 228, 104, 235, 91, 151, 102, 107, 179, 179, 61, 193, 245, 20, 243, 252, 20, 126, 154, 115, 20, 122, 94, 159, 255, 103, 110, 161, 139, 94, 117, 225, 24, 184, 50, 14, 75, 143, 164, 225, 80, 64, 30, 2, 163, 75, 85, 168, 150, 37, 237, 236, 140, 81, 19, 251, 105, 123, 169, 122, 169, 78, 128, 66, 35, 22, 212, 113, 61, 0, 183, 199, 93, 121, 34, 19, 195, 54, 38, 161, 241, 204, 104, 60, 54, 40, 204, 12, 18, 218, 235, 4, 8, 35, 57, 20, 84, 178, 22, 2, 85, 17, 32, 97, 10, 181, 61, 86, 51, 189, 229, 24, 30, 79, 230, 111, 85, 100, 136, 44, 231, 228, 113, 92, 130, 218, 89, 143, 159, 244, 11, 65, 61, 1, 0, 123, 57, 245, 93, 155, 136, 105, 251, 210, 176, 237, 66, 14, 78, 235, 242, 84, 107, 208, 244, 156, 114, 187, 77, 151, 189, 244, 224, 83, 157, 2, 133, 53, 81, 224, 8, 144, 203, 161, 249, 170, 60, 130, 101, 210, 173, 22, 196, 169, 6, 94, 47, 136, 221, 254, 171, 129, 161, 240, 225, 106, 184, 110, 194, 204, 150, 51, 83, 204, 114, 108, 50, 5, 155, 166, 24, 153, 127, 115, 61, 2, 195, 170, 44, 219, 102, 19, 99, 254, 166, 103, 8, 254, 163, 111, 168, 42, 239, 126, 73, 206, 247, 214, 120, 19, 62, 155, 29, 139, 158, 43, 226, 48, 97, 91, 34, 86, 28, 78, 195, 190, 203, 25, 208, 69, 153, 187, 254, 121, 163, 69, 143, 14, 213, 89, 80, 216, 18, 227, 248, 185, 197, 183, 17, 155, 86, 130, 235, 17, 121, 216, 117, 49, 29, 203, 14, 36, 98, 250, 142, 68, 12, 91, 27, 143, 238, 139, 99, 208, 102, 182, 9, 205, 166, 71, 225, 227, 201, 145, 104, 56, 209, 168, 248, 163, 73, 145, 104, 58, 45, 10, 109, 103, 153, 208, 117, 97, 140, 50, 125, 38, 111, 77, 196, 124, 223, 84, 172, 59, 145, 142, 131, 215, 178, 224, 23, 81, 32, 130, 95, 138, 172, 194, 91, 40, 190, 121, 11, 183, 239, 120, 53, 192, 163, 76, 15, 12, 40, 52, 82, 14, 172, 48, 65, 66, 135, 150, 142, 186, 226, 187, 95, 171, 4, 33, 163, 61, 52, 195, 108, 249, 150, 124, 199, 99, 238, 31, 47, 204, 223, 203, 127, 247, 207, 233, 37, 47, 145, 30, 56, 80, 84, 68, 148, 109, 123, 236, 37, 47, 185, 74, 15, 29, 40, 188, 228, 165, 170, 146, 23, 20, 94, 242, 146, 13, 121, 65, 225, 37, 47, 217, 144, 23, 20, 94, 242, 146, 13, 121, 65, 225, 37, 47, 217, 144, 23, 20, 94, 242, 146, 13, 121, 65, 225, 37, 47, 217, 144, 23, 20, 94, 242, 146, 13, 121, 65, 225, 37, 47, 217, 144, 23, 20, 94, 242, 146, 13, 121, 65, 225, 37, 47, 217, 144, 23, 20, 94, 242, 146, 13, 121, 65, 225, 37, 47, 217, 144, 23, 20, 94, 242, 210, 183, 8, 248, 255, 130, 15, 150, 230, 131, 99, 86, 254, 0, 0, 0, 0, 73, 69, 78, 68, 174, 66, 96, 130 }, "University", "123456789" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreateDay", "Email", "EmailConfirmed", "IsActive", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UpdateDay", "UserName" },
                values: new object[] { "5f2e01ce-5c18-47d1-8b26-4135d3ec2db7", 0, "01bda497-ccaf-4e4b-b5b1-642f8c3a0552", new DateTime(2023, 3, 10, 22, 38, 40, 95, DateTimeKind.Local).AddTicks(3222), null, false, true, false, null, null, "ADMIN", "AQAAAAEAACcQAAAAEFkVUdE8IHHuy9ZayHP1jP7ug6v3QPksy2+F2mNnwo2Bq1Ot/aNqjkBUwWnVphn11Q==", null, false, 1, "d5d1ec17-46fd-44bf-9ab5-dd21f423cd23", false, new DateTime(2023, 3, 10, 22, 38, 40, 95, DateTimeKind.Local).AddTicks(3232), "Admin" });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "356132cd-14f9-487e-88c8-2e064ec79c45", "5f2e01ce-5c18-47d1-8b26-4135d3ec2db7" });

            migrationBuilder.CreateIndex(
                name: "IX_Assets_BrandID",
                table: "Assets",
                column: "BrandID");

            migrationBuilder.CreateIndex(
                name: "IX_Assets_LocationID",
                table: "Assets",
                column: "LocationID");

            migrationBuilder.CreateIndex(
                name: "IX_Assets_SupplierID",
                table: "Assets",
                column: "SupplierID");

            migrationBuilder.CreateIndex(
                name: "IX_Assets_TypeID",
                table: "Assets",
                column: "TypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Components_BrandID",
                table: "Components",
                column: "BrandID");

            migrationBuilder.CreateIndex(
                name: "IX_Components_LocationID",
                table: "Components",
                column: "LocationID");

            migrationBuilder.CreateIndex(
                name: "IX_Components_SupplierID",
                table: "Components",
                column: "SupplierID");

            migrationBuilder.CreateIndex(
                name: "IX_Components_TypeID",
                table: "Components",
                column: "TypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Depreciations_AssetID",
                table: "Depreciations",
                column: "AssetID");

            migrationBuilder.CreateIndex(
                name: "IX_Depreciations_ComponentID",
                table: "Depreciations",
                column: "ComponentID");

            migrationBuilder.CreateIndex(
                name: "IX_Maintenances_AssetID",
                table: "Maintenances",
                column: "AssetID");

            migrationBuilder.CreateIndex(
                name: "IX_Maintenances_SupplierID",
                table: "Maintenances",
                column: "SupplierID");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Roles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                table: "UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Users",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Depreciations");

            migrationBuilder.DropTable(
                name: "Maintenances");

            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "Setting");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "Components");

            migrationBuilder.DropTable(
                name: "Assets");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "AssetTypes");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Supplier");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Web.DAL.Migrations
{
    public partial class Onemore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)"),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit"),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit"),
                    TwoFactorEnabled = table.Column<bool>(type: "bit"),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit"),
                    AccessFailedCount = table.Column<int>(type: "int")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Category = table.Column<int>(type: "int"),
                    DateCreated = table.Column<DateTime>(type: "datetime2"),
                    Rating = table.Column<int>(type: "int")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)"),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)"),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)"),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)"),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)"),
                    RoleId = table.Column<string>(type: "nvarchar(450)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)"),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)"),
                    Name = table.Column<string>(type: "nvarchar(450)"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Category", "DateCreated", "Name", "Rating" },
                values: new object[,]
                {
                    { new Guid("e154e724-4820-4a96-96f7-89a09943d2d9"), 11, new DateTime(2021, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wii Sports", 82 },
                    { new Guid("9d2f4d2b-a39b-4df0-b148-8947f2a5b496"), 5, new DateTime(1999, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Super Mario 64", 11 },
                    { new Guid("61bf2e55-dee8-49c4-a8b3-c91301f6f159"), 1, new DateTime(2000, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Grand Theft Auto V", 16 },
                    { new Guid("7c36e0ba-10a4-48df-bbe8-04cb09b934b8"), 9, new DateTime(2001, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Halo 3", 18 },
                    { new Guid("794fa56f-8b00-4e22-974f-6e5f92bf684e"), 7, new DateTime(2002, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mario Kart 7", 21 },
                    { new Guid("98b724c9-7338-4c7c-90ae-8942f8a66b44"), 1, new DateTime(2003, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Grand Theft Auto V", 22 },
                    { new Guid("705ea3b7-b76e-4add-b28c-edbed09fbf42"), 5, new DateTime(2004, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Super Mario Land", 22 },
                    { new Guid("59295032-71ac-41e1-820c-3b8cdabbe137"), 5, new DateTime(2005, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Super Mario World", 22 },
                    { new Guid("6058e0e7-52eb-494f-bc4f-f36f8555bc8b"), 1, new DateTime(2006, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Grand Theft Auto V", 21 },
                    { new Guid("af59aca6-d151-4879-96d8-2f6bf95c2fd8"), 4, new DateTime(2007, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Adventures", 22 },
                    { new Guid("734293f2-e3d4-45c5-882f-12b0f1889122"), 11, new DateTime(2008, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wii Fit Plus", 22 },
                    { new Guid("3ff88bf4-39a0-47e4-b317-9c04a1c6b7fb"), 11, new DateTime(2009, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wii Fit", 23 },
                    { new Guid("18c178c6-5262-4db5-b426-b89c86312c8c"), 7, new DateTime(2010, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mario Kart DS", 24 },
                    { new Guid("5985416a-13e7-472f-9d9d-176ea952487e"), 10, new DateTime(2011, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nintendo", 25 },
                    { new Guid("196bcaaa-b382-47f9-8528-c6369287220a"), 9, new DateTime(2013, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Duck Hunt", 28 },
                    { new Guid("13ebfdf8-e972-4c3a-9c42-8c098cceee9f"), 4, new DateTime(2014, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wii Play", 29 },
                    { new Guid("c0112e13-5ef5-48dd-b170-66b943cb242d"), 6, new DateTime(2015, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tetras", 31 },
                    { new Guid("508559f4-28a9-49ae-a389-f766f7c65bbe"), 11, new DateTime(2020, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wii Sports Resort", 33 },
                    { new Guid("c42ef01b-43c3-49c5-91d9-bc8145e0253c"), 7, new DateTime(2017, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mario Kart Wii", 35 },
                    { new Guid("61dfdb1a-08e3-475b-97b9-fa0d7432338f"), 5, new DateTime(2015, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Super Mario Bros", 41 },
                    { new Guid("11ae60ea-217e-447b-a790-3cfc76353551"), 4, new DateTime(1998, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gran Tur 4", 11 },
                    { new Guid("fdf006c2-db9e-45d9-9a66-8a852e986c76"), 7, new DateTime(1997, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Super Mario Galaxy", 11 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Category",
                table: "Product",
                column: "Category");

            migrationBuilder.CreateIndex(
                name: "IX_Product_DateCreated",
                table: "Product",
                column: "DateCreated");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Name",
                table: "Product",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Rating",
                table: "Product",
                column: "Rating");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Web.DAL.Migrations
{
    public partial class InitialMigrationNext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    AdditionalName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Category = table.Column<int>(type: "int", nullable: false),
                    Genre = table.Column<int>(type: "int", nullable: false),
                    RatingByAge = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Background = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    TotalRating = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "ProductRating",
                columns: table => new
                {
                    ProductRatingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Rating = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductRating", x => x.ProductRatingId);
                    table.ForeignKey(
                        name: "FK_ProductRating_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductRating_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Email", "EmailConfirmed", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "98e32914-abcd-4e4f-a04d-4081ea48bcb7", 0, null, "300d2d65-c524-4c63-9a8e-b623b3f544ff", null, false, "Jones", false, null, null, null, null, null, false, "2cad6b91-6676-450e-8a3b-2d516effe18e", false, null },
                    { "d3316868-61d6-4228-ae86-ec13e5cded59", 0, null, "9f19a17b-ae4b-465f-b6de-b2380b5fab4e", null, false, "Trump", false, null, null, null, null, null, false, "9f77cc91-1e4f-45ea-b265-f048ffd76251", false, null },
                    { "0d24d655-7246-48e9-b572-b31bb0e4118a", 0, null, "f71c42cd-be63-4b1f-accd-2434b0ecc9d6", null, false, "Obama", false, null, null, null, null, null, false, "0b46dc55-bde7-49ac-8afc-882e5e59ec17", false, null },
                    { "8b387dc9-c46b-4cbc-91c7-f163997b44d5", 0, null, "bae0e9ee-95cc-45ab-87a5-b63869d4122d", null, false, "Richter", false, null, null, null, null, null, false, "a51e691a-adf6-4c57-94a3-416aac037315", false, null },
                    { "33b29059-0a97-4586-b621-ed5707adfabd", 0, null, "b87a224b-648c-4ab5-8604-1474419426c6", null, false, "Suzuki", false, null, null, null, null, null, false, "cc88d7a7-be0d-46de-bff1-a998c8fb1125", false, null }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "AdditionalName", "Background", "Category", "Count", "DateCreated", "Genre", "Logo", "Name", "Price", "RatingByAge", "TotalRating" },
                values: new object[,]
                {
                    { 14, "Anton", "backgroundAwsLink", 11, 2, new DateTime(2021, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, "logoAwsLink", "Wii Sports", 18.600000000000001, 5, 0 },
                    { 13, "Anton", "backgroundAwsLink", 11, 2, new DateTime(2021, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, "logoAwsLink", "Wii Sports", 9.0999999999999996, 1, 0 },
                    { 12, "Anton", "backgroundAwsLink", 11, 2, new DateTime(2021, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, "logoAwsLink", "Wii Sports", 10.199999999999999, 1, 0 },
                    { 11, "Anton", "backgroundAwsLink", 11, 2, new DateTime(2021, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, "logoAwsLink", "Wii Sports", 11.300000000000001, 1, 0 },
                    { 10, "Anton", "backgroundAwsLink", 11, 2, new DateTime(2021, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, "logoAwsLink", "Wii Sports", 12.4, 1, 0 },
                    { 9, "Anton", "backgroundAwsLink", 11, 2, new DateTime(2021, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, "logoAwsLink", "Wii Sports", 13.5, 1, 0 },
                    { 8, "Anton", "backgroundAwsLink", 11, 2, new DateTime(2021, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, "logoAwsLink", "Wii Sports", 14.6, 1, 0 },
                    { 6, "Anton", "backgroundAwsLink", 11, 2, new DateTime(2021, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, "logoAwsLink", "Wii Sports", 16.800000000000001, 1, 0 },
                    { 15, "Anton", "backgroundAwsLink", 11, 2, new DateTime(2021, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 16, "logoAwsLink", "Wii Sports", 76.599999999999994, 1, 0 },
                    { 5, "Anton", "backgroundAwsLink", 11, 2, new DateTime(2021, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, "logoAwsLink", "Wii Sports", 16.899999999999999, 1, 0 },
                    { 4, "Anton", "backgroundAwsLink", 11, 2, new DateTime(2021, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, "logoAwsLink", "Wii Sports", 19.600000000000001, 1, 0 },
                    { 3, "Anton", "backgroundAwsLink", 11, 2, new DateTime(2021, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, "logoAwsLink", "Wii Sports", 18.600000000000001, 1, 0 },
                    { 2, "Anton", "backgroundAwsLink", 11, 2, new DateTime(2021, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, "logoAwsLink", "Wii Sports", 17.600000000000001, 1, 0 },
                    { 1, "Anton", "backgroundAwsLink", 11, 2, new DateTime(2020, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, "logoAwsLink", "Wii Sports", 16.600000000000001, 1, 0 },
                    { 7, "Anton", "backgroundAwsLink", 11, 2, new DateTime(2021, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, "logoAwsLink", "Wii Sports", 16.699999999999999, 1, 0 },
                    { 16, "Anton", "backgroundAwsLink", 11, 2, new DateTime(2021, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, "logoAwsLink", "Wii Sports", 96.599999999999994, 1, 0 }
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
                name: "IX_Product_Count",
                table: "Product",
                column: "Count");

            migrationBuilder.CreateIndex(
                name: "IX_Product_DateCreated",
                table: "Product",
                column: "DateCreated");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Genre",
                table: "Product",
                column: "Genre");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Name",
                table: "Product",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Price",
                table: "Product",
                column: "Price");

            migrationBuilder.CreateIndex(
                name: "IX_Product_RatingByAge",
                table: "Product",
                column: "RatingByAge");

            migrationBuilder.CreateIndex(
                name: "IX_Product_TotalRating",
                table: "Product",
                column: "TotalRating");

            migrationBuilder.CreateIndex(
                name: "IX_ProductRating_AppUserId",
                table: "ProductRating",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductRating_ProductId",
                table: "ProductRating",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductRating_Rating",
                table: "ProductRating",
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
                name: "ProductRating");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Product");
        }
    }
}

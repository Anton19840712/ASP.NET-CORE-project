using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Web.DAL.Migrations
{
    public partial class NewEntitiesConfiguration : Migration
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
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductRating", x => new { x.ProductId, x.AppUserId });
                    table.ForeignKey(
                        name: "FK_ProductRating_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    { "e4b49401-6162-4ac9-8dc9-ab0f6b838ef7", 0, null, "af544f15-e828-4376-ab47-e4d3cc06a5cb", null, false, "Jones", false, null, null, null, null, null, false, "d6d770bc-48f8-4e03-868e-85f4f79bbc9e", false, null },
                    { "3dbb8802-d038-4461-beba-928d31e00d87", 0, null, "92d257c9-9cb5-40e5-b877-f1abd2163da7", null, false, "Trump", false, null, null, null, null, null, false, "f29d78e4-1425-4daa-b20d-63ee1765ad50", false, null },
                    { "bb18ca1a-9067-42b7-b2c2-94e2304bfccc", 0, null, "91237bb7-6d29-4213-8928-7e87e85a91e1", null, false, "Obama", false, null, null, null, null, null, false, "5db8edde-cdee-4b24-bb98-66e9572f7125", false, null },
                    { "3158c3a3-d03c-413c-9de9-d361bea247db", 0, null, "684e05cb-d439-4721-bfdf-f72705d233e1", null, false, "Richter", false, null, null, null, null, null, false, "dd415d80-368c-44fe-87c7-83a811ecb67f", false, null },
                    { "9bd9c99a-ec7b-4ecd-9d0f-a0bae3e3ad87", 0, null, "951b122e-c12e-4f34-a628-c240b3751f38", null, false, "Suzuki", false, null, null, null, null, null, false, "ce668173-f19f-4fa9-b4f8-92d6b234be1d", false, null }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Background", "Category", "Count", "DateCreated", "Genre", "Logo", "Name", "Price", "RatingByAge", "TotalRating" },
                values: new object[,]
                {
                    { 14, "backgroundAwsLink", 11, 2, new DateTime(2021, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 17, "logoAwsLink", "Wii Sports", 18.600000000000001, 5, 0 },
                    { 13, "backgroundAwsLink", 11, 2, new DateTime(2021, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 25, "logoAwsLink", "Wii Sports", 9.0999999999999996, 1, 0 },
                    { 12, "backgroundAwsLink", 11, 2, new DateTime(2021, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 26, "logoAwsLink", "Wii Sports", 10.199999999999999, 4, 0 },
                    { 11, "backgroundAwsLink", 11, 2, new DateTime(2021, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 22, "logoAwsLink", "Wii Sports", 11.300000000000001, 1, 0 },
                    { 10, "backgroundAwsLink", 11, 2, new DateTime(2021, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 19, "logoAwsLink", "Wii Sports", 12.4, 4, 0 },
                    { 9, "backgroundAwsLink", 11, 2, new DateTime(2021, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 24, "logoAwsLink", "Wii Sports", 13.5, 3, 0 },
                    { 8, "backgroundAwsLink", 11, 2, new DateTime(2021, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 15, "logoAwsLink", "Wii Sports", 14.6, 1, 0 },
                    { 6, "backgroundAwsLink", 11, 2, new DateTime(2021, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "logoAwsLink", "Wii Sports", 16.800000000000001, 5, 0 },
                    { 15, "backgroundAwsLink", 11, 2, new DateTime(2021, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 16, "logoAwsLink", "Wii Sports", 76.599999999999994, 2, 0 },
                    { 5, "backgroundAwsLink", 11, 2, new DateTime(2021, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "logoAwsLink", "Wii Sports", 16.899999999999999, 1, 0 },
                    { 4, "backgroundAwsLink", 11, 2, new DateTime(2021, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 18, "logoAwsLink", "Wii Sports", 19.600000000000001, 5, 0 },
                    { 3, "backgroundAwsLink", 11, 2, new DateTime(2021, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 18, "logoAwsLink", "Wii Sports", 18.600000000000001, 5, 0 },
                    { 2, "backgroundAwsLink", 11, 2, new DateTime(2021, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "logoAwsLink", "Wii Sports", 17.600000000000001, 1, 0 },
                    { 1, "backgroundAwsLink", 11, 2, new DateTime(2020, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, "logoAwsLink", "Wii Sports", 16.600000000000001, 1, 0 },
                    { 7, "backgroundAwsLink", 11, 2, new DateTime(2021, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, "logoAwsLink", "Wii Sports", 16.699999999999999, 2, 0 },
                    { 16, "backgroundAwsLink", 11, 2, new DateTime(2021, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, "logoAwsLink", "Wii Sports", 96.599999999999994, 1, 0 }
                });

            migrationBuilder.InsertData(
                table: "ProductRating",
                columns: new[] { "AppUserId", "ProductId", "Rating" },
                values: new object[,]
                {
                    { "e4b49401-6162-4ac9-8dc9-ab0f6b838ef7", 1, 1 },
                    { "e4b49401-6162-4ac9-8dc9-ab0f6b838ef7", 2, 1 },
                    { "e4b49401-6162-4ac9-8dc9-ab0f6b838ef7", 3, 1 },
                    { "e4b49401-6162-4ac9-8dc9-ab0f6b838ef7", 4, 1 },
                    { "3dbb8802-d038-4461-beba-928d31e00d87", 5, 1 },
                    { "3dbb8802-d038-4461-beba-928d31e00d87", 6, 1 },
                    { "3dbb8802-d038-4461-beba-928d31e00d87", 7, 1 },
                    { "3dbb8802-d038-4461-beba-928d31e00d87", 8, 1 },
                    { "3dbb8802-d038-4461-beba-928d31e00d87", 10, 1 },
                    { "3dbb8802-d038-4461-beba-928d31e00d87", 11, 1 },
                    { "3dbb8802-d038-4461-beba-928d31e00d87", 12, 1 },
                    { "3158c3a3-d03c-413c-9de9-d361bea247db", 13, 1 },
                    { "3dbb8802-d038-4461-beba-928d31e00d87", 14, 1 },
                    { "3dbb8802-d038-4461-beba-928d31e00d87", 15, 1 },
                    { "9bd9c99a-ec7b-4ecd-9d0f-a0bae3e3ad87", 16, 1 }
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

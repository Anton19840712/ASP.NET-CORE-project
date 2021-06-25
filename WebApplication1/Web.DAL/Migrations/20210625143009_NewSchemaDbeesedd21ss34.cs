using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Web.DAL.Migrations
{
    public partial class NewSchemaDbeesedd21ss34 : Migration
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
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderNumber = table.Column<int>(type: "int", nullable: true),
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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

            migrationBuilder.CreateTable(
                name: "OrderProducts",
                columns: table => new
                {
                    OrderProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    AmountOfProducts = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProducts", x => x.OrderProductId);
                    table.ForeignKey(
                        name: "FK_OrderProducts_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderProducts_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Email", "EmailConfirmed", "LastName", "LockoutEnabled", "LockoutEnd", "Login", "NormalizedEmail", "NormalizedUserName", "Password", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "06524f74-cd5d-4f06-b507-bf3ee9a23e41", 0, null, "46988902-dece-4ee4-8838-47f649cd9183", null, false, "Jones", false, null, null, null, null, null, null, null, false, null, "04fb5441-0d12-4c4c-8e57-62c02decf595", false, null },
                    { "fd9b5508-8f60-48cf-a2a8-c5cb1bbfd9a9", 0, null, "2ec2ac44-c568-4cf7-a24b-3c70f2bb6d20", null, false, "Trump", false, null, null, null, null, null, null, null, false, null, "f2a906f7-b271-4a77-ac81-697816b4dea9", false, null },
                    { "6bce5df3-b1db-474d-a988-16d3bba59888", 0, null, "deb5ad1f-d7d4-4563-b615-85a4314481d2", null, false, "Obama", false, null, null, null, null, null, null, null, false, null, "f2760e09-a78a-44b3-b979-4db6bd49e32c", false, null },
                    { "f302d844-0a0c-4470-bbaa-fe99adddd806", 0, null, "a4c4da26-dbb0-422e-b46e-84c6f19cbb73", null, false, "Richter", false, null, null, null, null, null, null, null, false, null, "b2762185-1496-4f9f-aa74-07cf43c41950", false, null },
                    { "95241a85-2329-4dbc-bb16-ae288f510936", 0, null, "d58b9115-b650-4054-a3cf-19fe8eafdea9", null, false, "Suzuki", false, null, null, null, null, null, null, null, false, null, "3139b65f-b0fd-4a33-8bd6-6501d8b75490", false, null }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Background", "Category", "Count", "DateCreated", "Genre", "Logo", "Name", "Price", "RatingByAge", "TotalRating" },
                values: new object[,]
                {
                    { 14, "backgroundAwsLink", 11, 2, new DateTime(2021, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, "logoAwsLink", "Wii Sports", 18.600000000000001, 5, 0 },
                    { 13, "backgroundAwsLink", 11, 2, new DateTime(2021, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, "logoAwsLink", "Wii Sports", 9.0999999999999996, 1, 0 },
                    { 12, "backgroundAwsLink", 11, 2, new DateTime(2021, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, "logoAwsLink", "Wii Sports", 10.199999999999999, 1, 0 },
                    { 11, "backgroundAwsLink", 11, 2, new DateTime(2021, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, "logoAwsLink", "Wii Sports", 11.300000000000001, 1, 0 },
                    { 10, "backgroundAwsLink", 11, 2, new DateTime(2021, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, "logoAwsLink", "Wii Sports", 12.4, 1, 0 },
                    { 9, "backgroundAwsLink", 11, 2, new DateTime(2021, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, "logoAwsLink", "Wii Sports", 13.5, 1, 0 },
                    { 8, "backgroundAwsLink", 11, 2, new DateTime(2021, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, "logoAwsLink", "Wii Sports", 14.6, 1, 0 },
                    { 6, "backgroundAwsLink", 11, 2, new DateTime(2021, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, "logoAwsLink", "Wii Sports", 16.800000000000001, 1, 0 },
                    { 15, "backgroundAwsLink", 11, 2, new DateTime(2021, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 16, "logoAwsLink", "Wii Sports", 76.599999999999994, 1, 0 },
                    { 5, "backgroundAwsLink", 11, 2, new DateTime(2021, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, "logoAwsLink", "Wii Sports", 16.899999999999999, 1, 0 },
                    { 4, "backgroundAwsLink", 11, 2, new DateTime(2021, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, "logoAwsLink", "Wii Sports", 19.600000000000001, 1, 0 },
                    { 3, "backgroundAwsLink", 11, 2, new DateTime(2021, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, "logoAwsLink", "Wii Sports", 18.600000000000001, 1, 0 },
                    { 2, "backgroundAwsLink", 11, 2, new DateTime(2021, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, "logoAwsLink", "Wii Sports", 17.600000000000001, 1, 0 },
                    { 1, "backgroundAwsLink", 11, 2, new DateTime(2020, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, "logoAwsLink", "Wii Sports", 16.600000000000001, 1, 0 },
                    { 7, "backgroundAwsLink", 11, 2, new DateTime(2021, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, "logoAwsLink", "Wii Sports", 16.699999999999999, 1, 0 },
                    { 16, "backgroundAwsLink", 11, 2, new DateTime(2021, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, "logoAwsLink", "Wii Sports", 96.599999999999994, 1, 0 }
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
                name: "IX_OrderProducts_OrderId",
                table: "OrderProducts",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProducts_ProductId",
                table: "OrderProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_AppUserId",
                table: "Orders",
                column: "AppUserId");

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
                name: "OrderProducts");

            migrationBuilder.DropTable(
                name: "ProductRating");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}

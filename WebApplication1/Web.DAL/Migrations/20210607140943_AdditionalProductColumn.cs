using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Web.DAL.Migrations
{
    public partial class AdditionalProductColumn : Migration
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
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rating = table.Column<int>(type: "int"),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Background = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float"),
                    Count = table.Column<int>(type: "int")
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
                columns: new[] { "Id", "Background", "Category", "Count", "DateCreated", "Genre", "Logo", "Name", "Price", "Rating" },
                values: new object[,]
                {
                    { new Guid("aab226a8-278a-40ed-a702-c9af5a47cb01"), "BackLink1", 11, 2, new DateTime(2021, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "LogoLink1", "Wii Sports", 16.600000000000001, 1 },
                    { new Guid("2de37f54-4470-48a4-8d1b-86684fceb92e"), "BackLink20", 5, 25, new DateTime(1999, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "LogoLink20", "Super Mario 64", 32.600000000000001, 5 },
                    { new Guid("7940ac6f-60e5-431a-b311-d9a286a07544"), "BackLink19", 1, 25, new DateTime(2000, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "LogoLink19", "Grand Theft Auto V", 37.600000000000001, 4 },
                    { new Guid("1ef93a85-6bc4-4c07-b137-e9c2f3bce13b"), "BackLink18", 9, 42, new DateTime(2001, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "LogoLink18", "Halo 3", 346.60000000000002, 3 },
                    { new Guid("1b33eab9-456b-4505-bce7-95572f714d1e"), "BackLink17", 7, 27, new DateTime(2002, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "LogoLink17", "Mario Kart 7", 6.5999999999999996, 2 },
                    { new Guid("a4242b5d-d73e-416c-bb8d-75ed3f24f7d1"), "BackLink16", 1, 77, new DateTime(2003, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "LogoLink16", "Grand Theft Auto V", 386.60000000000002, 1 },
                    { new Guid("62ce43b3-49ea-4b27-b264-a9292ae50044"), "BackLink15", 5, 2, new DateTime(2004, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "LogoLink15", "Super Mario Land", 34.600000000000001, 5 },
                    { new Guid("1c13608e-7207-42e1-941c-f5ee41bc1e14"), "BackLink14", 5, 6, new DateTime(2005, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "LogoLink14", "Super Mario World", 346.60000000000002, 3 },
                    { new Guid("b1f971c3-172f-4a23-8e54-6735720df803"), "BackLink13", 1, 6, new DateTime(2006, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "LogoLink13", "Grand Theft Auto V", 365.60000000000002, 2 },
                    { new Guid("52e4fed9-d58e-442f-8337-8d488c98d494"), "BackLink12", 4, 55, new DateTime(2007, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "LogoLink12", "Adventures", 34.600000000000001, 1 },
                    { new Guid("b3b3d1bc-d639-4097-aa0d-535a089631ac"), "BackLink11", 11, 34, new DateTime(2008, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "LogoLink11", "Wii Fit Plus", 30.600000000000001, 1 },
                    { new Guid("3f07c4d4-8a9c-43a3-8e8b-f3647c74bcaa"), "BackLink10", 11, 3, new DateTime(2009, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "LogoLink10", "Wii Fit", 344.60000000000002, 5 },
                    { new Guid("caec9e49-a98f-4f04-812c-15eddbf47960"), "BackLink9", 7, 4, new DateTime(2010, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "LogoLink9", "Mario Kart DS", 377.60000000000002, 4 },
                    { new Guid("a2fb3a28-ef07-40c6-bd77-bbb0fe3d5906"), "BackLink8", 10, 99, new DateTime(2011, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "LogoLink8", "Nintendo", 77.599999999999994, 3 },
                    { new Guid("32e0cd32-d696-4f85-aec5-927fca521362"), "BackLink7", 9, 7, new DateTime(2013, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "LogoLink7", "Duck Hunt", 7.5999999999999996, 2 },
                    { new Guid("559c8d6d-84c9-4e56-a248-800424cbebf6"), "BackLink6", 4, 4, new DateTime(2014, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "LogoLink6", "Wii Play", 3.6000000000000001, 1 },
                    { new Guid("6d97aac8-4cdb-4b1a-aba7-5a754afb35c8"), "BackLink5", 6, 7, new DateTime(2015, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "LogoLink5", "Tetras", 365.60000000000002, 5 },
                    { new Guid("a6cc29ab-ef03-49e8-ba04-372f4bcd1e46"), "BackLink4", 11, 4, new DateTime(2020, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "LogoLink4", "Wii Sports Resort", 326.60000000000002, 4 },
                    { new Guid("4f03c92b-01bc-4ea8-9b4c-63be3b4f474a"), "BackLink3", 7, 7, new DateTime(2017, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "LogoLink3", "Mario Kart Wii", 136.59999999999999, 3 },
                    { new Guid("12087e0a-e4e7-4675-bf0b-a2c08ac9f14a"), "BackLink2", 5, 23, new DateTime(2015, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "LogoLink2", "Super Mario Bros", 37.600000000000001, 2 },
                    { new Guid("7f67a190-16d5-43b3-95d0-d229bca5347b"), "BackLink21", 4, 2, new DateTime(1998, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "LogoLink21", "Gran Tur 4", 376.60000000000002, 1 },
                    { new Guid("6b7fa717-903e-4e61-ac77-6d67397863c2"), "BackLink22", 7, 24, new DateTime(1997, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "LogoLink22", "Super Mario Galaxy", 2.6000000000000001, 5 }
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

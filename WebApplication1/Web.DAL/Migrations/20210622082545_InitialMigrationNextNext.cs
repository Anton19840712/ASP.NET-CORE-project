using Microsoft.EntityFrameworkCore.Migrations;

namespace Web.DAL.Migrations
{
    public partial class InitialMigrationNextNext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0d24d655-7246-48e9-b572-b31bb0e4118a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "33b29059-0a97-4586-b621-ed5707adfabd");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8b387dc9-c46b-4cbc-91c7-f163997b44d5");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "98e32914-abcd-4e4f-a04d-4081ea48bcb7");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d3316868-61d6-4228-ae86-ec13e5cded59");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Email", "EmailConfirmed", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "18a47106-2692-46de-96f2-d485eb2c0bec", 0, null, "6602f046-86b7-4110-81fd-d1ed9bc4f4b7", null, false, "Jones", false, null, null, null, null, null, false, "9c42732e-0875-474f-aeec-69e86b03bfa2", false, null },
                    { "877d5766-deda-4562-a3ad-69606c45d3df", 0, null, "280ac113-e92c-4658-a915-60408027da2f", null, false, "Trump", false, null, null, null, null, null, false, "0a655826-e988-4f9e-9aaa-ebbb37c3ce41", false, null },
                    { "2a938e79-0e3e-4b7c-bd87-2fcbf6aa5c53", 0, null, "39fe5b74-5a04-47e1-8b46-1a1eab7627b8", null, false, "Obama", false, null, null, null, null, null, false, "fd949c9b-e311-4495-93ee-7418c419e24c", false, null },
                    { "2d231270-a47e-433f-9f22-a9b4dd2351ff", 0, null, "72ebed4c-5785-43c2-bcb5-4b9111c50c79", null, false, "Richter", false, null, null, null, null, null, false, "4c721227-4826-4635-9665-3f7f1a62ed45", false, null },
                    { "9c52f38e-1158-44c6-a532-71022b84d3ad", 0, null, "1be8e89a-3704-4e35-8eeb-59e27b6b6836", null, false, "Suzuki", false, null, null, null, null, null, false, "86e8d66d-d4a6-4dff-82ef-1ae5ac2cad0e", false, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "18a47106-2692-46de-96f2-d485eb2c0bec");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2a938e79-0e3e-4b7c-bd87-2fcbf6aa5c53");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2d231270-a47e-433f-9f22-a9b4dd2351ff");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "877d5766-deda-4562-a3ad-69606c45d3df");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9c52f38e-1158-44c6-a532-71022b84d3ad");

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
        }
    }
}

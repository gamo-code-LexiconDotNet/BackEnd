using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEnd.Migrations.IdentityDb
{
    public partial class adminUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "33ef999c-5faa-44d4-9fdc-ea07fd5dfcf5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "994daa6c-304f-4832-8e3e-b302e6a2c216");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0050d850-c1f9-4526-a5bb-f93ea19bd38f", "6ac1755e-dacd-42d0-b3ff-385e18f5a13e", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "387ead7c-bfb5-41d0-9af6-3b56d4ccf2bf", "374672f0-d02e-4328-b0cc-bf5600fd36ec", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "945f179e-bffc-4593-baf1-f3193fb1dc4c", 0, new DateTime(2022, 2, 23, 9, 42, 59, 55, DateTimeKind.Local).AddTicks(4054), "7c34f0c5-880c-4038-b24c-2505bb4e37c2", "admin@admin.com", true, "Admin", "Nimda", false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEAl3WizwDW6H5PmjyRJ5TrWCwOGoeDInMvTMU4CDD7J92jYR5Vc+n5exSdDNrRP3yg==", null, false, "2dd6c7ee-8069-48b8-beea-b7cbdc02e993", false, "admin@admin.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "945f179e-bffc-4593-baf1-f3193fb1dc4c", "0050d850-c1f9-4526-a5bb-f93ea19bd38f" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "387ead7c-bfb5-41d0-9af6-3b56d4ccf2bf");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "945f179e-bffc-4593-baf1-f3193fb1dc4c", "0050d850-c1f9-4526-a5bb-f93ea19bd38f" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0050d850-c1f9-4526-a5bb-f93ea19bd38f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "945f179e-bffc-4593-baf1-f3193fb1dc4c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "33ef999c-5faa-44d4-9fdc-ea07fd5dfcf5", "964d2899-936e-474d-bc18-786b3189b94f", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "994daa6c-304f-4832-8e3e-b302e6a2c216", "6f8438b3-e345-43a8-8468-7de11aa98065", "User", "USER" });
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace FlightManager.Migrations
{
    public partial class MigrationNumber4UserAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e7c31328-8a76-4bde-8ffe-d2579926098f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "55ad1f28-59cc-4168-a2b3-63a9ba8b4bd9");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6b5cae7e-39f4-4766-a735-0f47b60c1060", "a3936027-4207-4051-9379-a8e4764f192b", "Admin", "Admin" },
                    { "1599480d-7a7d-4ab0-ad64-94bf8ec1a8f6", "678c8c47-2dd5-4fed-b1a5-f9f9d5bbe64b", "User", "User" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PIN", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "f3de3b12-1007-4a89-ac14-181bc02e0c0f", 0, null, "b87550c8-2892-4d4d-8dc5-dd7d22da7183", "admin@abv.bg", false, "Jack", "Johnson", false, null, "admin@abv.bg", "admin@abv.bg", null, "AQAAAAEAACcQAAAAECnV8n6To2aemBpIuNwDi9bCJ7+1pg5ASidy1ptU9jL0QmT5EKKa4XAGt7klxnQcMQ==", null, false, "", false, "admin@abv.bg" },
                    { "86285219-7ea6-4050-8f1c-73557bd6cc18", 0, null, "15d1c88b-7560-47f2-b516-d86b09e01ebd", "miroslav@abv.bg", false, "Jane", "Alexandrov", false, null, "miroslav@abv.bg", "miroslav@abv.bg", null, "AQAAAAEAACcQAAAAEMuZk/VCfNxB6Z1PJfUygkQCTCJC0SSraK073osOa2XzanZghfZuc0aMFgY02i++Iw==", null, false, "", false, "miroslav@abv.bg" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1599480d-7a7d-4ab0-ad64-94bf8ec1a8f6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6b5cae7e-39f4-4766-a735-0f47b60c1060");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "86285219-7ea6-4050-8f1c-73557bd6cc18");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f3de3b12-1007-4a89-ac14-181bc02e0c0f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e7c31328-8a76-4bde-8ffe-d2579926098f", "d12c7be5-24d1-4290-8817-8c3f56a6adbc", "Admin", "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PIN", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "55ad1f28-59cc-4168-a2b3-63a9ba8b4bd9", 0, null, "5ef2acde-e87c-451a-af58-075508486d28", "admin@abv.bg", false, "Alex", "Johnson", false, null, "admin@abv.bg", "admin@abv.bg", null, "AQAAAAEAACcQAAAAEEjvFG/KyYayDQdrOWMO8kF/e4tRwcWh+cZA9xW9OO8s+2GOb8D+aElZjFp/GuxFKA==", null, false, "", false, "admin@abv.bg" });
        }
    }
}

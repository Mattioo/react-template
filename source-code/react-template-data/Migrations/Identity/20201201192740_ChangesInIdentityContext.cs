using Microsoft.EntityFrameworkCore.Migrations;

namespace react_template_data.Migrations.Identity
{
    public partial class ChangesInIdentityContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "495b44bd-5688-4fd7-acfa-2e72d85517ab", 0, "703e0df0-79ec-4671-98d9-6b9218b69fea", "mattioo@mailinator.com", true, false, null, "MATTIOO@MAILINATOR.COM", "MATTIOO@MAILINATOR.COM", "AQAAAAEAACcQAAAAEDhO+smiCC1VyEsFQiKOSKJYxgUd0eUGI4NlHMhJ1EBWFkGBGJ3Q+Mn+DaSI40x6Bw==", null, false, "05a97a5a-05ec-41f3-bceb-eed97687ad39", false, "mattioo@mailinator.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "495b44bd-5688-4fd7-acfa-2e72d85517ab");
        }
    }
}

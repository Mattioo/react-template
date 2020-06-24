using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace react_template_data.Migrations
{
    public partial class AddDefaultClient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "LicenceSince",
                table: "Clients",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 24, 13, 36, 20, 216, DateTimeKind.Utc).AddTicks(2588),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2020, 6, 21, 21, 48, 58, 154, DateTimeKind.Utc).AddTicks(3613));

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Active", "Database", "LicenceNo", "LicenceSince", "LicenceTo", "Name" },
                values: new object[] { 1, true, "react-template-owner-dev", "default", new DateTime(2020, 6, 24, 13, 36, 20, 224, DateTimeKind.Utc).AddTicks(2813), null, "default" });

            migrationBuilder.UpdateData(
                table: "Styles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Active", "Default" },
                values: new object[] { true, true });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LicenceSince",
                table: "Clients",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 21, 21, 48, 58, 154, DateTimeKind.Utc).AddTicks(3613),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 6, 24, 13, 36, 20, 216, DateTimeKind.Utc).AddTicks(2588));

            migrationBuilder.UpdateData(
                table: "Styles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Active", "Default" },
                values: new object[] { true, true });
        }
    }
}

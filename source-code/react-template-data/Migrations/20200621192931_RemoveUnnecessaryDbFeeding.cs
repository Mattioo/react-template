using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace react_template_data.Migrations
{
    public partial class RemoveUnnecessaryDbFeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Urls",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LicenceSince",
                table: "Clients",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 21, 19, 29, 30, 978, DateTimeKind.Utc).AddTicks(8153),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2020, 6, 21, 19, 11, 3, 979, DateTimeKind.Utc).AddTicks(7736));

            migrationBuilder.UpdateData(
                table: "Styles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Active", "Default" },
                values: new object[] { true, true });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "LicenceSince",
                table: "Clients",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 21, 19, 11, 3, 979, DateTimeKind.Utc).AddTicks(7736),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 6, 21, 19, 29, 30, 978, DateTimeKind.Utc).AddTicks(8153));

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Active", "Database", "LicenceNo", "LicenceTo", "Name" },
                values: new object[] { 1, true, "default", "default", null, "default" });

            migrationBuilder.UpdateData(
                table: "Styles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Active", "Default" },
                values: new object[] { true, true });

            migrationBuilder.InsertData(
                table: "Urls",
                columns: new[] { "Id", "Active", "ClientId", "Path", "StyleId" },
                values: new object[] { 1, true, 1, null, 1 });
        }
    }
}

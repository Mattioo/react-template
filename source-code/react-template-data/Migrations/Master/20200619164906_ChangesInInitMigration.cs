using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace react_template_data.Migrations
{
    public partial class ChangesInInitMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "LicenceSince",
                table: "Clients",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 19, 16, 49, 5, 973, DateTimeKind.Utc).AddTicks(2246),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2020, 6, 9, 9, 45, 14, 502, DateTimeKind.Utc).AddTicks(8691));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Active", "LicenceNo" },
                values: new object[] { true, "default" });

            migrationBuilder.UpdateData(
                table: "Styles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Active", "Default", "File" },
                values: new object[] { true, true, "styles.7188d.min.css" });

            migrationBuilder.UpdateData(
                table: "Styles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Active", "File" },
                values: new object[] { true, "styles.f550f.min.css" });

            migrationBuilder.UpdateData(
                table: "Urls",
                keyColumn: "Id",
                keyValue: 1,
                column: "Active",
                value: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "LicenceSince",
                table: "Clients",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 9, 9, 45, 14, 502, DateTimeKind.Utc).AddTicks(8691),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 6, 19, 16, 49, 5, 973, DateTimeKind.Utc).AddTicks(2246));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Active", "LicenceNo" },
                values: new object[] { true, "DEFAULT" });

            migrationBuilder.UpdateData(
                table: "Styles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Active", "Default", "File" },
                values: new object[] { true, true, "styles.2GPJa.css" });

            migrationBuilder.UpdateData(
                table: "Styles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Active", "File" },
                values: new object[] { true, "styles.3Z37u.css" });

            migrationBuilder.UpdateData(
                table: "Urls",
                keyColumn: "Id",
                keyValue: 1,
                column: "Active",
                value: true);
        }
    }
}

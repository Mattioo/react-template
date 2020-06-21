using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace react_template_data.Migrations
{
    public partial class AddConfigurationFiles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Styles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LicenceSince",
                table: "Clients",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 21, 19, 11, 3, 979, DateTimeKind.Utc).AddTicks(7736),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2020, 6, 19, 16, 49, 5, 973, DateTimeKind.Utc).AddTicks(2246));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 1,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Styles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Active", "Default", "File" },
                values: new object[] { true, true, "bundle.css" });

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
                defaultValue: new DateTime(2020, 6, 19, 16, 49, 5, 973, DateTimeKind.Utc).AddTicks(2246),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 6, 21, 19, 11, 3, 979, DateTimeKind.Utc).AddTicks(7736));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 1,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Styles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Active", "Default", "File" },
                values: new object[] { true, true, "styles.7188d.min.css" });

            migrationBuilder.InsertData(
                table: "Styles",
                columns: new[] { "Id", "Active", "Dict", "File" },
                values: new object[] { 2, true, "other", "styles.f550f.min.css" });

            migrationBuilder.UpdateData(
                table: "Urls",
                keyColumn: "Id",
                keyValue: 1,
                column: "Active",
                value: true);
        }
    }
}

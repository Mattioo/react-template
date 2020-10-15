using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace react_template_data.Migrations
{
    public partial class AddRedirectUriTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "LicenceSince",
                table: "Clients",
                nullable: false,
                defaultValue: new DateTime(2020, 10, 15, 14, 17, 44, 682, DateTimeKind.Utc).AddTicks(3995),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2020, 10, 15, 14, 8, 57, 117, DateTimeKind.Utc).AddTicks(6520));

            migrationBuilder.CreateTable(
                name: "RedirectUris",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Uri = table.Column<string>(maxLength: 100, nullable: false),
                    Active = table.Column<bool>(nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RedirectUris", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Active", "LicenceSince" },
                values: new object[] { true, new DateTime(2020, 10, 15, 14, 17, 44, 689, DateTimeKind.Utc).AddTicks(2170) });

            migrationBuilder.InsertData(
                table: "RedirectUris",
                columns: new[] { "Id", "Active", "Uri" },
                values: new object[] { 1, true, "https://localhost:44394" });

            migrationBuilder.UpdateData(
                table: "Scopes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Scopes",
                keyColumn: "Id",
                keyValue: 2,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Scopes",
                keyColumn: "Id",
                keyValue: 3,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Styles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Active", "Default" },
                values: new object[] { true, true });

            migrationBuilder.CreateIndex(
                name: "IX_RedirectUris_Uri",
                table: "RedirectUris",
                column: "Uri",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RedirectUris");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LicenceSince",
                table: "Clients",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2020, 10, 15, 14, 8, 57, 117, DateTimeKind.Utc).AddTicks(6520),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 10, 15, 14, 17, 44, 682, DateTimeKind.Utc).AddTicks(3995));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Active", "LicenceSince" },
                values: new object[] { true, new DateTime(2020, 10, 15, 14, 8, 57, 125, DateTimeKind.Utc).AddTicks(9344) });

            migrationBuilder.UpdateData(
                table: "Scopes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Scopes",
                keyColumn: "Id",
                keyValue: 2,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Scopes",
                keyColumn: "Id",
                keyValue: 3,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Styles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Active", "Default" },
                values: new object[] { true, true });
        }
    }
}

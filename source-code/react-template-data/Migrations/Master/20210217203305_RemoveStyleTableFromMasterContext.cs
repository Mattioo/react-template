using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace react_template_data.Migrations
{
    public partial class RemoveStyleTableFromMasterContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Urls_Styles_StyleId",
                table: "Urls");

            migrationBuilder.DropTable(
                name: "Styles");

            migrationBuilder.DropIndex(
                name: "IX_Urls_StyleId",
                table: "Urls");

            migrationBuilder.DropIndex(
                name: "IX_Urls_UnitId_StyleId_Path",
                table: "Urls");

            migrationBuilder.DropColumn(
                name: "StyleId",
                table: "Urls");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LicenceSince",
                table: "Units",
                nullable: false,
                defaultValue: new DateTime(2021, 2, 17, 20, 33, 5, 386, DateTimeKind.Utc).AddTicks(3041),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2020, 11, 25, 14, 47, 47, 966, DateTimeKind.Utc).AddTicks(1290));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Active", "LicenceSince" },
                values: new object[] { true, new DateTime(2021, 2, 17, 20, 33, 5, 392, DateTimeKind.Utc).AddTicks(1603) });

            migrationBuilder.InsertData(
                table: "Urls",
                columns: new[] { "Id", "Active", "Path", "UnitId" },
                values: new object[] { 1, true, "localhost", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Urls_UnitId_Path",
                table: "Urls",
                columns: new[] { "UnitId", "Path" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Urls_UnitId_Path",
                table: "Urls");

            migrationBuilder.DeleteData(
                table: "Urls",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "StyleId",
                table: "Urls",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LicenceSince",
                table: "Units",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2020, 11, 25, 14, 47, 47, 966, DateTimeKind.Utc).AddTicks(1290),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 2, 17, 20, 33, 5, 386, DateTimeKind.Utc).AddTicks(3041));

            migrationBuilder.CreateTable(
                name: "Styles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Active = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    Default = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    Dict = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    File = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Styles", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Styles",
                columns: new[] { "Id", "Active", "Default", "Dict", "File" },
                values: new object[] { 1, true, true, "default", "bundle.css" });

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Active", "LicenceSince" },
                values: new object[] { true, new DateTime(2020, 11, 25, 14, 47, 47, 974, DateTimeKind.Utc).AddTicks(7169) });

            migrationBuilder.CreateIndex(
                name: "IX_Urls_StyleId",
                table: "Urls",
                column: "StyleId");

            migrationBuilder.CreateIndex(
                name: "IX_Urls_UnitId_StyleId_Path",
                table: "Urls",
                columns: new[] { "UnitId", "StyleId", "Path" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Styles_Dict_File",
                table: "Styles",
                columns: new[] { "Dict", "File" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Urls_Styles_StyleId",
                table: "Urls",
                column: "StyleId",
                principalTable: "Styles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

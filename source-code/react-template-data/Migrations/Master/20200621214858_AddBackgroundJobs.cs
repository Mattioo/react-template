using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace react_template_data.Migrations
{
    public partial class AddBackgroundJobs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "LicenceSince",
                table: "Clients",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 21, 21, 48, 58, 154, DateTimeKind.Utc).AddTicks(3613),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2020, 6, 21, 19, 29, 30, 978, DateTimeKind.Utc).AddTicks(8153));

            migrationBuilder.CreateTable(
                name: "BackgroundJobs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    LastRun = table.Column<DateTime>(nullable: true),
                    Active = table.Column<bool>(nullable: false, defaultValue: false),
                    ClientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BackgroundJobs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BackgroundJobs_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Styles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Active", "Default" },
                values: new object[] { true, true });

            migrationBuilder.CreateIndex(
                name: "IX_BackgroundJobs_ClientId",
                table: "BackgroundJobs",
                column: "ClientId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BackgroundJobs_Name",
                table: "BackgroundJobs",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BackgroundJobs");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LicenceSince",
                table: "Clients",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 21, 19, 29, 30, 978, DateTimeKind.Utc).AddTicks(8153),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 6, 21, 21, 48, 58, 154, DateTimeKind.Utc).AddTicks(3613));

            migrationBuilder.UpdateData(
                table: "Styles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Active", "Default" },
                values: new object[] { true, true });
        }
    }
}

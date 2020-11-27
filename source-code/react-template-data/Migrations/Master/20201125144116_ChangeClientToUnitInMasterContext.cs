using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace react_template_data.Migrations
{
    public partial class ChangeClientToUnitInMasterContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BackgroundJobs_Clients_ClientId",
                table: "BackgroundJobs");

            migrationBuilder.DropForeignKey(
                name: "FK_Urls_Clients_ClientId",
                table: "Urls");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Urls_ClientId_StyleId_Path",
                table: "Urls");

            migrationBuilder.DropIndex(
                name: "IX_BackgroundJobs_ClientId",
                table: "BackgroundJobs");

            migrationBuilder.DropIndex(
                name: "IX_BackgroundJobs_Name_ClientId",
                table: "BackgroundJobs");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Urls");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "BackgroundJobs");

            migrationBuilder.AddColumn<int>(
                name: "UnitId",
                table: "Urls",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UnitId",
                table: "BackgroundJobs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Database = table.Column<string>(maxLength: 50, nullable: false),
                    LicenceNo = table.Column<string>(maxLength: 50, nullable: false),
                    LicenceSince = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 11, 25, 14, 41, 15, 729, DateTimeKind.Utc).AddTicks(850)),
                    LicenceTo = table.Column<DateTime>(nullable: true),
                    Active = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "DomainSystems",
                keyColumn: "Id",
                keyValue: 1,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "GrantTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "IdentityResources",
                keyColumn: "Id",
                keyValue: 1,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "IdentityResources",
                keyColumn: "Id",
                keyValue: 2,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "IdentityResources",
                keyColumn: "Id",
                keyValue: 3,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "IdentityResources",
                keyColumn: "Id",
                keyValue: 4,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "IdentityResources",
                keyColumn: "Id",
                keyValue: 5,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "IdentityResources",
                keyColumn: "Id",
                keyValue: 6,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "IdentityResources",
                keyColumn: "Id",
                keyValue: 7,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "IdentityResources",
                keyColumn: "Id",
                keyValue: 8,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "IdentityResources",
                keyColumn: "Id",
                keyValue: 9,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "IdentityResources",
                keyColumn: "Id",
                keyValue: 10,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "IdentityResources",
                keyColumn: "Id",
                keyValue: 11,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "IdentityResources",
                keyColumn: "Id",
                keyValue: 12,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "IdentityResources",
                keyColumn: "Id",
                keyValue: 13,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "IdentityResources",
                keyColumn: "Id",
                keyValue: 14,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "IdentityResources",
                keyColumn: "Id",
                keyValue: 15,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "IdentityResources",
                keyColumn: "Id",
                keyValue: 16,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "IdentityResources",
                keyColumn: "Id",
                keyValue: 17,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "RedirectUris",
                keyColumn: "Id",
                keyValue: 1,
                column: "Active",
                value: true);

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
                table: "Scopes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Active", "ApiScope" },
                values: new object[] { true, true });

            migrationBuilder.UpdateData(
                table: "Styles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Active", "Default" },
                values: new object[] { true, true });

            migrationBuilder.InsertData(
                table: "Units",
                columns: new[] { "Id", "Active", "Database", "LicenceNo", "LicenceSince", "LicenceTo", "Name" },
                values: new object[] { 1, true, "react-template-owner-dev", "default", new DateTime(2020, 11, 25, 14, 41, 15, 738, DateTimeKind.Utc).AddTicks(4113), null, "default" });

            migrationBuilder.CreateIndex(
                name: "IX_Urls_UnitId_StyleId_Path",
                table: "Urls",
                columns: new[] { "UnitId", "StyleId", "Path" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BackgroundJobs_UnitId",
                table: "BackgroundJobs",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_BackgroundJobs_Name_UnitId",
                table: "BackgroundJobs",
                columns: new[] { "Name", "UnitId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Units_LicenceNo",
                table: "Units",
                column: "LicenceNo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Units_Name",
                table: "Units",
                column: "Name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BackgroundJobs_Units_UnitId",
                table: "BackgroundJobs",
                column: "UnitId",
                principalTable: "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Urls_Units_UnitId",
                table: "Urls",
                column: "UnitId",
                principalTable: "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BackgroundJobs_Units_UnitId",
                table: "BackgroundJobs");

            migrationBuilder.DropForeignKey(
                name: "FK_Urls_Units_UnitId",
                table: "Urls");

            migrationBuilder.DropTable(
                name: "Units");

            migrationBuilder.DropIndex(
                name: "IX_Urls_UnitId_StyleId_Path",
                table: "Urls");

            migrationBuilder.DropIndex(
                name: "IX_BackgroundJobs_UnitId",
                table: "BackgroundJobs");

            migrationBuilder.DropIndex(
                name: "IX_BackgroundJobs_Name_UnitId",
                table: "BackgroundJobs");

            migrationBuilder.DropColumn(
                name: "UnitId",
                table: "Urls");

            migrationBuilder.DropColumn(
                name: "UnitId",
                table: "BackgroundJobs");

            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "Urls",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "BackgroundJobs",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Active = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    Database = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    LicenceNo = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    LicenceSince = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValue: new DateTime(2020, 11, 3, 15, 19, 2, 965, DateTimeKind.Utc).AddTicks(831)),
                    LicenceTo = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Active", "Database", "LicenceNo", "LicenceSince", "LicenceTo", "Name" },
                values: new object[] { 1, true, "react-template-owner-dev", "default", new DateTime(2020, 11, 3, 15, 19, 2, 972, DateTimeKind.Utc).AddTicks(5640), null, "default" });

            migrationBuilder.UpdateData(
                table: "DomainSystems",
                keyColumn: "Id",
                keyValue: 1,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "GrantTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "IdentityResources",
                keyColumn: "Id",
                keyValue: 1,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "IdentityResources",
                keyColumn: "Id",
                keyValue: 2,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "IdentityResources",
                keyColumn: "Id",
                keyValue: 3,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "IdentityResources",
                keyColumn: "Id",
                keyValue: 4,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "IdentityResources",
                keyColumn: "Id",
                keyValue: 5,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "IdentityResources",
                keyColumn: "Id",
                keyValue: 6,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "IdentityResources",
                keyColumn: "Id",
                keyValue: 7,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "IdentityResources",
                keyColumn: "Id",
                keyValue: 8,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "IdentityResources",
                keyColumn: "Id",
                keyValue: 9,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "IdentityResources",
                keyColumn: "Id",
                keyValue: 10,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "IdentityResources",
                keyColumn: "Id",
                keyValue: 11,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "IdentityResources",
                keyColumn: "Id",
                keyValue: 12,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "IdentityResources",
                keyColumn: "Id",
                keyValue: 13,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "IdentityResources",
                keyColumn: "Id",
                keyValue: 14,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "IdentityResources",
                keyColumn: "Id",
                keyValue: 15,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "IdentityResources",
                keyColumn: "Id",
                keyValue: 16,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "IdentityResources",
                keyColumn: "Id",
                keyValue: 17,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "RedirectUris",
                keyColumn: "Id",
                keyValue: 1,
                column: "Active",
                value: true);

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
                table: "Scopes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Active", "ApiScope" },
                values: new object[] { true, true });

            migrationBuilder.UpdateData(
                table: "Styles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Active", "Default" },
                values: new object[] { true, true });

            migrationBuilder.CreateIndex(
                name: "IX_Urls_ClientId_StyleId_Path",
                table: "Urls",
                columns: new[] { "ClientId", "StyleId", "Path" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BackgroundJobs_ClientId",
                table: "BackgroundJobs",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_BackgroundJobs_Name_ClientId",
                table: "BackgroundJobs",
                columns: new[] { "Name", "ClientId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clients_LicenceNo",
                table: "Clients",
                column: "LicenceNo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clients_Name",
                table: "Clients",
                column: "Name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BackgroundJobs_Clients_ClientId",
                table: "BackgroundJobs",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Urls_Clients_ClientId",
                table: "Urls",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

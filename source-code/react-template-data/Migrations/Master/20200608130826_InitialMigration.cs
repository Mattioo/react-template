using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace react_template_data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Database = table.Column<string>(maxLength: 50, nullable: false),
                    LicenceNo = table.Column<string>(maxLength: 50, nullable: false),
                    LicenceSince = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 6, 8, 13, 8, 26, 34, DateTimeKind.Utc).AddTicks(3888)),
                    LicenceTo = table.Column<DateTime>(nullable: true),
                    Active = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Styles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Dict = table.Column<string>(maxLength: 50, nullable: false),
                    File = table.Column<string>(maxLength: 50, nullable: false),
                    Default = table.Column<bool>(nullable: false, defaultValue: false),
                    Active = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Styles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Urls",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Path = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: false, defaultValue: false),
                    ClientId = table.Column<int>(nullable: false),
                    StyleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Urls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Urls_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Urls_Styles_StyleId",
                        column: x => x.StyleId,
                        principalTable: "Styles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Active", "Database", "LicenceNo", "LicenceTo", "Name" },
                values: new object[] { 1, true, "default", "DEFAULT", null, "default" });

            migrationBuilder.InsertData(
                table: "Styles",
                columns: new[] { "Id", "Active", "Default", "Dict", "File" },
                values: new object[] { 1, true, true, "default", "styles.2GPJa.css" });

            migrationBuilder.InsertData(
                table: "Styles",
                columns: new[] { "Id", "Active", "Dict", "File" },
                values: new object[] { 2, true, "other", "styles.3Z37u.css" });

            migrationBuilder.InsertData(
                table: "Urls",
                columns: new[] { "Id", "Active", "ClientId", "Path", "StyleId" },
                values: new object[] { 1, true, 1, "http://localhost:9000", 1 });

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

            migrationBuilder.CreateIndex(
                name: "IX_Styles_Dict_File",
                table: "Styles",
                columns: new[] { "Dict", "File" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Urls_StyleId",
                table: "Urls",
                column: "StyleId");

            migrationBuilder.CreateIndex(
                name: "IX_Urls_ClientId_StyleId_Path",
                table: "Urls",
                columns: new[] { "ClientId", "StyleId", "Path" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Urls");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Styles");
        }
    }
}

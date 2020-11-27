using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace react_template_data.Migrations
{
    public partial class RemoveOldIdentityConfigurationFromMasterContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GrantTypes");

            migrationBuilder.DropTable(
                name: "IdentityResources");

            migrationBuilder.DropTable(
                name: "RedirectUris");

            migrationBuilder.DropTable(
                name: "Scopes");

            migrationBuilder.DropTable(
                name: "DomainSystems");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LicenceSince",
                table: "Units",
                nullable: false,
                defaultValue: new DateTime(2020, 11, 25, 14, 47, 47, 966, DateTimeKind.Utc).AddTicks(1290),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2020, 11, 25, 14, 41, 15, 729, DateTimeKind.Utc).AddTicks(850));

            migrationBuilder.UpdateData(
                table: "Styles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Active", "Default" },
                values: new object[] { true, true });

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Active", "LicenceSince" },
                values: new object[] { true, new DateTime(2020, 11, 25, 14, 47, 47, 974, DateTimeKind.Utc).AddTicks(7169) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "LicenceSince",
                table: "Units",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2020, 11, 25, 14, 41, 15, 729, DateTimeKind.Utc).AddTicks(850),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 11, 25, 14, 47, 47, 966, DateTimeKind.Utc).AddTicks(1290));

            migrationBuilder.CreateTable(
                name: "DomainSystems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Active = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    Identifier = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Secret = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DomainSystems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GrantTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Active = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    DomainSystemId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrantTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GrantTypes_DomainSystems_DomainSystemId",
                        column: x => x.DomainSystemId,
                        principalTable: "DomainSystems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdentityResources",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Active = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    Claim = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    DomainSystemId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityResources", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdentityResources_DomainSystems_DomainSystemId",
                        column: x => x.DomainSystemId,
                        principalTable: "DomainSystems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RedirectUris",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Active = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    DomainSystemId = table.Column<int>(type: "integer", nullable: false),
                    Uri = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RedirectUris", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RedirectUris_DomainSystems_DomainSystemId",
                        column: x => x.DomainSystemId,
                        principalTable: "DomainSystems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Scopes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Active = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    ApiScope = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    DomainSystemId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scopes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Scopes_DomainSystems_DomainSystemId",
                        column: x => x.DomainSystemId,
                        principalTable: "DomainSystems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "DomainSystems",
                columns: new[] { "Id", "Active", "Identifier", "Name", "Secret" },
                values: new object[] { 1, true, "react-template", "Front office", "sD3fPKLnFKZUjnSV4qA/XoJOqsmDfNfxWcZ7kPtLc0I=" });

            migrationBuilder.UpdateData(
                table: "Styles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Active", "Default" },
                values: new object[] { true, true });

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Active", "LicenceSince" },
                values: new object[] { true, new DateTime(2020, 11, 25, 14, 41, 15, 738, DateTimeKind.Utc).AddTicks(4113) });

            migrationBuilder.InsertData(
                table: "GrantTypes",
                columns: new[] { "Id", "Active", "DomainSystemId", "Name" },
                values: new object[] { 1, true, 1, "authorization_code" });

            migrationBuilder.InsertData(
                table: "IdentityResources",
                columns: new[] { "Id", "Active", "Claim", "DomainSystemId", "Name" },
                values: new object[,]
                {
                    { 17, true, "updated_at", 1, "profile" },
                    { 16, true, "locale", 1, "profile" },
                    { 15, true, "zoneinfo", 1, "profile" },
                    { 14, true, "birthdate", 1, "profile" },
                    { 13, true, "gender", 1, "profile" },
                    { 12, true, "website", 1, "profile" },
                    { 10, true, "profile", 1, "profile" },
                    { 9, true, "preferred_username", 1, "profile" },
                    { 11, true, "picture", 1, "profile" },
                    { 7, true, "middle_name", 1, "profile" },
                    { 6, true, "given_name", 1, "profile" },
                    { 5, true, "family_name", 1, "profile" },
                    { 4, true, "name", 1, "profile" },
                    { 3, true, "email_verified", 1, "email" },
                    { 2, true, "email", 1, "email" },
                    { 1, true, "sub", 1, "openid" },
                    { 8, true, "nickname", 1, "profile" }
                });

            migrationBuilder.InsertData(
                table: "RedirectUris",
                columns: new[] { "Id", "Active", "DomainSystemId", "Uri" },
                values: new object[] { 1, true, 1, "https://localhost:44394" });

            migrationBuilder.InsertData(
                table: "Scopes",
                columns: new[] { "Id", "Active", "DomainSystemId", "Name" },
                values: new object[,]
                {
                    { 3, true, 1, "custom" },
                    { 1, true, 1, "openid" },
                    { 2, true, 1, "profile" }
                });

            migrationBuilder.InsertData(
                table: "Scopes",
                columns: new[] { "Id", "Active", "ApiScope", "DomainSystemId", "Name" },
                values: new object[] { 4, true, true, 1, "custom" });

            migrationBuilder.CreateIndex(
                name: "IX_DomainSystems_Identifier",
                table: "DomainSystems",
                column: "Identifier",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GrantTypes_DomainSystemId",
                table: "GrantTypes",
                column: "DomainSystemId");

            migrationBuilder.CreateIndex(
                name: "IX_GrantTypes_Name",
                table: "GrantTypes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_IdentityResources_DomainSystemId",
                table: "IdentityResources",
                column: "DomainSystemId");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityResources_Name_Claim",
                table: "IdentityResources",
                columns: new[] { "Name", "Claim" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RedirectUris_DomainSystemId",
                table: "RedirectUris",
                column: "DomainSystemId");

            migrationBuilder.CreateIndex(
                name: "IX_RedirectUris_Uri",
                table: "RedirectUris",
                column: "Uri",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Scopes_DomainSystemId",
                table: "Scopes",
                column: "DomainSystemId");

            migrationBuilder.CreateIndex(
                name: "IX_Scopes_Name_DomainSystemId_ApiScope",
                table: "Scopes",
                columns: new[] { "Name", "DomainSystemId", "ApiScope" },
                unique: true);
        }
    }
}

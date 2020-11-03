using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace react_template_data.Migrations
{
    public partial class AddRelationBetweenNewTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DomainSystemId",
                table: "Scopes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DomainSystemId",
                table: "RedirectUris",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DomainSystemId",
                table: "GrantTypes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LicenceSince",
                table: "Clients",
                nullable: false,
                defaultValue: new DateTime(2020, 10, 20, 18, 24, 0, 975, DateTimeKind.Utc).AddTicks(9969),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2020, 10, 15, 14, 51, 10, 822, DateTimeKind.Utc).AddTicks(2162));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Active", "LicenceSince" },
                values: new object[] { true, new DateTime(2020, 10, 20, 18, 24, 0, 982, DateTimeKind.Utc).AddTicks(7592) });

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
                columns: new[] { "Active", "DomainSystemId" },
                values: new object[] { true, 1 });

            migrationBuilder.UpdateData(
                table: "RedirectUris",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Active", "DomainSystemId" },
                values: new object[] { true, 1 });

            migrationBuilder.UpdateData(
                table: "Scopes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Active", "DomainSystemId" },
                values: new object[] { true, 1 });

            migrationBuilder.UpdateData(
                table: "Scopes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Active", "DomainSystemId" },
                values: new object[] { true, 1 });

            migrationBuilder.UpdateData(
                table: "Scopes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Active", "DomainSystemId" },
                values: new object[] { true, 1 });

            migrationBuilder.UpdateData(
                table: "Styles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Active", "Default" },
                values: new object[] { true, true });

            migrationBuilder.CreateIndex(
                name: "IX_Scopes_DomainSystemId",
                table: "Scopes",
                column: "DomainSystemId");

            migrationBuilder.CreateIndex(
                name: "IX_RedirectUris_DomainSystemId",
                table: "RedirectUris",
                column: "DomainSystemId");

            migrationBuilder.CreateIndex(
                name: "IX_GrantTypes_DomainSystemId",
                table: "GrantTypes",
                column: "DomainSystemId");

            migrationBuilder.AddForeignKey(
                name: "FK_GrantTypes_DomainSystems_DomainSystemId",
                table: "GrantTypes",
                column: "DomainSystemId",
                principalTable: "DomainSystems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RedirectUris_DomainSystems_DomainSystemId",
                table: "RedirectUris",
                column: "DomainSystemId",
                principalTable: "DomainSystems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Scopes_DomainSystems_DomainSystemId",
                table: "Scopes",
                column: "DomainSystemId",
                principalTable: "DomainSystems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GrantTypes_DomainSystems_DomainSystemId",
                table: "GrantTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_RedirectUris_DomainSystems_DomainSystemId",
                table: "RedirectUris");

            migrationBuilder.DropForeignKey(
                name: "FK_Scopes_DomainSystems_DomainSystemId",
                table: "Scopes");

            migrationBuilder.DropIndex(
                name: "IX_Scopes_DomainSystemId",
                table: "Scopes");

            migrationBuilder.DropIndex(
                name: "IX_RedirectUris_DomainSystemId",
                table: "RedirectUris");

            migrationBuilder.DropIndex(
                name: "IX_GrantTypes_DomainSystemId",
                table: "GrantTypes");

            migrationBuilder.DropColumn(
                name: "DomainSystemId",
                table: "Scopes");

            migrationBuilder.DropColumn(
                name: "DomainSystemId",
                table: "RedirectUris");

            migrationBuilder.DropColumn(
                name: "DomainSystemId",
                table: "GrantTypes");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LicenceSince",
                table: "Clients",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2020, 10, 15, 14, 51, 10, 822, DateTimeKind.Utc).AddTicks(2162),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 10, 20, 18, 24, 0, 975, DateTimeKind.Utc).AddTicks(9969));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Active", "LicenceSince" },
                values: new object[] { true, new DateTime(2020, 10, 15, 14, 51, 10, 828, DateTimeKind.Utc).AddTicks(6300) });

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
                table: "Styles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Active", "Default" },
                values: new object[] { true, true });
        }
    }
}

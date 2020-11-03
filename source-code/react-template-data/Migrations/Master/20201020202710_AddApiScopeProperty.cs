using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace react_template_data.Migrations
{
    public partial class AddApiScopeProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Scopes_Name",
                table: "Scopes");

            migrationBuilder.AddColumn<bool>(
                name: "ApiScope",
                table: "Scopes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Scopes_Name_DomainSystemId_ApiScope",
                table: "Scopes",
                columns: new[] { "Name", "DomainSystemId", "ApiScope" },
                unique: true);

            migrationBuilder.InsertData(
                table: "Scopes",
                columns: new[] { "Id", "Name", "ApiScope", "DomainSystemId", "Active" },
                values: new object[] { 4, "custom", true, 1, true });

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Scopes_Name",
                table: "Scopes",
                column: "Name",
                unique: true);

            migrationBuilder.DropIndex(
                name: "IX_Scopes_Name_DomainSystemId_ApiScope",
                table: "Scopes");

            migrationBuilder.DropColumn(
                name: "ApiScope",
                table: "Scopes");

            migrationBuilder.DeleteData(
                table: "Scopes",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}

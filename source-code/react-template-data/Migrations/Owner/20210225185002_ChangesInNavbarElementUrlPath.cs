using Microsoft.EntityFrameworkCore.Migrations;

namespace react_template_data.Migrations.Owner
{
    public partial class ChangesInNavbarElementUrlPath : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "NavbarElements",
                keyColumn: "Id",
                keyValue: 1,
                column: "Url",
                value: "/");

            migrationBuilder.UpdateData(
                table: "NavbarElements",
                keyColumn: "Id",
                keyValue: 2,
                column: "Url",
                value: "/info");

            migrationBuilder.UpdateData(
                table: "NavbarElements",
                keyColumn: "Id",
                keyValue: 3,
                column: "Url",
                value: "/contact");

            migrationBuilder.UpdateData(
                table: "Pdfs",
                keyColumn: "Id",
                keyValue: 1,
                column: "Default",
                value: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "NavbarElements",
                keyColumn: "Id",
                keyValue: 1,
                column: "Url",
                value: "#");

            migrationBuilder.UpdateData(
                table: "NavbarElements",
                keyColumn: "Id",
                keyValue: 2,
                column: "Url",
                value: "#info");

            migrationBuilder.UpdateData(
                table: "NavbarElements",
                keyColumn: "Id",
                keyValue: 3,
                column: "Url",
                value: "#contact");

            migrationBuilder.UpdateData(
                table: "Pdfs",
                keyColumn: "Id",
                keyValue: 1,
                column: "Default",
                value: true);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace react_template_data.Migrations.Owner
{
    public partial class UrlInNavbarElementIsNowRequiredMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "NavbarElements",
                nullable: false,
                defaultValue: "#",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

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
                table: "Pdfs",
                keyColumn: "Id",
                keyValue: 1,
                column: "Default",
                value: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "NavbarElements",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldDefaultValue: "#");

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
                value: "/#info");

            migrationBuilder.UpdateData(
                table: "Pdfs",
                keyColumn: "Id",
                keyValue: 1,
                column: "Default",
                value: true);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace react_template_data.Migrations.Owner
{
    public partial class AddNewNavbarElementAndSetFAIconsMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "NavbarElements",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Icon", "Url" },
                values: new object[] { "far fa-home", "#" });

            migrationBuilder.UpdateData(
                table: "NavbarElements",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Icon", "Url" },
                values: new object[] { "far fa-info-circle", "#info" });

            migrationBuilder.InsertData(
                table: "NavbarElements",
                columns: new[] { "Id", "Content", "Icon", "Name", "Order", "Title", "Url" },
                values: new object[] { 3, "Kontakt", "far fa-address-card", "Contact", 3, "Przejdź do strony z danymi teleadresowymi", "#contact" });

            migrationBuilder.UpdateData(
                table: "Pdfs",
                keyColumn: "Id",
                keyValue: 1,
                column: "Default",
                value: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "NavbarElements",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "NavbarElements",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Icon", "Url" },
                values: new object[] { "home", "#" });

            migrationBuilder.UpdateData(
                table: "NavbarElements",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Icon", "Url" },
                values: new object[] { "info-circle", "#info" });

            migrationBuilder.UpdateData(
                table: "Pdfs",
                keyColumn: "Id",
                keyValue: 1,
                column: "Default",
                value: true);
        }
    }
}

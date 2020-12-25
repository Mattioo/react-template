using Microsoft.EntityFrameworkCore.Migrations;

namespace react_template_data.Migrations.Owner
{
    public partial class ChangesInDefaultSmtpConfig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "SmtpConfigs",
                keyColumn: "Id",
                keyValue: 1,
                column: "SecureSocketOption",
                value: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "SmtpConfigs",
                keyColumn: "Id",
                keyValue: 1,
                column: "SecureSocketOption",
                value: 0);
        }
    }
}

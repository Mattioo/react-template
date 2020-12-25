using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace react_template_data.Migrations.Owner
{
    public partial class AddSmtpAndSmsConfigTablesMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SmsConfigs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Token = table.Column<string>(maxLength: 100, nullable: false),
                    MaxNumberOfCharacters = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SmsConfigs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SmtpConfigs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Host = table.Column<string>(nullable: false),
                    Port = table.Column<int>(nullable: false),
                    Username = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    SecureSocketOption = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SmtpConfigs", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "SmsConfigs",
                columns: new[] { "Id", "Active", "MaxNumberOfCharacters", "Name", "Token" },
                values: new object[] { 1, true, 160, "default", "6gz7z1VyApBBzBoG8L8bJ2LyEqnuFuU8iUmY93oa" });

            migrationBuilder.InsertData(
                table: "SmtpConfigs",
                columns: new[] { "Id", "Active", "Host", "Name", "Password", "Port", "SecureSocketOption", "Username" },
                values: new object[] { 1, true, "smtp.gmail.com", "default", "WpMF3NPW", 587, 0, "m.korolvv@gmail.com" });

            migrationBuilder.CreateIndex(
                name: "IX_SmsConfigs_Name",
                table: "SmsConfigs",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SmtpConfigs_Name",
                table: "SmtpConfigs",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SmsConfigs");

            migrationBuilder.DropTable(
                name: "SmtpConfigs");
        }
    }
}

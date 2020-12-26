using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace react_template_data.Migrations.Owner
{
    public partial class AddPdfConfigurationTableMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pdfs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(maxLength: 100, nullable: false),
                    Default = table.Column<bool>(nullable: false, defaultValue: false),
                    Active = table.Column<bool>(nullable: false, defaultValue: true),
                    Encoding = table.Column<string>(nullable: false, defaultValue: "utf-8"),
                    Orientation = table.Column<int>(nullable: false, defaultValue: 1),
                    Size = table.Column<int>(nullable: false, defaultValue: 9),
                    Counter = table.Column<bool>(nullable: false),
                    MarginTop = table.Column<double>(nullable: true),
                    MarginBottom = table.Column<double>(nullable: true),
                    MarginLeft = table.Column<double>(nullable: true),
                    MarginRight = table.Column<double>(nullable: true),
                    MarginUnit = table.Column<int>(nullable: false),
                    HeaderFontName = table.Column<string>(nullable: false),
                    HeaderFontSize = table.Column<short>(nullable: false),
                    HeaderLeft = table.Column<string>(nullable: true),
                    HeaderRight = table.Column<string>(nullable: true),
                    HeaderCenter = table.Column<string>(nullable: true),
                    HeaderUrl = table.Column<string>(nullable: true),
                    HeaderSpacing = table.Column<double>(nullable: true),
                    HeaderLine = table.Column<bool>(nullable: false),
                    FooterFontName = table.Column<string>(nullable: false),
                    FooterFontSize = table.Column<short>(nullable: false),
                    FooterLeft = table.Column<string>(nullable: true),
                    FooterRight = table.Column<string>(nullable: true),
                    FooterCenter = table.Column<string>(nullable: true),
                    FooterUrl = table.Column<string>(nullable: true),
                    FooterSpacing = table.Column<double>(nullable: true),
                    FooterLine = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pdfs", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Pdfs",
                columns: new[] { "Id", "Counter", "Default", "FooterCenter", "FooterFontName", "FooterFontSize", "FooterLeft", "FooterLine", "FooterRight", "FooterSpacing", "FooterUrl", "HeaderCenter", "HeaderFontName", "HeaderFontSize", "HeaderLeft", "HeaderLine", "HeaderRight", "HeaderSpacing", "HeaderUrl", "MarginBottom", "MarginLeft", "MarginRight", "MarginTop", "MarginUnit", "Title" },
                values: new object[] { 1, true, true, "Mateusz Korolow 2020 ®", "Arial", (short)9, null, true, null, null, null, null, "Arial", (short)9, null, true, "Strona [page] z [toPage]", null, null, null, null, null, 10.0, 1, "Wydruk" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pdfs");
        }
    }
}

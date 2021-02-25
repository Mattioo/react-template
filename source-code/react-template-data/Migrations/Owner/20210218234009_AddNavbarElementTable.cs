using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace react_template_data.Migrations.Owner
{
    public partial class AddNavbarElementTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Properties");

            migrationBuilder.CreateTable(
                name: "NavbarElements",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Order = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Icon = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    Url = table.Column<string>(nullable: true),
                    Anonymous = table.Column<bool>(nullable: false, defaultValue: true),
                    Visible = table.Column<bool>(nullable: false, defaultValue: true),
                    Active = table.Column<bool>(nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NavbarElements", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "NavbarElements",
                columns: new[] { "Id", "Content", "Icon", "Name", "Order", "Title", "Url" },
                values: new object[,]
                {
                    { 1, "Strona główna", "home", "Home", 1, "Przejdź do strony głównej", "/" },
                    { 2, "Informacje", "info-circle", "About", 2, "Przejdź do strony z informacjami", "/#info" }
                });

            migrationBuilder.UpdateData(
                table: "Pdfs",
                keyColumn: "Id",
                keyValue: 1,
                column: "Default",
                value: true);

            migrationBuilder.CreateIndex(
                name: "IX_NavbarElements_Name",
                table: "NavbarElements",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NavbarElements");

            migrationBuilder.CreateTable(
                name: "Properties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Properties", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Pdfs",
                keyColumn: "Id",
                keyValue: 1,
                column: "Default",
                value: true);

            migrationBuilder.CreateIndex(
                name: "IX_Properties_Name",
                table: "Properties",
                column: "Name",
                unique: true);
        }
    }
}

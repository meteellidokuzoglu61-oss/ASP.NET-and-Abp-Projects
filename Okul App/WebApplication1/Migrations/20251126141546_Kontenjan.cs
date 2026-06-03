using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class Kontenjan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Dolu",
                table: "Bolumler");

            migrationBuilder.DropColumn(
                name: "ToplamKontenjan",
                table: "Bolumler");

            migrationBuilder.CreateTable(
                name: "Sinif",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sinif_Ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ToplamKontenjan = table.Column<int>(type: "int", nullable: false),
                    Dolu = table.Column<int>(type: "int", nullable: false),
                    ProgramTipi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BolumId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sinif", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sinif_Bolumler_BolumId",
                        column: x => x.BolumId,
                        principalTable: "Bolumler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sinif_BolumId",
                table: "Sinif",
                column: "BolumId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sinif");

            migrationBuilder.AddColumn<int>(
                name: "Dolu",
                table: "Bolumler",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ToplamKontenjan",
                table: "Bolumler",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

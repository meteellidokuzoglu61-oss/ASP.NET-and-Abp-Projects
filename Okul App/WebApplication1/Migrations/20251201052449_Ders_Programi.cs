using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class Ders_Programi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SinifId",
                schema: "dbo",
                table: "Ogrenciler",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DersProgramilari",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SinifId = table.Column<int>(type: "int", nullable: false),
                    DersAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ogretmen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gun = table.Column<int>(type: "int", nullable: false),
                    DersSaati = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DersProgramilari", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DersProgramilari_Sinif_SinifId",
                        column: x => x.SinifId,
                        principalTable: "Sinif",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ogrenciler_SinifId",
                schema: "dbo",
                table: "Ogrenciler",
                column: "SinifId");

            migrationBuilder.CreateIndex(
                name: "IX_DersProgramilari_SinifId",
                table: "DersProgramilari",
                column: "SinifId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ogrenciler_Sinif_SinifId",
                schema: "dbo",
                table: "Ogrenciler",
                column: "SinifId",
                principalTable: "Sinif",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ogrenciler_Sinif_SinifId",
                schema: "dbo",
                table: "Ogrenciler");

            migrationBuilder.DropTable(
                name: "DersProgramilari");

            migrationBuilder.DropIndex(
                name: "IX_Ogrenciler_SinifId",
                schema: "dbo",
                table: "Ogrenciler");

            migrationBuilder.DropColumn(
                name: "SinifId",
                schema: "dbo",
                table: "Ogrenciler");
        }
    }
}

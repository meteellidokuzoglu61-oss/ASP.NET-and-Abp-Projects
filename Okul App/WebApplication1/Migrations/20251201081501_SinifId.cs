using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class SinifId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SinifId",
                table: "Sinif");

            migrationBuilder.AddColumn<int>(
                name: "Sinif_Id",
                schema: "dbo",
                table: "Ogrenciler",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sinif_Id",
                schema: "dbo",
                table: "Ogrenciler");

            migrationBuilder.AddColumn<int>(
                name: "SinifId",
                table: "Sinif",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

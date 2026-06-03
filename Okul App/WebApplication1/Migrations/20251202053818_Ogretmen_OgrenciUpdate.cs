using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class Ogretmen_OgrenciUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Ogretmen_Subesi",
                table: "Ogretmenler",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Ogrenci_Subesi",
                schema: "dbo",
                table: "Ogrenciler",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ogretmen_Subesi",
                table: "Ogretmenler");

            migrationBuilder.DropColumn(
                name: "Ogrenci_Subesi",
                schema: "dbo",
                table: "Ogrenciler");
        }
    }
}

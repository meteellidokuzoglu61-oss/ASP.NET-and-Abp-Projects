using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class NotUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DonemNotu",
                table: "Notlar",
                newName: "YaziliSinav");

            migrationBuilder.AddColumn<int>(
                name: "Donem",
                table: "Notlar",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Proje",
                table: "Notlar",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Sozlu",
                table: "Notlar",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Donem",
                table: "Notlar");

            migrationBuilder.DropColumn(
                name: "Proje",
                table: "Notlar");

            migrationBuilder.DropColumn(
                name: "Sozlu",
                table: "Notlar");

            migrationBuilder.RenameColumn(
                name: "YaziliSinav",
                table: "Notlar",
                newName: "DonemNotu");
        }
    }
}

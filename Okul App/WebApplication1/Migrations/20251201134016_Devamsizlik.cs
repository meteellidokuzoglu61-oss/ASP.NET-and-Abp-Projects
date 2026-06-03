using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class Devamsizlik : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Devamsizliklar_Ogrenciler_OgrenciId",
                table: "Devamsizliklar");

            migrationBuilder.DropIndex(
                name: "IX_Devamsizliklar_OgrenciId",
                table: "Devamsizliklar");

            migrationBuilder.DropColumn(
                name: "Devamsiz",
                table: "Devamsizliklar");

            migrationBuilder.DropColumn(
                name: "OgrenciId",
                table: "Devamsizliklar");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Devamsiz",
                table: "Devamsizliklar",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "OgrenciId",
                table: "Devamsizliklar",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Devamsizliklar_OgrenciId",
                table: "Devamsizliklar",
                column: "OgrenciId");

            migrationBuilder.AddForeignKey(
                name: "FK_Devamsizliklar_Ogrenciler_OgrenciId",
                table: "Devamsizliklar",
                column: "OgrenciId",
                principalSchema: "dbo",
                principalTable: "Ogrenciler",
                principalColumn: "Ogrenci_ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

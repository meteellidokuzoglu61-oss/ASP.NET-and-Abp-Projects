using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OkulApplication.Migrations
{
    /// <inheritdoc />
    public partial class Initial3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppDevamsizlik_AppOgrenciler_OgrenciId",
                table: "AppDevamsizlik");

            migrationBuilder.DropIndex(
                name: "IX_AppDevamsizlik_OgrenciId",
                table: "AppDevamsizlik");

            migrationBuilder.CreateTable(
                name: "Takvimler",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Baslik = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    BaslangicTarihi = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    BitisTarihi = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Tip = table.Column<int>(type: "integer", nullable: false),
                    DersId = table.Column<Guid>(type: "uuid", nullable: true),
                    ExtraProperties = table.Column<string>(type: "text", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Takvimler", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Takvimler");

            migrationBuilder.CreateIndex(
                name: "IX_AppDevamsizlik_OgrenciId",
                table: "AppDevamsizlik",
                column: "OgrenciId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppDevamsizlik_AppOgrenciler_OgrenciId",
                table: "AppDevamsizlik",
                column: "OgrenciId",
                principalTable: "AppOgrenciler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

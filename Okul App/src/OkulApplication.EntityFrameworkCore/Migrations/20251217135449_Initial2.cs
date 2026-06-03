using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OkulApplication.Migrations
{
    /// <inheritdoc />
    public partial class Initial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppDevamsizlik",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OgrenciId = table.Column<Guid>(type: "uuid", nullable: false),
                    Devamsizlik_Tarihi = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Tip = table.Column<int>(type: "integer", nullable: false),
                    ExtraProperties = table.Column<string>(type: "text", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppDevamsizlik", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppDevamsizlik_AppOgrenciler_OgrenciId",
                        column: x => x.OgrenciId,
                        principalTable: "AppOgrenciler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppDevamsizlik_OgrenciId",
                table: "AppDevamsizlik",
                column: "OgrenciId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppDevamsizlik");
        }
    }
}

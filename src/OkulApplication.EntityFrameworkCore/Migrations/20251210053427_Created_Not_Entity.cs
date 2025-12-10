using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OkulApplication.Migrations
{
    /// <inheritdoc />
    public partial class Created_Not_Entity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Notlar",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Ders = table.Column<string>(type: "text", nullable: false),
                    Sozlu = table.Column<decimal>(type: "numeric", nullable: false),
                    Yazili = table.Column<decimal>(type: "numeric", nullable: false),
                    Proje = table.Column<decimal>(type: "numeric", nullable: false),
                    OlusturmaTarihi = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notlar", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notlar");
        }
    }
}

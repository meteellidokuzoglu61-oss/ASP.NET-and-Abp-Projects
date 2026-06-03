using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OkulApplication.Migrations
{
    /// <inheritdoc />
    public partial class Add_Email : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "AppOgrenciler");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "AppOgrenciler",
                type: "character varying(5)",
                maxLength: 5,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "AppOgrenciler");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "AppOgrenciler",
                type: "uuid",
                nullable: true);
        }
    }
}

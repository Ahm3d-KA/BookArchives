using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookArchives.Data.ApplicationData
{
    /// <inheritdoc />
    public partial class changedthenametoarchiveusername : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookId",
                table: "ArchiveDb");

            migrationBuilder.DropColumn(
                name: "DateRead",
                table: "ArchiveDb");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "ArchiveDb");

            migrationBuilder.RenameColumn(
                name: "FavouriteQuote",
                table: "ArchiveDb",
                newName: "BookName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BookName",
                table: "ArchiveDb",
                newName: "FavouriteQuote");

            migrationBuilder.AddColumn<string>(
                name: "BookId",
                table: "ArchiveDb",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateRead",
                table: "ArchiveDb",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "ArchiveDb",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookArchives.Data.ApplicationData
{
    /// <inheritdoc />
    public partial class addnewbookproperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateRead",
                table: "ArchiveDb",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "FavouriteQuote",
                table: "ArchiveDb",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "ArchiveDb",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateRead",
                table: "ArchiveDb");

            migrationBuilder.DropColumn(
                name: "FavouriteQuote",
                table: "ArchiveDb");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "ArchiveDb");
        }
    }
}

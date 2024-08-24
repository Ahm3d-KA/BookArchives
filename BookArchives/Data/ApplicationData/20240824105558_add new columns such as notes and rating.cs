using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookArchives.Data.ApplicationData
{
    /// <inheritdoc />
    public partial class addnewcolumnssuchasnotesandrating : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "BookName",
                table: "ArchiveDb",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "ArchiveDb",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "ArchiveDb",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReadingStatus",
                table: "ArchiveDb",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Notes",
                table: "ArchiveDb");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "ArchiveDb");

            migrationBuilder.DropColumn(
                name: "ReadingStatus",
                table: "ArchiveDb");

            migrationBuilder.AlterColumn<string>(
                name: "BookName",
                table: "ArchiveDb",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookArchives.Data
{
    /// <inheritdoc />
    public partial class Addinguserbook : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArchiveDb",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ArchiveUserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArchiveDb", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArchiveDb");
        }
    }
}

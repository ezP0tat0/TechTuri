using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechTuri.Migrations
{
    /// <inheritdoc />
    public partial class imgTest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "description",
                table: "Pictures");

            migrationBuilder.CreateTable(
                name: "imgs",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    imgData = table.Column<byte[]>(type: "BLOB", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_imgs", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "imgs");

            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "Pictures",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}

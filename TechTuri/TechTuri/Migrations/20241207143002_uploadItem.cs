using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechTuri.Migrations
{
    /// <inheritdoc />
    public partial class uploadItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "imgs");

            migrationBuilder.DropColumn(
                name: "fileExtension",
                table: "Pictures");

            migrationBuilder.DropColumn(
                name: "size",
                table: "Pictures");

            migrationBuilder.DropColumn(
                name: "title",
                table: "Pictures");

            migrationBuilder.RenameColumn(
                name: "bytes",
                table: "Pictures",
                newName: "imgData");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "imgData",
                table: "Pictures",
                newName: "bytes");

            migrationBuilder.AddColumn<string>(
                name: "fileExtension",
                table: "Pictures",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "size",
                table: "Pictures",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "title",
                table: "Pictures",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

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
    }
}

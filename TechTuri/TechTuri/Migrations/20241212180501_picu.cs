using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechTuri.Migrations
{
    /// <inheritdoc />
    public partial class picu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "imgData",
                table: "Pictures");

            migrationBuilder.AddColumn<string>(
                name: "filePath",
                table: "Pictures",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "filePath",
                table: "Pictures");

            migrationBuilder.AddColumn<byte[]>(
                name: "imgData",
                table: "Pictures",
                type: "BLOB",
                nullable: false,
                defaultValue: new byte[0]);
        }
    }
}

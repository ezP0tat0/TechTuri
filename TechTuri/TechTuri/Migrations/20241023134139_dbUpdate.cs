using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechTuri.Migrations
{
    /// <inheritdoc />
    public partial class dbUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Picture_Items_ItemId",
                table: "Picture");

            migrationBuilder.DropTable(
                name: "ReviewItemConnections");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Picture",
                table: "Picture");

            migrationBuilder.DropIndex(
                name: "IX_Picture_ItemId",
                table: "Picture");

            migrationBuilder.RenameTable(
                name: "Picture",
                newName: "Pictures");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pictures",
                table: "Pictures",
                column: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Pictures",
                table: "Pictures");

            migrationBuilder.RenameTable(
                name: "Pictures",
                newName: "Picture");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Picture",
                table: "Picture",
                column: "id");

            //migrationBuilder.CreateTable(
            //    name: "ReviewItemConnections",
            //    columns: table => new
            //    {
            //        id = table.Column<int>(type: "INTEGER", nullable: false)
            //            .Annotation("Sqlite:Autoincrement", true),
            //        ItemID = table.Column<int>(type: "INTEGER", nullable: false),
            //        ReviewID = table.Column<int>(type: "INTEGER", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_ReviewItemConnections", x => x.id);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_Picture_ItemId",
            //    table: "Picture",
            //    column: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Picture_Items_ItemId",
                table: "Picture",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

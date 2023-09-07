using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Update_Wisslist : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CakeId",
                table: "Wishlists",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Wishlists_CakeId",
                table: "Wishlists",
                column: "CakeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Wishlists_Cakes_CakeId",
                table: "Wishlists",
                column: "CakeId",
                principalTable: "Cakes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wishlists_Cakes_CakeId",
                table: "Wishlists");

            migrationBuilder.DropIndex(
                name: "IX_Wishlists_CakeId",
                table: "Wishlists");

            migrationBuilder.DropColumn(
                name: "CakeId",
                table: "Wishlists");
        }
    }
}

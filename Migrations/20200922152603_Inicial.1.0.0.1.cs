using Microsoft.EntityFrameworkCore.Migrations;

namespace Movies.Migrations
{
    public partial class Inicial1001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Categories_IdCategory",
                table: "Movies");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Categories_IdCategory",
                table: "Movies",
                column: "IdCategory",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Categories_IdCategory",
                table: "Movies");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Categories_IdCategory",
                table: "Movies",
                column: "IdCategory",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

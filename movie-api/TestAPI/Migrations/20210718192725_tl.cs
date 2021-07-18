using Microsoft.EntityFrameworkCore.Migrations;

namespace TestAPI.Migrations
{
    public partial class tl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MoviesMovieId",
                table: "Actor",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Actor_MoviesMovieId",
                table: "Actor",
                column: "MoviesMovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Actor_Movies_MoviesMovieId",
                table: "Actor",
                column: "MoviesMovieId",
                principalTable: "Movies",
                principalColumn: "MovieId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Actor_Movies_MoviesMovieId",
                table: "Actor");

            migrationBuilder.DropIndex(
                name: "IX_Actor_MoviesMovieId",
                table: "Actor");

            migrationBuilder.DropColumn(
                name: "MoviesMovieId",
                table: "Actor");
        }
    }
}

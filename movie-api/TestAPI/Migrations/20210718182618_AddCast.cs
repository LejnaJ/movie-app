using Microsoft.EntityFrameworkCore.Migrations;

namespace TestAPI.Migrations
{
    public partial class AddCast : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Actor_Movies_MovieId",
                table: "Actor");

            migrationBuilder.RenameColumn(
                name: "MovieId",
                table: "Actor",
                newName: "MoviesMovieId");

            migrationBuilder.RenameIndex(
                name: "IX_Actor_MovieId",
                table: "Actor",
                newName: "IX_Actor_MoviesMovieId");

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

            migrationBuilder.RenameColumn(
                name: "MoviesMovieId",
                table: "Actor",
                newName: "MovieId");

            migrationBuilder.RenameIndex(
                name: "IX_Actor_MoviesMovieId",
                table: "Actor",
                newName: "IX_Actor_MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Actor_Movies_MovieId",
                table: "Actor",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "MovieId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

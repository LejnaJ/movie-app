using Microsoft.EntityFrameworkCore.Migrations;

namespace TestAPI.Migrations
{
    public partial class Cast : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "Cast",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActorId = table.Column<int>(type: "int", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cast", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cast_Actor_ActorId",
                        column: x => x.ActorId,
                        principalTable: "Actor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cast_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cast_ActorId",
                table: "Cast",
                column: "ActorId");

            migrationBuilder.CreateIndex(
                name: "IX_Cast_MovieId",
                table: "Cast",
                column: "MovieId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cast");

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
    }
}

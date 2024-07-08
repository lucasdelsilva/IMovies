using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IMovies.API.Migrations.ConsoleApplication
{
    /// <inheritdoc />
    public partial class TablesConsole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    value = table.Column<int>(type: "int", nullable: false),
                    LogoPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    value = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "IMovieDetails",
                columns: table => new
                {
                    GuidId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Adulto = table.Column<bool>(type: "bit", nullable: false),
                    BackGroundPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PosterPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Genres_Capacity = table.Column<int>(type: "int", nullable: true),
                    IMovieDb = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OriginCountry = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OriginLanguage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OriginTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescriptionMovie = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Companies_Capacity = table.Column<int>(type: "int", nullable: true),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Languages_Capacity = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TagLine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VoteAverage = table.Column<double>(type: "float", nullable: false),
                    VoteCount = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IMovieDetails", x => x.GuidId);
                });

            migrationBuilder.CreateTable(
                name: "IMovies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Adulto = table.Column<bool>(type: "bit", nullable: false),
                    BackGroundPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PosterPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Genres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MovieIdentification = table.Column<int>(type: "int", nullable: false),
                    OriginLanguage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OriginTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VoteAverage = table.Column<double>(type: "float", nullable: false),
                    VoteCount = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IMovies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    NameLanguage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodeName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "IMovieDetails");

            migrationBuilder.DropTable(
                name: "IMovies");

            migrationBuilder.DropTable(
                name: "Languages");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vidly_MVC.Migrations
{
    /// <inheritdoc />
    public partial class Seed_Movies_Data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Movies (Name, GenreId, DateAdded, ReleaseDate, NumberInStock, NumberAvailable) VALUES ('Hangover', 1, '2024-04-17', '2009-06-02', 5, 100)");
            migrationBuilder.Sql("INSERT INTO Movies (Name, GenreId, DateAdded, ReleaseDate, NumberInStock, NumberAvailable) VALUES ('Die Hard', 1, '2024-04-17', '1988-07-15', 5, 100)");
            migrationBuilder.Sql("INSERT INTO Movies (Name, GenreId, DateAdded, ReleaseDate, NumberInStock, NumberAvailable) VALUES ('The Terminator', 1, '2024-04-17', '1984-10-26', 5, 100)");
            migrationBuilder.Sql("INSERT INTO Movies (Name, GenreId, DateAdded, ReleaseDate, NumberInStock, NumberAvailable) VALUES ('Toy Story', 3, '2024-04-17', '1995-11-22', 5, 100)");
            migrationBuilder.Sql("INSERT INTO Movies (Name, GenreId, DateAdded, ReleaseDate, NumberInStock, NumberAvailable) VALUES ('Titanic', 4, '2024-04-17', '1997-12-19', 5, 100)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}

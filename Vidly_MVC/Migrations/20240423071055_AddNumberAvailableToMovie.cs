using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vidly_MVC.Migrations
{
    /// <inheritdoc />
    public partial class AddNumberAvailableToMovie : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Update Movies SET NumberAvailable = NumberInStock");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}

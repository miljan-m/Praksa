using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LibraryApp.Migrations
{
    /// <inheritdoc />
    public partial class FifthMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Isbn", "AuthorId", "Available", "Genre", "Title" },
                values: new object[,]
                {
                    { "123456oadadadasf", null, true, "Avantura", "Le Petite Prince" },
                    { "123456oaihsf", null, true, "Avantura", "Alisa u zemlji cuda" },
                    { "127889asdihsf", null, true, "Avantura", "Harry Potter" },
                    { "189er56oaihsf", null, true, "Avantura", "The jungle book" },
                    { "asdffrghsf", null, true, "Avantura", "Lord of rings" },
                    { "deilgoihj2343", null, true, "Avantura", "Murder on Nil" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Isbn",
                keyValue: "123456oadadadasf");

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Isbn",
                keyValue: "123456oaihsf");

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Isbn",
                keyValue: "127889asdihsf");

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Isbn",
                keyValue: "189er56oaihsf");

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Isbn",
                keyValue: "asdffrghsf");

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Isbn",
                keyValue: "deilgoihj2343");
        }
    }
}

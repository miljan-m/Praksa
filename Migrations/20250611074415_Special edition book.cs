using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LibraryApp.Migrations
{
    /// <inheritdoc />
    public partial class Specialeditionbook : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "Autograph",
                table: "Books",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Books",
                type: "nvarchar(21)",
                maxLength: 21,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "InStorage",
                table: "Books",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Isbn", "AuthorId", "Available", "Discriminator", "Genre", "Title" },
                values: new object[,]
                {
                    { "123456oadadadasf", null, true, "Book", "Avantura", "Le Petite Prince" },
                    { "123456oaihsf", null, true, "Book", "Avantura", "Alisa u zemlji cuda" },
                    { "127889asdihsf", null, true, "Book", "Avantura", "Harry Potter" },
                    { "189er56oaihsf", null, true, "Book", "Avantura", "The jungle book" },
                    { "asdffrghsf", null, true, "Book", "Avantura", "Lord of rings" },
                    { "deilgoihj2343", null, true, "Book", "Avantura", "Murder on Nil" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Autograph",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "InStorage",
                table: "Books");
        }
    }
}

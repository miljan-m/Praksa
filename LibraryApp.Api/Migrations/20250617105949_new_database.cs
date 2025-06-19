using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LibraryApp.Migrations
{
    /// <inheritdoc />
    public partial class new_database : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    AdminId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.AdminId);
                });

            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    AuthorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.AuthorId);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    JMBG = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.JMBG);
                });

            migrationBuilder.CreateTable(
                name: "Rents",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rents", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Isbn = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Available = table.Column<bool>(type: "bit", nullable: false),
                    AuthorId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    InStorage = table.Column<int>(type: "int", nullable: true),
                    Autograph = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Isbn);
                    table.ForeignKey(
                        name: "FK_Books_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "AuthorId");
                });

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "AdminId", "DateOfBirth", "FirstName", "LastName" },
                values: new object[,]
                {
                    { "1", null, "Admin1Name", "Admin1LastName" },
                    { "2", null, "Admin2Name", "Admin2LastName" },
                    { "3", null, "Admin3Name", "Admin3LastName" },
                    { "4", null, "Admin4Name", "Admin4LastName" },
                    { "5", null, "Admin5Name", "Admin5LastName" }
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "AuthorId", "DateOfBirth", "LastName", "Name" },
                values: new object[,]
                {
                    { "1", null, "Author1LastName", "Author1Name" },
                    { "2", null, "Author2LastName", "Author2Name" },
                    { "3", null, "Author3LastName", "Author3Name" },
                    { "4", null, "Author4LastName", "Author4Name" }
                });

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

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "JMBG", "FirstName", "LastName" },
                values: new object[,]
                {
                    { "123456", "Customer1Name", "Customer1LastName" },
                    { "238476", "Customer5Name", "Customer5LastName" },
                    { "239184762", "Customer2Name", "Customer2LastName" },
                    { "324857", "Customer4Name", "Customer4LastName" },
                    { "329456", "Customer3Name", "Customer3LastName" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                column: "AuthorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Rents");

            migrationBuilder.DropTable(
                name: "Authors");
        }
    }
}

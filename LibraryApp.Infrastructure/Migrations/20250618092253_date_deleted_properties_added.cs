using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryApp.Migrations
{
    /// <inheritdoc />
    public partial class date_deleted_properties_added : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "Customers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Customers",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "Books",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Books",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "Authors",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Authors",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "Admins",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Admins",
                type: "bit",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "AdminId",
                keyValue: "1",
                columns: new[] { "DateDeleted", "IsDeleted" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "AdminId",
                keyValue: "2",
                columns: new[] { "DateDeleted", "IsDeleted" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "AdminId",
                keyValue: "3",
                columns: new[] { "DateDeleted", "IsDeleted" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "AdminId",
                keyValue: "4",
                columns: new[] { "DateDeleted", "IsDeleted" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "AdminId",
                keyValue: "5",
                columns: new[] { "DateDeleted", "IsDeleted" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: "1",
                columns: new[] { "DateDeleted", "IsDeleted" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: "2",
                columns: new[] { "DateDeleted", "IsDeleted" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: "3",
                columns: new[] { "DateDeleted", "IsDeleted" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: "4",
                columns: new[] { "DateDeleted", "IsDeleted" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Isbn",
                keyValue: "123456oadadadasf",
                columns: new[] { "DateDeleted", "IsDeleted" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Isbn",
                keyValue: "123456oaihsf",
                columns: new[] { "DateDeleted", "IsDeleted" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Isbn",
                keyValue: "127889asdihsf",
                columns: new[] { "DateDeleted", "IsDeleted" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Isbn",
                keyValue: "189er56oaihsf",
                columns: new[] { "DateDeleted", "IsDeleted" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Isbn",
                keyValue: "asdffrghsf",
                columns: new[] { "DateDeleted", "IsDeleted" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Isbn",
                keyValue: "deilgoihj2343",
                columns: new[] { "DateDeleted", "IsDeleted" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "JMBG",
                keyValue: "123456",
                columns: new[] { "DateDeleted", "IsDeleted" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "JMBG",
                keyValue: "238476",
                columns: new[] { "DateDeleted", "IsDeleted" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "JMBG",
                keyValue: "239184762",
                columns: new[] { "DateDeleted", "IsDeleted" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "JMBG",
                keyValue: "324857",
                columns: new[] { "DateDeleted", "IsDeleted" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "JMBG",
                keyValue: "329456",
                columns: new[] { "DateDeleted", "IsDeleted" },
                values: new object[] { null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "Admins");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Admins");
        }
    }
}

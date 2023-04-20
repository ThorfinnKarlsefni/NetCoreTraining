using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore.Migrations
{
    /// <inheritdoc />
    public partial class brid_annotations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "demo");

            migrationBuilder.RenameTable(
                name: "T_songs",
                newName: "T_songs",
                newSchema: "demo");

            migrationBuilder.RenameTable(
                name: "T_Persons",
                newName: "T_Persons",
                newSchema: "demo");

            migrationBuilder.RenameTable(
                name: "T_books",
                newName: "T_books",
                newSchema: "demo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "T_songs",
                schema: "demo",
                newName: "T_songs");

            migrationBuilder.RenameTable(
                name: "T_Persons",
                schema: "demo",
                newName: "T_Persons");

            migrationBuilder.RenameTable(
                name: "T_books",
                schema: "demo",
                newName: "T_books");
        }
    }
}

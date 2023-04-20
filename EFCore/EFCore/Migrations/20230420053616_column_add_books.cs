using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore.Migrations
{
    /// <inheritdoc />
    public partial class column_add_books : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "T_test",
                schema: "demo",
                newName: "T_test");

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

            migrationBuilder.AddColumn<string>(
                name: "lyric",
                table: "T_books",
                type: "varchar(80)",
                maxLength: 80,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "mins",
                table: "T_books",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_T_books_mins",
                table: "T_books",
                column: "mins",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_T_books_mins",
                table: "T_books");

            migrationBuilder.DropColumn(
                name: "lyric",
                table: "T_books");

            migrationBuilder.DropColumn(
                name: "mins",
                table: "T_books");

            migrationBuilder.RenameTable(
                name: "T_test",
                newName: "T_test",
                newSchema: "demo");

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
    }
}

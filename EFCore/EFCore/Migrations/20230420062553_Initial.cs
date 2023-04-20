using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "T_books",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titile = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PubTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    AuthorName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    lyric = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false),
                    mins = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_books", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "T_Persons",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    BirthPlace = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Persons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "T_songs",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PubTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_songs", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_T_books_mins",
                table: "T_books",
                column: "mins",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_books");

            migrationBuilder.DropTable(
                name: "T_Persons");

            migrationBuilder.DropTable(
                name: "T_songs");
        }
    }
}

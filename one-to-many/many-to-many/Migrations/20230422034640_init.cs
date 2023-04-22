using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace many_to_many.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "T_Students",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Students", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "T_Teacher",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Teacher", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "T_Student_and_Teacher",
                columns: table => new
                {
                    StudentsId = table.Column<long>(type: "bigint", nullable: false),
                    TeachersId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Student_and_Teacher", x => new { x.StudentsId, x.TeachersId });
                    table.ForeignKey(
                        name: "FK_T_Student_and_Teacher_T_Students_StudentsId",
                        column: x => x.StudentsId,
                        principalTable: "T_Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_T_Student_and_Teacher_T_Teacher_TeachersId",
                        column: x => x.TeachersId,
                        principalTable: "T_Teacher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_T_Student_and_Teacher_TeachersId",
                table: "T_Student_and_Teacher",
                column: "TeachersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_Student_and_Teacher");

            migrationBuilder.DropTable(
                name: "T_Students");

            migrationBuilder.DropTable(
                name: "T_Teacher");
        }
    }
}

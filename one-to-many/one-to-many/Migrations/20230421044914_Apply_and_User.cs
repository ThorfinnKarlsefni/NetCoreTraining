using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace one_to_many.Migrations
{
    /// <inheritdoc />
    public partial class Apply_and_User : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "T_Users",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "T_Applies",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequesterId = table.Column<long>(type: "bigint", nullable: false),
                    ApproverId = table.Column<long>(type: "bigint", nullable: true),
                    Remark = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    From = table.Column<DateTime>(type: "datetime2", nullable: false),
                    To = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Applies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_T_Applies_T_Users_ApproverId",
                        column: x => x.ApproverId,
                        principalTable: "T_Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_T_Applies_T_Users_RequesterId",
                        column: x => x.RequesterId,
                        principalTable: "T_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_T_Applies_ApproverId",
                table: "T_Applies",
                column: "ApproverId");

            migrationBuilder.CreateIndex(
                name: "IX_T_Applies_RequesterId",
                table: "T_Applies",
                column: "RequesterId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_Applies");

            migrationBuilder.DropTable(
                name: "T_Users");
        }
    }
}

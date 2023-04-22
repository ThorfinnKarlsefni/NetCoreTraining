using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace one_to_many.Migrations
{
    /// <inheritdoc />
    public partial class order_address : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "T_Addresses",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Addresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "T_Orders",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_T_Orders_T_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "T_Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_T_Orders_AddressId",
                table: "T_Orders",
                column: "AddressId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_Orders");

            migrationBuilder.DropTable(
                name: "T_Addresses");
        }
    }
}

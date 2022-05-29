using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalAPI.Migrations
{
    /// <inheritdoc />
    public partial class refactor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Apartaments_Users",
                columns: table => new
                {
                    ID_Apartament_User = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_Apartament = table.Column<long>(type: "bigint", nullable: false),
                    ID_User = table.Column<long>(type: "bigint", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTIme = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apartaments_Users", x => x.ID_Apartament_User);
                    table.ForeignKey(
                        name: "FK_Apartaments_Users_Apartamentes_ID_Apartament",
                        column: x => x.ID_Apartament,
                        principalTable: "Apartamentes",
                        principalColumn: "ID_Apartament");
                    table.ForeignKey(
                        name: "FK_Apartaments_Users_Users_ID_User",
                        column: x => x.ID_User,
                        principalTable: "Users",
                        principalColumn: "ID_User");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Apartaments_Users_ID_Apartament",
                table: "Apartaments_Users",
                column: "ID_Apartament",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Apartaments_Users_ID_User",
                table: "Apartaments_Users",
                column: "ID_User",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Apartaments_Users");
        }
    }
}

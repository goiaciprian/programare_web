using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalAPI.Migrations
{
    /// <inheritdoc />
    public partial class user_has_multiple_apartaments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ID_User",
                table: "Apartamentes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ID_User",
                table: "Apartamentes",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AM.Infrastructures.Migrations
{
    /// <inheritdoc />
    public partial class AirlineLogo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Airline",
                table: "Planes",
                newName: "Airlinelogo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Airlinelogo",
                table: "Planes",
                newName: "Airline");
        }
    }
}

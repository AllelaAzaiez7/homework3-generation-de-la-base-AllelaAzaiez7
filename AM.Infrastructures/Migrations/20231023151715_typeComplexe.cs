using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AM.Infrastructures.Migrations
{
    /// <inheritdoc />
    public partial class typeComplexe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Passengers",
                newName: "fUllName_LastName");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Passengers",
                newName: "fUllName_FirstName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "fUllName_LastName",
                table: "Passengers",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "fUllName_FirstName",
                table: "Passengers",
                newName: "FirstName");
        }
    }
}

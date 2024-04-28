using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASP_SPU221_HMW.Migrations
{
    /// <inheritdoc />
    public partial class newMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Registered",
                table: "Users",
                newName: "Registrate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Registrate",
                table: "Users",
                newName: "Registered");
        }
    }
}

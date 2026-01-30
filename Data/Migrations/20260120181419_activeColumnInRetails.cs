using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api_LojaTricotllure.Data.Migrations
{
    /// <inheritdoc />
    public partial class activeColumnInRetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "active",
                table: "retail",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "active",
                table: "retail");
        }
    }
}

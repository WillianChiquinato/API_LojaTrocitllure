using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api_LojaTricotllure.Data.Migrations
{
    /// <inheritdoc />
    public partial class produtoContagemParaDestaque : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "is_emphasis",
                table: "product_consolidateds");

            migrationBuilder.AddColumn<int>(
                name: "sold_out_count",
                table: "product_consolidateds",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "sold_out_count",
                table: "product_consolidateds");

            migrationBuilder.AddColumn<bool>(
                name: "is_emphasis",
                table: "product_consolidateds",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }
    }
}

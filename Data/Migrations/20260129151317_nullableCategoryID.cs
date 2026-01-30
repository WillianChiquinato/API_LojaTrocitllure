using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api_LojaTricotllure.Data.Migrations
{
    /// <inheritdoc />
    public partial class nullableCategoryID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_product_consolidateds_category_parent_category_parent_id",
                table: "product_consolidateds_category");

            migrationBuilder.AlterColumn<int>(
                name: "parent_id",
                table: "product_consolidateds_category",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_product_consolidateds_category_parent_category_parent_id",
                table: "product_consolidateds_category",
                column: "parent_id",
                principalTable: "parent_category",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_product_consolidateds_category_parent_category_parent_id",
                table: "product_consolidateds_category");

            migrationBuilder.AlterColumn<int>(
                name: "parent_id",
                table: "product_consolidateds_category",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_product_consolidateds_category_parent_category_parent_id",
                table: "product_consolidateds_category",
                column: "parent_id",
                principalTable: "parent_category",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

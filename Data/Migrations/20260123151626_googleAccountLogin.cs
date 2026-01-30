using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api_LojaTricotllure.Data.Migrations
{
    /// <inheritdoc />
    public partial class googleAccountLogin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_product_consolidateds_image_product_consolidateds_product_id",
                table: "product_consolidateds_image");

            migrationBuilder.DropForeignKey(
                name: "FK_shopping_cart_user_user_id",
                table: "shopping_cart");

            migrationBuilder.AddColumn<string>(
                name: "google_id",
                table: "user",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "user_id",
                table: "shopping_cart",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "product_id",
                table: "product_consolidateds_image",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_product_consolidateds_image_product_consolidateds_product_id",
                table: "product_consolidateds_image",
                column: "product_id",
                principalTable: "product_consolidateds",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_shopping_cart_user_user_id",
                table: "shopping_cart",
                column: "user_id",
                principalTable: "user",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_product_consolidateds_image_product_consolidateds_product_id",
                table: "product_consolidateds_image");

            migrationBuilder.DropForeignKey(
                name: "FK_shopping_cart_user_user_id",
                table: "shopping_cart");

            migrationBuilder.DropColumn(
                name: "google_id",
                table: "user");

            migrationBuilder.AlterColumn<int>(
                name: "user_id",
                table: "shopping_cart",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "product_id",
                table: "product_consolidateds_image",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_product_consolidateds_image_product_consolidateds_product_id",
                table: "product_consolidateds_image",
                column: "product_id",
                principalTable: "product_consolidateds",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_shopping_cart_user_user_id",
                table: "shopping_cart",
                column: "user_id",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

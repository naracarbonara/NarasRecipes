using Microsoft.EntityFrameworkCore.Migrations;

namespace Naras_Kitchen.Data.Migrations
{
    public partial class teest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_Ingredients_IngredientId",
                table: "Ingredients");

            migrationBuilder.DropIndex(
                name: "IX_Ingredients_IngredientId",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "IngredientId",
                table: "Ingredients");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IngredientId",
                table: "Ingredients",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_IngredientId",
                table: "Ingredients",
                column: "IngredientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_Ingredients_IngredientId",
                table: "Ingredients",
                column: "IngredientId",
                principalTable: "Ingredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

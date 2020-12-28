using Microsoft.EntityFrameworkCore.Migrations;

namespace Naras_Kitchen.Data.Migrations
{
    public partial class newlogicmenu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Days_WeeklyMenus_WeeklyMenuId",
                table: "Days");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_WeeklyMenus_WeeklyMenuId",
                table: "Recipes");

            migrationBuilder.DropIndex(
                name: "IX_Recipes_WeeklyMenuId",
                table: "Recipes");

            migrationBuilder.DropIndex(
                name: "IX_Days_WeeklyMenuId",
                table: "Days");

            migrationBuilder.DropColumn(
                name: "WeeklyMenuId",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "WeeklyMenuId",
                table: "Days");

            migrationBuilder.AddColumn<string>(
                name: "Day",
                table: "WeeklyMenus",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RecipeId",
                table: "WeeklyMenus",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_WeeklyMenus_RecipeId",
                table: "WeeklyMenus",
                column: "RecipeId");

            migrationBuilder.AddForeignKey(
                name: "FK_WeeklyMenus_Recipes_RecipeId",
                table: "WeeklyMenus",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WeeklyMenus_Recipes_RecipeId",
                table: "WeeklyMenus");

            migrationBuilder.DropIndex(
                name: "IX_WeeklyMenus_RecipeId",
                table: "WeeklyMenus");

            migrationBuilder.DropColumn(
                name: "Day",
                table: "WeeklyMenus");

            migrationBuilder.DropColumn(
                name: "RecipeId",
                table: "WeeklyMenus");

            migrationBuilder.AddColumn<int>(
                name: "WeeklyMenuId",
                table: "Recipes",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WeeklyMenuId",
                table: "Days",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_WeeklyMenuId",
                table: "Recipes",
                column: "WeeklyMenuId");

            migrationBuilder.CreateIndex(
                name: "IX_Days_WeeklyMenuId",
                table: "Days",
                column: "WeeklyMenuId");

            migrationBuilder.AddForeignKey(
                name: "FK_Days_WeeklyMenus_WeeklyMenuId",
                table: "Days",
                column: "WeeklyMenuId",
                principalTable: "WeeklyMenus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_WeeklyMenus_WeeklyMenuId",
                table: "Recipes",
                column: "WeeklyMenuId",
                principalTable: "WeeklyMenus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

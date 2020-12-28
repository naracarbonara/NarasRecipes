using Microsoft.EntityFrameworkCore.Migrations;

namespace Naras_Kitchen.Data.Migrations
{
    public partial class errordays : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Day_WeeklyMenus_WeeklyMenuId",
                table: "Day");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Day",
                table: "Day");

            migrationBuilder.RenameTable(
                name: "Day",
                newName: "Days");

            migrationBuilder.RenameIndex(
                name: "IX_Day_WeeklyMenuId",
                table: "Days",
                newName: "IX_Days_WeeklyMenuId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Days",
                table: "Days",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Days_WeeklyMenus_WeeklyMenuId",
                table: "Days",
                column: "WeeklyMenuId",
                principalTable: "WeeklyMenus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Days_WeeklyMenus_WeeklyMenuId",
                table: "Days");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Days",
                table: "Days");

            migrationBuilder.RenameTable(
                name: "Days",
                newName: "Day");

            migrationBuilder.RenameIndex(
                name: "IX_Days_WeeklyMenuId",
                table: "Day",
                newName: "IX_Day_WeeklyMenuId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Day",
                table: "Day",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Day_WeeklyMenus_WeeklyMenuId",
                table: "Day",
                column: "WeeklyMenuId",
                principalTable: "WeeklyMenus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

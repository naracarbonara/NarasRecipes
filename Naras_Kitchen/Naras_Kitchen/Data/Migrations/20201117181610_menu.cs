using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Naras_Kitchen.Data.Migrations
{
    public partial class menu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WeeklyMenuId",
                table: "Recipes",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "WeeklyMenus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: true),
                    Days = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeeklyMenus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeeklyMenus_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_WeeklyMenuId",
                table: "Recipes",
                column: "WeeklyMenuId");

            migrationBuilder.CreateIndex(
                name: "IX_WeeklyMenus_UserId",
                table: "WeeklyMenus",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_WeeklyMenus_WeeklyMenuId",
                table: "Recipes",
                column: "WeeklyMenuId",
                principalTable: "WeeklyMenus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_WeeklyMenus_WeeklyMenuId",
                table: "Recipes");

            migrationBuilder.DropTable(
                name: "WeeklyMenus");

            migrationBuilder.DropIndex(
                name: "IX_Recipes_WeeklyMenuId",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "WeeklyMenuId",
                table: "Recipes");
        }
    }
}

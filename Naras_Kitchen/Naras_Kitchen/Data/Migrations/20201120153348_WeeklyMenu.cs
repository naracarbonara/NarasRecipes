using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Naras_Kitchen.Data.Migrations
{
    public partial class WeeklyMenu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Days",
                table: "WeeklyMenus");

            migrationBuilder.CreateTable(
                name: "Day",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    WeeklyMenuId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Day", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Day_WeeklyMenus_WeeklyMenuId",
                        column: x => x.WeeklyMenuId,
                        principalTable: "WeeklyMenus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Day_WeeklyMenuId",
                table: "Day",
                column: "WeeklyMenuId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Day");

            migrationBuilder.AddColumn<string>(
                name: "Days",
                table: "WeeklyMenus",
                nullable: true);
        }
    }
}

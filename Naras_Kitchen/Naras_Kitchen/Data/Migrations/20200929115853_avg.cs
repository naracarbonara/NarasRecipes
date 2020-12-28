using Microsoft.EntityFrameworkCore.Migrations;

namespace Naras_Kitchen.Data.Migrations
{
    public partial class avg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "AvgRating",
                table: "Recipes",
                nullable: false,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "AvgRating",
                table: "Recipes",
                nullable: false,
                oldClrType: typeof(double));
        }
    }
}

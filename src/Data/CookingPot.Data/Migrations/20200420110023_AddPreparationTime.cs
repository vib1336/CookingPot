using Microsoft.EntityFrameworkCore.Migrations;

namespace CookingPot.Data.Migrations
{
    public partial class AddPreparationTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TimeToPrepare",
                table: "Recipes",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TimeToPrepare",
                table: "Recipes");
        }
    }
}

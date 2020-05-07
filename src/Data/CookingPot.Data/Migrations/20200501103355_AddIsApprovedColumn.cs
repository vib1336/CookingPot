using Microsoft.EntityFrameworkCore.Migrations;

namespace CookingPot.Data.Migrations
{
    public partial class AddIsApprovedColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "ApprovalRecipes",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "ApprovalRecipes");
        }
    }
}

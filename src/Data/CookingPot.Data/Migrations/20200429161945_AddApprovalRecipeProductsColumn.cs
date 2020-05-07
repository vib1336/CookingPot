using Microsoft.EntityFrameworkCore.Migrations;

namespace CookingPot.Data.Migrations
{
    public partial class AddApprovalRecipeProductsColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductRecipes_ApprovalRecipes_ApprovalRecipeId",
                table: "ProductRecipes");

            migrationBuilder.DropIndex(
                name: "IX_ProductRecipes_ApprovalRecipeId",
                table: "ProductRecipes");

            migrationBuilder.DropColumn(
                name: "ApprovalRecipeId",
                table: "ProductRecipes");

            migrationBuilder.AddColumn<string>(
                name: "RecipeProducts",
                table: "ApprovalRecipes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RecipeProducts",
                table: "ApprovalRecipes");

            migrationBuilder.AddColumn<int>(
                name: "ApprovalRecipeId",
                table: "ProductRecipes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductRecipes_ApprovalRecipeId",
                table: "ProductRecipes",
                column: "ApprovalRecipeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductRecipes_ApprovalRecipes_ApprovalRecipeId",
                table: "ProductRecipes",
                column: "ApprovalRecipeId",
                principalTable: "ApprovalRecipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CookingPot.Data.Migrations
{
    public partial class AddApprovalRecipes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ApprovalRecipeId",
                table: "ProductRecipes",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ApprovalRecipes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    TimeToPrepare = table.Column<int>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false),
                    SubcategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApprovalRecipes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApprovalRecipes_Subcategories_SubcategoryId",
                        column: x => x.SubcategoryId,
                        principalTable: "Subcategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ApprovalRecipes_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductRecipes_ApprovalRecipeId",
                table: "ProductRecipes",
                column: "ApprovalRecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalRecipes_IsDeleted",
                table: "ApprovalRecipes",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalRecipes_SubcategoryId",
                table: "ApprovalRecipes",
                column: "SubcategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalRecipes_UserId",
                table: "ApprovalRecipes",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductRecipes_ApprovalRecipes_ApprovalRecipeId",
                table: "ProductRecipes",
                column: "ApprovalRecipeId",
                principalTable: "ApprovalRecipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductRecipes_ApprovalRecipes_ApprovalRecipeId",
                table: "ProductRecipes");

            migrationBuilder.DropTable(
                name: "ApprovalRecipes");

            migrationBuilder.DropIndex(
                name: "IX_ProductRecipes_ApprovalRecipeId",
                table: "ProductRecipes");

            migrationBuilder.DropColumn(
                name: "ApprovalRecipeId",
                table: "ProductRecipes");
        }
    }
}

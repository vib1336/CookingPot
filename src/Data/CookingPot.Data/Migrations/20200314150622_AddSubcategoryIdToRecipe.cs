namespace CookingPot.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AddSubcategoryIdToRecipe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "SubcategoryId",
                table: "Recipes",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "SubcategoryId",
                table: "Recipes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}

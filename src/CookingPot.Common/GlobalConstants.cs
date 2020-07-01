namespace CookingPot.Common
{
    public static class GlobalConstants
    {
        public const string SystemName = "CookingPot";

        public const string AdministratorRoleName = "Administrator";

        public const int RecipesPerPage = 9;

        public const string NewLine = "\r\n";

        public const string RecipePosted = "Recipe was successfully posted!";

        public const string RecipeEdited = "Recipe was successfully edited!";

        public const string RecipeDeleted = "Recipe was successfully deleted!";

        public const string RecipeReview = "Thank you! Your recipe will be reviewed by administrator.";

        public const string FiveMinuteRule = "You have to wait 5 minutes before posting a new recipe.";

        public const int FiveMinutesInSeconds = 300;

        public const int RecipeDescriptionMaxLength = 1000;

        public const int RecipeDescriptionMinLength = 10;

        public const int RecipeNameMaxLength = 100;

        public const int RecipeNameMinLength = 3;

        public const int RecipeProductsMaxLength = 400;

        public const int RecipeProductsMinLength = 10;

        public const string SaladsSubcategoryName = "All Salads";

        public const int SubcategoryMaxInputName = 50;

        public const int SubcategoryMinInputName = 3;

        public const int SubcategoryMaxInputDescription = 100;

        public const int SubcategoryMinInputDescription = 5;

        public const string MeatSoups = "Meat soups";

        public const string VegetarianSoups = "Vegetarian soups";

        public const string MeatMainCourses = "Meat main courses";

        public const string VegetarianMainCourses = "Vegetarian main courses";

        public const string Cakes = "Cakes";

        public const string FruitSalads = "Fruit salads";

        public const string NoResultsFound = "No results were found";

        // pages to show for pagination
        public const int PagesToShow = 3;
    }
}

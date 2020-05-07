namespace CookingPot.Web.ViewModels.Recipes
{
    // ?
    public class DbRecipeInputModel
    {
        public int ApprovalRecipeId { get; set; }

        public string Name { get; set; }

        public string SubcategoryId { get; set; }

        public string UserId { get; set; }

        public string Description { get; set; }

        public int TimeToPrepare { get; set; }

        public string RecipeProducts { get; set; }

        public string ImageUrl { get; set; }
    }
}

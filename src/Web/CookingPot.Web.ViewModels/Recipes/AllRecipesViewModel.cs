namespace CookingPot.Web.ViewModels.Recipes
{
    using System.Collections.Generic;

    public class AllRecipesViewModel
    {
        public IEnumerable<DisplayRecipeViewModel> AllRecipes { get; set; }
    }
}

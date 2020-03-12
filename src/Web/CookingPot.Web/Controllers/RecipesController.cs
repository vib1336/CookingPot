namespace CookingPot.Web.Controllers
{
    using CookingPot.Services.Data;
    using CookingPot.Web.ViewModels.Recipes;
    using Microsoft.AspNetCore.Mvc;

    public class RecipesController : Controller
    {
        private readonly IRecipesService recipesService;

        public RecipesController(IRecipesService recipesService)
        {
            this.recipesService = recipesService;
        }

        public IActionResult All()
        {
            var recipeViewModel = new AllRecipesViewModel();
            var recipes = this.recipesService.GetAll<DisplayRecipeViewModel>();
            recipeViewModel.AllRecipes = recipes;

            return this.View(recipeViewModel);
        }
    }
}

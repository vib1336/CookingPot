namespace CookingPot.Web.Controllers
{
    using CookingPot.Services.Data;
    using CookingPot.Web.ViewModels.Recipes;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class RecipesController : Controller
    {
        private readonly IRecipesService recipesService;

        public RecipesController(IRecipesService recipesService)
        {
            this.recipesService = recipesService;
        }

        [Authorize]
        public IActionResult Details(int id)
        {
            var detailsRecipeViewModel = this.recipesService.GetRecipe<DetailsRecipeViewModel>(id);

            if (detailsRecipeViewModel == null)
            {
                return this.RedirectToAction("Error", "Home");

                // make error view 404
            }

            detailsRecipeViewModel.ControllerName = detailsRecipeViewModel.SubcategoryId switch
            {
                1 => "Salads",
                _ => string.Empty,
            };

            return this.View(detailsRecipeViewModel);
        }
    }
}

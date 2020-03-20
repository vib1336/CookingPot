namespace CookingPot.Web.Controllers
{
    using CookingPot.Services.Data;
    using CookingPot.Web.ViewModels.Recipes;
    using CookingPot.Web.ViewModels.Categories;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class RecipesController : Controller
    {
        private readonly IRecipesService recipesService;
        private readonly ICategoryService categoryService;

        public RecipesController(IRecipesService recipesService, ICategoryService categoryService)
        {
            this.recipesService = recipesService;
            this.categoryService = categoryService;
        }

        [Authorize] // ?
        public IActionResult AddRecipe()
        {
            var categories = this.categoryService.GetCategories<CategoryDisplayModel>();
            var recipeInputModel = new RecipeInputModel();
            recipeInputModel.Categories = categories;
            return this.View(recipeInputModel);
        }

        [HttpPost] // ?
        public IActionResult AddRecipe(RecipeInputModel inputModel)
        {
            return this.View();
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

namespace CookingPot.Web.Controllers
{
    using CookingPot.Data.Models;
    using CookingPot.Services.Data;
    using CookingPot.Web.ViewModels.Categories;
    using CookingPot.Web.ViewModels.Recipes;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class RecipesController : Controller
    {
        private readonly IRecipesService recipesService;
        private readonly ICategoryService categoryService;
        private readonly UserManager<ApplicationUser> userManager;

        public RecipesController(
            IRecipesService recipesService,
            ICategoryService categoryService,
            UserManager<ApplicationUser> userManager)
        {
            this.recipesService = recipesService;
            this.categoryService = categoryService;
            this.userManager = userManager;
        }

        [Authorize] // ?
        public IActionResult AddRecipe()
        {
            var categories = this.categoryService.GetCategories<CategoryDisplayModel>();
            var recipeInputModel = new RecipeInputModel();
            recipeInputModel.Categories = categories;
            return this.View(recipeInputModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddRecipe(RecipeInputModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(inputModel);
            }

            var user = await this.userManager.GetUserAsync(this.User);

            int recipeId = await this.recipesService.AddRecipeAsync(inputModel.Name, inputModel.Description, inputModel.RecipeProducts, inputModel.ImageUrl, inputModel.SubcategoryId, user.Id);
            return this.RedirectToAction(nameof(this.Details), new { recipeId });
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

namespace CookingPot.Web.Controllers
{
    using System;
    using System.Text;
    using System.Threading.Tasks;

    using CookingPot.Data.Models;
    using CookingPot.Services.Data;
    using CookingPot.Web.ViewModels.Categories;
    using CookingPot.Web.ViewModels.Recipes;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    using static CookingPot.Common.GlobalConstants;

    [Authorize]
    public class RecipesController : Controller
    {
        private readonly IRecipesService recipesService;
        private readonly ICategoryService categoryService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IVotesService votesService;
        private readonly ICommentsService commentsService;

        public RecipesController(
            IRecipesService recipesService,
            ICategoryService categoryService,
            UserManager<ApplicationUser> userManager,
            IVotesService votesService,
            ICommentsService commentsService)
        {
            this.recipesService = recipesService;
            this.categoryService = categoryService;
            this.userManager = userManager;
            this.votesService = votesService;
            this.commentsService = commentsService;
        }

        public IActionResult AddRecipe()
        {
            var categories = this.categoryService.GetCategories<CategoryDisplayModel>();
            var recipeInputModel = new RecipeInputModel();
            recipeInputModel.Categories = categories;
            return this.View(recipeInputModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddRecipe(RecipeInputModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(inputModel);
            }

            var user = await this.userManager.GetUserAsync(this.User);

            int recipeId = await this.recipesService.AddRecipeAsync(inputModel.Name, inputModel.Description, inputModel.Image, inputModel.RecipeProducts, inputModel.SubcategoryId, user.Id);
            this.TempData["InfoMessage"] = RecipePosted;
            return this.RedirectToAction(nameof(this.Details), new { id = recipeId });
        }

        public async Task<IActionResult> Details(int id)
        {
            var user = await this.userManager.GetUserAsync(this.User);
            bool isInRole = await this.userManager.IsInRoleAsync(user, AdministratorRoleName);

            var detailsRecipeViewModel = this.recipesService.GetRecipe<DetailsRecipeViewModel>(id);

            if (detailsRecipeViewModel == null)
            {
                this.Response.StatusCode = 404;
                return this.View("RecipeNotFound", id);
            }

            detailsRecipeViewModel.CurrentUserName = user.UserName;
            detailsRecipeViewModel.CurrentUserId = user.Id;
            detailsRecipeViewModel.IsUserInRole = isInRole;
            detailsRecipeViewModel.PositiveVotes = this.votesService.CountVotes(id)[0];
            detailsRecipeViewModel.NegativeVotes = this.votesService.CountVotes(id)[1];
            detailsRecipeViewModel.RecipeComments = this.commentsService.GetRecipeComments<CommentViewModel>(id);
            return this.View(detailsRecipeViewModel);
        }

        public IActionResult EditRecipe(int id)
        {
            var editRecipeViewModel = this.recipesService.GetRecipe<EditRecipeViewModel>(id);

            if (editRecipeViewModel == null)
            {
                this.Response.StatusCode = 404;
                return this.View("RecipeNotFound", id);
            }

            var products = new StringBuilder();

            foreach (var product in editRecipeViewModel.RecipeProducts)
            {
                products.AppendLine(product.Name);
            }

            editRecipeViewModel.ProductsForViewModel = products.ToString();

            return this.View(editRecipeViewModel);
        }

        public async Task<IActionResult> UpdateRecipe(EditRecipeViewModel editModel)
        {
            var isRecipeExistent = this.recipesService.RecipeExists(editModel.Id);
            if (!isRecipeExistent)
            {
                this.BadRequest(); // ?
            }

            if (!this.ModelState.IsValid)
            {
                return this.View("EditRecipe", editModel);
            }

            await this.recipesService.UpdateRecipeAsync(editModel.Id, editModel.Name, editModel.Description, editModel.ProductsForViewModel);
            this.TempData["InfoMessage"] = RecipeEdited;
            return this.RedirectToAction(nameof(this.Details), new { id = editModel.Id });
        }

        [Authorize(Roles = AdministratorRoleName)]
        public IActionResult AreYouSureDelete(int id)
        {
            return this.View(id);
        }

        [Authorize(Roles = AdministratorRoleName)]
        public IActionResult Delete(int id)
        {
            this.recipesService.DeleteRecipe(id);
            return this.RedirectToAction("Index", "Home");
        }
    }
}

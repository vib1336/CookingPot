namespace CookingPot.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using CookingPot.Services.Data;
    using CookingPot.Web.ViewModels.Administration.Dashboard;
    using CookingPot.Web.ViewModels.ApprovalRecipes;
    using CookingPot.Web.ViewModels.Recipes;
    using Microsoft.AspNetCore.Mvc;

    using static CookingPot.Common.GlobalConstants;

    public class DashboardController : AdministrationController
    {
        private readonly IRecipesService recipesService;

        public DashboardController(IRecipesService recipesService)
        {
            this.recipesService = recipesService;
        }

        public IActionResult Index()
        {
            var viewModel = new IndexViewModel
            {
                ApprovalRecipes = new List<ApprovalRecipeReturnModel>(),
            };

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> GetApprovalRecipes(ApprovalRecipeInputModel inputModel)
        {
            var parsedBool = bool.Parse(inputModel.IsDeleted);

            var approvalRecipes = await this.recipesService.GetApprovalRecipesAsync<ApprovalRecipeReturnModel>(parsedBool);

            var viewModel = new IndexViewModel
            {
                ApprovalRecipes = approvalRecipes,
            };
            return this.View("Index", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddRecipe(DbRecipeInputModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(inputModel);
            }

            var subcategoryInfo = inputModel.SubcategoryId.Split(new[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
            int subcategoryId = int.Parse(subcategoryInfo[0]);

            var recipeId = await this.recipesService.AddRecipeAsync(inputModel.Name, inputModel.Description, inputModel.TimeToPrepare, inputModel.ImageUrl, inputModel.RecipeProducts, subcategoryId, inputModel.UserId);
            await this.recipesService.SetIsApprovedRecipe(inputModel.ApprovalRecipeId);

            this.TempData["InfoMessage"] = RecipePosted;
            return this.Redirect($"https://localhost:44319/Recipes/Details/{recipeId}");
        }
    }
}

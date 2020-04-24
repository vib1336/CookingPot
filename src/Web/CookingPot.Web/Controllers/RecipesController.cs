namespace CookingPot.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;

    using CookingPot.Data.Models;
    using CookingPot.Services.Data;
    using CookingPot.Web.ViewModels.Categories;
    using CookingPot.Web.ViewModels.Recipes;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Newtonsoft.Json;

    using static CookingPot.Common.GlobalConstants;

    [Authorize]
    public class RecipesController : Controller
    {
        private readonly IRecipesService recipesService;
        private readonly ICategoryService categoryService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IVotesService votesService;
        private readonly ICommentsService commentsService;
        private IConfiguration configuration;

        public RecipesController(
            IRecipesService recipesService,
            ICategoryService categoryService,
            UserManager<ApplicationUser> userManager,
            IVotesService votesService,
            ICommentsService commentsService,
            IConfiguration configuration)
        {
            this.recipesService = recipesService;
            this.categoryService = categoryService;
            this.userManager = userManager;
            this.votesService = votesService;
            this.commentsService = commentsService;
            this.configuration = configuration;
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

            // Recaptcha
            var isCaptchaValid = this.IsCaptchaValid(inputModel.RecaptchaValue);
            if (!isCaptchaValid)
            {
                return this.View(inputModel);
            }

            var user = await this.userManager.GetUserAsync(this.User);

            var recipeId = await this.recipesService.AddRecipeAsync(inputModel.Name, inputModel.Description, inputModel.TimeToPrepare, inputModel.Image, inputModel.RecipeProducts, inputModel.SubcategoryId, user.Id);
            this.TempData["InfoMessage"] = RecipePosted;
            return this.RedirectToAction(nameof(this.Details), new { id = recipeId });
        }

        public async Task<IActionResult> Details(int id)
        {
            var user = await this.userManager.GetUserAsync(this.User);
            var isInRole = await this.userManager.IsInRoleAsync(user, AdministratorRoleName);

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
            var userId = this.userManager.GetUserId(this.User);
            var editRecipeViewModel = this.recipesService.GetRecipe<EditRecipeViewModel>(id);

            if (editRecipeViewModel == null)
            {
                this.Response.StatusCode = 404;
                return this.View("RecipeNotFound", id);
            }

            if (userId != editRecipeViewModel.UserId && !this.User.IsInRole(AdministratorRoleName))
            {
                return this.RedirectToAction(nameof(this.Details), new { id });
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
                return this.View("EditRecipe", editModel);
            }

            if (!this.ModelState.IsValid)
            {
                return this.View("EditRecipe", editModel);
            }

            await this.recipesService.UpdateRecipeAsync(editModel.Id, editModel.Name, editModel.Description, editModel.TimeToPrepare, editModel.ProductsForViewModel);
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
            this.TempData["InfoMessage"] = RecipeDeleted;
            return this.RedirectToAction("Index", "Home");
        }

        private bool IsCaptchaValid(string response)
        {
            try
            {
                var secret = this.configuration["GoogleReCaptcha:SecretKey"];
                using var client = new HttpClient();

                var values = new Dictionary<string, string>
                {
                    { "secret", secret },
                    { "response", response },
                    { "remoteip", this.HttpContext.Connection.RemoteIpAddress.ToString() },
                };
                var content = new FormUrlEncodedContent(values);
                var httpResponse = client.PostAsync("https://www.google.com/recaptcha/api/siteverify", content).GetAwaiter().GetResult();
                var captchaResponseJson = httpResponse.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                var captchaResult = JsonConvert.DeserializeObject<CaptchaResponseViewModel>(captchaResponseJson);

                return captchaResult.Success
                    && captchaResult.Action == "addrecipe_form"
                    && captchaResult.Score > 0.5;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}

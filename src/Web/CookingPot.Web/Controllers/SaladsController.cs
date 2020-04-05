namespace CookingPot.Web.Controllers
{
    using CookingPot.Services.Data;
    using CookingPot.Web.ViewModels.Salads;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using static CookingPot.Common.GlobalConstants;

    public class SaladsController : Controller
    {
        private readonly ISubcategoriesService subcategoriesService;
        private readonly IRecipesService recipesService;

        public SaladsController(ISubcategoriesService subcategoriesService, IRecipesService recipesService)
        {
            this.subcategoriesService = subcategoriesService;
            this.recipesService = recipesService;
        }

        public IActionResult Subcategories()
        {
            var saladsSubcategoryViewModel = this.subcategoriesService
                .GetSubcategory<SaladsSubcategoryViewModel>(SaladsSubcategoryName);

            return this.View(saladsSubcategoryViewModel);
        }

        [Authorize]
        public IActionResult All(int page = 1)
        {
            var allSaladsViewModel = new AllSaladsViewModel
            {
                AllSalads = this.recipesService.GetRecipes<DisplaySaladSubcategoryViewModel>(1, page),
                Total = this.recipesService.GetTotalRecipesFromSubcategory(1),
                CurrentPage = page,
            };
            return this.View(allSaladsViewModel);
        }
    }
}

namespace CookingPot.Web.Controllers
{
    using CookingPot.Services.Data;
    using CookingPot.Web.ViewModels.Soups;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using static CookingPot.Common.GlobalConstants;

    public class SoupsController : Controller
    {
        private readonly ISubcategoriesService subcategoriesService;
        private readonly IRecipesService recipesService;

        public SoupsController(ISubcategoriesService subcategoriesService, IRecipesService recipesService)
        {
            this.subcategoriesService = subcategoriesService;
            this.recipesService = recipesService;
        }

        public IActionResult Subcategories()
        {
            var allSoupsSubcategoryViewModel = new AllSoupsSubcategoryViewModel
            {
                MeatSoups = this.subcategoriesService.GetSubcategory<MeatSoupsSubcategoryViewModel>(MeatSoups),
                VegetarianSoups = this.subcategoriesService.GetSubcategory<VegetarianSoupsSubcategoryViewModel>(VegetarianSoups),
            };

            return this.View(allSoupsSubcategoryViewModel);
        }

        [Authorize]
        public IActionResult AllMeatSoups(int page = 1)
        {
            int subcategoryId = this.subcategoriesService.GetSubcategoryId(MeatSoups);

            var allMeatSoups = new AllMeatSoupsViewModel
            {
                AllMeatSoups = this.recipesService.GetRecipes<MeatSoupsViewModel>(subcategoryId, page),
                Total = this.recipesService.GetTotalRecipesFromSubcategory(subcategoryId),
                CurrentPage = page,
            };

            return this.View(allMeatSoups);
        }

        [Authorize]
        public IActionResult AllVegetarianSoups(int page = 1)
        {
            int subcategoryId = this.subcategoriesService.GetSubcategoryId(VegetarianSoups);

            var allVegetarianSoups = new AllVegetarianSoupsViewModel
            {
                AllVegetarianSoups = this.recipesService.GetRecipes<VegetarianSoupsViewModel>(subcategoryId, page),
                Total = this.recipesService.GetTotalRecipesFromSubcategory(subcategoryId),
                CurrentPage = page,
            };

            return this.View(allVegetarianSoups);
        }
    }
}

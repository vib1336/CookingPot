namespace CookingPot.Web.Controllers
{
    using System;

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

            int totalRecipes = this.recipesService.GetTotalRecipesFromSubcategory(subcategoryId);
            double maxPage = Math.Ceiling(((double)totalRecipes) / RecipesPerPage);
            if (maxPage == 0)
            {
                return this.View("EmptySubcategory");
            }

            if (page > maxPage)
            {
                this.Response.StatusCode = 404;
                return this.View("InvalidPage");
            }

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

            int totalRecipes = this.recipesService.GetTotalRecipesFromSubcategory(subcategoryId);
            double maxPage = Math.Ceiling(((double)totalRecipes) / RecipesPerPage);
            if (maxPage == 0)
            {
                return this.View("EmptySubcategory");
            }

            if (page > maxPage)
            {
                this.Response.StatusCode = 404;
                return this.View("InvalidPage");
            }

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

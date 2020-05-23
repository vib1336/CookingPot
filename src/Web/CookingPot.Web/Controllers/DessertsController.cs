namespace CookingPot.Web.Controllers
{
    using System;

    using CookingPot.Services.Data;
    using CookingPot.Web.ViewModels.Desserts;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using static CookingPot.Common.GlobalConstants;

    public class DessertsController : Controller
    {
        private readonly ISubcategoriesService subcategoriesService;
        private readonly IRecipesService recipesService;

        public DessertsController(ISubcategoriesService subcategoriesService, IRecipesService recipesService)
        {
            this.subcategoriesService = subcategoriesService;
            this.recipesService = recipesService;
        }

        public IActionResult Subcategories()
        {
            var dessertsSubcategoryViewModel = new DessertsSubcategoryViewModel
            {
                Cakes = this.subcategoriesService.GetSubcategory<CakesSubcategoryViewModel>(Cakes),
                FruitSalads = this.subcategoriesService.GetSubcategory<FruitSaladsSubcategoryViewModel>(FruitSalads),
            };

            return this.View(dessertsSubcategoryViewModel);
        }

        [Authorize]
        public IActionResult AllCakes(int page = 1)
        {
            int subcategoryId = this.subcategoriesService.GetSubcategoryId(Cakes);

            int totalRecipes = this.recipesService.GetTotalRecipesFromSubcategory(subcategoryId);
            double maxPage = Math.Ceiling(((double)totalRecipes) / RecipesPerPage);
            if (maxPage == 0)
            {
                return this.View("EmptySubcategory");
            }

            if (page > maxPage)
            {
                return this.View("InvalidPage");
            }

            var allCakes = new AllCakesViewModel
            {
                AllCakes = this.recipesService.GetRecipes<CakesViewModel>(subcategoryId, page),
                Total = this.recipesService.GetTotalRecipesFromSubcategory(subcategoryId),
                CurrentPage = page,
            };

            return this.View(allCakes);
        }

        [Authorize]
        public IActionResult AllFruitSalads(int page = 1)
        {
            int subcategoryId = this.subcategoriesService.GetSubcategoryId(FruitSalads);

            int totalRecipes = this.recipesService.GetTotalRecipesFromSubcategory(subcategoryId);
            double maxPage = Math.Ceiling(((double)totalRecipes) / RecipesPerPage);
            if (maxPage == 0)
            {
                return this.View("EmptySubcategory");
            }

            if (page > maxPage)
            {
                return this.View("InvalidPage");
            }

            var allFruitSalads = new AllFruitSaladsViewModel
            {
                AllFruitSalads = this.recipesService.GetRecipes<FruitSaladsViewModel>(subcategoryId, page),
                Total = this.recipesService.GetTotalRecipesFromSubcategory(subcategoryId),
                CurrentPage = page,
            };

            return this.View(allFruitSalads);
        }
    }
}

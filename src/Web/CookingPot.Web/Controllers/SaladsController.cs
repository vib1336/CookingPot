namespace CookingPot.Web.Controllers
{
    using System;

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
            if (page <= 0)
            {
                page = 1;
            }

            int subcategoryId = this.subcategoriesService.GetSubcategoryId(SaladsSubcategoryName);

            int totalRecipes = this.recipesService.GetTotalRecipesFromSubcategory(subcategoryId);
            int maxPage = (int)Math.Ceiling(((double)totalRecipes) / RecipesPerPage);
            if (maxPage == 0)
            {
                return this.View("EmptySubcategory");
            }

            if (page > maxPage)
            {
                this.Response.StatusCode = 404;
                return this.View("InvalidPage");
            }

            var allSaladsViewModel = new AllSaladsViewModel
            {
                AllSalads = this.recipesService.GetRecipes<DisplaySaladSubcategoryViewModel>(subcategoryId, page),
                Total = this.recipesService.GetTotalRecipesFromSubcategory(subcategoryId),
                CurrentPage = page,
                MaxPage = maxPage,
            };
            return this.View(allSaladsViewModel);
        }
    }
}

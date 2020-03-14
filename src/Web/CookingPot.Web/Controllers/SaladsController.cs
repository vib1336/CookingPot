namespace CookingPot.Web.Controllers
{
    using CookingPot.Services.Data;
    using CookingPot.Web.ViewModels.Salads;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using System.Collections.Generic;

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
                .GetSubcategory<SaladsSubcategoryViewModel>("Salads");

            return this.View(saladsSubcategoryViewModel);
        }

        [Authorize]
        public IActionResult All()
        {
            var saladsSubcategoryViewModel = this.recipesService.GetRecipes<DisplaySaladSubcategoryViewModel>(1);

            return this.View(saladsSubcategoryViewModel);
        }
    }
}

namespace CookingPot.Web.Controllers
{
    using CookingPot.Services.Data;
    using CookingPot.Web.ViewModels.Salads;
    using Microsoft.AspNetCore.Mvc;

    using System.Collections.Generic;

    public class SaladsController : Controller
    {
        private readonly ISubcategoriesService subcategoriesService;

        public SaladsController(ISubcategoriesService subcategoriesService)
        {
            this.subcategoriesService = subcategoriesService;
        }

        public IActionResult All()
        {
            var saladSubcategoryViewModel = new SaladsSubcategoryViewModel();

            var subcategories = this.subcategoriesService.GetAll<DisplaySaladSubcategoryViewModel>();

            saladSubcategoryViewModel.Subcategories = subcategories;

            return this.View(saladSubcategoryViewModel);
        }
    }
}

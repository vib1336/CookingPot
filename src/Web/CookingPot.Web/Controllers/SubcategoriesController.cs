namespace CookingPot.Web.Controllers
{
    using System.Threading.Tasks;

    using CookingPot.Services.Data;
    using CookingPot.Web.ViewModels.Subcategories;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using static CookingPot.Common.GlobalConstants;

    [Authorize(Roles = AdministratorRoleName)]
    public class SubcategoriesController : Controller
    {
        private readonly ICategoryService categoryService;
        private readonly ISubcategoriesService subcategoriesService;

        public SubcategoriesController(ICategoryService categoryService, ISubcategoriesService subcategoriesService)
        {
            this.categoryService = categoryService;
            this.subcategoriesService = subcategoriesService;
        }

        public IActionResult AddSubcategory()
        {
            var subcategoryInputModel = new SubcategoryInputModel();
            subcategoryInputModel.Categories = this.categoryService.GetCategories<GetCategoriesViewModel>();

            return this.View(subcategoryInputModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddSubcategory(SubcategoryInputModel subcategoryInputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(subcategoryInputModel);
            }

            await this.subcategoriesService.AddSubcategoryAsync(
                subcategoryInputModel.Name,
                subcategoryInputModel.Description,
                subcategoryInputModel.Image,
                subcategoryInputModel.CategoryId);

            return this.RedirectToAction("Index", "Home");
        }
    }
}

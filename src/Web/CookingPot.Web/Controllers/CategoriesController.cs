namespace CookingPot.Web.Controllers
{
    using System.Threading.Tasks;

    using CookingPot.Services.Data;
    using CookingPot.Web.ViewModels.Categories;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using static CookingPot.Common.GlobalConstants;

    [Authorize(Roles = AdministratorRoleName)]
    public class CategoriesController : Controller
    {
        private readonly ICategoryService categoryService;

        public CategoriesController(ICategoryService categoryService)
            => this.categoryService = categoryService;

        public IActionResult AddCategory()
        {
            var categoryInputModel = new CategoryInputModel();

            return this.View(categoryInputModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(CategoryInputModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(inputModel);
            }

            await this.categoryService.AddCategoryAsync(inputModel.Name);
            return this.RedirectToAction("Index", "Home");
        }
    }
}

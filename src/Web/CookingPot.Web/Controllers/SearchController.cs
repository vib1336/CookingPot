namespace CookingPot.Web.Controllers
{
    using System.Collections.Generic;

    using CookingPot.Services.Data;
    using CookingPot.Web.ViewModels.Search;
    using Microsoft.AspNetCore.Mvc;

    public class SearchController : Controller
    {
        private readonly ISearchService searchService;

        public SearchController(ISearchService searchService)
            => this.searchService = searchService;

        public IActionResult SearchRecipe(string searchValue)
        {
            var vm = new SearchInputModel();
            vm.FoundRecipes = new List<DisplaySearchRecipeViewModel>();

            if (!string.IsNullOrWhiteSpace(searchValue))
            {
                vm.FoundRecipes = this.searchService.Search<DisplaySearchRecipeViewModel>(searchValue);
                return this.View(vm);
            }

            return this.View(vm);
        }
    }
}

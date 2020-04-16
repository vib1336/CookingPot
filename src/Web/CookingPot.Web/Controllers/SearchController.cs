namespace CookingPot.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;

    using CookingPot.Services.Data;
    using CookingPot.Web.ViewModels.Search;
    using Microsoft.AspNetCore.Mvc;

    using static CookingPot.Common.GlobalConstants;

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
                if (vm.FoundRecipes.Count() == 0)
                {
                    this.TempData["InfoMessage"] = NoResultsFound;
                }

                return this.View(vm);
            }

            return this.View(vm);
        }
    }
}

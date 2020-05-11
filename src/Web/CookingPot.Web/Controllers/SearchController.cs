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
            var viewModel = new SearchInputModel();
            viewModel.FoundRecipes = new List<DisplaySearchRecipeViewModel>();

            if (!string.IsNullOrWhiteSpace(searchValue))
            {
                viewModel.FoundRecipes = this.searchService.Search<DisplaySearchRecipeViewModel>(searchValue);
                if (viewModel.FoundRecipes.Count() == 0)
                {
                    this.TempData["InfoMessage"] = NoResultsFound;
                }

                return this.View(viewModel);
            }

            return this.View(viewModel);
        }
    }
}

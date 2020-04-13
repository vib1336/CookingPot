namespace CookingPot.Web.Controllers
{
    using CookingPot.Services.Data;
    using CookingPot.Web.ViewModels.Search;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;

    public class SearchController : Controller
    {
        private readonly ISearchService searchService;

        public SearchController(ISearchService searchService)
        {
            this.searchService = searchService;
        }

        public IActionResult SearchRecipe()
        {
            var searchViewModel = new SearchInputModel();
            searchViewModel.FoundRecipes = new List<DisplaySearchRecipeViewModel>();
            return this.View(searchViewModel);
        }

        [HttpPost]
        public IActionResult SearchRecipe(SearchInputModel inputModel)
        {
            var searchViewModel = new SearchInputModel();
            searchViewModel.FoundRecipes = this.searchService.Search<DisplaySearchRecipeViewModel>(inputModel.SearchValue);

            return this.View(searchViewModel);
        }
    }
}

namespace CookingPot.Web.ViewModels.Search
{
    using System.Collections.Generic;

    public class SearchInputModel
    {
        public IEnumerable<DisplaySearchRecipeViewModel> FoundRecipes { get; set; }
    }
}

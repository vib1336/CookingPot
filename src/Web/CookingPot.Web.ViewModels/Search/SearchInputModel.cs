namespace CookingPot.Web.ViewModels.Search
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Mvc;

    public class SearchInputModel
    {
        [BindProperty(SupportsGet = true)]
        [Display(Name = "Search")]
        public string SearchValue { get; set; }

        public IEnumerable<DisplaySearchRecipeViewModel> FoundRecipes { get; set; }
    }
}

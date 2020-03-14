namespace CookingPot.Web.ViewModels.Recipes
{
    using System;

    using CookingPot.Data.Models;
    using CookingPot.Services.Mapping;

    public class DetailsRecipeViewModel : IMapFrom<Recipe>
    {
        public DateTime CreatedOn { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public string UserUserName { get; set; }

    }
}

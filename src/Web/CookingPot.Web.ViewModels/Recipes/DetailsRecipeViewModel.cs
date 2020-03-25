namespace CookingPot.Web.ViewModels.Recipes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;
    using CookingPot.Data.Models;
    using CookingPot.Services.Mapping;

    public class DetailsRecipeViewModel : IMapFrom<Recipe>
    {
        public int Id { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public string UserUserName { get; set; }

        public string UserId { get; set; } // not sure?

        public string CurrentUserId { get; set; } // not sure?

        public int SubcategoryId { get; set; }

        public string ControllerName { get; set; }

        public IEnumerable<ProductViewModel> RecipeProducts { get; set; }
    }
}

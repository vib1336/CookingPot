namespace CookingPot.Web.ViewModels.Recipes
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using CookingPot.Web.ViewModels.Categories;

    public class RecipeInputModel
    {
        [Required]
        [StringLength(100, MinimumLength = 3)]
        [Display(Name = "Recipe name")]
        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        [Required]
        [StringLength(400, MinimumLength = 10)]
        [Display(Name = "Products needed")]
        public string RecipeProducts { get; set; }

        public IEnumerable<CategoryDisplayModel> Categories { get; set; } // ?
    }
}

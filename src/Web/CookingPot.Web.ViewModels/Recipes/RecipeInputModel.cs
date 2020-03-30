namespace CookingPot.Web.ViewModels.Recipes
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using CookingPot.Web.ViewModels.Categories;
    using Microsoft.AspNetCore.Http;

    public class RecipeInputModel
    {
        [Required]
        [StringLength(100, MinimumLength = 3)]
        [Display(Name = "Recipe name")]
        public string Name { get; set; }

        public int SubcategoryId { get; set; }

        [Required]
        [StringLength(1000, MinimumLength = 10)]
        public string Description { get; set; }

        public IFormFile Image { get; set; }

        [Required]
        [StringLength(400, MinimumLength = 10)]
        [Display(Name = "Products needed")]
        public string RecipeProducts { get; set; }

        public IEnumerable<CategoryDisplayModel> Categories { get; set; } // ?
    }
}

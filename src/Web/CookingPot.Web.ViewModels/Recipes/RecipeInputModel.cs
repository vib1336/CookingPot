namespace CookingPot.Web.ViewModels.Recipes
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using CookingPot.Web.ViewModels.Categories;
    using Microsoft.AspNetCore.Http;

    using static CookingPot.Common.GlobalConstants;

    public class RecipeInputModel
    {
        [Required]
        [StringLength(RecipeNameMaxLength, MinimumLength = RecipeNameMinLength)]
        [Display(Name = "Recipe name")]
        public string Name { get; set; }

        public int SubcategoryId { get; set; }

        [Required]
        [StringLength(RecipeDescriptionMaxLength, MinimumLength = RecipeDescriptionMinLength)]
        public string Description { get; set; }

        public IFormFile Image { get; set; }

        [Required]
        [StringLength(RecipeProductsMaxLength, MinimumLength = RecipeProductsMinLength)]
        [Display(Name = "Products needed")]
        public string RecipeProducts { get; set; }

        public IEnumerable<CategoryDisplayModel> Categories { get; set; } // ?
    }
}

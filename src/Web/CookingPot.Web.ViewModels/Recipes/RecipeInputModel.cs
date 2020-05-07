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
        public string Name { get; set; }

        public int SubcategoryId { get; set; }

        [Required]
        [StringLength(RecipeDescriptionMaxLength, MinimumLength = RecipeDescriptionMinLength)]
        public string Description { get; set; }

        [Range(1, 600)]
        public int TimeToPrepare { get; set; }

        public IFormFile Image { get; set; }

        [Required]
        [StringLength(RecipeProductsMaxLength, MinimumLength = RecipeProductsMinLength)]
        public string RecipeProducts { get; set; }

        public string RecaptchaValue { get; set; }

        public IEnumerable<CategoryDisplayModel> Categories { get; set; }
    }
}

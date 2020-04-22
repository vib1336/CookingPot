namespace CookingPot.Web.ViewModels.Recipes
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using CookingPot.Data.Models;
    using CookingPot.Services.Mapping;

    using static CookingPot.Common.GlobalConstants;

    public class EditRecipeViewModel : IMapFrom<Recipe>
    {
        public int Id { get; set; }

        [Required]
        [StringLength(RecipeNameMaxLength, MinimumLength = RecipeNameMinLength)]
        [Display(Name = "Recipe name")]
        public string Name { get; set; }

        [Required]
        [StringLength(RecipeDescriptionMaxLength, MinimumLength = RecipeDescriptionMinLength)]
        public string Description { get; set; }

        [Range(1, 600)]
        [Display(Name = "Time to prepare (mins)")]
        public int TimeToPrepare { get; set; }

        [Required]
        [StringLength(RecipeProductsMaxLength, MinimumLength = RecipeProductsMinLength)]
        [Display(Name = "Products needed")]
        public string ProductsForViewModel { get; set; }

        public string UserId { get; set; }

        public IEnumerable<ProductViewModel> RecipeProducts { get; set; }
    }
}

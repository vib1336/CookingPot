namespace CookingPot.Web.ViewModels.Recipes
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using CookingPot.Data.Models;
    using CookingPot.Services.Mapping;

    public class EditRecipeViewModel : IMapFrom<Recipe>
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        [Display(Name = "Recipe name")]
        public string Name { get; set; }

        [Required]
        [StringLength(400, MinimumLength = 10)]
        public string Description { get; set; }

        [Required]
        [StringLength(400, MinimumLength = 10)]
        [Display(Name = "Products needed")]
        public string ProductsForViewModel { get; set; }

        public IEnumerable<ProductViewModel> RecipeProducts { get; set; }
    }
}

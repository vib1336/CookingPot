namespace CookingPot.Web.ViewModels.ApprovalRecipes
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using CookingPot.Data.Models;
    using CookingPot.Services.Mapping;
    using CookingPot.Web.ViewModels.Recipes;

    using static CookingPot.Common.GlobalConstants;

    public class ApprovalRecipeReturnModel : IMapFrom<ApprovalRecipe>
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
        [StringLength(300, MinimumLength = 30)]
        [Display(Name = "Image URL")]
        public string ImageUrl { get; set; }

        public string UserId { get; set; }

        public int SubcategoryId { get; set; }

        public string SubcategoryName { get; set; }

        [Required]
        [StringLength(RecipeProductsMaxLength, MinimumLength = RecipeProductsMinLength)]
        [Display(Name = "Products needed")]
        public string RecipeProducts { get; set; }
    }
}

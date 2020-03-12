namespace CookingPot.Data.Models
{
    using System.Collections.Generic;

    using CookingPot.Data.Common.Models;

    public class Recipe : BaseDeletableModel<int>
    {
        public Recipe()
        {
            this.RecipeProducts = new HashSet<ProductRecipe>();
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<ProductRecipe> RecipeProducts { get; set; }
    }
}

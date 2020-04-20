namespace CookingPot.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using CookingPot.Data.Common.Models;

    public class Recipe : BaseDeletableModel<int>
    {
        public Recipe()
        {
            this.RecipeProducts = new HashSet<ProductRecipe>();
            this.Votes = new HashSet<Vote>();
            this.Comments = new HashSet<Comment>();
        }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public int TimeToPrepare { get; set; }

        public string ImageUrl { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public int SubcategoryId { get; set; }

        public virtual Subcategory Subcategory { get; set; }

        public virtual ICollection<ProductRecipe> RecipeProducts { get; set; }

        public virtual ICollection<Vote> Votes { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}

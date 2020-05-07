namespace CookingPot.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using CookingPot.Data.Common.Models;

    public class ApprovalRecipe : BaseDeletableModel<int>
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public int TimeToPrepare { get; set; }

        public string RecipeProducts { get; set; }

        public string ImageUrl { get; set; }

        public bool IsApproved { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public int SubcategoryId { get; set; }

        public virtual Subcategory Subcategory { get; set; }
    }
}

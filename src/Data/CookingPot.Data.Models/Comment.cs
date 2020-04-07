namespace CookingPot.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using CookingPot.Data.Common.Models;

    public class Comment : BaseDeletableModel<int>
    {
        [Required]
        [StringLength(400, MinimumLength = 5)]
        public string Content { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public int RecipeId { get; set; }

        public virtual Recipe Recipe { get; set; }
    }
}

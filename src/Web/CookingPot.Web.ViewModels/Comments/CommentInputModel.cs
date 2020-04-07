using System.ComponentModel.DataAnnotations;

namespace CookingPot.Web.ViewModels.Comments
{
    public class CommentInputModel
    {
        public int RecipeId { get; set; }

        [Required]
        public string CurrentUserId { get; set; }

        [Required]
        [StringLength(400, MinimumLength = 5)]
        public string Comment { get; set; }
    }
}

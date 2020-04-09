namespace CookingPot.Web.ViewModels.Categories
{
    using System.ComponentModel.DataAnnotations;

    public class CategoryInputModel
    {
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }
    }
}

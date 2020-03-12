namespace CookingPot.Web.ViewModels.Recipes
{
    using CookingPot.Data.Models;
    using CookingPot.Services.Mapping;

    public class DisplayRecipeViewModel : IMapFrom<Recipe>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public string ShortDescription
            => this.Description.Length > 10 ? this.Description.Substring(0, 10) + "..." : this.Description;
    }
}

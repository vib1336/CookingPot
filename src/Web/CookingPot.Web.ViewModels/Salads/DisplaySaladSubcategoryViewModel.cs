namespace CookingPot.Web.ViewModels.Salads
{
    using CookingPot.Data.Models;
    using CookingPot.Services.Mapping;

    public class DisplaySaladSubcategoryViewModel : IMapFrom<Recipe>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public string ShortDescription
            => this.Description.Length > 20 ? this.Description.Substring(0, 20) + "..." : this.Description;
    }
}

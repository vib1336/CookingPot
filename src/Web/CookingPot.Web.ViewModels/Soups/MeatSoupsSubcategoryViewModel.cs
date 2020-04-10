namespace CookingPot.Web.ViewModels.Soups
{
    using CookingPot.Data.Models;
    using CookingPot.Services.Mapping;

    public class MeatSoupsSubcategoryViewModel : IMapFrom<Subcategory>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }
    }
}

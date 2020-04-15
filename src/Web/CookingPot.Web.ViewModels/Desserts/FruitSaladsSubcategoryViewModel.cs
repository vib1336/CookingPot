namespace CookingPot.Web.ViewModels.Desserts
{
    using CookingPot.Data.Models;
    using CookingPot.Services.Mapping;

    public class FruitSaladsSubcategoryViewModel : IMapFrom<Subcategory>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }
    }
}

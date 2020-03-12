namespace CookingPot.Web.ViewModels.Salads
{
    using CookingPot.Data.Models;
    using CookingPot.Services.Mapping;

    public class DisplaySaladSubcategoryViewModel : IMapFrom<Subcategory>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }
    }
}

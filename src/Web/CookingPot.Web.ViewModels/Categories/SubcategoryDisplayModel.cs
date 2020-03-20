namespace CookingPot.Web.ViewModels.Categories
{
    using CookingPot.Data.Models;
    using CookingPot.Services.Mapping;

    public class SubcategoryDisplayModel : IMapFrom<Subcategory>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}

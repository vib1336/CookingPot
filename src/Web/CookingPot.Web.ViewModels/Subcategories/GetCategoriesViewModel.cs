namespace CookingPot.Web.ViewModels.Subcategories
{
    using CookingPot.Data.Models;
    using CookingPot.Services.Mapping;

    public class GetCategoriesViewModel : IMapFrom<Category>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}

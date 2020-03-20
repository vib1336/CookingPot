namespace CookingPot.Web.ViewModels.Categories
{
    using CookingPot.Data.Models;
    using CookingPot.Services.Mapping;
    using System.Collections.Generic;

    public class CategoryDisplayModel : IMapFrom<Category>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<SubcategoryDisplayModel> Subcategories { get; set; }
    }
}

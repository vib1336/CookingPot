namespace CookingPot.Web.ViewModels.Categories
{
    using System.Collections.Generic;

    using CookingPot.Data.Models;
    using CookingPot.Services.Mapping;

    public class CategoryDisplayModel : IMapFrom<Category>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<SubcategoryDisplayModel> Subcategories { get; set; }
    }
}

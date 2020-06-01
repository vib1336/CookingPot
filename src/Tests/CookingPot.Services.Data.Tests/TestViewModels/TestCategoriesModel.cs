namespace CookingPot.Services.Data.Tests.TestViewModels
{
    using CookingPot.Data.Models;
    using CookingPot.Services.Mapping;

    public class TestCategoriesModel : IMapFrom<Category>
    {
        public string Name { get; set; }
    }
}

namespace CookingPot.Services.Data.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using CookingPot.Data;
    using CookingPot.Data.Models;
    using CookingPot.Data.Repositories;
    using CookingPot.Services.Data.Tests.TestViewModels;
    using CookingPot.Services.Mapping;
    using Microsoft.EntityFrameworkCore;
    using Xunit;

    public class CategoriesServiceTests
    {
        [Fact]
        public async Task TestIfServiceAddCategory()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("CookingPot");
            var categoriesRepository = new EfRepository<Category>(new ApplicationDbContext(options.Options));

            var service = new CategoryService(categoriesRepository);
            await service.AddCategoryAsync("firstCategory");
            await service.AddCategoryAsync("secondCategory");

            AutoMapperConfig.RegisterMappings(this.GetType().Assembly);

            var categories = service.GetCategories<TestCategoriesModel>() as List<TestCategoriesModel>;
            Assert.Equal(2, categories.Count());
            Assert.Equal("firstCategory", categories[0].Name);
            Assert.Equal("secondCategory", categories[1].Name);
        }
    }
}

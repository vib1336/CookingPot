namespace CookingPot.Services.Data.Tests
{
    using System.Linq;
    using System.Threading.Tasks;

    using CookingPot.Data;
    using CookingPot.Data.Models;
    using CookingPot.Data.Repositories;
    using CookingPot.Web.ViewModels.Categories;
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
            await service.AddCategoryAsync("example");
            await service.AddCategoryAsync("secondExample");
            var count = service.GetCountCategories();

            Assert.Equal(2, count);
        }
    }
}

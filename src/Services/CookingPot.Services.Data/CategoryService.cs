namespace CookingPot.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using CookingPot.Data.Common.Repositories;
    using CookingPot.Data.Models;
    using CookingPot.Services.Mapping;

    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> categoriesRepository;

        public CategoryService(IRepository<Category> categoriesRepository)
            => this.categoriesRepository = categoriesRepository;

        public async Task AddCategoryAsync(string name)
        {
            Category category = new Category { Name = name };
            await this.categoriesRepository.AddAsync(category);
            await this.categoriesRepository.SaveChangesAsync();
        }

        public IEnumerable<T> GetCategories<T>()
            => this.categoriesRepository.All().To<T>().ToList();

        // Test purposes
        public int GetCountCategories() => this.categoriesRepository.All().Count();

    }
}

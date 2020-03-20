namespace CookingPot.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using CookingPot.Data.Common.Repositories;
    using CookingPot.Data.Models;
    using CookingPot.Services.Mapping;

    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> categoriesRepository;

        public CategoryService(IRepository<Category> categoriesRepository)
        {
            this.categoriesRepository = categoriesRepository;
        }

        public IEnumerable<T> GetCategories<T>()
            => this.categoriesRepository.All().To<T>().ToList();
    }
}

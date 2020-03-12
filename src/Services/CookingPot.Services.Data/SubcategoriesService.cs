namespace CookingPot.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using CookingPot.Data.Common.Repositories;
    using CookingPot.Data.Models;
    using CookingPot.Services.Mapping;

    public class SubcategoriesService : ISubcategoriesService
    {
        private readonly IRepository<Subcategory> subcategoriesRepository;

        public SubcategoriesService(IRepository<Subcategory> subcategoriesRepository)
        {
            this.subcategoriesRepository = subcategoriesRepository;
        }

        public IEnumerable<T> GetAll<T>()
        {
            IQueryable<Subcategory> subcategories = this.subcategoriesRepository.All();
            return subcategories.To<T>().ToList();
        }
    }
}

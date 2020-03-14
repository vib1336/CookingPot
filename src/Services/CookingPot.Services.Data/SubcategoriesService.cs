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

        public T GetSubcategory<T>(string subcategory = null)
            => this.subcategoriesRepository.All()
            .Where(s => s.Name == subcategory).To<T>().FirstOrDefault();
    }
}

namespace CookingPot.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using CookingPot.Data.Common.Repositories;
    using CookingPot.Data.Models;
    using CookingPot.Services.Mapping;

    public class SearchService : ISearchService
    {
        private readonly IDeletableEntityRepository<Recipe> recipesRepository;

        public SearchService(IDeletableEntityRepository<Recipe> recipesRepository)
            => this.recipesRepository = recipesRepository;

        public IEnumerable<T> Search<T>(string searchValue)
        {
            if (string.IsNullOrWhiteSpace(searchValue))
            {
                return this.recipesRepository.All()
                    .To<T>()
                    .ToList();
            }

            return this.recipesRepository.All()
                .Where(r => r.Name.ToLower().Contains(searchValue.ToLower()) && !r.IsDeleted)
                .To<T>()
                .ToList();
        }
    }
}

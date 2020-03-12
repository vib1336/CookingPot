namespace CookingPot.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using CookingPot.Data.Common.Repositories;
    using CookingPot.Data.Models;
    using CookingPot.Services.Mapping;

    public class RecipesService : IRecipesService
    {
        private readonly IDeletableEntityRepository<Recipe> recipesRepository;

        public RecipesService(IDeletableEntityRepository<Recipe> recipesRepository)
        {
            this.recipesRepository = recipesRepository;
        }

        public IEnumerable<T> GetAll<T>()
        {
            IQueryable<Recipe> recipes = this.recipesRepository.All();
            return recipes.To<T>().ToList();
        }
    }
}

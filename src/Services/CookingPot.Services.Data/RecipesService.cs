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

        public IEnumerable<T> GetRecipes<T>(int subcategoryId)
        {
            IQueryable<Recipe> recipes = this.recipesRepository.All().Where(r => r.SubcategoryId == subcategoryId);
            return recipes.To<T>().ToList();
        }

        public T GetRecipe<T>(int id)
        {
            T recipe = this.recipesRepository.All().Where(r => r.Id == id).To<T>().FirstOrDefault();
            return recipe;
        }
    }
}

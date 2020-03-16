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

        public IEnumerable<T> GetRecipes<T>(int subcategoryId, int page)
        {
            IQueryable<Recipe> recipes = this.recipesRepository.All()
                .Where(r => r.SubcategoryId == subcategoryId)
                .Skip((page - 1) * 9)
                .Take(9);

            return recipes.To<T>().ToList();
        }

        public T GetRecipe<T>(int id)
        {
            T recipe = this.recipesRepository.All().Where(r => r.Id == id).To<T>().FirstOrDefault();
            return recipe;
        }

        public int GetTotalRecipesFromSubcategory(int subcategoryId)
            => this.recipesRepository.All()
            .Where(r => r.SubcategoryId == subcategoryId)
            .Count();
    }
}

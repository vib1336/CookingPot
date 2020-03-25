namespace CookingPot.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IRecipesService
    {
        IEnumerable<T> GetRecipes<T>(int subcategoryId, int page);

        T GetRecipe<T>(int id);

        int GetTotalRecipesFromSubcategory(int subcategoryId);

        Task<int> AddRecipeAsync(string name, string description, string neededProducts, string imageUrl, int subcategoryId, string userId);

        Task UpdateRecipeAsync(int id, string name, string description, string products); // ?
    }
}

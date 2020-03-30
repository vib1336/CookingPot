namespace CookingPot.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Http;

    public interface IRecipesService
    {
        IEnumerable<T> GetRecipes<T>(int subcategoryId, int page);

        T GetRecipe<T>(int id);

        int GetTotalRecipesFromSubcategory(int subcategoryId);

        Task<int> AddRecipeAsync(string name, string description, IFormFile image, string neededProducts, int subcategoryId, string userId);

        Task UpdateRecipeAsync(int id, string name, string description, string products); // ?
    }
}

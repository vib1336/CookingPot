namespace CookingPot.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Http;

    public interface IRecipesService
    {
        IEnumerable<T> GetRecipes<T>(int subcategoryId, int page);

        T GetRecipe<T>(int id);

        int GetTotalRecipesFromSubcategory(int subcategoryId);

        Task<int> AddRecipeAsync(string name, string description, int timeToPrepare, string imageUrl, string neededProducts, int subcategoryId, string userId);

        Task<int> AddApprovalRecipeAsync(string name, string description, int timeToPrepare, IFormFile image, string neededProducts, int subcategoryId, string userId);

        Task<IEnumerable<T>> GetApprovalRecipesAsync<T>(bool isDeleted);

        Task SetIsApprovedRecipe(int id);

        Task<bool> SetIsDeletedApprovalRecipe(int id);

        Task<T> GetUserLastApprovalRecipeAsync<T>(string userId);

        Task UpdateRecipeAsync(int id, string name, string description, int timeToPrepare, string products);

        bool RecipeExists(int id);

        void DeleteRecipe(int id);
    }
}

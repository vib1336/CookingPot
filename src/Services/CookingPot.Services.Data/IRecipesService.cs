namespace CookingPot.Services.Data
{
    using System.Collections.Generic;

    public interface IRecipesService
    {
        IEnumerable<T> GetRecipes<T>(int subcategoryId, int page);

        T GetRecipe<T>(int id);

        int GetTotalRecipesFromSubcategory(int subcategoryId);

    }
}

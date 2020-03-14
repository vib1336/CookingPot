namespace CookingPot.Services.Data
{
    using System.Collections.Generic;

    public interface IRecipesService
    {
        IEnumerable<T> GetRecipes<T>(int subcategoryId);

        T GetRecipe<T>(int id);
    }
}

namespace CookingPot.Services.Data
{
    using System.Collections.Generic;

    public interface IRecipesService
    {
        IEnumerable<T> GetAll<T>();
    }
}

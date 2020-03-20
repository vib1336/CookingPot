namespace CookingPot.Services.Data
{
    using System.Collections.Generic;

    public interface ICategoryService
    {
        IEnumerable<T> GetCategories<T>();
    }
}

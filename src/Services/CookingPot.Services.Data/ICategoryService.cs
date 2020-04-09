namespace CookingPot.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICategoryService
    {
        Task AddCategoryAsync(string name);

        IEnumerable<T> GetCategories<T>();
    }
}

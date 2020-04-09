namespace CookingPot.Services.Data
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Http;

    public interface ISubcategoriesService
    {
        Task AddSubcategoryAsync(string name, string description, IFormFile image, int categoryId);

        T GetSubcategory<T>(string subcategory = null);
    }
}

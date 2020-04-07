namespace CookingPot.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICommentsService
    {
        Task<int> AddCommentAsync(int recipeId, string userId, string content);

        T GetComment<T>(int id);

        IEnumerable<T> GetRecipeComments<T>(int id);
    }
}

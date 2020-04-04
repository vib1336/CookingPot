namespace CookingPot.Services.Data
{
    using System.Threading.Tasks;

    public interface IVotesService
    {
        Task AddVote(int recipeId, string userId, bool isUpVote);

        int CountPositiveVotes(int recipeId);

        int CountNegativeVotes(int recipeId);
    }
}

namespace CookingPot.Services.Data
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using CookingPot.Data.Common.Repositories;
    using CookingPot.Data.Models;

    public class VotesService : IVotesService
    {
        private readonly IRepository<Vote> votesRepository;

        public VotesService(IRepository<Vote> votesRepository)
        {
            this.votesRepository = votesRepository;
        }

        public async Task AddVote(int recipeId, string userId, bool isUpVote)
        {
           Vote vote = this.votesRepository.All().FirstOrDefault(v => v.RecipeId == recipeId && v.UserId == userId);

           if (vote == null)
           {
                vote = new Vote
                {
                    RecipeId = recipeId,
                    UserId = userId,
                    VoteType = isUpVote ? VoteType.UpVote : VoteType.DownVote,
                };
                await this.votesRepository.AddAsync(vote);
                await this.votesRepository.SaveChangesAsync();
           }
        }

        public int[] CountVotes(int recipeId)
        {
            int positiveVotes = this.votesRepository.All()
                .Where(v => v.RecipeId == recipeId)
                .Count(v => v.VoteType == VoteType.UpVote);

            int negativeVotes = this.votesRepository.All()
                .Where(v => v.RecipeId == recipeId)
                .Count(v => v.VoteType == VoteType.DownVote);

            return new int[] { positiveVotes, negativeVotes };
        }
    }
}

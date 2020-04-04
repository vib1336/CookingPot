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
        private readonly IDeletableEntityRepository<Recipe> recipesRepository;

        public VotesService(
            IRepository<Vote> votesRepository,
            IDeletableEntityRepository<Recipe> recipesRepository)
        {
            this.votesRepository = votesRepository;
            this.recipesRepository = recipesRepository;
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

        public int CountPositiveVotes(int recipeId)
            => this.votesRepository.All().Where(v => v.RecipeId == recipeId)
            .Count(v => v.VoteType == VoteType.UpVote);

        public int CountNegativeVotes(int recipeId)
            => this.votesRepository.All().Where(v => v.RecipeId == recipeId)
            .Count(v => v.VoteType == VoteType.DownVote);
    }
}

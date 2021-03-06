﻿namespace CookingPot.Services.Data
{
    using System.Threading.Tasks;

    public interface IVotesService
    {
        Task<bool> AddVote(int recipeId, string userId, bool isUpVote);

        int[] CountVotes(int recipeId);
    }
}

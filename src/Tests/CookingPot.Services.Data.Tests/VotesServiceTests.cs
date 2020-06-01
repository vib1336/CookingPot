namespace CookingPot.Services.Data.Tests
{
    using System;
    using System.Threading.Tasks;

    using CookingPot.Data;
    using CookingPot.Data.Models;
    using CookingPot.Data.Repositories;
    using Microsoft.EntityFrameworkCore;
    using Xunit;

    public class VotesServiceTests
    {
        [Fact]
        public async Task VotesServiceCountsVotesCorrectly()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString());
            var votesRepository = new EfRepository<Vote>(new ApplicationDbContext(options.Options));

            var service = new VotesService(votesRepository);

            await service.AddVote(1, "1", true);
            await service.AddVote(1, "2", true);
            await service.AddVote(1, "3", false);

            var votes = service.CountVotes(1);

            Assert.Equal(2, votes[0]);
            Assert.Equal(1, votes[1]);
        }
    }
}

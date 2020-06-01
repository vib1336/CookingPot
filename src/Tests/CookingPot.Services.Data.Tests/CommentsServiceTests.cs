namespace CookingPot.Services.Data.Tests
{
    using System;
    using System.Threading.Tasks;

    using CookingPot.Data;
    using CookingPot.Data.Models;
    using CookingPot.Data.Repositories;
    using CookingPot.Services.Data.Tests.TestViewModels;
    using CookingPot.Services.Mapping;
    using Microsoft.EntityFrameworkCore;
    using Xunit;

    public class CommentsServiceTests
    {
        [Fact]
        public async Task TestIfServiceAddComment()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("CookingPot");
            var commentsRepository = new EfDeletableEntityRepository<Comment>(new ApplicationDbContext(options.Options));

            var service = new CommentsService(commentsRepository);
            for (int i = 0; i < 5; i++)
            {
                await service.AddCommentAsync(1, "1", i.ToString());
            }

            var count = service.GetRecipeCountComments(1);

            Assert.Equal(5, count);
        }

        [Fact]
        public async Task TestIfServiceReturnComment()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString());
            var context = new ApplicationDbContext(options.Options);
            var commentsRepository = new EfDeletableEntityRepository<Comment>(context);

            var service = new CommentsService(commentsRepository);

            var firstId = await service.AddCommentAsync(1, "1", "Test content");
            var secondId = await service.AddCommentAsync(1, "1", "Test content 2");
            var thirdId = await service.AddCommentAsync(1, "1", "Test content 3");

            AutoMapperConfig.RegisterMappings(this.GetType().Assembly);

            var firstComment = service.GetComment<TestCommentModel>(firstId);
            var secondComment = service.GetComment<TestCommentModel>(secondId);
            var thirdComment = service.GetComment<TestCommentModel>(thirdId);
            Assert.Equal("Test content", firstComment.Content);
            Assert.Equal("Test content 2", secondComment.Content);
            Assert.Equal("Test content 3", thirdComment.Content);
        }
    }
}

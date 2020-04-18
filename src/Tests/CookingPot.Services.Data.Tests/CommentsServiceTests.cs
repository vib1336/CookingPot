namespace CookingPot.Services.Data.Tests
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Threading.Tasks;

    using CookingPot.Data;
    using CookingPot.Data.Models;
    using CookingPot.Data.Repositories;
    using CookingPot.Services.Mapping;
    using CookingPot.Web.ViewModels;
    using CookingPot.Web.ViewModels.Comments;
    using Microsoft.EntityFrameworkCore;
    using Xunit;

    public class CommentsServiceTests
    {
        public CommentsServiceTests()
        {
            AutoMapperConfig.RegisterMappings(typeof(CommentReturnInfoModel).GetTypeInfo().Assembly);
        }

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
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString());
            var context = new ApplicationDbContext(options.Options);
            var commentsRepository = new EfDeletableEntityRepository<Comment>(context);

            var service = new CommentsService(commentsRepository);

            var firstId = await service.AddCommentAsync(1, "1", "Test content");
            var secondId = await service.AddCommentAsync(1, "1", "Test content 2");
            var thirdId = await service.AddCommentAsync(1, "1", "Test content 3");

            var comment = service.GetComment<CommentReturnInfoModel>(firstId);
            Assert.Equal("Test content", comment.Content);

        }
    }
}

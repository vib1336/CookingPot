namespace CookingPot.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using CookingPot.Data.Common.Repositories;
    using CookingPot.Data.Models;
    using CookingPot.Services.Mapping;

    public class CommentsService : ICommentsService
    {
        private readonly IDeletableEntityRepository<Comment> commentsRepository;

        public CommentsService(IDeletableEntityRepository<Comment> commentsRepository)
            => this.commentsRepository = commentsRepository;

        public async Task<int> AddCommentAsync(int recipeId, string userId, string content)
        {
            Comment comment = new Comment
            {
                Content = content,
                RecipeId = recipeId,
                UserId = userId,
            };

            await this.commentsRepository.AddAsync(comment);
            await this.commentsRepository.SaveChangesAsync();

            return comment.Id;
        }

        public T GetComment<T>(int id)
            => this.commentsRepository.All().Where(c => c.Id == id).To<T>().FirstOrDefault();

        public IEnumerable<T> GetRecipeComments<T>(int id)
            => this.commentsRepository.All().Where(c => c.RecipeId == id).To<T>().ToList();

        // Test purposes
        public int GetRecipeCountComments(int recipeId)
            => this.commentsRepository.All().Where(c => c.RecipeId == recipeId).Count();

        public async Task<bool> DeleteCommentAsync(int id)
        {
            var comment = this.commentsRepository.All().FirstOrDefault(c => c.Id == id);

            comment.IsDeleted = true;

            await this.commentsRepository.SaveChangesAsync();

            return comment.IsDeleted;
        }
    }
}

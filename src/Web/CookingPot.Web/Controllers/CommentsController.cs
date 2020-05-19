namespace CookingPot.Web.Controllers
{
    using System.Threading.Tasks;

    using CookingPot.Services.Data;
    using CookingPot.Web.ViewModels.Comments;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentsService commentsService;

        public CommentsController(ICommentsService commentsService)
            => this.commentsService = commentsService;

        [HttpPost]
        [Authorize]
        [Route("Comments/Comment")]
        public async Task<ActionResult<CommentReturnInfoModel>> Comment(CommentInputModel inputModel)
        {
            var commentId = await this.commentsService.AddCommentAsync(inputModel.RecipeId, inputModel.CurrentUserId, inputModel.Comment);

            var commentReturnModel = this.commentsService.GetComment<CommentReturnInfoModel>(commentId);

            return commentReturnModel;
        }

        [HttpPost]
        [Authorize]
        [Route("Comments/DeleteComment")]
        public async Task<ActionResult<DeleteCommentReturnModel>> DeleteComment(DeleteCommentInputModel inputModel)
        {
            var isCommentDeleted = await this.commentsService.DeleteCommentAsync(inputModel.CommentId);

            return new DeleteCommentReturnModel { IsCommentDeleted = isCommentDeleted };
        }
    }
}

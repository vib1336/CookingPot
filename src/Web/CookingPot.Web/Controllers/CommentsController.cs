namespace CookingPot.Web.Controllers
{
    using System.Threading.Tasks;

    using CookingPot.Services.Data;
    using CookingPot.Web.ViewModels.Comments;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/[controller]")]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentsService commentsService;

        public CommentsController(ICommentsService commentsService)
        {
            this.commentsService = commentsService;
        }

        public async Task<ActionResult<CommentReturnInfoModel>> Comment(CommentInputModel inputModel)
        {
            var commentId = await this.commentsService.AddCommentAsync(inputModel.RecipeId, inputModel.CurrentUserId, inputModel.Comment);

            var commentReturnModel = this.commentsService.GetComment<CommentReturnInfoModel>(commentId);

            return commentReturnModel;
        }
    }
}

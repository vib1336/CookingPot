namespace CookingPot.Web.Controllers
{
    using System.Threading.Tasks;

    using CookingPot.Data.Models;
    using CookingPot.Services.Data;
    using CookingPot.Web.ViewModels.Votes;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/[controller]")]
    public class VotesController : ControllerBase
    {
        private readonly IVotesService votesService;
        private readonly UserManager<ApplicationUser> userManager;

        public VotesController(IVotesService votesService, UserManager<ApplicationUser> userManager)
        {
            this.votesService = votesService;
            this.userManager = userManager;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<VoteCounterModel>> Vote(VoteInputModel inputModel)
        {
            var user = await this.userManager.GetUserAsync(this.User);

            await this.votesService.AddVote(inputModel.RecipeId, user.Id, inputModel.IsUpVote);

            int positiveVotes = this.votesService.CountVotes(inputModel.RecipeId)[0];
            int negativeVotes = this.votesService.CountVotes(inputModel.RecipeId)[1];

            return new VoteCounterModel
            {
                PositiveVotes = positiveVotes,
                NegativeVotes = negativeVotes,
            };
        }
    }
}

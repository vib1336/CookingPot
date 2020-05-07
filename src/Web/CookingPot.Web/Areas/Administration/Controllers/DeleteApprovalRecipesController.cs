namespace CookingPot.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using CookingPot.Services.Data;
    using CookingPot.Web.ViewModels.ApprovalRecipes;
    using Microsoft.AspNetCore.Mvc;

    [Area("Administration")]
    [ApiController]
    [Route("api/[controller]")]
    public class DeleteApprovalRecipesController : ControllerBase
    {
        private readonly IRecipesService recipesService;

        public DeleteApprovalRecipesController(IRecipesService recipesService)
            => this.recipesService = recipesService;

        public async Task<ActionResult<IsDeletedReturnModel>> DeleteApprovalRecipe(DeleteApprovalRecipeModel inputModel)
        {
            var isDeleted = await this.recipesService.SetIsDeletedApprovalRecipe(inputModel.ApprovalRecipeId);

            return new IsDeletedReturnModel { IsApprovalRecipeDeleted = isDeleted };
        }
    }
}

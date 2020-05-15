namespace CookingPot.Web.ViewModels.ApprovalRecipes
{
    using System;

    using CookingPot.Data.Models;
    using CookingPot.Services.Mapping;

    public class GetLastApprovalRecipeModel : IMapFrom<ApprovalRecipe>
    {
        public DateTime CreatedOn { get; set; }
    }
}

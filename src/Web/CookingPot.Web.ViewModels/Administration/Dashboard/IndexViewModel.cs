namespace CookingPot.Web.ViewModels.Administration.Dashboard
{
    using System.Collections.Generic;

    using CookingPot.Web.ViewModels.ApprovalRecipes;

    public class IndexViewModel
    {
        public int SettingsCount { get; set; }

        public IEnumerable<ApprovalRecipeReturnModel> ApprovalRecipes { get; set; }
    }
}

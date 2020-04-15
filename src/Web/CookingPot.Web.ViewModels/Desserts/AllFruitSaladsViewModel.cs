namespace CookingPot.Web.ViewModels.Desserts
{
    using System;
    using System.Collections.Generic;

    using static CookingPot.Common.GlobalConstants;

    public class AllFruitSaladsViewModel
    {
        public IEnumerable<FruitSaladsViewModel> AllFruitSalads { get; set; }

        public int Total { get; set; }

        public int CurrentPage { get; set; }

        public int PreviousPage => this.CurrentPage - 1;

        public int NextPage => this.CurrentPage + 1;

        public bool PreviousDisabled => this.CurrentPage == 1;

        public bool NextDisabled
        {
            get
            {
                double maxPage = Math.Ceiling(((double)this.Total) / RecipesPerPage);

                return this.CurrentPage == maxPage;
            }
        }
    }
}

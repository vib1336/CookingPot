namespace CookingPot.Web.ViewModels.Salads
{
    using System.Collections.Generic;
    using System;

    public class AllSaladsViewModel
    {
        public IEnumerable<DisplaySaladSubcategoryViewModel> AllSalads { get; set; }

        public int Total { get; set; }

        public int CurrentPage { get; set; }

        public int PreviousPage => this.CurrentPage - 1;

        public int NextPage => this.CurrentPage + 1;

        public bool PreviousDisabled => this.CurrentPage == 1;

        public bool NextDisabled
        {
            get
            {
                double maxPage = Math.Ceiling(((double)this.Total) / 9);

                return this.CurrentPage == maxPage;
            }
        }
    }
}

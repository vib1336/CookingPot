﻿namespace CookingPot.Web.ViewModels.MainCourses
{
    using System;
    using System.Collections.Generic;

    using static CookingPot.Common.GlobalConstants;

    public class AllMeatMainCoursesViewModel
    {
        public IEnumerable<MeatMainCoursesViewModel> AllMeatMainCourses { get; set; }

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

        public int MaxPage { get; set; }

        public bool InvalidPage
        {
            get
            {
                double maxPage = Math.Ceiling(((double)this.Total) / RecipesPerPage);

                bool isInvalid = false;

                if (this.CurrentPage > maxPage)
                {
                    isInvalid = true;
                }

                return isInvalid;
            }
        }
    }
}

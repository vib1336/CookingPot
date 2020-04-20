namespace CookingPot.Web.ViewModels.Recipes
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    using CookingPot.Data.Models;
    using CookingPot.Services.Mapping;

    public class DetailsRecipeViewModel : IMapFrom<Recipe>
    {
        public int Id { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int TimeToPrepare { get; set; }

        public string ImageUrl { get; set; }

        public string UserUserName { get; set; }

        public string ShortUsername
        {
            get
            {
                string hideEmailFromUsername = Regex.Replace(this.UserUserName, @"@[A-Za-z0-9](.)*", string.Empty);
                return hideEmailFromUsername;
            }
        }

        public string UserId { get; set; }

        public string CurrentUserId { get; set; }

        public string CurrentUserName { get; set; }

        public bool IsUserInRole { get; set; }

        public int PositiveVotes { get; set; }

        public int NegativeVotes { get; set; }

        public IEnumerable<ProductViewModel> RecipeProducts { get; set; }

        public IEnumerable<CommentViewModel> RecipeComments { get; set; }
    }
}

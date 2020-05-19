namespace CookingPot.Web.ViewModels.Recipes
{
    using System;
    using System.Text.RegularExpressions;

    using CookingPot.Data.Models;
    using CookingPot.Services.Mapping;

    public class CommentViewModel : IMapFrom<Comment>
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Content { get; set; }

        public string UserUserName { get; set; }

        public string ShortUsername
        {
            get
            {
                string hideEmailFromUsername = Regex.Replace(this.UserUserName, @"@[A-Za-z0-9](.)*", string.Empty);
                return hideEmailFromUsername;
            }
        }
    }
}

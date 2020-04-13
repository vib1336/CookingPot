namespace CookingPot.Web.ViewModels.Comments
{
    using System;
    using System.Text.RegularExpressions;

    using CookingPot.Data.Models;
    using CookingPot.Services.Mapping;

    public class CommentReturnInfoModel : IMapFrom<Comment>
    {
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

namespace CookingPot.Web.ViewModels.Recipes
{
    using System;

    using CookingPot.Data.Models;
    using CookingPot.Services.Mapping;

    public class CommentViewModel : IMapFrom<Comment>
    {
        public DateTime CreatedOn { get; set; }

        public string Content { get; set; }

        public string UserUserName { get; set; }
    }
}

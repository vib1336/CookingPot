namespace CookingPot.Services.Data.Tests.TestViewModels
{
    using CookingPot.Data.Models;
    using CookingPot.Services.Mapping;

    public class TestCommentModel : IMapFrom<Comment>
    {
        public string Content { get; set; }
    }
}

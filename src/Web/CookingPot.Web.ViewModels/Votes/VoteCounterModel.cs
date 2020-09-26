namespace CookingPot.Web.ViewModels.Votes
{
    public class VoteCounterModel
    {
        public int PositiveVotes { get; set; }

        public int NegativeVotes { get; set; }

        public bool HasUserVoted { get; set; }
    }
}

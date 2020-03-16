namespace CookingPot.Web.ViewModels.Salads
{
    using CookingPot.Data.Models;
    using CookingPot.Services.Mapping;

    public class DisplaySaladSubcategoryViewModel : IMapFrom<Recipe>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public string ShortDescription
        {
            get
            {
                string defaultDescription = string.Empty;

                if (this.Description?.Length > 20)
                {
                    defaultDescription = this.Description.Substring(0, 20) + "...";
                }
                else if (this.Description?.Length < 20)
                {
                    defaultDescription = this.Description;
                }
                else
                {
                    defaultDescription = "(No description avalaible)";
                }

                return defaultDescription;
            }
        }
    }
}

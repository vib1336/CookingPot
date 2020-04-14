namespace CookingPot.Web.ViewModels.MainCourses
{
    using CookingPot.Data.Models;
    using CookingPot.Services.Mapping;

    public class MeatMainCoursesViewModel : IMapFrom<Recipe>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ShortName
            => this.Name.Length > 15
            ? this.Name.Substring(0, 15) + "..." : this.Name;

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
                else
                {
                    defaultDescription = this.Description;
                }

                return defaultDescription;
            }
        }
    }
}

namespace CookingPot.Web.ViewModels.MainCourses
{
    using CookingPot.Data.Models;
    using CookingPot.Services.Mapping;

    public class VegetarianMainCoursesSubcategoryViewModel : IMapFrom<Subcategory>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }
    }
}

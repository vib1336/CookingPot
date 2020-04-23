namespace CookingPot.Web.Tests
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc.Testing;
    using Xunit;

    public class MaincoursersPageTests
    {
        [Fact]
        public async Task TestIfMaincoursesPageHasTitle()
        {
            var serverFactory = new WebApplicationFactory<Startup>();
            var httpClient = serverFactory.CreateClient();

            var response = await httpClient.GetAsync("/Maincourses/Subcategories");
            var responseAsString = await response.Content.ReadAsStringAsync();

            Assert.Contains("<title>Main courses - CookingPot</title>", responseAsString);
        }

        [Fact]
        public async Task TestIfVegetarianMaincourseHasImage()
        {
            var serverFactory = new WebApplicationFactory<Startup>();
            var httpClient = serverFactory.CreateClient();

            var response = await httpClient.GetAsync("/Maincourses/Subcategories");
            var responseAsString = await response.Content.ReadAsStringAsync();

            Assert.Contains("<img class=\"card-img-top\"", responseAsString);
        }
    }
}

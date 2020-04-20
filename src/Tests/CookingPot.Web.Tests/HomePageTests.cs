namespace CookingPot.Web.Tests
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc.Testing;
    using Xunit;

    public class HomePageTests
    {
        [Fact]
        public async Task HomePageShouldContainImgTag()
        {
            var serverFactory = new WebApplicationFactory<Startup>();
            var httpClient = serverFactory.CreateClient();

            var response = await httpClient.GetAsync("/");
            var responseAsString = await response.Content.ReadAsStringAsync();

            Assert.Contains("<img", responseAsString);
        }

        [Fact]
        public async Task HomePageShouldContainFooter()
        {
            var serverFactory = new WebApplicationFactory<Startup>();
            var httpClient = serverFactory.CreateClient();

            var response = await httpClient.GetAsync("/");
            var responseAsString = await response.Content.ReadAsStringAsync();

            Assert.Contains("<footer", responseAsString);
        }
    }
}

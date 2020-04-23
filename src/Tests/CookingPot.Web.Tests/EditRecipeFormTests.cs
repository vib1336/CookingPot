namespace CookingPot.Web.Tests
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc.Testing;
    using Xunit;

    public class EditRecipeFormTests
    {
        [Fact]
        public async Task TestIfEditFormHaveSubmitButton()
        {
            var serverFactory = new WebApplicationFactory<Startup>();
            var httpClient = serverFactory.CreateClient();

            var response = await httpClient.GetAsync("/Recipes/EditRecipe/2");
            var responseAsString = await response.Content.ReadAsStringAsync();

            Assert.Contains("<input type=\"submit\"", responseAsString);
        }

        [Fact]
        public async Task TestIfEditFormHaveH2()
        {
            var serverFactory = new WebApplicationFactory<Startup>();
            var httpClient = serverFactory.CreateClient();

            var response = await httpClient.GetAsync("/Recipes/EditRecipe/2");
            var responseAsString = await response.Content.ReadAsStringAsync();

            Assert.Contains("<h2 class=\"text-center\"", responseAsString);
        }

        [Fact]
        public async Task TestIfEditFormHaveFooter()
        {
            var serverFactory = new WebApplicationFactory<Startup>();
            var httpClient = serverFactory.CreateClient();

            var response = await httpClient.GetAsync("/Recipes/EditRecipe/2");
            var responseAsString = await response.Content.ReadAsStringAsync();

            Assert.Contains("<footer class=\"border-top footer text-muted\"", responseAsString);
        }
    }
}

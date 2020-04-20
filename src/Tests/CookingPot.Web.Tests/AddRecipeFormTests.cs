namespace CookingPot.Web.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc.Testing;
    using Xunit;

    public class AddRecipeFormTests
    {
        [Fact]
        public async Task TestIfAddFormHaveSubmitButton()
        {
            var serverFactory = new WebApplicationFactory<Startup>();
            var httpClient = serverFactory.CreateClient();

            var response = await httpClient.GetAsync("/Recipes/AddRecipe");
            var responseAsString = await response.Content.ReadAsStringAsync();

            Assert.Contains("<input type=\"submit\"", responseAsString);
        }

        [Fact]
        public async Task TestIfAddFormHaveUploadImageButton()
        {
            var serverFactory = new WebApplicationFactory<Startup>();
            var httpClient = serverFactory.CreateClient();

            var response = await httpClient.GetAsync("/Recipes/AddRecipe");
            var responseAsString = await response.Content.ReadAsStringAsync();

            Assert.Contains("<input type=\"file\"", responseAsString);
        }
    }
}

namespace CookingPot.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using CookingPot.Data.Common.Repositories;
    using CookingPot.Data.Models;
    using CookingPot.Services.Mapping;

    public class RecipesService : IRecipesService
    {
        private readonly IDeletableEntityRepository<Recipe> recipesRepository;
        private readonly IRepository<ProductRecipe> productRecipeRepository; // ?
        private readonly IRepository<Product> productsRepository; // ?

        public RecipesService(
            IDeletableEntityRepository<Recipe> recipesRepository,
            IRepository<ProductRecipe> productRecipeRepository,
            IRepository<Product> productsRepository)
        {
            this.recipesRepository = recipesRepository;
            this.productRecipeRepository = productRecipeRepository;
            this.productsRepository = productsRepository;
        }

        public IEnumerable<T> GetRecipes<T>(int subcategoryId, int page)
        {
            IQueryable<Recipe> recipes = this.recipesRepository.All()
                .Where(r => r.SubcategoryId == subcategoryId)
                .Skip((page - 1) * 9)
                .Take(9);

            return recipes.To<T>().ToList();
        }

        public T GetRecipe<T>(int id)
        {
            T recipe = this.recipesRepository.All().Where(r => r.Id == id).To<T>().FirstOrDefault();
            return recipe;
        }

        public int GetTotalRecipesFromSubcategory(int subcategoryId)
            => this.recipesRepository.All()
            .Where(r => r.SubcategoryId == subcategoryId)
            .Count();

        public async Task<int> AddRecipeAsync(string name, string description, string neededProducts, string imageUrl, int subcategoryId, string userId)
        {
            string[] splittedProducts = neededProducts
                .Split(new[] { "\r\n" }, StringSplitOptions.None)
                .Where(sp => sp != string.Empty)
                .ToArray();

            Recipe recipe = new Recipe
            {
                Name = name,
                Description = description,
                ImageUrl = imageUrl,
                SubcategoryId = subcategoryId,
                UserId = userId,
            };

            await this.recipesRepository.AddAsync(recipe);
            await this.recipesRepository.SaveChangesAsync();

            foreach (var prod in splittedProducts)
            {
                string productWithFixedLetterCase = char.ToUpper(prod[0]) + prod.Substring(1).ToLower();

                Product product = this.productsRepository.All()
                    .Where(p => p.Name == productWithFixedLetterCase)
                    .FirstOrDefault();

                if (product == null)
                {
                    product = new Product
                    {
                        Name = productWithFixedLetterCase,
                    };

                    await this.productsRepository.AddAsync(product);
                    await this.productsRepository.SaveChangesAsync();
                }

                ProductRecipe productRecipe = new ProductRecipe
                {
                    RecipeId = recipe.Id,
                    ProductId = product.Id,
                };

                await this.productRecipeRepository.AddAsync(productRecipe);
            }

            await this.productsRepository.SaveChangesAsync();

            return recipe.Id;
        }
    }
}

namespace CookingPot.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using CloudinaryDotNet;
    using CloudinaryDotNet.Actions;
    using CookingPot.Data.Common.Repositories;
    using CookingPot.Data.Models;
    using CookingPot.Services.Mapping;
    using Microsoft.AspNetCore.Http;

    using static CookingPot.Common.GlobalConstants;

    public class RecipesService : IRecipesService
    {
        private readonly IDeletableEntityRepository<Recipe> recipesRepository;
        private readonly IRepository<ProductRecipe> productRecipeRepository; // ?
        private readonly IRepository<Product> productsRepository; // ?
        private readonly Cloudinary cloudinary;

        public RecipesService(
            IDeletableEntityRepository<Recipe> recipesRepository,
            IRepository<ProductRecipe> productRecipeRepository,
            IRepository<Product> productsRepository,
            Cloudinary cloudinary)
        {
            this.recipesRepository = recipesRepository;
            this.productRecipeRepository = productRecipeRepository;
            this.productsRepository = productsRepository;
            this.cloudinary = cloudinary;
        }

        public IEnumerable<T> GetRecipes<T>(int subcategoryId, int page)
        {
            IQueryable<Recipe> recipes = this.recipesRepository.All()
                .Where(r => r.SubcategoryId == subcategoryId)
                .Skip((page - 1) * RecipesPerPage)
                .Take(RecipesPerPage);

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

        public async Task<int> AddRecipeAsync(string name, string description, IFormFile image, string neededProducts, int subcategoryId, string userId)
        {
            string[] splittedProducts = neededProducts
                .Split(new[] { "\r\n" }, StringSplitOptions.None)
                .Where(sp => sp != string.Empty)
                .ToArray();

            /** Cloudinary upload image **/
            byte[] destinationImage;

            using var memoryStream = new MemoryStream();
            await image.CopyToAsync(memoryStream);
            destinationImage = memoryStream.ToArray();

            using var destinationStream = new MemoryStream(destinationImage);

            var uploadParams = new ImageUploadParams
            {
                File = new FileDescription(image.FileName, destinationStream),
            };

            var uploadResult = await this.cloudinary.UploadAsync(uploadParams);
            /** Cloudinary upload image **/
            Recipe recipe = new Recipe
            {
                Name = name,
                Description = description,
                ImageUrl = uploadResult.Uri.AbsoluteUri,
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

        public async Task UpdateRecipeAsync(int id, string name, string description, string products)
        {
            var recipeToEdit = this.recipesRepository.All().Where(r => r.Id == id).FirstOrDefault();

            string[] filteredProducts = products
                .Split(new[] { NewLine }, StringSplitOptions.None)
                .Where(p => p != string.Empty)
                .ToArray();

            foreach (var pr in filteredProducts)
            {
                string productWithFixedLetterCase = char.ToUpper(pr[0]) + pr.Substring(1).ToLower();

                if (this.productsRepository.All().FirstOrDefault(p => p.Name == productWithFixedLetterCase) == null)
                {
                    Product product = new Product { Name = productWithFixedLetterCase };
                    await this.productsRepository.AddAsync(product);
                    await this.productsRepository.SaveChangesAsync();

                    ProductRecipe productRecipe = new ProductRecipe { ProductId = product.Id, RecipeId = id };
                    await this.productRecipeRepository.AddAsync(productRecipe);
                }
                else
                {
                    var product = this.productsRepository.All().Where(p => p.Name == productWithFixedLetterCase)
                        .FirstOrDefault();

                    if (!this.productRecipeRepository.All().Any(pr => pr.ProductId == product.Id
                    && pr.RecipeId == id))
                    {
                        ProductRecipe productRecipe = new ProductRecipe
                        {
                            ProductId = product.Id,
                            RecipeId = id,
                        };
                        await this.productRecipeRepository.AddAsync(productRecipe);
                    }
                }
            }

            await this.productRecipeRepository.SaveChangesAsync();

            recipeToEdit.Name = name;
            recipeToEdit.Description = description;
            recipeToEdit.ModifiedOn = DateTime.UtcNow;

            await this.recipesRepository.SaveChangesAsync();
        }
    }
}

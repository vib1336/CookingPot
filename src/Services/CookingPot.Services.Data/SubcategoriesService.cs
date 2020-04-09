﻿namespace CookingPot.Services.Data
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

    public class SubcategoriesService : ISubcategoriesService
    {
        private readonly IRepository<Subcategory> subcategoriesRepository;
        private readonly Cloudinary cloudinary;

        public SubcategoriesService(IRepository<Subcategory> subcategoriesRepository, Cloudinary cloudinary)
        {
            this.subcategoriesRepository = subcategoriesRepository;
            this.cloudinary = cloudinary;
        }

        public async Task AddSubcategoryAsync(string name, string description, IFormFile image, int categoryId)
        {
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
            Subcategory subcategory = new Subcategory
            {
                Name = name,
                Description = description,
                ImageUrl = uploadResult.Uri.AbsoluteUri,
                CategoryId = categoryId,
            };

            await this.subcategoriesRepository.AddAsync(subcategory);
            await this.subcategoriesRepository.SaveChangesAsync();
        }

        public T GetSubcategory<T>(string subcategory = null)
            => this.subcategoriesRepository.All()
            .Where(s => s.Name == subcategory).To<T>().FirstOrDefault();
    }
}

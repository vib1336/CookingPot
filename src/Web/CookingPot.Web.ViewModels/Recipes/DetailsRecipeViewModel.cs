namespace CookingPot.Web.ViewModels.Recipes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;
    using CookingPot.Data.Models;
    using CookingPot.Services.Mapping;

    public class DetailsRecipeViewModel : IMapFrom<Recipe>//, IHaveCustomMappings
    {
        public DateTime CreatedOn { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public string UserUserName { get; set; }

        public int SubcategoryId { get; set; }

        public string ControllerName { get; set; }

        public IEnumerable<ProductViewModel> RecipeProducts { get; set; }

        //public void CreateMappings(IProfileExpression configuration)
        //{
        //    configuration.CreateMap<Recipe, ProductViewModel>()
        //        .ForMember(
        //            dest => dest.Name,
        //            opt => opt.MapFrom(src => src.RecipeProducts.Select(rp => rp.Product.Name)));

        //    configuration.CreateMap<Recipe, ProductViewModel>()
        //        .ForMember(
        //            dest => dest.Quantity,
        //            opt => opt.MapFrom(src => src.RecipeProducts.Select(rp => rp.Product.Quantity)));
        //}
    }
}

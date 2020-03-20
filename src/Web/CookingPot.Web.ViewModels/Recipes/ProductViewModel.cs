namespace CookingPot.Web.ViewModels.Recipes
{
    using AutoMapper;
    using CookingPot.Data.Models;
    using CookingPot.Services.Mapping;

    public class ProductViewModel : IHaveCustomMappings
    {
        public string Name { get; set; }

        public double Quantity { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<ProductRecipe, ProductViewModel>()
                .ForMember(
                dest => dest.Name,
                opt => opt.MapFrom(src => src.Product.Name))
                .ForMember(
                dest => dest.Quantity,
                opt => opt.MapFrom(src => src.Product.Quantity));
        }
    }
}

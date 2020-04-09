namespace CookingPot.Web.ViewModels.Subcategories
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Http;

    using static CookingPot.Common.GlobalConstants;

    public class SubcategoryInputModel
    {
        [Required]
        [StringLength(SubcategoryMaxInputName, MinimumLength = SubcategoryMinInputName)]
        public string Name { get; set; }

        [Required]
        [StringLength(SubcategoryMaxInputDescription, MinimumLength = SubcategoryMinInputDescription)]
        public string Description { get; set; }

        public IFormFile Image { get; set; }

        public int CategoryId { get; set; }

        public IEnumerable<GetCategoriesViewModel> Categories { get; set; }
    }
}

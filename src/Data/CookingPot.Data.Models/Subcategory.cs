namespace CookingPot.Data.Models
{
    using System.Collections.Generic;

    public class Subcategory
    {
        public Subcategory()
        {
            this.Recipes = new HashSet<Recipe>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<Recipe> Recipes { get; set; }
    }
}

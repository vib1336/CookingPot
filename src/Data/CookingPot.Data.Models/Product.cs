namespace CookingPot.Data.Models
{
    using System.Collections.Generic;

    public class Product
    {
        public Product()
        {
            this.ProductRecipes = new HashSet<ProductRecipe>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public double Quantity { get; set; }

        public virtual ICollection<ProductRecipe> ProductRecipes { get; set; }
    }
}

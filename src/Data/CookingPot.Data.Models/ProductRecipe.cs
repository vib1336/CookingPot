namespace CookingPot.Data.Models
{
    public class ProductRecipe
    {
        public int ProductId { get; set; }

        public virtual Product Product { get; set; }

        public int RecipeId { get; set; }

        public virtual Recipe Recipe { get; set; }
    }
}

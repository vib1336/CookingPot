namespace CookingPot.Data.Models
{
    using System.Collections.Generic;

    public class Category
    {
        public Category()
        {
            this.Subcategories = new HashSet<Subcategory>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Subcategory> Subcategories { get; set; }
    }
}

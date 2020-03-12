namespace CookingPot.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface ISubcategoriesService
    {
        IEnumerable<T> GetAll<T>();
    }
}

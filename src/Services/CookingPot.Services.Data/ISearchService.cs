namespace CookingPot.Services.Data
{
    using System.Collections.Generic;

    public interface ISearchService
    {
        IEnumerable<T> Search<T>(string searchValue);
    }
}

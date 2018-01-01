using System.Linq;
using ContactManager.Data.Models;

namespace ContactManager.Data.Interfaces
{
    public interface IRepoLookups
    {
        IQueryable<Lookups.StateProvinces> GetStateProvinces { get; }
        IQueryable<Lookups.Categories> GetCategories { get; }
    }
}

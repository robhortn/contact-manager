using System.Linq;
using ContactManager.Data.Models;

namespace ContactManager.Data.Interfaces
{
    public interface IRepoCompanies
    {
        IQueryable<Company> GetCompanies { get; }
    }
}

using System.Linq;
using ContactManager.Data.Models;
using ContactManager.Data.Interfaces;

namespace ContactManager.Data
{
    public class RepoLookups : RepoBase, IRepoLookups
    {
        public IQueryable<Lookups.StateProvinces> GetStateProvinces
        {
            get
            {
                return Context.LookupStates.Select(x => new Lookups.StateProvinces
                {
                    Id = x.Id,
                    Statename = x.StateName,
                    StateCode = x.StateCode
                });
            }
        }

        public IQueryable<Lookups.Categories> GetCategories {
            get
            {
                return Context.CompanyCategories.Select(x => new Lookups.Categories
                {
                    Id = x.Id,
                    Category = x.Category
                });
            }
        }
    }

    public class RepoCompanies : RepoBase, IRepoCompanies {

        public IQueryable<Company> GetCompanies => throw new System.NotImplementedException();

    }

    public class RepoContacts : RepoBase, IRepoContacts
    {
    }
}

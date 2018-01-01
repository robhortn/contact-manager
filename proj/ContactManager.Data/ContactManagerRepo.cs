using System.Linq;
using ContactManager.Data.Models;
using ContactManager.Data.Interfaces;

namespace ContactManager.Data
{
    public class RepoLookup : RepoBase, IRepoLookups
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

        public IQueryable<Lookups.Categories> GetCategories => throw new System.NotImplementedException();
    }
}

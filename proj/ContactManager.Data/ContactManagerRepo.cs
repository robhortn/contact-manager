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
                return Context.LookupCompanyCategories.Select(x => new Lookups.Categories
                {
                    Id = x.Id,
                    Category = x.Category
                });
            }
        }
    }

    public class RepoCompanies : RepoBase, IRepoCompanies {

        public IQueryable<Company> GetCompanies {
            get
            {
                return Context.Companies.Where(a => a.IsActive).Select(x => new Company
                {
                    Id = x.Id,
                    CompanyName = x.CompanyName,
                    Address1 = x.Address1,
                    Address2 = x.Address2,
                    CategoryId = x.CategoryId, 
                    CategoryName = "UNMAPPED FIELD",
                    City = x.City,
                    CompanyFax = x.FaxNumber,
                    CompanyPhone = x.PhoneNumber,
                    IsActive = x.IsActive,
                    PostalCode = x.PostalCode,
                    StateId = x.StateId,
                    StateProvinceName = "UNMAPPED FIELD"
                });
            }
        }
    }

    public class RepoContacts : RepoBase, IRepoContacts
    {
        public IQueryable<Contact> GetContacts {
            get
            {
                return Context.Contacts.Select(x => new Contact
                {
                    Id = x.Id,
                    CompanyId = x.CompanyId,
                    EmailAddress = x.EmailAddress,
                    NameFirst = x.NameFirst,
                    NameLast = x.NameLast,
                    PhoneDirectLine = x.PhoneDirectLine,
                    PhoneExtension = x.PhoneExtension,
                    PhoneHome = x.PhoneHome
                });
            }
        }
    }
}

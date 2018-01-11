using ContactManager.Data.Models;

namespace ContactManager.Tests.Builders
{
    public class ObjectBuilders
    {
        public Company GenerateCompanyData()
        {
            Company result = new Company
            {
                Id = 1,
                CompanyName = "code12studios",
                City = "Warrenton",
                Address1 = "18306 Royal Drive",
                IsActive = true,
                PostalCode = "63383",
                Address2 = string.Empty,
                CompanyPhone = "3331115432",
                CompanyFax = "3331115433",
                StateId = 25,
                CategoryId = 3
            };
            return result;
        }

        public Company GenerateCompanyDate_BadUpdate()
        {
            Company result = new Company
            {
                Id = 23,
                CompanyName = "Test Company Delete Me",
                City = "Test City",
                Address1 = "123 Anywhere Street",
                IsActive = true,
                PostalCode = "63383",
                Address2 = string.Empty,
                CompanyPhone = "3331115432",
                CompanyFax = "3331115433",
                StateId = 25,
                CategoryId = 3
            };
            return result;
        }
    }
}


using ContactManager.Tests.Builders;
using ContactManager.Data.Models;

namespace ContactManager.Tests
{
    public class TestBase
    {
        protected readonly bool runInTestMode = true;
        protected readonly ObjectBuilder _objBuilder;

        public TestBase()
        {
            _objBuilder = new ObjectBuilder();
        }

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

        public Company GenerateCompanyData_BadUpdate()
        {
            Company result = new Company
            {
                Id = 23,
                CompanyName = null,
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

        public Contact GenerateContactData()
        {
            Contact result = new Contact
            {
                Id = 2,
                NameFirst = "Rob",
                NameLast = "Horton",
                CompanyId = 1,
                PhoneDirectLine = "3145551212",
                PhoneExtension = "1111",
                PhoneHome = "6365556789",
                EmailAddress = "robhorton@outlook.com"
            };

            return result;
        }

        public Contact GenerateContactData_Update()
        {
            Contact result = new Contact
            {
                Id = 2,
                NameFirst = "Rob",
                NameLast = "Horton",
                CompanyId = 1,
                PhoneDirectLine = "3145551212",
                PhoneExtension = "1111",
                PhoneHome = "6365556789",
                EmailAddress = "robhorton@outlook.com"
            };

            return result;
        }

        public Contact GenerateContactData_BadUpdate()
        {
            Contact result = new Contact
            {
                Id = 0,
                NameFirst = "Rob",
                NameLast = "Horton",
                CompanyId = 1,
                PhoneDirectLine = "3145551212",
                PhoneExtension = "1111",
                PhoneHome = "6365556789",
                EmailAddress = "robhorton@outlook.com"
            };

            return result;
        }

        public Contact GenerateContactData_BadInsert_MissingData()
        {
            Contact result = new Contact
            {
                Id = 1,
                NameFirst = null,
                NameLast = "Horton",
                CompanyId = 1,
                PhoneDirectLine = "3145551212",
                PhoneExtension = "1111",
                PhoneHome = "6365556789",
                EmailAddress = "robhorton@outlook.com"
            };

            return result;
        }

    }
}

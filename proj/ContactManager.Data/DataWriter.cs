using System;
using System.Linq;
using ContactManager.Data.EF;

namespace ContactManager.Data
{
    public class DataWriter
    {
        private readonly bool _inTestMode = false;

        private ContactManagerEntities _db;

        public DataWriter()
        {
            _db = new ContactManagerEntities();
        }

        public DataWriter(bool setForTestMode)
        {
            _db = new ContactManagerEntities();
            _inTestMode = setForTestMode;
        }

        public int AddCompany(Models.Company company) {
            Company objCompany = new Company
            {
                CompanyName = company.CompanyName,
                City = company.City,
                CategoryId = company.CategoryId,
                Address2 = company.Address2,
                Address1 = company.Address1,
                FaxNumber = company.CompanyFax,
                IsActive = company.IsActive,
                PhoneNumber = company.CompanyPhone,
                PostalCode = company.PostalCode,
                StateId = company.StateId
            };

            _db.Companies.Add(objCompany);

            if (_inTestMode) return 1;  //Exit early if we are unit testing.

            //if (_inTestMode) return this.GetType().GetMethods().First().ReturnType;

            _db.SaveChanges();
            return objCompany.Id;
        }
    }
}

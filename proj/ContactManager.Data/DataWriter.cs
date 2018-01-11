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

        #region Companies

        public int AddCompany(Models.Company company)
        {
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

            _db.SaveChanges();
            return objCompany.Id;
        }

        public int UpdateCompany(Models.Company company)
        {
            if (company == null || company.Id == 0) return 0;

            Company result = _db.Companies.Find(company.Id);

            if (result != null)
            {
                result.IsActive = company.IsActive;
                result.PhoneNumber = company.CompanyPhone;
                result.PostalCode = company.PostalCode;
                result.StateId = company.StateId;
                result.FaxNumber = company.CompanyFax;
                result.Address1 = company.Address1;
                result.Address2 = company.Address2;
                result.CategoryId = company.CategoryId;
                result.City = company.City;
                result.CompanyName = company.CompanyName;
            }
            else
            {
                return 0;
            }

            if (_inTestMode) return company.Id;  //Exit early if we are unit testing.

            _db.SaveChanges();
            return company.Id;
        }

        public bool DeleteCompany(Models.Company company)
        {
            if (company == null || company.Id == 0) return false;

            Company result = _db.Companies.Find(company.Id);

            if (result != null)
            {
                result.IsActive = false;
            }
            else
            {
                return false;
            }

            if (_inTestMode) return true;  //Exit early if we are unit testing.

            _db.SaveChanges();
            return true;
        }

        #endregion

        #region Contacts

        public int AddContact(Models.Company company)
        {
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

            _db.SaveChanges();
            return objCompany.Id;
        }

        #endregion
    }
}

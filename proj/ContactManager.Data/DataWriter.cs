using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactManager.Data.EF;
using ContactManager.Data.Models;

namespace ContactManager.Data
{
    public class DataWriter
    {
        private ContactManagerEntities _db;

        public DataWriter()
        {
            _db = new ContactManagerEntities();
        }

        public int AddCompany(Models.Company company) {
            EF.Company objCompany = new EF.Company
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
            _db.SaveChanges();
            return objCompany.Id;
        }
    }
}

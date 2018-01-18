using System;
using System.Linq;
using System.Reflection;
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

        public int SaveCompany(Models.Company company)
        {
            Company objCompany = null;

            // Go get the existing record, if there is one, so we can update it.
            if (company.Id > 0)
            {
                objCompany = _db.Companies.Find(company.Id);
            }

            // If we found no existing record or we had no Id at all, then we default an add new record.
            if (objCompany == null)
            {
                objCompany = new Company();
                _db.Companies.Add(objCompany);
            }

            objCompany.CompanyName = company.CompanyName;
            objCompany.City = company.City;
            objCompany.CategoryId = company.CategoryId;
            objCompany.Address2 = company.Address2;
            objCompany.Address1 = company.Address1;
            objCompany.FaxNumber = company.CompanyFax;
            objCompany.IsActive = company.IsActive;
            objCompany.PhoneNumber = company.CompanyPhone;
            objCompany.PostalCode = company.PostalCode;
            objCompany.StateId = company.StateId;

            if (_inTestMode) return 1;  //Exit early if we are unit testing.

            _db.SaveChanges();
            return objCompany.Id;
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

        public int AddContact(Models.Contact objIn)
        {
            if (objIn == null || IsAnyNullOrEmpty(objIn)) return 0;

            Contact objNew = new Contact
            {
                NameFirst = objIn.NameFirst,
                NameLast = objIn.NameLast,
                CompanyId = objIn.CompanyId,
                PhoneDirectLine = objIn.PhoneDirectLine,
                PhoneExtension = objIn.PhoneExtension,
                PhoneHome = objIn.PhoneHome,
                EmailAddress = objIn.EmailAddress
            };

            _db.Contacts.Add(objNew);

            if (_inTestMode) return 1;  //Exit early if we are unit testing.

            _db.SaveChanges();
            return objNew.Id;
        }

        public int UpdateContact(Models.Contact objIn)
        {
            if (objIn == null || objIn.Id == 0 || IsAnyNullOrEmpty(objIn)) return 0;

            Contact result = _db.Contacts.Find(objIn.Id);

            if (result != null)
            {
                result.NameFirst = objIn.NameFirst;
                result.NameLast = objIn.NameLast;
                result.CompanyId = objIn.CompanyId;
                result.PhoneDirectLine = objIn.PhoneDirectLine;
                result.PhoneExtension = objIn.PhoneExtension;
                result.PhoneHome = objIn.PhoneHome;
                result.EmailAddress = objIn.EmailAddress;
            }
            else
            {
                return 0;
            }

            if (_inTestMode) return objIn.Id;  //Exit early if we are unit testing.

            _db.SaveChanges();
            return objIn.Id;
        }

        public bool DeleteContact(Models.Contact objIn)
        {
            if (objIn == null || objIn.Id == 0) return false;

            Contact result = _db.Contacts.Find(objIn.Id);

            if (result == null) return false;

            _db.Contacts.Remove(result);

            if (_inTestMode) return true;  //Exit early if we are unit testing.

            _db.SaveChanges();
            return true;
        }

        #endregion

        #region Validation 

        bool IsAnyNullOrEmpty(object myObject)
        {
            foreach (PropertyInfo pi in myObject.GetType().GetProperties())
            {
                if (pi.PropertyType == typeof(string))
                {
                    string value = (string)pi.GetValue(myObject);
                    if (string.IsNullOrEmpty(value))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        #endregion

    }
}

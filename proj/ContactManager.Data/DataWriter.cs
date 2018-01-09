using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactManager.Data.EF;
using Company = ContactManager.Data.EF.Company;
using ContactManager.Data.Models;

namespace ContactManager.Data
{
        //private readonly bool _inTestMode = false;

        //public DataWriter()
        //{
        //    Console.WriteLine("_inTestMode for DataWriter() says: " + _inTestMode);
        //}
        //public DataWriter(bool runInTestMode)
        //{
        //    _inTestMode = runInTestMode;
        //    Console.WriteLine("_inTestMode for DataWriter(bool runInTestMode) says: " + _inTestMode);
        //}

        //public int Save()
        //{
        //    Console.WriteLine("_inTestMode for Save() says: " + _inTestMode);

        //    // Get the Type and MethodInfo.
        //    //UnitTestHandler();

        //    DataWriter db = new DataWriter();
        //    Type classType = db.GetType();
        //    Type returnType = Type.GetType("System.Reflection.FieldInfo");
        //    MethodInfo mymethodinfo = returnType.GetMethod("GetValue");


        //    Console.Write("\n" + returnType.FullName + "." + mymethodinfo.Name);

        //    // Get and display the ReturnType.
        //    Console.Write("\nReturnType = {0}", mymethodinfo.ReturnType);

        //    Console.WriteLine("Type determined as {0}", classType);
        //    Console.WriteLine("Return type determined as {0}", returnType);

        //    //Console.WriteLine("returnType is {0}", returnType.fie);

        //    Console.WriteLine("returnType is assignable as int: {0}", returnType.IsAssignableFrom(typeof(int)));

        //    Console.WriteLine(this.GetType().GetMethods().First().ReturnType);


        //    return 1;
        //}
    public class DataWriter
    {
        private ContactManagerEntities _db;
        public bool SetForTestMode { get; set; }

        public DataWriter()
        {
            _db = new ContactManagerEntities();
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

            if (SetForTestMode) return 1;

            _db.SaveChanges();
            return objCompany.Id;
        }
    }
}

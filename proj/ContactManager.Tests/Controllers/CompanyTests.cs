
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ContactManager.api;
using System.Web.Http;

using ContactManager.Data.Models;

namespace ContactManager.Tests.Controllers
{
    [TestClass]
    public class CompanyTests
    {
        private CompanyController controller;
        private bool testmode = true;

        public CompanyTests()
        {
            controller = new CompanyController(testmode);
        }
        
        [TestMethod]
        public void CompaniesTest()
        {
            // Arrange
            
            // Act
            IHttpActionResult result = controller.Companies();
           
            // Assert
            Assert.IsNotNull(result);
            //Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<Company>));
        }

        [TestMethod]
        public void CompanyByIdTest()
        {
            // Arrange
            var param = 1;

            // Act
            IHttpActionResult result = controller.CompanyById(param);

            // Assert
            Assert.IsNotNull(result);
            //Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<Company>));
        }

        [TestMethod]
        public void CompaniesByCategoryTest()
        {
            // Arrange
            var param = 1;

            // Act
            IHttpActionResult result = controller.CompaniesByCategory(param);

            // Assert
            Assert.IsNotNull(result);
            //Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<Company>));
        }

        [TestMethod]
        public void CompanyByPhoneNumberTest()
        {
            // Arrange
            var param = "3145551211";

            // Act
            IHttpActionResult result = controller.CompaniesByPhoneNumber(param);

            // Assert
            Assert.IsNotNull(result);
            //Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<Company>));
        }

        [TestMethod]
        public void CompanyAdd()
        {
            // Arrange
            Company param = new Company {
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

            Data.DataWriter db = new Data.DataWriter(testmode);

            // Act
            var result = db.AddCompany(param);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result > 0);
            Assert.IsInstanceOfType(result, typeof(int));
        }
       
        //CompanyUpdateTest
        //CompanyDeleteTest

    }
}

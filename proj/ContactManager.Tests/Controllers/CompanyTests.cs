
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

        public CompanyTests()
        {
            controller = new CompanyController();
            controller._isInTestMode = true;
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
                City = "Test City"
            };

            // Act
            IHttpActionResult result = controller.CompanyAdd(param);

            // Assert
            Assert.IsNotNull(result);
            //Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<Company>));
        }
       
        //CompanyUpdateTest
        //CompanyDeleteTest

    }
}

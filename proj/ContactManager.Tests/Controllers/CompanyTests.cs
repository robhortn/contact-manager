
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ContactManager.api;
using System.Web.Http;

namespace ContactManager.Tests.Controllers
{
    [TestClass]
    public class CompanyTests
    {
        private CompanyController controller;

        public CompanyTests()
        {
            controller = new CompanyController();
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
            var id = 1;

            // Act
            IHttpActionResult result = controller.CompanyById(id);

            // Assert
            Assert.IsNotNull(result);
            //Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<Company>));
        }


        //CompanyByIdTest
        //CompaniesByCategoryTest
        //CompaniesByPhoneNumberTest
        //CompanyAddTest
        //CompanyUpdateTest
        //CompanyDeleteTest

    }
}

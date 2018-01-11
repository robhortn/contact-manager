
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ContactManager.api;
using System.Web.Http;

using ContactManager.Data.Models;
using FluentAssertions;
using ContactManager.Tests.Builders;

namespace ContactManager.Tests.Controllers
{
    [TestClass]
    public class CompanyTests : TestBase
    {
        private CompanyController controller;
        private ObjectBuilders objBuilder;

        public CompanyTests()
        {
            controller = new CompanyController(testmode);
            objBuilder = new ObjectBuilders();
        }
        
        [TestMethod]
        public void CompaniesTest()
        {
            // Arrange
            
            // Act
            IHttpActionResult result = controller.Companies();
           
            // Assert
            Assert.IsNotNull(result);
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
        public void CompanyAddTest()
        {
            // Arrange
            Company param = objBuilder.GenerateCompanyData();
            Data.DataWriter db = new Data.DataWriter(testmode);

            // Act
            var result = db.AddCompany(param);

            // Assert
            result.Should().NotBe(null).And.BeGreaterThan(0).And.BeOfType(typeof(int));
        }

        [TestMethod]
        public void CompanyUpdateTest()
        {
            // Arrange
            Company param = objBuilder.GenerateCompanyData();
            Data.DataWriter db = new Data.DataWriter(testmode);

            // Act
            var result = db.UpdateCompany(param);

            // Assert
            result.Should().Be(param.Id);
        }

        [TestMethod]
        public void CompanyUpdateTest_Fail()
        {
            // Arrange
            Company param = objBuilder.GenerateCompanyDate_BadUpdate();
            Data.DataWriter db = new Data.DataWriter(testmode);

            // Act
            var result = db.UpdateCompany(param);

            // Assert
            result.Should().NotBe(param.Id);
        }

        [TestMethod]
        public void CompanyDeleteTest()
        {
            // Arrange
            Company param = objBuilder.GenerateCompanyData();
            Data.DataWriter db = new Data.DataWriter(testmode);

            // Act
            var result = db.DeleteCompany(param);

            // Assert
            result.Should().Be(true, "it should return True when a record is removed");
        }
    }
}

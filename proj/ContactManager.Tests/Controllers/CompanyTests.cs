
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ContactManager.api;
using System.Web.Http;

namespace ContactManager.Tests.Controllers
{
    [TestClass]
    public class CompanyTests
    {
        [TestMethod]
        public void GetCompaniesTest()
        {
            // Arrange
            CompanyController controller = new CompanyController();

            // Act
            IHttpActionResult result = controller.GetCompanies();
           
            // Assert
            Assert.IsNotNull(result);
            //Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<Company>));
        }
    }
}

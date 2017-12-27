
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ContactManager.api;
using System.Web.Http;
using System.Web.Http.Results;

namespace ContactManager.Tests.Controllers
{
    [TestClass]
    public class CompanyControllerTest
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
            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<System.String>));
            OkNegotiatedContentResult<string> conNegResult = (OkNegotiatedContentResult<string>)result;
            Assert.IsTrue(string.Empty != conNegResult.Content);

        }
    }
}

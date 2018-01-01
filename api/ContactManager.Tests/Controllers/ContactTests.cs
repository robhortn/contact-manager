using Microsoft.VisualStudio.TestTools.UnitTesting;
using ContactManager.api;
using System.Web.Http;
using System.Web.Http.Results;

namespace ContactManager.Tests.Controllers
{
    [TestClass]
    public class ContactTests
    {
        [TestMethod]
        public void GetContactsTest()
        {
            // Arrange
            ContactController controller = new ContactController();

            // Act
            IHttpActionResult result = controller.GetContacts();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<System.String>));
            OkNegotiatedContentResult<string> conNegResult = (OkNegotiatedContentResult<string>)result;
            Assert.IsTrue(string.Empty != conNegResult.Content);

        }
    }
}

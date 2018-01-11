using Microsoft.VisualStudio.TestTools.UnitTesting;
using ContactManager.api;
using System.Web.Http;
using System.Web.Http.Results;

namespace ContactManager.Tests.Controllers
{
    [TestClass]
    public class ContactTests : TestBase
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
        }
    }
}

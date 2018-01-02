using Microsoft.VisualStudio.TestTools.UnitTesting;
using ContactManager.api;
using System.Web.Http;

namespace ContactManager.Tests.Controllers
{
    [TestClass]
    public class LookupTests
    {
        [TestMethod]
        public void GetStateProvincesTest()
        {
            // Arrange
            LookupController controller = new LookupController();

            // Act
            IHttpActionResult result = controller.GetStateProvinces();

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetCatgoriesTest()
        {
            // Arrange
            LookupController controller = new LookupController();

            // Act
            IHttpActionResult result = controller.GetCategories();

            // Assert
            Assert.IsNotNull(result);
        }

    }
}

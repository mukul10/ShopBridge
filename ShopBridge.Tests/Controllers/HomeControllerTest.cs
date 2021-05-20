using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShopBridge;
using ShopBridge.Controllers;
using System.Web.Mvc;

namespace ShopBridge.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Home Page", result.ViewBag.Title);
        }
    }
}

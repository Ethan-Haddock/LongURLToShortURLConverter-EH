using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LongURLToShortURLConverter_EH;
using LongURLToShortURLConverter_EH.Controllers;
using LongURLToShortURLConverter_EH.Models;

namespace LongURLToShortURLConverter_EH.Tests.Controllers
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
        }

        [TestMethod]
        public void Short_URL_Generation()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            string result1 = controller.GenerateUniqueShortUrl();

            // Assert
            Assert.IsNotNull(result1);
        }
        
        [TestMethod]
        public void Unique_Short_URL_Generation()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            string result1 = controller.GenerateUniqueShortUrl();

            string result2 = controller.GenerateUniqueShortUrl();

            // Assert
            Assert.AreNotEqual(result1, result2);
        }

        [TestMethod]
        public void Short_URL_Generation_From_Long_Url()
        {
            // Arrange
            HomeController controller = new HomeController();
            DbConfig _databaseContext = new DbConfig();

            // Act
            string testLongUrl = "https://www.amazon.co.uk/dp/B0126R4F8W/ref=twister_B01A75Y490?_encoding=UTF8&th=1";

            ActionResult result = controller.GenerateShortUrl(testLongUrl);

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Is_Valid_Long_Url()
        {
            // Arranges
            HomeController controller = new HomeController();

            // Act
            string testLongUrl = "https://www.amazon.co.uk/dp/B0126R4F8W/ref=twister_B01A75Y490?_encoding=UTF8&th=1";

            bool result = controller.ValidateUrl(testLongUrl);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Is_Non_Valid_Long_Url()
        {
            // Arranges
            HomeController controller = new HomeController();

            // Act
            string testLongUrl = "on.co.uk/dp/B0126R1";

            bool result = controller.ValidateUrl(testLongUrl);

            // Assert
            Assert.IsFalse(result);
        }
    }
}

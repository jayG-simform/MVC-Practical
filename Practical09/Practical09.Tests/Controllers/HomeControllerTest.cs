using Microsoft.VisualStudio.TestTools.UnitTesting;
using Practical09;
using Practical09.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Practical09.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Test3()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Test3() as ViewResult;

            // Assert
            Assert.AreEqual("Hello world",result.ViewBag.Message);
        }
    }
}

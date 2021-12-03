using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MortoSweepstakes.Controllers;

namespace MortoSweepstakesTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void IndexReturnsSomething()
        {
            var controller = new DummiesController();

            var result = controller.Index();

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void IndexLoadsIndexView()
        {
            var controller = new DummiesController();

            var result = (ViewResult)controller.Index();

            //The method returns a IActionResult - we need to cast the result to ViewResult
            Assert.AreEqual("Index", result.ViewName);
        }

        [TestMethod]
        public void IndexViewDataShowMessage()
        {
            var controller = new DummiesController();

            var result = (ViewResult)controller.Index();

            //The method returns a IActionResult - we need to cast the result to ViewResult
            Assert.AreEqual("This is a viewdata message", result.ViewData["Message"]);
        }
    }
}
